using System;
using System.Drawing;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.Fonts;
//using O2S.Components.PDF4NET.Graphics.Shapes;

namespace O2S.Samples.PDF4NET.ArcsPies
{
    /// <summary>
    /// This sample will show how to draw arcs and pies
    /// on the page.
    /// </summary>
    class ArcsPies
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Create the pdf document
            //PDF4NET v5: PDFDocument pdfDoc = new PDFDocument();
            PDFFixedDocument pdfDoc = new PDFFixedDocument();

            // Create the graphic objects 
            //PDF4NET v5: PDFFont fontText = new PDFFont(PDFFontFace.Helvetica, 12);
            PDFStandardFont fontText = new PDFStandardFont(PDFStandardFontFace.Helvetica, 12);
            //PDF4NET v5: PDFBrush blackBrush = new PDFBrush(new PDFRgbColor(Color.Black));
            PDFBrush blackBrush = new PDFBrush(PDFRgbColor.Black);

            Random rnd = new Random();

            // Create first page
            //PDF4NET v5: PDFPage pdfPage1 = pdfDoc.AddPage();
            PDFPage pdfPage1 = pdfDoc.Pages.Add();

            byte[] rgb = new byte[3];
            // Draw 50 arcs
            for (int i = 0; i < 50; i++)
            {
                // Create random colors for the border and the interior
                //PDF4NET v5: Color penColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                // Create the pen to draw the border
                //PDF4NET v5: PDFPen randomPen = new PDFPen(new PDFRgbColor(penColor), 1);
                rnd.NextBytes(rgb);
                PDFPen randomPen = new PDFPen(new PDFRgbColor(rgb[0], rgb[1], rgb[2]), 1);

                // Generate random positions
                float left = rnd.Next((int)pdfPage1.Width);
                float top = rnd.Next((int)pdfPage1.Height);

                // Generate random sizes
                float width = rnd.Next((int)(pdfPage1.Width - left)); // try to keep the arc within the page
                float height = rnd.Next((int)(pdfPage1.Height - top)); // try to keep the arc within the page
                float startAngle = rnd.Next(360);
                float sweepAngle = rnd.Next(360);

                // Draw the ellipse
                pdfPage1.Canvas.DrawArc(randomPen, top, left, width, height, startAngle, sweepAngle);
            }

            // Draw a label
            //PDF4NET v5: pdfPage1.Canvas.DrawText("Random arcs", fontText, null, blackBrush, 20, 20);
            pdfPage1.Canvas.DrawString("Random arcs", fontText, blackBrush, 20, 20);

            // Create the second page
            //PDF4NET v5: PDFPage pdfPage2 = pdfDoc.AddPage();
            PDFPage pdfPage2 = pdfDoc.Pages.Add();

            // Draw 50 pies
            for (int i = 0; i < 50; i++)
            {
                // Create random colors for the border and the interior
                //PDF4NET v5: Color brushColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                //PDF4NET v5: Color penColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                // Create the brush to fill the interior
                //PDF4NET v5: PDFBrush randomBrush = new PDFBrush(new PDFRgbColor(brushColor));
                rnd.NextBytes(rgb);
                PDFBrush randomBrush = new PDFBrush(new PDFRgbColor(rgb[0], rgb[1], rgb[2]));
                // Create the pen to draw the border
                //PDF4NET v5: PDFPen randomPen = new PDFPen(new PDFRgbColor(penColor), 1);
                rnd.NextBytes(rgb);
                PDFPen randomPen = new PDFPen(new PDFRgbColor(rgb[0], rgb[1], rgb[2]), 1);

                // Generate random positions
                float left = rnd.Next((int)pdfPage2.Width);
                float top = rnd.Next((int)pdfPage2.Height);

                // Generate random sizes
                float width = rnd.Next((int)(pdfPage2.Width - left)); // try to keep the pie within the page
                float height = rnd.Next((int)(pdfPage2.Height - top)); // try to keep the pie within the page
                float startAngle = rnd.Next(360);
                float sweepAngle = rnd.Next(360);

                // Draw the ellipse
                pdfPage2.Canvas.DrawPie(randomPen, randomBrush, top, left, width, height, startAngle, sweepAngle);
            }

            // Draw a label
            //PDF4NET v5: pdfPage2.Canvas.DrawText("Random pies", fontText, null, blackBrush, 20, 20);
            pdfPage2.Canvas.DrawString("Random pies", fontText, blackBrush, 20, 20);

            // Save the document to disk
            pdfDoc.Save("Sample_ArcsPies.pdf");
        }
    }
}
