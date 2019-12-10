using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Type3 fonts sample.
    /// </summary>
    public class Type3Fonts
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run()
        {
            PDFFixedDocument document = new PDFFixedDocument();
            PDFPage page = document.Pages.Add();

            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.Helvetica, 20);
            PDFBrush blackBrush = new PDFBrush(PDFRgbColor.Black);
            page.Canvas.DrawString("The digits below, from 0 to 9, are drawn using a Type3 font.", helvetica, blackBrush, 50, 100);

            PDFType3Font t3 = new PDFType3Font("DemoT3");
            t3.Size = 24;
            t3.FirstChar = (byte)' ';
            t3.LastChar = (byte)'9';
            t3.FontMatrix = new PDFMatrix(0.01, 0, 0, 0.01, 0, 0);
            double[] widths = new double[] { 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
            t3.Widths = widths;

            PDFPen hollowPen = new PDFPen(null, 8);
            PDFBrush hollowBrush = new PDFBrush(null);
            // space
            PDFType3Glyph t3s = new PDFType3Glyph(0x20, new PDFSize(100, 100));
            t3.Glyphs.Add(t3s);
            // 0
            PDFType3Glyph t30 = new PDFType3Glyph(0x30, new PDFSize(100, 100));
            t30.Canvas.DrawRectangle(hollowPen, 5, 5, 90, 90);
            t30.Canvas.CompressAndClose();
            t3.Glyphs.Add(t30);
            // 1
            PDFType3Glyph t31 = new PDFType3Glyph(0x31, new PDFSize(100, 100));
            t31.Canvas.DrawRectangle(hollowPen, 5, 5, 90, 90);
            t31.Canvas.DrawEllipse(hollowBrush, 40, 40, 20, 20);
            t31.Canvas.CompressAndClose();
            t3.Glyphs.Add(t31);
            // 2
            PDFType3Glyph t32 = new PDFType3Glyph(0x32, new PDFSize(100, 100));
            t32.Canvas.DrawRectangle(hollowPen, 5, 5, 90, 90);
            t32.Canvas.DrawEllipse(hollowBrush, 15, 15, 20, 20);
            t32.Canvas.DrawEllipse(hollowBrush, 65, 65, 20, 20);
            t32.Canvas.CompressAndClose();
            t3.Glyphs.Add(t32);
            // 3
            PDFType3Glyph t33 = new PDFType3Glyph(0x33, new PDFSize(100, 100));
            t33.Canvas.DrawRectangle(hollowPen, 5, 5, 90, 90);
            t33.Canvas.DrawEllipse(hollowBrush, 15, 15, 20, 20);
            t33.Canvas.DrawEllipse(hollowBrush, 40, 40, 20, 20);
            t33.Canvas.DrawEllipse(hollowBrush, 65, 65, 20, 20);
            t33.Canvas.CompressAndClose();
            t3.Glyphs.Add(t33);
            // 4
            PDFType3Glyph t34 = new PDFType3Glyph(0x34, new PDFSize(100, 100));
            t34.Canvas.DrawRectangle(hollowPen, 5, 5, 90, 90);
            t34.Canvas.DrawEllipse(hollowBrush, 15, 15, 20, 20);
            t34.Canvas.DrawEllipse(hollowBrush, 65, 15, 20, 20);
            t34.Canvas.DrawEllipse(hollowBrush, 15, 65, 20, 20);
            t34.Canvas.DrawEllipse(hollowBrush, 65, 65, 20, 20);
            t34.Canvas.CompressAndClose();
            t3.Glyphs.Add(t34);
            // 5
            PDFType3Glyph t35 = new PDFType3Glyph(0x35, new PDFSize(100, 100));
            t35.Canvas.DrawRectangle(hollowPen, 5, 5, 90, 90);
            t35.Canvas.DrawEllipse(hollowBrush, 15, 15, 20, 20);
            t35.Canvas.DrawEllipse(hollowBrush, 65, 15, 20, 20);
            t35.Canvas.DrawEllipse(hollowBrush, 40, 40, 20, 20);
            t35.Canvas.DrawEllipse(hollowBrush, 15, 65, 20, 20);
            t35.Canvas.DrawEllipse(hollowBrush, 65, 65, 20, 20);
            t35.Canvas.CompressAndClose();
            t3.Glyphs.Add(t35);
            // 6
            PDFType3Glyph t36 = new PDFType3Glyph(0x36, new PDFSize(100, 100));
            t36.Canvas.DrawRectangle(hollowPen, 5, 5, 90, 90);
            t36.Canvas.DrawEllipse(hollowBrush, 15, 15, 20, 20);
            t36.Canvas.DrawEllipse(hollowBrush, 65, 15, 20, 20);
            t36.Canvas.DrawEllipse(hollowBrush, 15, 40, 20, 20);
            t36.Canvas.DrawEllipse(hollowBrush, 65, 40, 20, 20);
            t36.Canvas.DrawEllipse(hollowBrush, 15, 65, 20, 20);
            t36.Canvas.DrawEllipse(hollowBrush, 65, 65, 20, 20);
            t36.Canvas.CompressAndClose();
            t3.Glyphs.Add(t36);
            // 7
            PDFType3Glyph t37 = new PDFType3Glyph(0x37, new PDFSize(100, 100));
            t37.Canvas.DrawRectangle(hollowPen, 5, 5, 90, 90);
            t37.Canvas.DrawEllipse(hollowBrush, 15, 15, 20, 20);
            t37.Canvas.DrawEllipse(hollowBrush, 65, 15, 20, 20);
            t37.Canvas.DrawEllipse(hollowBrush, 15, 40, 20, 20);
            t37.Canvas.DrawEllipse(hollowBrush, 40, 40, 20, 20);
            t37.Canvas.DrawEllipse(hollowBrush, 65, 40, 20, 20);
            t37.Canvas.DrawEllipse(hollowBrush, 15, 65, 20, 20);
            t37.Canvas.DrawEllipse(hollowBrush, 65, 65, 20, 20);
            t37.Canvas.CompressAndClose();
            t3.Glyphs.Add(t37);
            // 8
            PDFType3Glyph t38 = new PDFType3Glyph(0x38, new PDFSize(100, 100));
            t38.Canvas.DrawRectangle(hollowPen, 5, 5, 90, 90);
            t38.Canvas.DrawEllipse(hollowBrush, 15, 15, 20, 20);
            t38.Canvas.DrawEllipse(hollowBrush, 40, 15, 20, 20);
            t38.Canvas.DrawEllipse(hollowBrush, 65, 15, 20, 20);
            t38.Canvas.DrawEllipse(hollowBrush, 15, 40, 20, 20);
            t38.Canvas.DrawEllipse(hollowBrush, 65, 40, 20, 20);
            t38.Canvas.DrawEllipse(hollowBrush, 15, 65, 20, 20);
            t38.Canvas.DrawEllipse(hollowBrush, 40, 65, 20, 20);
            t38.Canvas.DrawEllipse(hollowBrush, 65, 65, 20, 20);
            t38.Canvas.CompressAndClose();
            t3.Glyphs.Add(t38);
            // 9
            PDFType3Glyph t39 = new PDFType3Glyph(0x39, new PDFSize(100, 100));
            t39.Canvas.DrawRectangle(hollowPen, 5, 5, 90, 90);
            t39.Canvas.DrawEllipse(hollowBrush, 15, 15, 20, 20);
            t39.Canvas.DrawEllipse(hollowBrush, 40, 15, 20, 20);
            t39.Canvas.DrawEllipse(hollowBrush, 65, 15, 20, 20);
            t39.Canvas.DrawEllipse(hollowBrush, 15, 40, 20, 20);
            t39.Canvas.DrawEllipse(hollowBrush, 40, 40, 20, 20);
            t39.Canvas.DrawEllipse(hollowBrush, 65, 40, 20, 20);
            t39.Canvas.DrawEllipse(hollowBrush, 15, 65, 20, 20);
            t39.Canvas.DrawEllipse(hollowBrush, 40, 65, 20, 20);
            t39.Canvas.DrawEllipse(hollowBrush, 65, 65, 20, 20);
            t39.Canvas.CompressAndClose();
            t3.Glyphs.Add(t39);

            PDFBrush paleVioletRedbrush = new PDFBrush(PDFRgbColor.PaleVioletRed);
            page.Canvas.DrawString("0 1 2 3 4 5 6 7 8 9", t3, paleVioletRedbrush, 50, 150);
            PDFBrush midnightBluebrush = new PDFBrush(PDFRgbColor.MidnightBlue);
            page.Canvas.DrawString("0 1 2 3 4 5 6 7 8 9", t3, midnightBluebrush, 50, 200);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "type3fonts.pdf") };
            return output;
        }
    }
}