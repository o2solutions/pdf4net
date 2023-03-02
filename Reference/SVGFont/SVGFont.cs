using System;
using System.IO;
using O2S.Components.PDF4NET.Core;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.FormattedContent;

namespace O2S.Components.PDF4NET.Samples
{
    class SVGFont
    {
        static void Main(string[] args)
        {
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableColorGlyphs = true;
            PDFStandardFont titlefont = new PDFStandardFont(PDFStandardFontFace.Helvetica, 12);
            PDFUnicodeTrueTypeFont svgTtf = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\DigitaltsOrange.ttf", 24, true, fontFeatures);
            PDFBrush blackBrush = new PDFBrush(PDFRgbColor.Black);
            PDFBrush darkRedBrush = new PDFBrush(PDFRgbColor.DarkRed);

            PDFFixedDocument document = new PDFFixedDocument();
            PDFPage page = document.Pages.Add();

            PDFType3Font svgType3 = new PDFType3Font(svgTtf);
            svgType3.Size = 24;
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)'C', 'C');
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)'r', 'r');
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)'e', 'e');
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)'a', 'a');
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)'t', 't');
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)'d', 'd');
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)' ', ' ');
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)'w', 'w');
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)'i', 'i');
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)'h', 'h');
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)'P', 'P');
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)'D', 'D');
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)'F', 'F');
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)'4', '4');
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)'N', 'N');
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)'E', 'E');
            svgType3.CreateGlyphFromUnicodeCodePoint((byte)'T', 'T');

            // Full SVG glyph appearance
            page.Canvas.DrawString("Full SVG glyph appearance (text color is given in SVG, brush has no effect)", titlefont, blackBrush, 50, 75);
            page.Canvas.DrawString("Created with PDF4NET", svgType3, darkRedBrush, 50, 90);


            // Standard TrueType glyph appearance
            page.Canvas.DrawString("Standard TrueType glyph appearance (text color is given by the brush)", titlefont, blackBrush, 50, 150);
            page.Canvas.DrawString("Created with PDF4NET", svgTtf, darkRedBrush, 50, 165);

            document.Save("SVGFont.pdf");

            Console.WriteLine("File saved with success to current folder.");
        }

    }
}
