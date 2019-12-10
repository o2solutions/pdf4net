using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Actions;
using O2S.Components.PDF4NET.Annotations;
using O2S.Components.PDF4NET.Core.Cos;
using O2S.Components.PDF4NET.Forms;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.FormattedContent;
using O2S.Components.PDF4NET.LogicalStructure;
using O2S.Components.PDF4NET.Standards;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// PDF/A sample.
    /// </summary>
    public class PDFUA
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo Run(Stream verdanaInput, Stream verdanaBoldInput, Stream imageStream)
        {
            PDFAnsiTrueTypeFont verdana = new PDFAnsiTrueTypeFont(verdanaInput, 10, true);
            PDFAnsiTrueTypeFont verdanaBold = new PDFAnsiTrueTypeFont(verdanaBoldInput, 10, true);

            PDFFixedDocument document = new PDFFixedDocument();
            document.Language = "en-US";

            document.DocumentInformation = new PDFDocumentInformation();
            document.DocumentInformation.Author = "O2 Solutions";
            document.DocumentInformation.Title = "PDF4NET PDF/UA Demo";
            document.DocumentInformation.Creator = "PDF4NET PDF/UA Demo Application";
            document.DocumentInformation.Producer = "PDF4NET";
            document.DocumentInformation.Keywords = "pdf/ua";
            document.DocumentInformation.Subject = "PDF/UA-1 Sample produced by PDF4NET";
            document.XmpMetadata = new PDFXmpMetadata();

            document.ViewerPreferences = new PDFViewerPreferences();
            document.ViewerPreferences.DisplayDocumentTitle = true;

            document.MarkInformation = new PDFMarkInformation();
            document.MarkInformation.IsTaggedPDF = true;

            document.StructureTree = new PDFStructureTree();

            PDFStructureElement seDocument = new PDFStructureElement(PDFStandardStructureTypes.Document);
            seDocument.Title = "PDF4NET PDF/UA-1 Demo";
            document.StructureTree.StructureElements = seDocument;

            SimpleText(document, seDocument, verdana, imageStream);

            FormattedContent(document, seDocument, verdana);

            AnnotationsAndFormFields(document, seDocument, verdana);

            return new SampleOutputInfo(document, "pdfua1.pdf");
        }

        private static void SimpleText(PDFFixedDocument document, PDFStructureElement seParent, PDFAnsiTrueTypeFont font, Stream imageStream)
        {
            PDFAnsiTrueTypeFont headingFont = new PDFAnsiTrueTypeFont(font, 16);
            PDFAnsiTrueTypeFont textFont = new PDFAnsiTrueTypeFont(font, 10);
            PDFBrush blackBrush = new PDFBrush(PDFRgbColor.Black);
            PDFPen blackPen = new PDFPen(PDFRgbColor.Black, 1);
            PDFPage page = document.Pages.Add();

            PDFStructureElement seSection = new PDFStructureElement(PDFStandardStructureTypes.Section);
            seSection.Title = "Simple text";
            seParent.AppendChild(seSection);

            PDFStructureElement seHeading = new PDFStructureElement(PDFStandardStructureTypes.Heading);
            seSection.AppendChild(seHeading);

            page.Graphics.BeginStructureElement(seHeading);
            page.Graphics.DrawString("Page heading", headingFont, blackBrush, 30, 50);
            page.Graphics.EndStructureElement();

            PDFStructureElement seParagraph1 = new PDFStructureElement(PDFStandardStructureTypes.Paragraph);
            seSection.AppendChild(seParagraph1);

            page.Graphics.BeginStructureElement(seParagraph1);
            page.Graphics.DrawString("Sample paragraph. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris in sodales ligula at lobortis.", textFont, blackBrush, 30, 70);
            page.Graphics.EndStructureElement();

            PDFStructureElement seFigure = new PDFStructureElement(PDFStandardStructureTypes.Figure);
            seFigure.ActualText = "PDF4NET";
            seFigure.AlternateDescription = "PDF4NET Logo";
            seSection.AppendChild(seFigure);

            page.Graphics.BeginStructureElement(seFigure);
            PDFPngImage logoImage = new PDFPngImage(imageStream);
            page.Graphics.DrawImage(logoImage, 30, 90, 256, 128);
            page.Graphics.EndStructureElement();

            // A structure element with 2 content items and an artifact between them.
            PDFStructureElement seParagraph2 = new PDFStructureElement(PDFStandardStructureTypes.Paragraph);
            seSection.AppendChild(seParagraph2);

            page.Graphics.BeginStructureElement(seParagraph2);
            page.Graphics.DrawString("First line of text.", textFont, blackBrush, 30, 230);
            page.Graphics.EndStructureElement();

            page.Graphics.BeginArtifactMarkedContent();
            page.Graphics.DrawLine(blackPen, 30, 242, 100, 242);
            page.Graphics.EndMarkedContent();

            page.Graphics.BeginStructureElement(seParagraph2);
            page.Graphics.DrawString("Second line of text.", textFont, blackBrush, 30, 245);
            page.Graphics.EndStructureElement();

            PDFStructureElement seParagraph3 = new PDFStructureElement(PDFStandardStructureTypes.Paragraph);
            seSection.AppendChild(seParagraph3);

            string text = "Paragraph with underlined text. The structure element is passed as parameter to DrawString method in order to properly tag graphic artifacts such as underlines. " +
                "Morbi pulvinar eros sit amet diam lacinia, ut feugiat ligula bibendum. Suspendisse ultrices cursus condimentum. " +
                "Pellentesque semper iaculis luctus. Sed ac maximus urna. Aliquam erat volutpat. Vivamus vel sollicitudin dui. Aenean efficitur " +
                "fringilla dui, at varius lacus luctus ac. Quisque tellus dui, lacinia non lectus nec, semper faucibus erat.";
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = blackBrush;
            sao.Font = textFont;
            sao.Font.Underline = true;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.X = 30;
            slo.Y = 260;
            slo.Width = 550;
            page.Graphics.DrawString(text, sao, slo, seParagraph3);

            // A custom structure element that will be mapped to standard Pargraph structure.
            PDFStructureElement seSpecialParagraph = new PDFStructureElement("SpecialParagraph");
            // The structure element specifies an ID that needs to be added to document's IDMap.
            seSpecialParagraph.ID = "specialpara";
            seSection.AppendChild(seSpecialParagraph);

            page.Graphics.BeginStructureElement(seSpecialParagraph);
            textFont.Underline = false;
            textFont.Size = 18;
            page.Graphics.DrawString("A special paragraph with custom structure element type.", textFont, blackBrush, 30, 350);
            page.Graphics.EndStructureElement();

            // Map the custom structure type to a known structure type.
            document.StructureTree.RoleMap = new PDFRoleMap();
            document.StructureTree.RoleMap["SpecialParagraph"] = PDFStandardStructureTypes.Paragraph;

            // Include the ID of the structure element in the document's identifiers map.
            document.StructureTree.IdentifierMap = new PDFIdMap();
            document.StructureTree.IdentifierMap["specialpara"] = seSpecialParagraph;
        }

        private static void FormattedContent(PDFFixedDocument document, PDFStructureElement seParent, PDFAnsiTrueTypeFont font)
        {
            string text1 = "Morbi pulvinar eros sit amet diam lacinia, ut feugiat ligula bibendum. Suspendisse ultrices cursus condimentum. " +
                "Pellentesque semper iaculis luctus. Sed ac maximus urna. Aliquam erat volutpat. ";
            string text2 = "Vivamus vel sollicitudin dui. Aenean efficitur " +
                "fringilla dui, at varius lacus luctus ac. Quisque tellus dui, lacinia non lectus nec, semper faucibus erat.";

            PDFAnsiTrueTypeFont headingFont = new PDFAnsiTrueTypeFont(font, 16);
            PDFAnsiTrueTypeFont textFont = new PDFAnsiTrueTypeFont(font, 10);
            PDFBrush blackBrush = new PDFBrush(PDFRgbColor.Black);
            PDFPen blackPen = new PDFPen(PDFRgbColor.Black, 1);
            PDFPage page = document.Pages.Add();
            page.TabOrder = PDFPageTabOrder.Structure;

            PDFStructureElement seSection = new PDFStructureElement(PDFStandardStructureTypes.Section);
            seSection.Title = "Formatted content";
            seParent.AppendChild(seSection);

            PDFStructureElement seHeading = new PDFStructureElement(PDFStandardStructureTypes.Heading);
            seSection.AppendChild(seHeading);

            page.Graphics.BeginStructureElement(seHeading);
            page.Graphics.DrawString("Another heading", headingFont, blackBrush, 30, 50);
            page.Graphics.EndStructureElement();

            PDFFormattedContent fc = new PDFFormattedContent();

            PDFFormattedParagraph paragraph1 = new PDFFormattedParagraph(text1, textFont);
            paragraph1.LineSpacing = 1.2;
            paragraph1.LineSpacingMode = PDFFormattedParagraphLineSpacing.Multiple;
            paragraph1.StructureElement = new PDFStructureElement(PDFStandardStructureTypes.Paragraph);
            seSection.AppendChild(paragraph1.StructureElement);
            fc.Paragraphs.Add(paragraph1);

            PDFFormattedTextBlock block1 = new PDFFormattedTextBlock("Sample paragraph with a link.\r\n", textFont);
            block1.StructureElement = new PDFStructureElement(PDFStandardStructureTypes.Span);
            PDFFormattedTextBlock block2 = new PDFFormattedTextBlock("http://www.o2sol.com/\r\n", textFont);
            block2.TextColor = new PDFBrush(PDFRgbColor.Blue);
            block2.Action = new PDFUriAction("http://www.o2sol.com/");
            block2.StructureElement = new PDFStructureElement(PDFStandardStructureTypes.Link);
            PDFFormattedTextBlock block3 = new PDFFormattedTextBlock("http://www.pdf4net.com/", textFont);
            block3.TextColor = new PDFBrush(PDFRgbColor.Blue);
            block3.Action = new PDFUriAction("http://www.pdf4net.com/");
            block3.StructureElement = new PDFStructureElement(PDFStandardStructureTypes.Link);
            PDFFormattedParagraph paragraph2 = new PDFFormattedParagraph(block1, block2, block3);
            paragraph2.LineSpacing = 1.2;
            paragraph2.LineSpacingMode = PDFFormattedParagraphLineSpacing.Multiple;
            paragraph2.StructureElement = new PDFStructureElement(PDFStandardStructureTypes.Paragraph);
            // Do not mark the paragraph in the content stream, instead its blocks will be marked.
            paragraph2.StructureElement.GenerateMarkedContentSequence = false;
            paragraph2.StructureElement.AppendChild(block1.StructureElement);
            paragraph2.StructureElement.AppendChild(block2.StructureElement);
            paragraph2.StructureElement.AppendChild(block3.StructureElement);
            seSection.AppendChild(paragraph2.StructureElement);
            fc.Paragraphs.Add(paragraph2);

            PDFFormattedParagraph paragraph3 = new PDFFormattedParagraph(text2, textFont);
            paragraph3.LineSpacing = 1.2;
            paragraph3.LineSpacingMode = PDFFormattedParagraphLineSpacing.Multiple;
            paragraph3.StructureElement = new PDFStructureElement(PDFStandardStructureTypes.Paragraph);
            seSection.AppendChild(paragraph3.StructureElement);
            fc.Paragraphs.Add(paragraph3);

            page.Graphics.DrawFormattedContent(fc, 30, 70, 550, 0);
        }

        private static void AnnotationsAndFormFields(PDFFixedDocument document, PDFStructureElement seParent, PDFAnsiTrueTypeFont font)
        {
            PDFAnsiTrueTypeFont headingFont = new PDFAnsiTrueTypeFont(font, 16);
            PDFAnsiTrueTypeFont textFont = new PDFAnsiTrueTypeFont(font, 10);
            PDFBrush blackBrush = new PDFBrush(PDFRgbColor.Black);
            PDFPen blackPen = new PDFPen(PDFRgbColor.Black, 1);
            PDFPage page = document.Pages.Add();
            page.TabOrder = PDFPageTabOrder.Structure;

            PDFStructureElement seSection = new PDFStructureElement(PDFStandardStructureTypes.Section);
            seSection.Title = "Annotations and form fields";
            seParent.AppendChild(seSection);

            PDFStructureElement seHeading = new PDFStructureElement(PDFStandardStructureTypes.Heading);
            seSection.AppendChild(seHeading);

            page.Graphics.BeginStructureElement(seHeading);
            page.Graphics.DrawString("Annotations and form fields", headingFont, blackBrush, 30, 50);
            page.Graphics.EndStructureElement();

            PDFStructureElement seParagraph1 = new PDFStructureElement(PDFStandardStructureTypes.Paragraph);
            seSection.AppendChild(seParagraph1);

            page.Graphics.BeginStructureElement(seParagraph1);
            page.Graphics.DrawString("Our website:", textFont, blackBrush, 30, 70);
            page.Graphics.EndStructureElement();

            PDFStructureElement seLink = new PDFStructureElement(PDFStandardStructureTypes.Link);
            seParagraph1.AppendChild(seLink);

            page.Graphics.BeginStructureElement(seLink);
            page.Graphics.DrawString("http://www.o2sol.com/", textFont, blackBrush, 100, 70);
            page.Graphics.EndStructureElement();

            PDFLinkAnnotation link = new PDFLinkAnnotation();
            page.Annotations.Add(link);
            link.VisualRectangle = new PDFVisualRectangle(95, 70, 130, 10);
            link.HighlightStyle = PDFLinkAnnotationHighlightStyle.Invert;
            link.Contents = "http://www.o2sol.com/";

            PDFObjectReference linkRef = new PDFObjectReference();
            linkRef.Page = page;
            linkRef.Stream = link.CosDictionary as PDFCosDictionaryContainer;
            seLink.AppendChild(linkRef);
            document.StructureTree.MapObjectReference(link, seLink);

            PDFStructureElement seParagraph2 = new PDFStructureElement(PDFStandardStructureTypes.Paragraph);
            seSection.AppendChild(seParagraph2);

            page.Graphics.BeginStructureElement(seParagraph2);
            page.Graphics.DrawString("Enter your name:", textFont, blackBrush, 30, 100);
            page.Graphics.EndStructureElement();

            PDFStructureElement seForm = new PDFStructureElement(PDFStandardStructureTypes.Form);
            seParagraph2.AppendChild(seForm);

            PDFTextBoxField fldName = new PDFTextBoxField("name");
            page.Fields.Add(fldName);
            fldName.AlternateName = "Enter your name";
            fldName.Widgets[0].VisualRectangle = new PDFVisualRectangle(120, 95, 130, 20);
            fldName.Widgets[0].BorderColor = PDFRgbColor.Blue;
            fldName.Widgets[0].BorderWidth = 1;
            fldName.Widgets[0].BackgroundColor = PDFRgbColor.LightBlue;
            fldName.Widgets[0].Font = textFont;

            PDFObjectReference fieldRef = new PDFObjectReference();
            fieldRef.Page = page;
            fieldRef.Stream = fldName.Widgets[0].CosDictionary as PDFCosDictionaryContainer;
            seForm.AppendChild(fieldRef);
            document.StructureTree.MapObjectReference(fldName.Widgets[0], seForm);
        }
    }
}