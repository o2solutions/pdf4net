using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Core;
using O2S.Components.PDF4NET.Content;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// PageObjects sample.
    /// </summary>
    public class PageObjects
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream input)
        {
            PDFBrush brush = new PDFBrush();
            PDFPen redPen = new PDFPen(PDFRgbColor.Red, 1);
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.Helvetica, 10);

            PDFFixedDocument document = new PDFFixedDocument(input);

            PDFContentExtractor ce = new PDFContentExtractor(document.Pages[0]);
            PDFVisualObjectCollection voc = ce.ExtractVisualObjects(false);

            PDFPath contour = null;
            for (int i = 0; i < voc.Count; i++)
            {
                switch (voc[i].Type)
                {
                    case PDFVisualObjectType.Image:
                        PDFImageVisualObject ivo = voc[i] as PDFImageVisualObject;
                        contour = new PDFPath();
                        contour.StartSubpath(ivo.Image.ImageCorners[0].X - 5, ivo.Image.ImageCorners[0].Y + 5);
                        contour.AddLineTo(ivo.Image.ImageCorners[1].X + 5, ivo.Image.ImageCorners[1].Y + 5);
                        contour.AddLineTo(ivo.Image.ImageCorners[2].X + 5, ivo.Image.ImageCorners[2].Y - 5);
                        contour.AddLineTo(ivo.Image.ImageCorners[3].X - 5, ivo.Image.ImageCorners[3].Y - 5);
                        contour.CloseSubpath();
                        document.Pages[0].Canvas.DrawPath(redPen, contour);

                        document.Pages[0].Canvas.DrawString("Image", helvetica, brush,
                            ivo.Image.ImageCorners[0].X - 5, ivo.Image.ImageCorners[0].Y + 5);
                        break;
                    case PDFVisualObjectType.Text:
                        PDFTextVisualObject tvo = voc[i] as PDFTextVisualObject;
                        contour = new PDFPath();
                        contour.StartSubpath(tvo.TextFragment.FragmentCorners[0].X - 5, tvo.TextFragment.FragmentCorners[0].Y + 5);
                        contour.AddLineTo(tvo.TextFragment.FragmentCorners[1].X + 5, tvo.TextFragment.FragmentCorners[1].Y + 5);
                        contour.AddLineTo(tvo.TextFragment.FragmentCorners[2].X + 5, tvo.TextFragment.FragmentCorners[2].Y - 5);
                        contour.AddLineTo(tvo.TextFragment.FragmentCorners[3].X - 5, tvo.TextFragment.FragmentCorners[3].Y - 5);
                        contour.CloseSubpath();
                        document.Pages[0].Canvas.DrawPath(redPen, contour);

                        document.Pages[0].Canvas.DrawString("Text", helvetica, brush,
                            tvo.TextFragment.FragmentCorners[0].X - 5, tvo.TextFragment.FragmentCorners[0].Y + 5);
                        break;
                    case PDFVisualObjectType.Path:
                        PDFPathVisualObject pvo = voc[i] as PDFPathVisualObject;
                        // Examine all the path points and determine the minimum rectangle that bounds the path.
                        double minX = 999999, minY = 999999, maxX = -999999, maxY = -999999;
                        for (int j = 0; j < pvo.PathItems.Count; j++)
                        {
                            PDFPathItem pi = pvo.PathItems[j];
                            if (pi.Points != null)
                            {
                                for (int k = 0; k < pi.Points.Length; k++)
                                {
                                    if (minX >= pi.Points[k].X)
                                    {
                                        minX = pi.Points[k].X;
                                    }
                                    if (minY >= pi.Points[k].Y)
                                    {
                                        minY = pi.Points[k].Y;
                                    }
                                    if (maxX <= pi.Points[k].X)
                                    {
                                        maxX = pi.Points[k].X;
                                    }
                                    if (maxY <= pi.Points[k].Y)
                                    {
                                        maxY = pi.Points[k].Y;
                                    }
                                }
                            }
                        }

                        contour = new PDFPath();
                        contour.StartSubpath(minX - 5, minY - 5);
                        contour.AddLineTo(maxX + 5, minY - 5);
                        contour.AddLineTo(maxX + 5, maxY + 5);
                        contour.AddLineTo(minX - 5, maxY + 5);
                        contour.CloseSubpath();
                        document.Pages[0].Canvas.DrawPath(redPen, contour);

                        document.Pages[0].Canvas.DrawString("Path", helvetica, brush, minX - 5, maxY + 5);
                        // Skip the rest of path objects, they are the evaluation message
                        i = voc.Count;
                        break;
                }
            }

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "pageobjects.pdf") };
            return output;
        }
    }
}