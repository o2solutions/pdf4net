using System;
using System.Drawing;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
//using O2S.Components.PDF4NET.Graphics.Shapes;
using O2S.Components.PDF4NET.Graphics.Fonts;

namespace O2S.Samples.PDF4NET.Ellipses
{
    /// <summary>
    /// This sample will show how to draw various ellipses
    /// on the page.
    /// </summary>
    class Ellipses
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
            PDFBrush greenBrush = new PDFBrush(new PDFRgbColor(0, 255, 0));
            PDFPen pen = new PDFPen(PDFRgbColor.Orange, 1);

            // Draw an ellipse that has a border
            //PDF4NET v5: pdfPage1.Canvas.DrawText("This ellipse is drawn by drawing its border", fontText, null, blackBrush, 20, 20, 0, PDFTextAlign.TopLeft);
            pdfPage1.Canvas.DrawString("This ellipse is drawn by drawing its border", fontText, blackBrush, 20, 20);
            pdfPage1.Canvas.DrawEllipse(pen, null, 20, 35, 200, 100);

            // Draw an ellipse that has no border and its interior is filled
            //PDF4NET v5: pdfPage1.Canvas.DrawText("This ellipse is drawn by filling its interior", fontText, null, blackBrush, 300, 20, 0, PDFTextAlign.TopLeft);
            pdfPage1.Canvas.DrawString("This ellipse is drawn by filling its interior", fontText, blackBrush, 300, 20);
            pdfPage1.Canvas.DrawEllipse(null, greenBrush, 300, 35, 300, 150);

            // Draw an ellipse that has a border and its interior is filled
            //PDF4NET v5: pdfPage1.Canvas.DrawText("This ellipse has a border and a filled interior", fontText, null, blackBrush, 20, 200, 0, PDFTextAlign.TopLeft);
            pdfPage1.Canvas.DrawString("This ellipse has a border and a filled interior", fontText, blackBrush, 20, 200);
            pdfPage1.Canvas.DrawEllipse(pen, greenBrush, 20, 215, 200, 150);

            // Draw a circle
            //PDF4NET v5: pdfPage1.Canvas.DrawText("This is a circle", fontText, null, blackBrush, 300, 200, 0, PDFTextAlign.TopLeft);
            pdfPage1.Canvas.DrawString("This is a circle", fontText, blackBrush, 300, 200);
            pdfPage1.Canvas.DrawEllipse(pen, greenBrush, 300, 215, 200, 200);

            // Create the second page
            //PDF4NET v5: PDFPage pdfPage2 = pdfDoc.AddPage();
            PDFPage pdfPage2 = pdfDoc.Pages.Add();

            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                // Create random colors for the border and the interior
                PDFRgbColor brushColor = new PDFRgbColor((byte)rnd.Next(256),
                    (byte)rnd.Next(256), (byte)rnd.Next(256));
                PDFRgbColor penColor = new PDFRgbColor((byte)rnd.Next(256),
                    (byte)rnd.Next(256), (byte)rnd.Next(256));

                // Create the brush to fill the interior
                PDFBrush randomBrush = new PDFBrush(brushColor);
                // Create the pen to draw the border
                PDFPen randomPen = new PDFPen(penColor, 1);

                // Generate random positions
                float left = rnd.Next((int)pdfPage2.Width);
                float top = rnd.Next((int)pdfPage2.Height);

                // Generate random sizes
                float width = rnd.Next((int)(pdfPage2.Width - left)); // try to keep the rectangle
                float height = rnd.Next((int)(pdfPage2.Height - top));   // within the page

                // Draw the ellipse
                pdfPage2.Canvas.DrawEllipse(randomPen, randomBrush, left, top, width, height);
            }

            // Draw a label
            //PDF4NET v5: pdfPage2.Canvas.DrawText("Random ellipses", fontText, null, blackBrush, 20, 350, 0, PDFTextAlign.TopLeft);
            pdfPage2.Canvas.DrawString("Random ellipses", fontText, blackBrush, 20, 350);

            // Save the document to disk
            pdfDoc.Save("Sample_Ellipses.pdf"); 
        }
    }
}
