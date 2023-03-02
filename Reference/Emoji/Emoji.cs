using System;
using System.IO;
using O2S.Components.PDF4NET.Core;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.FormattedContent;

namespace O2S.Components.PDF4NET.Samples
{
    class Emoji
    {
        static void Main(string[] args)
        {
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableColorGlyphs = true;
            PDFUnicodeTrueTypeFont emojiTtf = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\SegoeUIEmoji.ttf", 24, true, fontFeatures);

            PDFFixedDocument document = new PDFFixedDocument();
            PDFPage page = document.Pages.Add();

            PDFType3Font emojiType3 = new PDFType3Font(emojiTtf);
            emojiType3.Size = 24;
            emojiType3.CreateGlyphFromUnicodeCodePoint((byte)'A', 0x1F382); // Birthday cake
            emojiType3.CreateGlyphFromUnicodeCodePoint((byte)'B', 0x1F389); // Party Popper
            emojiType3.CreateGlyphFromUnicodeCodePoint((byte)'C', 0x1F973); // Face With Party Horn And Party Hat
            emojiType3.CreateGlyphFromUnicodeCodePoint((byte)'D', 0x1F37E); // Bottle With Popping Cork

            // Full emoji appearance
            PDFFormattedContent fc1 = BuildTextContent(emojiTtf, emojiType3, "A", "BCD");
            page.Canvas.DrawFormattedContent(fc1, 0, 50, page.Width, page.Height);

            // Standard TrueType emoji appearance
            PDFFormattedContent fc2 = BuildTextContent(emojiTtf, emojiTtf, 
                char.ConvertFromUtf32(0x1F382), char.ConvertFromUtf32(0x1F389) + char.ConvertFromUtf32(0x1F973) + char.ConvertFromUtf32(0x1F37E));
            page.Canvas.DrawFormattedContent(fc2, 0, 200, page.Width, page.Height);

            document.Save("Emoji.pdf");

            Console.WriteLine("File saved with success to current folder.");
        }

        private static PDFFormattedContent BuildTextContent(PDFFont standardTextFont, PDFFont emojiFont, string emojiText1, string emojiText2)
        {
            PDFFormattedContent fc = new PDFFormattedContent();
            fc.Paragraphs.Add(new PDFFormattedTextBlock(emojiText1, emojiFont));
            fc.Paragraphs[0].HorizontalAlign = PDFStringHorizontalAlign.Center;
            fc.Paragraphs[0].SpacingAfter = 6;
            fc.Paragraphs.Add(new PDFFormattedTextBlock("Happy Birthday!", standardTextFont));
            fc.Paragraphs[1].HorizontalAlign = PDFStringHorizontalAlign.Center;
            fc.Paragraphs[1].SpacingAfter = 6;
            fc.Paragraphs.Add(new PDFFormattedTextBlock(emojiText2, emojiFont));
            fc.Paragraphs[2].HorizontalAlign = PDFStringHorizontalAlign.Center;

            return fc;
        }

    }
}
