using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Actions;
using O2S.Components.PDF4NET.FlowDocument;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.FormattedContent;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// SuperscriptSubscript sample.
    /// </summary>
    public class SuperscriptSubscript
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream verdanaFontStream)
        {
            PDFAnsiTrueTypeFont verdana = new PDFAnsiTrueTypeFont(verdanaFontStream, 36, true);

            PDFFlowDocument document = new PDFFlowDocument();

            PDFFlowContent superscriptSection = BuildSuperscript(verdana);
            document.AddContent(superscriptSection);

            PDFFlowContent subscriptSection = BuildSubscript(verdana);
            document.AddContent(subscriptSection);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "superscriptsubscript.pdf") };
            return output;
        }

        private static PDFFlowContent BuildSuperscript(PDFAnsiTrueTypeFont font)
        {
            PDFAnsiTrueTypeFont fontSuperscript = new PDFAnsiTrueTypeFont(font, 18);
            PDFAnsiTrueTypeFont fontRegular = new PDFAnsiTrueTypeFont(font, 12);

            PDFFormattedContent content = new PDFFormattedContent();
            PDFFlowTextContent flowText = new PDFFlowTextContent(content);

            PDFFormattedTextBlock titleBlock = new PDFFormattedTextBlock("Superscript text", fontRegular);
            content.Paragraphs.Add(new PDFFormattedParagraph(titleBlock));
            content.Paragraphs.Add(new PDFFormattedParagraph(" "));

            PDFFormattedTextBlock xBlock = new PDFFormattedTextBlock("X", font);
            xBlock.Superscript.Add(new PDFFormattedTextBlock("2", fontSuperscript));
            PDFFormattedTextBlock yBlock = new PDFFormattedTextBlock(" + Y", font);
            yBlock.Superscript.Add(new PDFFormattedTextBlock("2", fontSuperscript));
            PDFFormattedTextBlock zBlock = new PDFFormattedTextBlock(" = Z", font);
            zBlock.Superscript.Add(new PDFFormattedTextBlock("2", fontSuperscript));

            PDFFormattedParagraph paragraph = new PDFFormattedParagraph(xBlock, yBlock, zBlock);
            paragraph.HorizontalAlign = PDFStringHorizontalAlign.Center;
            content.Paragraphs.Add(paragraph);

            return flowText;
        }

        private static PDFFlowContent BuildSubscript(PDFAnsiTrueTypeFont font)
        {
            PDFAnsiTrueTypeFont fontSubscript = new PDFAnsiTrueTypeFont(font, 18);
            PDFAnsiTrueTypeFont fontRegular = new PDFAnsiTrueTypeFont(font, 12);

            PDFFormattedContent content = new PDFFormattedContent();
            PDFFlowTextContent flowText = new PDFFlowTextContent(content);
            flowText.OuterMargins = new PDFFlowContentMargins(0, 0, 36, 0);

            PDFFormattedTextBlock titleBlock = new PDFFormattedTextBlock("Subscript text", fontRegular);
            content.Paragraphs.Add(new PDFFormattedParagraph(titleBlock));
            content.Paragraphs.Add(new PDFFormattedParagraph(" "));

            PDFFormattedTextBlock block1 = new PDFFormattedTextBlock("Y = X", font);
            block1.Subscript.Add(new PDFFormattedTextBlock("1", fontSubscript));
            PDFFormattedTextBlock block2 = new PDFFormattedTextBlock(" + X", font);
            block2.Subscript.Add(new PDFFormattedTextBlock("2", fontSubscript));
            PDFFormattedTextBlock block3 = new PDFFormattedTextBlock(" + X", font);
            block3.Subscript.Add(new PDFFormattedTextBlock("3", fontSubscript));
            PDFFormattedTextBlock blockn = new PDFFormattedTextBlock(" + ... + X", font);
            blockn.Subscript.Add(new PDFFormattedTextBlock("n", fontSubscript));

            PDFFormattedParagraph paragraph = new PDFFormattedParagraph(block1, block2, block3, blockn);
            paragraph.HorizontalAlign = PDFStringHorizontalAlign.Center;
            content.Paragraphs.Add(paragraph);

            return flowText;
        }
    }
}