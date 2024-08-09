using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.OptionalContent;
using O2S.Components.PDF4NET.Standards;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// PDF/A sample.
    /// </summary>
    public class PDFA
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream iccInput, Stream ttfInput)
        {
            PDFFixedDocument pdfa1bDocument = CreatePDFA1bDocument(iccInput, ttfInput);
            PDFFixedDocument pdfa2uDocument = CreatePDFA2uDocument(iccInput, ttfInput);
            PDFFixedDocument pdfa3uDocument = CreatePDFA3uDocument(iccInput, ttfInput);

            // The document is formatted as PDF/A using the PDFAFormatter class:
            // PDFAFormatter.Save(document, outputStream, PDFAFormat.PDFA1b);
            SampleOutputInfo[] output = new SampleOutputInfo[] 
                {
                    new SampleOutputInfo(pdfa1bDocument, "pdfa1b.pdf"),
                    new SampleOutputInfo(pdfa2uDocument, "pdfa2u.pdf"),
                    new SampleOutputInfo(pdfa3uDocument, "pdfa3u.pdf"),
                };
            return output;
        }

        private static PDFFixedDocument CreatePDFA1bDocument(Stream iccInput, Stream ttfInput)
        {
            iccInput.Position = 0;
            ttfInput.Position = 0;

            PDFFixedDocument document = new PDFFixedDocument();

            // Setup the document by creating a PDF/A output intent, based on a RGB ICC profile, 
            // and document information and metadata
            PDFIccColorSpace icc = new PDFIccColorSpace();
            byte[] profilePayload = new byte[iccInput.Length];
            iccInput.Read(profilePayload, 0, profilePayload.Length);
            icc.IccProfile = profilePayload;
            PDFOutputIntent oi = new PDFOutputIntent();
            oi.Type = PDFOutputIntentType.PDFA1;
            oi.Info = "sRGB IEC61966-2.1";
            oi.OutputConditionIdentifier = "Custom";
            oi.DestinationOutputProfile = icc;
            document.OutputIntents = new PDFOutputIntentCollection();
            document.OutputIntents.Add(oi);

            document.DocumentInformation = new PDFDocumentInformation();
            document.DocumentInformation.Author = "O2 Solutions";
            document.DocumentInformation.Title = "PDF4NET PDF/A-1B Demo";
            document.DocumentInformation.Creator = "PDF4NET PDF/A-1B Demo Application";
            document.DocumentInformation.Producer = "PDF4NET";
            document.DocumentInformation.Keywords = "pdf/a";
            document.DocumentInformation.Subject = "PDF/A-1B Sample produced by PDF4NET";
            document.XmpMetadata = new PDFXmpMetadata();

            PDFPage page = document.Pages.Add();
            page.Rotation = 90;

            // All fonts must be embedded in a PDF/A document.
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Font = new PDFAnsiTrueTypeFont(ttfInput, 24, true);
            sao.Brush = new PDFBrush(new PDFRgbColor(0, 0, 128));

            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Bottom;
            slo.X = page.Width / 2;
            slo.Y = page.Height / 2 - 10;
            page.Canvas.DrawString("PDF4NET", sao, slo);
            slo.Y = page.Height / 2 + 10;
            slo.VerticalAlign = PDFStringVerticalAlign.Top;
            sao.Font.Size = 16;
            page.Canvas.DrawString("This is a sample PDF/A-1B document that shows the PDF/A-1B capabilities in PDF4NET library", sao, slo);

            return document;
        }

        private static PDFFixedDocument CreatePDFA2uDocument(Stream iccInput, Stream ttfInput)
        {
            iccInput.Position = 0;
            ttfInput.Position = 0;

            PDFFixedDocument document = new PDFFixedDocument();
            document.OptionalContentProperties = new PDFOptionalContentProperties();

            // Setup the document by creating a PDF/A output intent, based on a RGB ICC profile, 
            // and document information and metadata
            PDFIccColorSpace icc = new PDFIccColorSpace();
            byte[] profilePayload = new byte[iccInput.Length];
            iccInput.Read(profilePayload, 0, profilePayload.Length);
            icc.IccProfile = profilePayload;
            PDFOutputIntent oi = new PDFOutputIntent();
            oi.Type = PDFOutputIntentType.PDFA1;
            oi.Info = "sRGB IEC61966-2.1";
            oi.OutputConditionIdentifier = "Custom";
            oi.DestinationOutputProfile = icc;
            document.OutputIntents = new PDFOutputIntentCollection();
            document.OutputIntents.Add(oi);

            document.DocumentInformation = new PDFDocumentInformation();
            document.DocumentInformation.Author = "O2 Solutions";
            document.DocumentInformation.Title = "PDF4NET PDF/A-2B/U Demo";
            document.DocumentInformation.Creator = "PDF4NET PDF/A-2B/U Demo Application";
            document.DocumentInformation.Producer = "PDF4NET";
            document.DocumentInformation.Keywords = "pdf/a";
            document.DocumentInformation.Subject = "PDF/A-2B/U Sample produced by PDF4NET";
            document.XmpMetadata = new PDFXmpMetadata();

            PDFPage page = document.Pages.Add();
            page.Rotation = 90;

            // All fonts must be embedded in a PDF/A document.
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Font = new PDFAnsiTrueTypeFont(ttfInput, 24, true);
            sao.Brush = new PDFBrush(new PDFRgbColor(0, 0, 128));

            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Bottom;
            slo.X = page.Width / 2;
            slo.Y = page.Height / 2 - 10;
            page.Canvas.DrawString("PDF4NET", sao, slo);
            slo.Y = page.Height / 2 + 10;
            slo.VerticalAlign = PDFStringVerticalAlign.Top;
            sao.Font.Size = 14;
            page.Canvas.DrawString("This is a sample PDF/A-2B/U document that shows the PDF/A-2B/U capabilities in PDF4NET library", sao, slo);

            // PDF/A-2 documents support optional content and transparency.
            PDFOptionalContentGroup ocgPage1 = new PDFOptionalContentGroup();
            ocgPage1.Name = "Green Rectangle";
            page.Canvas.BeginOptionalContentGroup(ocgPage1);
            page.Canvas.SaveGraphicsState();
            PDFExtendedGraphicState gs = new PDFExtendedGraphicState();
            gs.FillAlpha = 0.8;
            gs.StrokeAlpha = 0.2;
            gs.BlendMode = PDFBlendMode.Luminosity;
            page.Canvas.SetExtendedGraphicState(gs);

            PDFBrush greenBrush = new PDFBrush(PDFRgbColor.DarkGreen);
            PDFPen bluePen = new PDFPen(PDFRgbColor.DarkBlue, 5);
            page.Canvas.DrawRectangle(bluePen, greenBrush, 20, 20, page.Width - 40, page.Height - 40);

            page.Canvas.RestoreGraphicsState();
            page.Canvas.EndOptionalContentGroup();

            // Build the display tree for the optional content, 
            // how its structure and relationships between optional content groups are presented to the user.
            PDFOptionalContentDisplayTreeNode ocgPage1Node = new PDFOptionalContentDisplayTreeNode(ocgPage1);
            document.OptionalContentProperties.DisplayTree.Nodes.Add(ocgPage1Node);

            return document;
        }

        private static PDFFixedDocument CreatePDFA3uDocument(Stream iccInput, Stream ttfInput)
        {
            iccInput.Position = 0;
            ttfInput.Position = 0;

            PDFFixedDocument document = new PDFFixedDocument();
            document.OptionalContentProperties = new PDFOptionalContentProperties();

            // Setup the document by creating a PDF/A output intent, based on a RGB ICC profile, 
            // and document information and metadata
            PDFIccColorSpace icc = new PDFIccColorSpace();
            byte[] profilePayload = new byte[iccInput.Length];
            iccInput.Read(profilePayload, 0, profilePayload.Length);
            icc.IccProfile = profilePayload;
            PDFOutputIntent oi = new PDFOutputIntent();
            oi.Type = PDFOutputIntentType.PDFA1;
            oi.Info = "sRGB IEC61966-2.1";
            oi.OutputConditionIdentifier = "Custom";
            oi.DestinationOutputProfile = icc;
            document.OutputIntents = new PDFOutputIntentCollection();
            document.OutputIntents.Add(oi);

            document.DocumentInformation = new PDFDocumentInformation();
            document.DocumentInformation.Author = "O2 Solutions";
            document.DocumentInformation.Title = "PDF4NET PDF/A-3B/U Demo";
            document.DocumentInformation.Creator = "PDF4NET PDF/A-3B/U Demo Application";
            document.DocumentInformation.Producer = "PDF4NET";
            document.DocumentInformation.Keywords = "pdf/a";
            document.DocumentInformation.Subject = "PDF/A-3B/U Sample produced by PDF4NET";
            document.XmpMetadata = new PDFXmpMetadata();

            PDFPage page = document.Pages.Add();
            page.Rotation = 90;

            // All fonts must be embedded in a PDF/A document.
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Font = new PDFAnsiTrueTypeFont(ttfInput, 24, true);
            sao.Brush = new PDFBrush(new PDFRgbColor(0, 0, 128));

            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Bottom;
            slo.X = page.Width / 2;
            slo.Y = page.Height / 2 - 10;
            page.Canvas.DrawString("PDF4NET", sao, slo);
            slo.Y = page.Height / 2 + 10;
            slo.VerticalAlign = PDFStringVerticalAlign.Top;
            sao.Font.Size = 14;
            page.Canvas.DrawString("This is a sample PDF/A-3B/U document that shows the PDF/A-3B/U capabilities in PDF4NET library", sao, slo);

            // PDF/A-3 documents support optional content and transparency.
            PDFOptionalContentGroup ocgPage1 = new PDFOptionalContentGroup();
            ocgPage1.Name = "Green Rectangle";
            page.Canvas.BeginOptionalContentGroup(ocgPage1);
            page.Canvas.SaveGraphicsState();
            PDFExtendedGraphicState gs = new PDFExtendedGraphicState();
            gs.FillAlpha = 0.8;
            gs.StrokeAlpha = 0.2;
            gs.BlendMode = PDFBlendMode.Luminosity;
            page.Canvas.SetExtendedGraphicState(gs);

            PDFBrush greenBrush = new PDFBrush(PDFRgbColor.DarkGreen);
            PDFPen bluePen = new PDFPen(PDFRgbColor.DarkBlue, 5);
            page.Canvas.DrawRectangle(bluePen, greenBrush, 20, 20, page.Width - 40, page.Height - 40);

            page.Canvas.RestoreGraphicsState();
            page.Canvas.EndOptionalContentGroup();

            // Build the display tree for the optional content, 
            // how its structure and relationships between optional content groups are presented to the user.
            PDFOptionalContentDisplayTreeNode ocgPage1Node = new PDFOptionalContentDisplayTreeNode(ocgPage1);
            document.OptionalContentProperties.DisplayTree.Nodes.Add(ocgPage1Node);

            // PDF/A-3 files also support document attachments.
            // Include the TrueType font as an attachment.
            ttfInput.Position = 0;
            byte[] ttfData = new byte[ttfInput.Length];
            ttfInput.Read(ttfData, 0, ttfData.Length);
            PDFDocumentFileAttachment att = new PDFDocumentFileAttachment(ttfData);
            att.FileName = "verdana.ttf";
            att.Description = "Verdana Regular";
            att.MimeType = "application/octet-stream";
            document.FileAttachments.Add(att);

            return document;
        }
    }
}