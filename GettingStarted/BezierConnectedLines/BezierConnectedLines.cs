using System;
using System.IO;
using O2S.Components.PDF4NET.Content;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Redaction;

namespace O2S.Components.PDF4NET.Samples
{
    public class BezierConnectedLines
    {
        public static void Main(string[] args)
        {
            PDFFixedDocument document = new PDFFixedDocument();
            PDFPage page = document.Pages.Add();
            PDFPen pen = new PDFPen(PDFRgbColor.Black, 1);
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.Helvetica, 16);

            PDFPoint[] points = new PDFPoint[] {
                new PDFPoint(50, 150), new PDFPoint(100, 200), new PDFPoint(150, 50), new PDFPoint(200, 150), new PDFPoint(250, 50) };
            DrawBezierConnectedLines(page, points, pen, 0, helvetica);

            page.Canvas.TranslateTransform(0, 200);
            DrawBezierConnectedLines(page, points, pen, 0.1, helvetica);

            page.Canvas.TranslateTransform(0, 200);
            DrawBezierConnectedLines(page, points, pen, 0.3, helvetica);

            page.Canvas.TranslateTransform(0, 200);
            DrawBezierConnectedLines(page, points, pen, 0.5, helvetica);

            using (FileStream output = File.Create("BezierConnectedLines.pdf"))
            {
                document.Save(output);
            }
        } 

        /// <summary>
        /// Draws the Bezier connected lines on the page.
        /// </summary>
        /// <param name="page">Page where to draw the lines.</param>
        /// <param name="points">List of points representing the connected lines.</param>
        /// <param name="pen">Pen to draw the final path.</param>
        /// <param name="smoothFactor">Smooth factor for computing the Bezier curve</param>
        /// <param name="font"></param>
        private static void DrawBezierConnectedLines(PDFPage page, PDFPoint[] points, PDFPen pen, double smoothFactor, PDFFont font)
        {

            PDFPath path = new PDFPath();
            path.StartSubpath(points[0].X, points[0].Y);

            for (int i = 0; i < points.Length - 2; i++)
            {
                PDFPoint[] pts = ComputeBezierConnectedLines(points[i], points[i + 1], points[i + 2], smoothFactor, i == 0, i == points.Length - 3);
                switch (pts.Length)
                {
                    case 2: // Intermediate/last section - straight lines
                        path.AddLineTo(pts[0].X, pts[0].Y);
                        path.AddLineTo(pts[1].X, pts[1].Y);
                        break;
                    case 3: // First section - straight lines
                        path.AddLineTo(pts[0].X, pts[0].Y);
                        path.AddLineTo(pts[1].X, pts[1].Y);
                        path.AddLineTo(pts[2].X, pts[2].Y);
                        break;
                    case 4: // Intermediate/last section
                        path.AddLineTo(pts[0].X, pts[0].Y);
                        path.AddBezierTo(pts[1].X, pts[1].Y, pts[1].X, pts[1].Y, pts[2].X, pts[2].Y);
                        path.AddLineTo(pts[3].X, pts[3].Y);
                        break;
                    case 5: // First section
                        path.AddLineTo(pts[0].X, pts[0].Y);
                        path.AddLineTo(pts[1].X, pts[1].Y);
                        path.AddBezierTo(pts[2].X, pts[2].Y, pts[2].X, pts[2].Y, pts[3].X, pts[3].Y);
                        path.AddLineTo(pts[4].X, pts[4].Y);
                        break;
                }
            }

            page.Canvas.DrawPath(pen, path);

            page.Canvas.DrawString($"Smooth factor = {smoothFactor}", font, new PDFBrush(), points[points.Length - 1].X, points[0].Y);
        }

        /// <summary>
        /// Given a sequence of 3 consecutive points representing 2 connected lines the method computes the points required to display the new lines and the connecting curve.
        /// </summary>
        /// <param name="pt1">First point</param>
        /// <param name="pt2">Second point</param>
        /// <param name="pt3">Third point</param>
        /// <param name="smoothFactor">Smooth factor for computing the Bezier curve</param>
        /// <param name="isFirstSection">True if the points are the first 3 in the list of points</param>
        /// <param name="isLastSection">True if the 3 points are last 3 in the list of points.</param>
        /// <returns>A list of points representing the new lines and the connecting curve.</returns>
        /// <remarks>The method returns 5 points if this is the first section, points that represent the first line, connecting curve and last line.
        /// If this is not the first section the method returns 4 points representing the connecting curve and the last line.</remarks>
        private static PDFPoint[] ComputeBezierConnectedLines(PDFPoint pt1, PDFPoint pt2, PDFPoint pt3, double smoothFactor, bool isFirstSection, bool isLastSection)
        {
            PDFPoint[] outputPoints = null;

            if (smoothFactor > 0.5)
            {
                smoothFactor = 0.5; // Half line maximum
            }
            if (((pt1.X == pt2.X) && (pt2.X == pt3.X)) || // Vertical lines
                ((pt1.Y == pt2.Y) && (pt2.Y == pt3.Y)) || // Horizontal lines
                (smoothFactor == 0))
            {
                if (!isFirstSection)
                {
                    pt1 = ComputeIntermediatePoint(pt1, pt2, smoothFactor, false);
                }
                if (!isLastSection)
                {
                    pt3 = ComputeIntermediatePoint(pt2, pt3, smoothFactor, true);
                }
                if (isFirstSection)
                {
                    outputPoints = new PDFPoint[] { pt1, pt2, pt3 };
                }
                else
                {
                    outputPoints = new PDFPoint[] { pt2, pt3 };
                }
            }
            else
            {
                PDFPoint startPoint = new PDFPoint(pt1);
                if (!isFirstSection)
                {
                    startPoint = ComputeIntermediatePoint(pt1, pt2, smoothFactor, false);
                }
                PDFPoint firstIntermediaryPoint = ComputeIntermediatePoint(pt1, pt2, smoothFactor, true);
                PDFPoint secondIntermediaryPoint = new PDFPoint(pt2);
                PDFPoint thirdIntermediaryPoint = ComputeIntermediatePoint(pt2, pt3, smoothFactor, false);
                PDFPoint endPoint = new PDFPoint(pt3);
                if (!isLastSection)
                {
                    endPoint = ComputeIntermediatePoint(pt2, pt3, smoothFactor, true);
                }

                if (isFirstSection)
                {
                    outputPoints = new PDFPoint[] { startPoint, firstIntermediaryPoint, secondIntermediaryPoint, thirdIntermediaryPoint, endPoint };
                }
                else
                {
                    outputPoints = new PDFPoint[] { firstIntermediaryPoint, secondIntermediaryPoint, thirdIntermediaryPoint, endPoint };
                }
            }

            return outputPoints;
        }

        /// <summary>
        /// Given the line from pt1 to pt2 the method computes an intermediary point on the line.
        /// </summary>
        /// <param name="pt1">Start point</param>
        /// <param name="pt2">End point</param>
        /// <param name="smoothFactor">Smooth factor specifying how from from the line end the intermediary point is located.</param>
        /// <param name="isEndLocation">True if the intermediary point should be computed relative to end point, 
        /// false if the intermediary point should be computed relative to start point.</param>
        /// <returns>A point on the line defined by pt1->pt2</returns>
        private static PDFPoint ComputeIntermediatePoint(PDFPoint pt1, PDFPoint pt2, double smoothFactor, bool isEndLocation)
        {
            if (isEndLocation)
            {
                smoothFactor = 1 - smoothFactor;
            }

            PDFPoint intermediate = new PDFPoint();
            if (pt1.X == pt2.X)
            {
                intermediate.X = pt1.X;
                intermediate.Y = pt1.Y + (pt2.Y - pt1.Y) * smoothFactor;
            }
            else
            {
                intermediate.X = pt1.X + (pt2.X - pt1.X) * smoothFactor;
                intermediate.Y = (intermediate.X * (pt2.Y - pt1.Y) + (pt2.X * pt1.Y - pt1.X * pt2.Y)) / (pt2.X - pt1.X);
            }

            return intermediate;
        }
    }
}
