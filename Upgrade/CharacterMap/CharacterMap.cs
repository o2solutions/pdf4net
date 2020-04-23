using System;
using System.Drawing;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
//using O2S.Components.PDF4NET.Graphics.Shapes;
using O2S.Components.PDF4NET.Graphics.Fonts;

namespace O2S.Samples.PDF4NET.CharacterMap
{
    /// <summary>
    /// This sample prints all available characters in WinAnsiEncoding, plus
    /// those available in ZapfDingbats and Symbol fonts.
    /// </summary>
    class CharacterMap
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

            DrawFirstPage(pdfDoc);
            DrawSecondPage(pdfDoc);
            DrawThirdPage(pdfDoc);

            // Save the document to disk
            pdfDoc.Save("Sample_CharacterMap.pdf");
        }

        private static void DrawFirstPage(PDFFixedDocument pdfDoc)
        {
            //PDF4NET v5: PDFPage pdfPage = pdfDoc.AddPage();
            PDFPage pdfPage = pdfDoc.Pages.Add();

            // Create the graphic objects 
            //PDF4NET v5: PDFFont fontText = new PDFFont(PDFFontFace.Helvetica, 12);
            PDFStandardFont fontText = new PDFStandardFont(PDFStandardFontFace.Helvetica, 12);
            //PDF4NET v5: PDFFont fontCode = new PDFFont(PDFFontFace.Helvetica, 11);
            PDFStandardFont fontCode = new PDFStandardFont(PDFStandardFontFace.Helvetica, 11);
            PDFBrush blackBrush = new PDFBrush(new PDFRgbColor());

            //PDF4NET v5: pdfPage.Canvas.DrawText("Latin font - WinAnsiEncoding", fontText, null, blackBrush, 10, 30, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Latin font - WinAnsiEncoding", fontText, blackBrush, 10, 30);

            // Draw the header for the first column
            //PDF4NET v5: pdfPage.Canvas.DrawText("Decimal", fontText, null, blackBrush, 10, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Decimal", fontText, blackBrush, 10, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Hex", fontText, null, blackBrush, 70, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Hex", fontText, blackBrush, 70, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Char", fontText, null, blackBrush, 100, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Char", fontText, blackBrush, 100, 50);
            // Draw the header for the second column
            //PDF4NET v5: pdfPage.Canvas.DrawText("Decimal", fontText, null, blackBrush, 170, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Decimal", fontText, blackBrush, 170, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Hex", fontText, null, blackBrush, 230, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Hex", fontText, blackBrush, 230, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Char", fontText, null, blackBrush, 260, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Char", fontText, blackBrush, 260, 50);
            // Draw the header for the third column
            //PDF4NET v5: pdfPage.Canvas.DrawText("Decimal", fontText, null, blackBrush, 330, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Decimal", fontText, blackBrush, 330, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Hex", fontText, null, blackBrush, 390, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Hex", fontText, blackBrush, 390, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Char", fontText, null, blackBrush, 420, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Char", fontText, blackBrush, 420, 50);
            // Draw the header for the fourth column
            //PDF4NET v5: pdfPage.Canvas.DrawText("Decimal", fontText, null, blackBrush, 490, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Decimal", fontText, blackBrush, 490, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Hex", fontText, null, blackBrush, 550, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Hex", fontText, blackBrush, 550, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Char", fontText, null, blackBrush, 580, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Char", fontText, blackBrush, 580, 50);

            // Draw the codes and characters
            float xDec = 10;
            float xHex = 70;
            float xChar = 100;
            float xDelta = 160;
            float y = 65;
            byte i = 31;
            while (i <= 255)
            {
                i++;
                if (((i - 32) % 60 == 0) && i != 32)
                {
                    xDec = xDec + xDelta;
                    xHex = xHex + xDelta;
                    xChar = xChar + xDelta;
                    y = 65;
                }

                char c = (char)i;
                //PDF4NET v5: pdfPage.Canvas.DrawText(i.ToString(), fontCode, null, blackBrush, xDec, y, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString(i.ToString(), fontCode, blackBrush, xDec, y);
                //PDF4NET v5: pdfPage.Canvas.DrawText("\\x" + i.ToString("X"), fontCode, null, blackBrush, xHex, y, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString("\\x" + i.ToString("X"), fontCode, blackBrush, xHex, y);
                //PDF4NET v5: pdfPage.Canvas.DrawText(c.ToString(), fontCode, null, blackBrush, xChar, y, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString(c.ToString(), fontCode, blackBrush, xChar, y);
                y = y + 12;

                if (i == 255)
                {
                    break;
                }
            }
        }

        private static void DrawSecondPage(PDFFixedDocument pdfDoc)
        {
            //PDF4NET v5: PDFPage pdfPage = pdfDoc.AddPage();
            PDFPage pdfPage = pdfDoc.Pages.Add();

            // Create the graphic objects 
            //PDF4NET v5: PDFFont fontText = new PDFFont(PDFFontFace.Helvetica, 12);
            PDFStandardFont fontText = new PDFStandardFont(PDFStandardFontFace.Helvetica, 12);
            //PDF4NET v5: PDFFont fontCode = new PDFFont(PDFFontFace.Helvetica, 11);
            PDFStandardFont fontCode = new PDFStandardFont(PDFStandardFontFace.Helvetica, 11);
            //PDF4NET v5: PDFFont fontChar = new PDFFont(PDFFontFace.Symbol, 11);
            PDFStandardFont fontChar = new PDFStandardFont(PDFStandardFontFace.Symbol, 11);
            PDFBrush blackBrush = new PDFBrush(new PDFRgbColor());

            //PDF4NET v5: pdfPage.Canvas.DrawText("Symbol font", fontText, null, blackBrush, 10, 30, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Symbol font", fontText, blackBrush, 10, 30);

            // Draw the header for the first column
            //PDF4NET v5: pdfPage.Canvas.DrawText("Decimal", fontText, null, blackBrush, 10, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Decimal", fontText, blackBrush, 10, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Hex", fontText, null, blackBrush, 70, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Hex", fontText, blackBrush, 70, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Char", fontText, null, blackBrush, 100, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Char", fontText, blackBrush, 100, 50);
            // Draw the header for the second column
            //PDF4NET v5: pdfPage.Canvas.DrawText("Decimal", fontText, null, blackBrush, 170, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Decimal", fontText, blackBrush, 170, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Hex", fontText, null, blackBrush, 230, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Hex", fontText, blackBrush, 230, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Char", fontText, null, blackBrush, 260, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Char", fontText, blackBrush, 260, 50);
            // Draw the header for the third column
            //PDF4NET v5: pdfPage.Canvas.DrawText("Decimal", fontText, null, blackBrush, 330, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Decimal", fontText, blackBrush, 330, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Hex", fontText, null, blackBrush, 390, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Hex", fontText, blackBrush, 390, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Char", fontText, null, blackBrush, 420, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Char", fontText, blackBrush, 420, 50);
            // Draw the header for the fourth column
            //PDF4NET v5: pdfPage.Canvas.DrawText("Decimal", fontText, null, blackBrush, 490, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Decimal", fontText, blackBrush, 490, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Hex", fontText, null, blackBrush, 550, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Hex", fontText, blackBrush, 550, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Char", fontText, null, blackBrush, 580, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Char", fontText, blackBrush, 580, 50);

            // Draw the codes and characters
            float xDec = 10;
            float xHex = 70;
            float xChar = 100;
            float xDelta = 160;
            float y = 65;
            byte i = 31;
            while (i <= 255)
            {
                i++;
                if (((i - 32) % 60 == 0) && i != 32)
                {
                    xDec = xDec + xDelta;
                    xHex = xHex + xDelta;
                    xChar = xChar + xDelta;
                    y = 65;
                }

                char c = (char)i;
                //PDF4NET v5: pdfPage.Canvas.DrawText(i.ToString(), fontCode, null, blackBrush, xDec, y, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString(i.ToString(), fontCode, blackBrush, xDec, y);
                //PDF4NET v5: pdfPage.Canvas.DrawText("\\x" + i.ToString("X"), fontCode, null, blackBrush, xHex, y, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString("\\x" + i.ToString("X"), fontCode, blackBrush, xHex, y);
                //PDF4NET v5: pdfPage.Canvas.DrawText(c.ToString(), fontChar, null, blackBrush, xChar, y, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString(c.ToString(), fontChar, blackBrush, xChar, y);
                y = y + 12;

                if (i == 255)
                {
                    break;
                }
            }
        }

        private static void DrawThirdPage(PDFFixedDocument pdfDoc)
        {
            //PDF4NET v5: PDFPage pdfPage = pdfDoc.AddPage();
            PDFPage pdfPage = pdfDoc.Pages.Add();

            // Create the graphic objects 
            //PDF4NET v5: PDFFont fontText = new PDFFont(PDFFontFace.Helvetica, 12);
            PDFStandardFont fontText = new PDFStandardFont(PDFStandardFontFace.Helvetica, 12);
            //PDF4NET v5: PDFFont fontCode = new PDFFont(PDFFontFace.Helvetica, 11);
            PDFStandardFont fontCode = new PDFStandardFont(PDFStandardFontFace.Helvetica, 11);
            //PDF4NET v5: PDFFont fontChar = new PDFFont(PDFFontFace.Symbol, 11);
            PDFStandardFont fontChar = new PDFStandardFont(PDFStandardFontFace.ZapfDingbats, 11);
            PDFBrush blackBrush = new PDFBrush(new PDFRgbColor());

            pdfPage.Canvas.DrawText("ZapfDingbats font", fontText, null, blackBrush, 10, 30, 0, PDFTextAlign.TopLeft);

            // Draw the header for the first column
            //PDF4NET v5: pdfPage.Canvas.DrawText("Decimal", fontText, null, blackBrush, 10, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Decimal", fontText, blackBrush, 10, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Hex", fontText, null, blackBrush, 70, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Hex", fontText, blackBrush, 70, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Char", fontText, null, blackBrush, 100, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Char", fontText, blackBrush, 100, 50);
            // Draw the header for the second column
            //PDF4NET v5: pdfPage.Canvas.DrawText("Decimal", fontText, null, blackBrush, 170, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Decimal", fontText, blackBrush, 170, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Hex", fontText, null, blackBrush, 230, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Hex", fontText, blackBrush, 230, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Char", fontText, null, blackBrush, 260, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Char", fontText, blackBrush, 260, 50);
            // Draw the header for the third column
            //PDF4NET v5: pdfPage.Canvas.DrawText("Decimal", fontText, null, blackBrush, 330, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Decimal", fontText, blackBrush, 330, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Hex", fontText, null, blackBrush, 390, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Hex", fontText, blackBrush, 390, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Char", fontText, null, blackBrush, 420, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Char", fontText, blackBrush, 420, 50);
            // Draw the header for the fourth column
            //PDF4NET v5: pdfPage.Canvas.DrawText("Decimal", fontText, null, blackBrush, 490, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Decimal", fontText, blackBrush, 490, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Hex", fontText, null, blackBrush, 550, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Hex", fontText, blackBrush, 550, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Char", fontText, null, blackBrush, 580, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Char", fontText, blackBrush, 580, 50);

            // Draw the codes and characters
            float xDec = 10;
            float xHex = 70;
            float xChar = 100;
            float xDelta = 160;
            float y = 65;
            byte i = 31;
            while (i <= 255)
            {
                i++;
                if (((i - 32) % 60 == 0) && i != 32)
                {
                    xDec = xDec + xDelta;
                    xHex = xHex + xDelta;
                    xChar = xChar + xDelta;
                    y = 65;
                }

                char c = (char)i;
                //PDF4NET v5: pdfPage.Canvas.DrawText(i.ToString(), fontCode, null, blackBrush, xDec, y, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString(i.ToString(), fontCode, blackBrush, xDec, y);
                //PDF4NET v5: pdfPage.Canvas.DrawText("\\x" + i.ToString("X"), fontCode, null, blackBrush, xHex, y, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString("\\x" + i.ToString("X"), fontCode, blackBrush, xHex, y);
                //PDF4NET v5: pdfPage.Canvas.DrawText(c.ToString(), fontChar, null, blackBrush, xChar, y, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString(c.ToString(), fontChar, blackBrush, xChar, y);
                y = y + 12;

                if (i == 255)
                {
                    break; 
                }
            }
        }
    }
}
