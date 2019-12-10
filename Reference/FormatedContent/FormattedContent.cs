using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Actions;
using O2S.Components.PDF4NET.Graphics.FormattedContent;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// FormattedContent sample.
    /// </summary>
    public class FormattedContent
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run()
        {
            string pdf4netText = "PDF4NET";
            string paragraph1Block2Text = " library is a .NET/Xamarin library for cross-platform PDF development. Code written for ";
            string paragraph1Block4Text = " can be compiled on all supported platforms without changes. The library features a " +
                "wide range of capabilities, for both beginers and advanced PDF developers.";
            string paragraph2Block1Text = "The development style is based on fixed document model, where each page is created as needed " +
                "and content is placed at fixed position using a grid based layout.\r\n" +
                "This gives you access to all PDF features, whether you want to create a simple file " +
                "or you want to create a transparency knockout group at COS level, and lets you build more complex models on top of the library.";
            string paragraph3Block2Text = " has been developed entirely in C# and it is 100% managed code.";
            string paragraph4Block1Text = "With ";
            string paragraph4Block3Text = " you can port your PDF application logic to other platforms with zero effort which means faster time to market.";
            string paragraph5Block1Text = "Simple licensing per developer with royalty free distribution helps you keep your costs under control.";
            string paragraph6Block1Text = "SUPPORTED PLATFORMS";
            string paragraph7Block1Text = "NET 2.0 to .NET 4.5";
            string paragraph8Block1Text = "Windows Forms";
            string paragraph9Block1Text = "ASP.NET Webforms and MVC";
            string paragraph10Block1Text = "Console applications";
            string paragraph11Block1Text = "Windows services";
            string paragraph12Block1Text = "Mono";
            string paragraph13Block1Text = "WPF 4.0 & 4.5";
            string paragraph14Block1Text = "Silverlight 4 & 5";
            string paragraph15Block1Text = "WinRT (Windows Store applications)";
            string paragraph16Block1Text = "Windows Phone 7 & 8";
            string paragraph17Block1Text = "Xamarin.iOS";
            string paragraph18Block1Text = "Xamarin.Android";

            PDFStandardFont textFont = new PDFStandardFont(PDFStandardFontFace.Helvetica, 10);
            PDFFormattedTextBlock pdf4netLinkBlock = new PDFFormattedTextBlock(pdf4netText);
            pdf4netLinkBlock.Font = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 10);
            pdf4netLinkBlock.Font.Underline = true;
            pdf4netLinkBlock.TextColor = new PDFBrush(PDFRgbColor.Blue);
            pdf4netLinkBlock.Action = new PDFUriAction("http://www.o2sol.com/");

            PDFFormattedParagraph paragraph1 = new PDFFormattedParagraph();
            paragraph1.LineSpacingMode = PDFFormattedParagraphLineSpacing.Multiple;
            paragraph1.LineSpacing = 1.2;
            paragraph1.SpacingAfter = 3;
            paragraph1.FirstLineIndent = 10;
            paragraph1.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            paragraph1.Blocks.Add(pdf4netLinkBlock);
            paragraph1.Blocks.Add(new PDFFormattedTextBlock(paragraph1Block2Text, textFont));
            paragraph1.Blocks.Add(pdf4netLinkBlock);
            paragraph1.Blocks.Add(new PDFFormattedTextBlock(paragraph1Block4Text, textFont));

            PDFFormattedParagraph paragraph2 = new PDFFormattedParagraph();
            paragraph2.SpacingAfter = 3;
            paragraph2.FirstLineIndent = 10;
            paragraph2.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            paragraph2.LineSpacingMode = PDFFormattedParagraphLineSpacing.Multiple;
            paragraph2.LineSpacing = 1.2;
            paragraph2.Blocks.Add(new PDFFormattedTextBlock(paragraph2Block1Text, textFont));

            PDFFormattedParagraph paragraph3 = new PDFFormattedParagraph();
            paragraph3.LineSpacingMode = PDFFormattedParagraphLineSpacing.Multiple;
            paragraph3.LineSpacing = 1.2;
            paragraph3.SpacingAfter = 3;
            paragraph3.FirstLineIndent = 10;
            paragraph3.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            paragraph3.Blocks.Add(pdf4netLinkBlock);
            paragraph3.Blocks.Add(new PDFFormattedTextBlock(paragraph3Block2Text, textFont));

            PDFFormattedParagraph paragraph4 = new PDFFormattedParagraph();
            paragraph4.LineSpacingMode = PDFFormattedParagraphLineSpacing.Multiple;
            paragraph4.LineSpacing = 1.2;
            paragraph4.SpacingAfter = 3;
            paragraph4.FirstLineIndent = 10;
            paragraph4.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            paragraph4.Blocks.Add(new PDFFormattedTextBlock(paragraph4Block1Text, textFont));
            paragraph4.Blocks.Add(pdf4netLinkBlock);
            paragraph4.Blocks.Add(new PDFFormattedTextBlock(paragraph4Block3Text, textFont));

            PDFFormattedParagraph paragraph5 = new PDFFormattedParagraph();
            paragraph5.FirstLineIndent = 10;
            paragraph5.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            paragraph5.Blocks.Add(new PDFFormattedTextBlock(paragraph5Block1Text, textFont));

            PDFFormattedParagraph paragraph6 = new PDFFormattedParagraph();
            paragraph6.SpacingBefore = 10;
            paragraph6.Blocks.Add(new PDFFormattedTextBlock(paragraph6Block1Text, textFont));

            PDFFormattedTextBlock bulletBlock = new PDFFormattedTextBlock("\x76 ", new PDFStandardFont(PDFStandardFontFace.ZapfDingbats, 10));

            PDFFormattedParagraph paragraph7 = new PDFFormattedParagraph();
            paragraph7.SpacingBefore = 3;
            paragraph7.Bullet = bulletBlock;
            paragraph7.LeftIndentation = 10;
            paragraph7.Blocks.Add(new PDFFormattedTextBlock(paragraph7Block1Text, textFont));

            PDFFormattedParagraph paragraph8 = new PDFFormattedParagraph();
            paragraph8.SpacingBefore = 3;
            paragraph8.Bullet = bulletBlock;
            paragraph8.LeftIndentation = 10;
            paragraph8.Blocks.Add(new PDFFormattedTextBlock(paragraph8Block1Text, textFont));

            PDFFormattedParagraph paragraph9 = new PDFFormattedParagraph();
            paragraph9.SpacingBefore = 3;
            paragraph9.Bullet = bulletBlock;
            paragraph9.LeftIndentation = 10;
            paragraph9.Blocks.Add(new PDFFormattedTextBlock(paragraph9Block1Text, textFont));

            PDFFormattedParagraph paragraph10 = new PDFFormattedParagraph();
            paragraph10.SpacingBefore = 3;
            paragraph10.Bullet = bulletBlock;
            paragraph10.LeftIndentation = 10;
            paragraph10.Blocks.Add(new PDFFormattedTextBlock(paragraph10Block1Text, textFont));

            PDFFormattedParagraph paragraph11 = new PDFFormattedParagraph();
            paragraph11.SpacingBefore = 3;
            paragraph11.Bullet = bulletBlock;
            paragraph11.LeftIndentation = 10;
            paragraph11.Blocks.Add(new PDFFormattedTextBlock(paragraph11Block1Text, textFont));

            PDFFormattedParagraph paragraph12 = new PDFFormattedParagraph();
            paragraph12.SpacingBefore = 3;
            paragraph12.Bullet = bulletBlock;
            paragraph12.LeftIndentation = 10;
            paragraph12.Blocks.Add(new PDFFormattedTextBlock(paragraph12Block1Text, textFont));

            PDFFormattedParagraph paragraph13 = new PDFFormattedParagraph();
            paragraph13.SpacingBefore = 3;
            paragraph13.Bullet = bulletBlock;
            paragraph13.LeftIndentation = 10;
            paragraph13.Blocks.Add(new PDFFormattedTextBlock(paragraph13Block1Text, textFont));

            PDFFormattedParagraph paragraph14 = new PDFFormattedParagraph();
            paragraph14.SpacingBefore = 3;
            paragraph14.Bullet = bulletBlock;
            paragraph14.LeftIndentation = 10;
            paragraph14.Blocks.Add(new PDFFormattedTextBlock(paragraph14Block1Text, textFont));

            PDFFormattedParagraph paragraph15 = new PDFFormattedParagraph();
            paragraph15.SpacingBefore = 3;
            paragraph15.Bullet = bulletBlock;
            paragraph15.LeftIndentation = 10;
            paragraph15.Blocks.Add(new PDFFormattedTextBlock(paragraph15Block1Text, textFont));

            PDFFormattedParagraph paragraph16 = new PDFFormattedParagraph();
            paragraph16.SpacingBefore = 3;
            paragraph16.Bullet = bulletBlock;
            paragraph16.LeftIndentation = 10;
            paragraph16.Blocks.Add(new PDFFormattedTextBlock(paragraph16Block1Text, textFont));

            PDFFormattedParagraph paragraph17 = new PDFFormattedParagraph();
            paragraph17.SpacingBefore = 3;
            paragraph17.Bullet = bulletBlock;
            paragraph17.LeftIndentation = 10;
            paragraph17.Blocks.Add(new PDFFormattedTextBlock(paragraph17Block1Text, textFont));

            PDFFormattedParagraph paragraph18 = new PDFFormattedParagraph();
            paragraph18.SpacingBefore = 3;
            paragraph18.Bullet = bulletBlock;
            paragraph18.LeftIndentation = 10;
            paragraph18.Blocks.Add(new PDFFormattedTextBlock(paragraph18Block1Text, textFont));

            PDFFormattedContent formattedContent = new PDFFormattedContent();
            formattedContent.Paragraphs.Add(paragraph1);
            formattedContent.Paragraphs.Add(paragraph2);
            formattedContent.Paragraphs.Add(paragraph3);
            formattedContent.Paragraphs.Add(paragraph4);
            formattedContent.Paragraphs.Add(paragraph5);
            formattedContent.Paragraphs.Add(paragraph6);
            formattedContent.Paragraphs.Add(paragraph7);
            formattedContent.Paragraphs.Add(paragraph8);
            formattedContent.Paragraphs.Add(paragraph9);
            formattedContent.Paragraphs.Add(paragraph10);
            formattedContent.Paragraphs.Add(paragraph11);
            formattedContent.Paragraphs.Add(paragraph12);
            formattedContent.Paragraphs.Add(paragraph13);
            formattedContent.Paragraphs.Add(paragraph14);
            formattedContent.Paragraphs.Add(paragraph15);
            formattedContent.Paragraphs.Add(paragraph16);
            formattedContent.Paragraphs.Add(paragraph17);
            formattedContent.Paragraphs.Add(paragraph18);

            PDFFixedDocument document = new PDFFixedDocument();
            PDFPage page = document.Pages.Add();

            page.Canvas.DrawFormattedContent(formattedContent, 50, 50, 500, 700);
            page.Canvas.CompressAndClose();
			
            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "formattedcontent.pdf") };
            return output;
        }
    }
}