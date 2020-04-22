using System;
using System.Drawing;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Annotations;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.Fonts;
//using O2S.Components.PDF4NET.Graphics.Shapes;

namespace O2S.Samples.PDF4NET.Annotations
{
    /// <summary>
    /// This sample shows all annotations that can be created with PDF4NET.
    /// </summary>
    class Annotations
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Create the pdf document
            //PDF4NET v5: PDFDocument doc = new PDFDocument();
            PDFFixedDocument doc = new PDFFixedDocument();

            // Create one page
            //PDF4NET v5: PDFPage page = doc.AddPage();
            PDFPage page = doc.Pages.Add();

            PDFBrush blackBrush = new PDFBrush(new PDFRgbColor(0, 0, 0));
            //PDF4NET v5: PDFFont fontSection = new PDFFont(PDFFontFace.Helvetica, 10);
            PDFStandardFont fontSection = new PDFStandardFont(PDFStandardFontFace.Helvetica, 10);
            fontSection.Bold = true;
            //PDF4NET v5: PDFFont fontText = new PDFFont(PDFFontFace.Helvetica, 8);
            PDFStandardFont fontText = new PDFStandardFont(PDFStandardFontFace.Helvetica, 8);

            //PDF4NET v5: page.Canvas.DrawText("Text annotations", fontSection, null, blackBrush, 20, 45, 0, PDFTextAlign.BottomLeft);
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions() { X = 20, Y = 45, VerticalAlign = PDFStringVerticalAlign.Bottom };
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions() { Font = fontSection, Brush = blackBrush };
            page.Canvas.DrawString("Text annotations", sao, slo);

            // Create all available text annotations
            //PDF4NET v5: PDFTextAnnotation ta = new PDFTextAnnotation("Comment", "Comment annotation");
            PDFTextAnnotation ta = new PDFTextAnnotation() { Author= "Comment", Contents= "Comment annotation" };
            page.Annotations.Add(ta);
            ta.Icon = PDFTextAnnotationIcon.Comment;
            //PDF4NET v5: ta.Rectangle = new RectangleF(20, 60, 20, 20);
            ta.Location = new PDFPoint(20, 60);
            //PDF4NET v5: page.Canvas.DrawText("Comment", fontText, null, blackBrush, 20, 80, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Comment", fontText, blackBrush, 20, 80);

            //PDF4NET v5: ta = new PDFTextAnnotation("Help", "Help annotation");
            ta = new PDFTextAnnotation() { Author = "Help", Contents = "Help annotation" };
            page.Annotations.Add(ta);
            ta.Icon = PDFTextAnnotationIcon.Help;
            //PDF4NET v5: ta.Rectangle = new RectangleF(100, 60, 20, 20);
            ta.Location = new PDFPoint(100, 60);
            //PDF4NET v5: page.Canvas.DrawText("Help", fontText, null, blackBrush, 100, 80, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Help", fontText, blackBrush, 100, 80);

            //PDF4NET v5: ta = new PDFTextAnnotation("Insert", "Insert annotation");
            ta = new PDFTextAnnotation() { Author = "Insert", Contents = "Insert annotation" };
            page.Annotations.Add(ta);
            ta.Icon = PDFTextAnnotationIcon.Insert;
            //PDF4NET v5: ta.Rectangle = new RectangleF(180, 60, 20, 20);
            ta.Location = new PDFPoint(180, 60);
            //PDF4NET v5: page.Canvas.DrawText("Insert", fontText, null, blackBrush, 180, 80, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Insert", fontText, blackBrush, 180, 80);

            //PDF4NET v5: ta = new PDFTextAnnotation("Key", "Key annotation");
            ta = new PDFTextAnnotation() { Author = "Key", Contents = "Key annotation" };
            page.Annotations.Add(ta);
            ta.Icon = PDFTextAnnotationIcon.Key;
            //PDF4NET v5: ta.Rectangle = new RectangleF(260, 60, 20, 20);
            ta.Location = new PDFPoint(260, 60);
            //PDF4NET v5: page.Canvas.DrawText("Key", fontText, null, blackBrush, 260, 80, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Key", fontText, blackBrush, 260, 80);

            //PDF4NET v5: ta = new PDFTextAnnotation("New paragraph", "New paragraph annotation");
            ta = new PDFTextAnnotation() { Author = "New paragraph", Contents = "New paragraph annotation" };
            page.Annotations.Add(ta);
            ta.Icon = PDFTextAnnotationIcon.NewParagraph;
            //PDF4NET v5: ta.Rectangle = new RectangleF(340, 60, 20, 20);
            ta.Location = new PDFPoint(340, 60);
            //PDF4NET v5: page.Canvas.DrawText("New paragraph", fontText, null, blackBrush, 340, 80, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("New paragraph", fontText, blackBrush, 340, 80);

            //PDF4NET v5: ta = new PDFTextAnnotation("Note", "Note annotation");
            ta = new PDFTextAnnotation() { Author = "Note", Contents = "Note annotation" };
            page.Annotations.Add(ta);
            ta.Icon = PDFTextAnnotationIcon.Note;
            //PDF4NET v5: ta.Rectangle = new RectangleF(420, 60, 20, 20);
            ta.Location = new PDFPoint(420, 60);
            //PDF4NET v5: page.Canvas.DrawText("Note", fontText, null, blackBrush, 420, 80, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Note", fontText, blackBrush, 420, 80);

            //PDF4NET v5: ta = new PDFTextAnnotation("Paragraph", "Paragraph annotation");
            ta = new PDFTextAnnotation() { Author = "Paragraph", Contents = "Paragraph annotation" };
            page.Annotations.Add(ta);
            ta.Icon = PDFTextAnnotationIcon.Paragraph;
            //PDF4NET v5: ta.Rectangle = new RectangleF(500, 60, 20, 20);
            ta.Location = new PDFPoint(500, 60);
            //PDF4NET v5: page.Canvas.DrawText("Paragraph", fontText, null, blackBrush, 500, 80, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Paragraph", fontText, blackBrush, 500, 80);

            // Rubber stamp annotations

            //PDF4NET v5: page.Canvas.DrawText("Rubber stamp annotations", fontSection, null, blackBrush, 20, 120, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Rubber stamp annotations", fontSection, blackBrush, 20, 120);

            // Create all available rubber stamp annotations
            //PDF4NET v5: PDFRubberStampAnnotation rsa = new PDFRubberStampAnnotation("Approved", "Approved annotation");
            PDFRubberStampAnnotation rsa = new PDFRubberStampAnnotation() { Author = "Approved", Contents = "Approved annotation" };
            page.Annotations.Add(rsa);
            //PDF4NET v5: rsa.Icon = PDFRubberStampAnnotationIcon.Approved;
            rsa.StampName = PDFRubberStampAnnotationName.Approved;
            //PDF4NET v5: rsa.Rectangle = new RectangleF(20, 140, 100, 30);
            rsa.DisplayRectangle = new PDFDisplayRectangle(20, 140, 100, 30);
            rsa.Opacity = 50;
            //PDF4NET v5: page.Canvas.DrawText("Approved", fontText, null, blackBrush, 20, 180, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Approved", fontText, blackBrush, 20, 180);

            //PDF4NET v5: rsa = new PDFRubberStampAnnotation("As Is", "As Is annotation");
            rsa = new PDFRubberStampAnnotation() { Author = "As Is", Contents = "As Is annotation" };
            page.Annotations.Add(rsa);
            //PDF4NET v5: rsa.Icon = PDFRubberStampAnnotationIcon.AsIs;
            rsa.StampName = PDFRubberStampAnnotationName.AsIs;
            //PDF4NET v5: rsa.Rectangle = new RectangleF(120, 140, 100, 30);
            rsa.DisplayRectangle = new PDFDisplayRectangle(120, 140, 100, 30);
            //PDF4NET v5: page.Canvas.DrawText("As Is", fontText, null, blackBrush, 120, 180, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("As Is", fontText, blackBrush, 120, 180);

            //PDF4NET v5: rsa = new PDFRubberStampAnnotation("Confidential", "Confidential annotation");
            rsa = new PDFRubberStampAnnotation() { Author = "Confidential", Contents = "Confidential annotation" };
            page.Annotations.Add(rsa);
            //PDF4NET v5: rsa.Icon = PDFRubberStampAnnotationIcon.Confidential;
            rsa.StampName = PDFRubberStampAnnotationName.Confidential;
            //PDF4NET v5: rsa.Rectangle = new RectangleF(220, 140, 100, 30);
            rsa.DisplayRectangle = new PDFDisplayRectangle(220, 140, 100, 30);
            //PDF4NET v5: page.Canvas.DrawText("Confidential", fontText, null, blackBrush, 220, 180, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Confidential", fontText, blackBrush, 220, 180);

            //PDF4NET v5: rsa = new PDFRubberStampAnnotation("Departmental", "Departmental annotation");
            rsa = new PDFRubberStampAnnotation() { Author = "Departmental", Contents = "Departmental annotation" };
            page.Annotations.Add(rsa);
            //PDF4NET v5: rsa.Icon = PDFRubberStampAnnotationIcon.Departmental;
            rsa.StampName = PDFRubberStampAnnotationName.Departmental;
            //PDF4NET v5: rsa.Rectangle = new RectangleF(320, 140, 100, 30);
            rsa.DisplayRectangle = new PDFDisplayRectangle(320, 140, 100, 30);
            //PDF4NET v5: page.Canvas.DrawText("Departmental", fontText, null, blackBrush, 320, 180, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Departmental", fontText, blackBrush, 320, 180);

            //PDF4NET v5: rsa = new PDFRubberStampAnnotation("Draft", "Draft annotation");
            rsa = new PDFRubberStampAnnotation() { Author = "Draft", Contents = "Draft annotation" };
            page.Annotations.Add(rsa);
            //PDF4NET v5: rsa.Icon = PDFRubberStampAnnotationIcon.Draft;
            rsa.StampName = PDFRubberStampAnnotationName.Draft;
            //PDF4NET v5: rsa.Rectangle = new RectangleF(420, 140, 100, 30);
            rsa.DisplayRectangle = new PDFDisplayRectangle(420, 140, 100, 30);
            //PDF4NET v5: page.Canvas.DrawText("Draft", fontText, null, blackBrush, 420, 180, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Draft", fontText, blackBrush, 420, 180);

            //PDF4NET v5: rsa = new PDFRubberStampAnnotation("Experimental", "Experimental annotation");
            rsa = new PDFRubberStampAnnotation() { Author = "Experimental", Contents = "Experimental annotation" };
            page.Annotations.Add(rsa);
            //PDF4NET v5: rsa.Icon = PDFRubberStampAnnotationIcon.Experimental;
            rsa.StampName = PDFRubberStampAnnotationName.Experimental;
            //PDF4NET v5: rsa.Rectangle = new RectangleF(520, 140, 100, 30);
            rsa.DisplayRectangle = new PDFDisplayRectangle(520, 140, 100, 30);
            //PDF4NET v5: page.Canvas.DrawText("Experimental", fontText, null, blackBrush, 520, 180, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Experimental", fontText, blackBrush, 520, 180);

            //PDF4NET v5: rsa = new PDFRubberStampAnnotation("Expired", "Expired annotation");
            rsa = new PDFRubberStampAnnotation() { Author = "Expired", Contents = "Expired annotation" };
            page.Annotations.Add(rsa);
            //PDF4NET v5: rsa.Icon = PDFRubberStampAnnotationIcon.Expired;
            rsa.StampName = PDFRubberStampAnnotationName.Expired;
            //PDF4NET v5: rsa.Rectangle = new RectangleF(20, 200, 100, 30);
            rsa.DisplayRectangle = new PDFDisplayRectangle(20, 200, 100, 30);
            //PDF4NET v5: page.Canvas.DrawText("Expired", fontText, null, blackBrush, 20, 240, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Expired", fontText, blackBrush, 20, 240);

            //PDF4NET v5: rsa = new PDFRubberStampAnnotation("Final", "Final annotation");
            rsa = new PDFRubberStampAnnotation() { Author = "Final", Contents = "Final annotation" };
            page.Annotations.Add(rsa);
            //PDF4NET v5: rsa.Icon = PDFRubberStampAnnotationIcon.Final;
            rsa.StampName = PDFRubberStampAnnotationName.Final;
            //PDF4NET v5: rsa.Rectangle = new RectangleF(120, 200, 100, 30);
            rsa.DisplayRectangle = new PDFDisplayRectangle(120, 200, 100, 30);
            //PDF4NET v5: page.Canvas.DrawText("Final", fontText, null, blackBrush, 120, 240, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Final", fontText, blackBrush, 120, 240);

            //PDF4NET v5: rsa = new PDFRubberStampAnnotation("ForComment", "ForComment annotation");
            rsa = new PDFRubberStampAnnotation() { Author = "ForComment", Contents = "ForComment annotation" };
            page.Annotations.Add(rsa);
            //PDF4NET v5: rsa.Icon = PDFRubberStampAnnotationIcon.ForComment;
            rsa.StampName = PDFRubberStampAnnotationName.ForComment;
            //PDF4NET v5: rsa.Rectangle = new RectangleF(220, 200, 100, 30);
            rsa.DisplayRectangle = new PDFDisplayRectangle(220, 200, 100, 30);
            //PDF4NET v5: page.Canvas.DrawText("ForComment", fontText, null, blackBrush, 220, 240, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("ForComment", fontText, blackBrush, 220, 240);

            //PDF4NET v5: rsa = new PDFRubberStampAnnotation("ForPublicRelease", "ForPublicRelease annotation");
            rsa = new PDFRubberStampAnnotation() { Author = "ForPublicRelease", Contents = "ForPublicRelease annotation" };
            page.Annotations.Add(rsa);
            //PDF4NET v5: rsa.Icon = PDFRubberStampAnnotationIcon.ForPublicRelease;
            rsa.StampName = PDFRubberStampAnnotationName.ForPublicRelease;
            //PDF4NET v5: rsa.Rectangle = new RectangleF(320, 200, 100, 30);
            rsa.DisplayRectangle = new PDFDisplayRectangle(320, 200, 100, 30);
            //PDF4NET v5: page.Canvas.DrawText("ForPublicRelease", fontText, null, blackBrush, 320, 240, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("ForPublicRelease", fontText, blackBrush, 320, 240);

            //PDF4NET v5: rsa = new PDFRubberStampAnnotation("NotApproved", "NotApproved annotation");
            rsa = new PDFRubberStampAnnotation() { Author = "NotApproved", Contents = "NotApproved annotation" };
            page.Annotations.Add(rsa);
            //PDF4NET v5: rsa.Icon = PDFRubberStampAnnotationIcon.NotApproved;
            rsa.StampName = PDFRubberStampAnnotationName.NotApproved;
            //PDF4NET v5: rsa.Rectangle = new RectangleF(420, 200, 100, 30);
            rsa.DisplayRectangle = new PDFDisplayRectangle(420, 200, 100, 30);
            //PDF4NET v5: page.Canvas.DrawText("NotApproved", fontText, null, blackBrush, 420, 240, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("NotApproved", fontText, blackBrush, 420, 240);

            //PDF4NET v5: rsa = new PDFRubberStampAnnotation("NotForPublicRelease", "NotForPublicRelease annotation");
            rsa = new PDFRubberStampAnnotation() { Author = "NotForPublicRelease", Contents = "NotForPublicRelease annotation" };
            page.Annotations.Add(rsa);
            //PDF4NET v5: rsa.Icon = PDFRubberStampAnnotationIcon.NotForPublicRelease;
            rsa.StampName = PDFRubberStampAnnotationName.NotForPublicRelease;
            //PDF4NET v5: rsa.Rectangle = new RectangleF(520, 200, 100, 30);
            rsa.DisplayRectangle = new PDFDisplayRectangle(520, 200, 100, 30);
            //PDF4NET v5: page.Canvas.DrawText("NotForPublicRelease", fontText, null, blackBrush, 520, 240, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("NotForPublicRelease", fontText, blackBrush, 520, 240);

            //PDF4NET v5: rsa = new PDFRubberStampAnnotation("Sold", "Sold annotation");
            rsa = new PDFRubberStampAnnotation() { Author = "Sold", Contents = "Sold annotation" };
            page.Annotations.Add(rsa);
            //PDF4NET v5: rsa.Icon = PDFRubberStampAnnotationIcon.Sold;
            rsa.StampName = PDFRubberStampAnnotationName.Sold;
            //PDF4NET v5: rsa.Rectangle = new RectangleF(20, 260, 100, 30);
            rsa.DisplayRectangle = new PDFDisplayRectangle(20, 260, 100, 30);
            //PDF4NET v5: page.Canvas.DrawText("Sold", fontText, null, blackBrush, 20, 300, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Sold", fontText, blackBrush, 20, 300);

            //PDF4NET v5: rsa = new PDFRubberStampAnnotation("TopSecret", "TopSecret annotation");
            rsa = new PDFRubberStampAnnotation() { Author = "TopSecret", Contents = "TopSecret annotation" };
            page.Annotations.Add(rsa);
            //PDF4NET v5: rsa.Icon = PDFRubberStampAnnotationIcon.TopSecret;
            rsa.StampName = PDFRubberStampAnnotationName.TopSecret;
            //PDF4NET v5: rsa.Rectangle = new RectangleF(120, 260, 100, 30);
            rsa.DisplayRectangle = new PDFDisplayRectangle(120, 260, 100, 30);
            //PDF4NET v5: page.Canvas.DrawText("TopSecret", fontText, null, blackBrush, 120, 300, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("TopSecret", fontText, blackBrush, 120, 300);

            // Line annotations

            //PDF4NET v5: page.Canvas.DrawText("Line annotations", fontSection, null, blackBrush, 20, 350, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Line annotations", fontSection, blackBrush, 20, 350);
            //PDF4NET v5: PDFLineAnnotation la = new PDFLineAnnotation("Line", "Line annotation");
            PDFLineAnnotation la = new PDFLineAnnotation() { Author = "Line", Contents = "Line annotation" };
            page.Annotations.Add(la);
            //PDF4NET v5: la.BeginLineStyle = PDFLineEndingStyle.Circle;
            la.StartLineSymbol = PDFLineEndingStyle.Circle;
            //PDF4NET v5: la.EndLineStyle = PDFLineEndingStyle.OpenArrow;
            la.EndLineSymbol = PDFLineEndingStyle.OpenArrow;
            //PDF4NET v5: la.LineDirection = PDFLineDirection.TopLeftToBottomRight;

            //PDF4NET v5: la.Rectangle = new RectangleF(20, 370, 150, 30);
            la.StartPoint = new PDFPoint(20, 370);
            la.EndPoint = new PDFPoint(170, 400);
            //PDF4NET v5: la.Border = new PDFAnnotationBorder(1, PDFBorderStyle.Solid);
            la.LineWidth = 1;
            //PDF4NET v5: la.Color = new PDFRgbColor(Color.Red);
            la.LineColor = PDFRgbColor.Red;
            //PDF4NET v5: la.InteriorColor = new PDFRgbColor(Color.CornflowerBlue);
            la.InteriorColor = PDFRgbColor.CornflowerBlue;
            //PDF4NET v5: page.Canvas.DrawText("Line annotation with a circle and open arrow", fontText, null, blackBrush, 20, 420, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Line annotation with a circle and open arrow", fontText, blackBrush, 20, 420);

            // File attachment annotations

            //PDF4NET v5: page.Canvas.DrawText("File attachment annotations", fontSection, null, blackBrush, 20, 450, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("File attachment annotations", fontSection, blackBrush, 20, 450);
            // Create all available file attachment annotations
            //PDF4NET v5: PDFFileAttachmentAnnotation faa = new PDFFileAttachmentAnnotation("Graph", "Graph icon");
            PDFFileAttachmentAnnotation faa = new PDFFileAttachmentAnnotation() { Author = "Graph", Contents = "Graph icon" };
            page.Annotations.Add(faa);
            faa.Icon = PDFFileAttachmentAnnotationIcon.Graph;
            //PDF4NET v5: faa.Rectangle = new RectangleF(20, 470, 20, 20);
            faa.Location = new PDFPoint(20, 470);
            faa.FileName = "sample.pdf";
            faa.Payload = File.ReadAllBytes("..\\..\\..\\..\\..\\SupportFiles\\sample.pdf");
            //PDF4NET v5: page.Canvas.DrawText("Graph", fontText, null, blackBrush, 20, 500, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Graph", fontText, blackBrush, 20, 500);

            //PDF4NET v5: faa = new PDFFileAttachmentAnnotation("Paperclip", "Paperclip icon");
            faa = new PDFFileAttachmentAnnotation() { Author = "Paperclip", Contents = "Paperclip icon" };
            page.Annotations.Add(faa);
            faa.Icon = PDFFileAttachmentAnnotationIcon.Paperclip;
            //PDF4NET v5: faa.Rectangle = new RectangleF(100, 470, 20, 20);
            faa.Location = new PDFPoint(100, 470);
            faa.FileName = "sample.pdf";
            faa.Payload = File.ReadAllBytes("..\\..\\..\\..\\..\\SupportFiles\\sample.pdf");
            //PDF4NET v5: page.Canvas.DrawText("Paperclip", fontText, null, blackBrush, 100, 500, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Paperclip", fontText, blackBrush, 100, 500);

            //PDF4NET v5: faa = new PDFFileAttachmentAnnotation("PushPin", "PushPin icon");
            faa = new PDFFileAttachmentAnnotation() { Author = "PushPin", Contents = "PushPin icon" };
            page.Annotations.Add(faa);
            faa.Icon = PDFFileAttachmentAnnotationIcon.PushPin;
            //PDF4NET v5: faa.Rectangle = new RectangleF(180, 470, 20, 20);
            faa.Location = new PDFPoint(180, 470);
            faa.FileName = "sample.pdf";
            faa.Payload = File.ReadAllBytes("..\\..\\..\\..\\..\\SupportFiles\\sample.pdf");
            //PDF4NET v5: page.Canvas.DrawText("PushPin", fontText, null, blackBrush, 180, 500, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("PushPin", fontText, blackBrush, 180, 500);

            //PDF4NET v5: faa = new PDFFileAttachmentAnnotation("Tag", "Tag icon");
            faa = new PDFFileAttachmentAnnotation() { Author = "Tag", Contents = "Tag icon" };
            page.Annotations.Add(faa);
            faa.Icon = PDFFileAttachmentAnnotationIcon.Tag;
            //PDF4NET v5: faa.Rectangle = new RectangleF(260, 470, 20, 20);
            faa.Location = new PDFPoint(260, 470);
            faa.FileName = "sample.pdf";
            faa.Payload = File.ReadAllBytes("..\\..\\..\\..\\..\\SupportFiles\\sample.pdf");
            //PDF4NET v5: page.Canvas.DrawText("Graph", fontText, null, blackBrush, 260, 500, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Graph", fontText, blackBrush, 260, 500);

            // Highlight annotation

            //PDF4NET v5: page.Canvas.DrawText("Markup annotation - this text will be highlighted", fontSection, null, blackBrush, 20, 610);
            page.Canvas.DrawString("Markup annotation - this text will be highlighted", fontSection, blackBrush, 20, 610);
            //PDF4NET v5: PDFHighlightAnnotation ha = new PDFHighlightAnnotation("Markup annotation", "Markup annotation with highlight style");
            PDFTextMarkupAnnotation tma = new PDFTextMarkupAnnotation() { Author = "Markup annotation", Contents = "Markup annotation with highlight style" };
            tma.TextMarkupType = PDFTextMarkupAnnotationType.Highlight;
            page.Annotations.Add(tma);
            //PDF4NET v5: ha.Rectangle = new RectangleF(100, 610, 100, 10);
            tma.DisplayRectangle = new PDFDisplayRectangle(100, 610, 100, 10);
            tma.TextMarkupColor = new PDFRgbColor(255, 255, 0);

            // Square and circle annotations

            //PDF4NET v5: page.Canvas.DrawText("Square and circle annotations", fontSection, null, blackBrush, 20, 650);
            page.Canvas.DrawString("Square and circle annotations", fontSection, blackBrush, 20, 650);
            //PDF4NET v5: PDFEllipseAnnotation ea = new PDFEllipseAnnotation("Ellipse annotation", "An ellipse annotation");
            PDFCircleAnnotation ca = new PDFCircleAnnotation() { Author = "Ellipse annotation", Contents = "An ellipse annotation" };
            page.Annotations.Add(ca);
            //PDF4NET v5: ea.Rectangle = new RectangleF(20, 670, 150, 75);
            ca.DisplayRectangle = new PDFDisplayRectangle(20, 670, 150, 75);
            //PDF4NET v5: ea.Color = new PDFRgbColor(255, 255, 0);
            ca.BorderColor = new PDFRgbColor(255, 255, 0);
            ca.InteriorColor = new PDFRgbColor(0, 255, 0);

            //PDF4NET v5: PDFRectangleAnnotation ra = new PDFRectangleAnnotation("Rectangle annotation", "A rectangle annotation");
            PDFSquareAnnotation sa = new PDFSquareAnnotation() { Author = "Rectangle annotation", Contents = "A rectangle annotation" };
            page.Annotations.Add(sa);
            //PDF4NET v5: ra.Rectangle = new RectangleF(200, 670, 150, 75);
            sa.DisplayRectangle = new PDFDisplayRectangle(200, 670, 150, 75);
            //PDF4NET v5: ra.Color = new PDFRgbColor(255, 64, 0);
            sa.BorderColor = new PDFRgbColor(255, 64, 0);
            sa.InteriorColor = new PDFRgbColor(64, 0, 255);

            // Create 2nd page
            //PDF4NET v5: page = doc.AddPage();
            page = doc.Pages.Add();

            //PDF4NET v5: page.Canvas.DrawText("Annotations with custom appearance", fontSection, null, blackBrush, 20, 45, 0, PDFTextAlign.BottomLeft);
            slo.Y = 45;
            page.Canvas.DrawString("Annotations with custom appearance", sao, slo);

            //PDF4NET v5: page.Canvas.DrawText("a. Annotations with image appearance", fontSection, null, blackBrush, 20, 60, 0, PDFTextAlign.BottomLeft);
            slo.Y = 60;
            page.Canvas.DrawString("a. Annotations with image appearance", sao, slo);

            //PDF4NET v5: PDFRubberStampAnnotation isa = new PDFRubberStampAnnotation("ImageAppearance", "Annotation with image appearance.");
            PDFRubberStampAnnotation isa = new PDFRubberStampAnnotation() { Author = "ImageAppearance", Contents = "Annotation with image appearance." };
            page.Annotations.Add(isa);
            //PDF4NET v5: isa.Rectangle = new RectangleF(20, 70, 200, 100);
            isa.DisplayRectangle = new PDFDisplayRectangle(20, 70, 200, 100);
            //PDF4NET v5: Bitmap img = new Bitmap("..\\SupportFiles\\auto1.jpg");
            //PDF4NET v5: isa.Appearance = new PDFImageAppearance(img);
            //PDF4NET v5: img.Dispose();

            FileStream imgStream = File.OpenRead("..\\..\\..\\..\\..\\SupportFiles\\auto1.jpg");
            PDFJpegImage img = new PDFJpegImage(imgStream);
            imgStream.Dispose();
            PDFAnnotationAppearance ia = new PDFAnnotationAppearance(isa.DisplayRectangle.Width, isa.DisplayRectangle.Height);
            ia.Canvas.DrawImage(img, 0, 0, ia.Width, ia.Height);
            isa.NormalAppearance = ia;

            //PDF4NET v5: page.Canvas.DrawText("Image appearance", fontText, null, blackBrush, 20, 175, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Image appearance", fontText, blackBrush, 20, 175);

            //PDF4NET v5: page.Canvas.DrawText("b. Annotations with owner draw appearance", fontSection, null, blackBrush, 20, 200, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("b. Annotations with owner draw appearance", fontSection, blackBrush, 20, 200);
            //PDF4NET v5: PDFRubberStampAnnotation odsa = new PDFRubberStampAnnotation("OwnerDrawAppearance", "Annotation with owner draw appearance.");
            PDFRubberStampAnnotation odsa = new PDFRubberStampAnnotation() { Author = "OwnerDrawAppearance", Contents = "Annotation with owner draw appearance." };
            page.Annotations.Add(odsa);
            //PDF4NET v5: odsa.Rectangle = new RectangleF(20, 220, 200, 100);
            odsa.DisplayRectangle = new PDFDisplayRectangle(20, 220, 200, 100);
            //PDF4NET v5: odsa.Appearance = new PDFAnnotationAppearance();
            //PDF4NET v5: odsa.Appearance.Width = odsa.Rectangle.Width;
            //PDF4NET v5: odsa.Appearance.Height = odsa.Rectangle.Height;
            odsa.NormalAppearance = new PDFAnnotationAppearance(odsa.DisplayRectangle.Width, odsa.DisplayRectangle.Height);
            PDFBrush redBrush = new PDFBrush(new PDFRgbColor(192, 0, 0));
            //PDF4NET v5: odsa.Appearance.Canvas.DrawRoundRectangle(redBrush, 0, 0, odsa.Rectangle.Width, odsa.Rectangle.Height, 40, 40);
            odsa.NormalAppearance.Canvas.DrawRoundRectangle(redBrush, 0, 0, odsa.DisplayRectangle.Width, odsa.DisplayRectangle.Height, 40, 40);
            PDFBrush blueBrush = new PDFBrush(new PDFRgbColor(0, 0, 128));
            //PDF4NET v5: odsa.Appearance.Canvas.DrawEllipse(blueBrush, (odsa.Rectangle.Width - odsa.Rectangle.Height) / 2, 0, odsa.Rectangle.Height, odsa.Rectangle.Height);
            odsa.NormalAppearance.Canvas.DrawEllipse(blueBrush, 
                (odsa.DisplayRectangle.Width - odsa.DisplayRectangle.Height) / 2, 0, odsa.DisplayRectangle.Height, odsa.DisplayRectangle.Height);
            //PDF4NET v5: page.Canvas.DrawText("Owner draw appearance", fontText, null, blackBrush, 20, 325, 0, PDFTextAlign.TopLeft);
            page.Canvas.DrawString("Owner draw appearance", fontText, blackBrush, 20, 325);

            // Save the document to disk
            doc.Save("Sample_Annotations.pdf");
        }
    }
}
