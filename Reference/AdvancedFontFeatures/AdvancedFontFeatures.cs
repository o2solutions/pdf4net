using System;
using System.IO;
using O2S.Components.PDF4NET.Core;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.FormattedContent;

namespace O2S.Components.PDF4NET.Samples
{
    class AdvancedFontFeatures
    {
        static void Main(string[] args)
        {
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableStandardLigatures = true;
            fontFeatures.EnableVerticalGlyphs = true;
            fontFeatures.EnableSmallCapsForLowercase = true;
            fontFeatures.EnableSmallCapsForUppercase = true;
            fontFeatures.EnableOldStyleFigures = true;
            PDFUnicodeTrueTypeFont ttf = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\calibri.ttf", 24, true, fontFeatures);
            PDFBrush blackBrush = new PDFBrush(PDFRgbColor.Black);

            PDFFixedDocument document = new PDFFixedDocument();

            PDFPage page = document.Pages.Add();
            DisplayStandardLigatures(page, blackBrush, ttf);

            page = document.Pages.Add();
            DisplayVerticalGlyphs(page, blackBrush, ttf);

            page = document.Pages.Add();
            DisplaySmallCapitals(page, blackBrush);

            page = document.Pages.Add();
            DisplayOldStyleFigures(page, blackBrush);

            document.Save("AdvancedFontFeatures.pdf");

            Console.WriteLine("File saved with success to current folder.");
        }

        public static void DisplayStandardLigatures(PDFPage page, PDFBrush blackBrush, PDFUnicodeTrueTypeFont font)
        {
            font.FontFeatures.EnableStandardLigatures = true;
            page.Canvas.DrawString("Standard ligatures enabled:", font, blackBrush, 50, 50);
            page.Canvas.DrawString("f f i - ffi", font, blackBrush, 50, 75);
            page.Canvas.DrawString("f i - fi", font, blackBrush, 50, 100);
            page.Canvas.DrawString("f l - fl", font, blackBrush, 50, 125);

            font.FontFeatures.EnableStandardLigatures = false;
            page.Canvas.DrawString("Standard ligatures disabled:", font, blackBrush, 50, 200);
            page.Canvas.DrawString("f f i - ffi", font, blackBrush, 50, 225);
            page.Canvas.DrawString("f i - fi", font, blackBrush, 50, 250);
            page.Canvas.DrawString("f l - fl", font, blackBrush, 50, 275);
        }

        public static void DisplayVerticalGlyphs(PDFPage page, PDFBrush blackBrush, PDFUnicodeTrueTypeFont font)
        {
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableVerticalGlyphs = true;
            // File NotoSansCJKjp-Regular.ttf is very large and it has not been included in the install kit.
            // It can be downloaded here: https://o2sol.com/downoad/samples/NotoSansCJKjp-Regular.ttf
            PDFUnicodeTrueTypeFont ttf = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansCJKjp-Regular.ttf", 48, true, fontFeatures);

            ttf.FontFeatures.EnableVerticalGlyphs = false;
            page.Canvas.DrawString("Horizontal text:", font, blackBrush, 50, 75);
            page.Canvas.DrawString("\uFF08\u3303\uFF09", ttf, blackBrush, 50, 100);

            ttf.FontFeatures.EnableVerticalGlyphs = true;
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = blackBrush;
            sao.Font = ttf;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.X = 50;
            slo.Y = 185;
            slo.Width = 9999;
            slo.Height = 9999;
            page.Canvas.DrawString("Vertical text (vertical glyphs enabled):", font, blackBrush, 50, 175);
            page.Canvas.DrawString("\uFF08\n\u3303\n\uFF09", sao, slo);

            ttf.FontFeatures.EnableVerticalGlyphs = false;
            slo.Y = 375;
            page.Canvas.DrawString("Vertical text (vertical glyphs disabled):", font, blackBrush, 50, 350);
            page.Canvas.DrawString("\uFF08\n\u3303\n\uFF09", sao, slo);
        }

        public static void DisplaySmallCapitals(PDFPage page, PDFBrush blackBrush)
        {
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableSmallCapsForLowercase = true;
            fontFeatures.EnableSmallCapsForUppercase = true;
            PDFUnicodeTrueTypeFont font = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\arial.ttf", 24, true, fontFeatures);

            font.FontFeatures.EnableSmallCapsForUppercase = false;
            page.Canvas.DrawString("UPPERCASE - REGULAR", font, blackBrush, 50, 75);
            font.FontFeatures.EnableSmallCapsForUppercase = true;
            page.Canvas.DrawString("UPPERCASE - SMALL CAPS", font, blackBrush, 50, 105);

            font.FontFeatures.EnableSmallCapsForUppercase = false;
            font.FontFeatures.EnableSmallCapsForLowercase = false;
            page.Canvas.DrawString("Lowercase - Regular", font, blackBrush, 50, 150);
            font.FontFeatures.EnableSmallCapsForLowercase = true;
            page.Canvas.DrawString("Lowercase - Small Caps", font, blackBrush, 50, 180);

        }

        public static void DisplayOldStyleFigures(PDFPage page, PDFBrush blackBrush)
        {
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableOldStyleFigures = true;
            PDFUnicodeTrueTypeFont font = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\arial.ttf", 24, true, fontFeatures);

            font.FontFeatures.EnableOldStyleFigures = true;
            page.Canvas.DrawString("0123456789 - old style figures", font, blackBrush, 50, 70);
            font.FontFeatures.EnableOldStyleFigures = false;
            page.Canvas.DrawString("0123456789 - default figures", font, blackBrush, 50, 105);
        }

    }
}
