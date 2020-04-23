using System;
using System.Drawing;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
//using O2S.Components.PDF4NET.Graphics.Shapes;
using O2S.Components.PDF4NET.Graphics.Fonts;

namespace O2S.Samples.PDF4NET.Bezier
{
    /// <summary>
    /// This sample will show how to draw Bezier splines
    /// on the page.
    /// </summary>
    class Bezier
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

            // Create first page
            //PDF4NET v5: PDFPage pdfPage1 = pdfDoc.AddPage();
            PDFPage pdfPage1 = pdfDoc.Pages.Add();

            // Create the graphic objects 
            //PDF4NET v5: PDFFont fontText = new PDFFont(PDFFontFace.Helvetica, 12);
            PDFStandardFont fontText = new PDFStandardFont(PDFStandardFontFace.Helvetica, 12);
            PDFBrush blackBrush = new PDFBrush(new PDFRgbColor());

            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                // Create random colors for drawing the spline
                PDFColor penColor = new PDFRgbColor((byte)rnd.Next(256),
                    (byte)rnd.Next(256), (byte)rnd.Next(256));

                // Create the pen to draw the border
                PDFPen randomPen = new PDFPen(penColor, 1);

                // Generate random control points
                float x1 = rnd.Next((int)pdfPage1.Width);
                float y1 = rnd.Next((int)pdfPage1.Height);
                float x2 = rnd.Next((int)pdfPage1.Width);
                float y2 = rnd.Next((int)pdfPage1.Height);
                float x3 = rnd.Next((int)pdfPage1.Width);
                float y3 = rnd.Next((int)pdfPage1.Height);
                float x4 = rnd.Next((int)pdfPage1.Width);
                float y4 = rnd.Next((int)pdfPage1.Height);

                // Draw the Bezier spline
                pdfPage1.Canvas.DrawBezier(randomPen, x1, y1, x2, y2, x3, y3, x4, y4);
            }

            // Draw a label
            //PDF4NET v5: pdfPage1.Canvas.DrawText("Random Bezier splines", fontText, null, blackBrush, 20, 20, 0, PDFTextAlign.TopLeft);
            pdfPage1.Canvas.DrawString("Random Bezier splines", fontText, blackBrush, 20, 20);

            // Save the document to disk
            pdfDoc.Save("Sample_Bezier.pdf");
        }
    }
}
