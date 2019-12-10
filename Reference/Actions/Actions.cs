using System;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Annotations;
using O2S.Components.PDF4NET.Actions;
using O2S.Components.PDF4NET.Destinations;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Actions sample.
    /// </summary>
    public class Actions
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run()
        {
            // Create a PDF document with 10 pages.
            PDFFixedDocument document = new PDFFixedDocument();
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.Helvetica, 216);
            PDFBrush blackBrush = new PDFBrush();
            for (int i = 0; i < 10; i++)
            {
                PDFPage page = document.Pages.Add();
                page.Canvas.DrawString((i + 1).ToString(), helvetica, blackBrush, 5, 5);
            }

            CreateNamedActions(document, helvetica);

            CreateGoToActions(document, helvetica);

            CreateRemoteGoToActions(document, helvetica);

            CreateLaunchActions(document, helvetica);

            CreateUriActions(document, helvetica);

            CreateJavaScriptActions(document, helvetica);

            CreateDocumentActions(document);

            // Compress the page graphic content.
            for (int i = 0; i < document.Pages.Count; i++)
            {
                document.Pages[i].Canvas.CompressAndClose();
            }

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "actions.pdf") };
            return output;
        }

        private static void CreateNamedActions(PDFFixedDocument document, PDFFont font)
        {
            PDFPen blackPen = new PDFPen(new PDFRgbColor(0, 0, 0), 1);
            PDFBrush blackBrush = new PDFBrush();

            font.Size = 12;
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = blackBrush;
            sao.Font = font;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Middle;

            for (int i = 0; i < document.Pages.Count; i++)
            {
                document.Pages[i].Canvas.DrawString("Named actions:", font, blackBrush, 400, 20);

                /////////////
                // First page
                /////////////
                document.Pages[i].Canvas.DrawRectangle(blackPen, 400, 40, 200, 20);
                slo.X = 500;
                slo.Y = 50;
                document.Pages[i].Canvas.DrawString("Go To First Page", sao, slo);

                // Create a link annotation on top of the widget.
                PDFLinkAnnotation link = new PDFLinkAnnotation();
                document.Pages[i].Annotations.Add(link);
                link.VisualRectangle = new PDFDisplayRectangle(400, 40, 200, 20);

                // Create a named action and attach it to the link.
                PDFNamedAction namedAction = new PDFNamedAction();
                namedAction.NamedAction = PDFActionName.FirstPage;
                link.Action = namedAction;

                /////////////
                // Prev page
                /////////////
                document.Pages[i].Canvas.DrawRectangle(blackPen, 400, 80, 200, 20);
                slo.Y = 90;
                document.Pages[i].Canvas.DrawString("Go To Previous Page", sao, slo);

                // Create a link annotation on top of the widget.
                link = new PDFLinkAnnotation();
                document.Pages[i].Annotations.Add(link);
                link.VisualRectangle = new PDFDisplayRectangle(400, 80, 200, 20);

                // Create a named action and attach it to the link.
                namedAction = new PDFNamedAction();
                namedAction.NamedAction = PDFActionName.PrevPage;
                link.Action = namedAction;

                /////////////
                // Next page
                /////////////
                document.Pages[i].Canvas.DrawRectangle(blackPen, 400, 120, 200, 20);
                slo.Y = 130;
                document.Pages[i].Canvas.DrawString("Go To Next Page", sao, slo);

                // Create a link annotation on top of the widget.
                link = new PDFLinkAnnotation();
                document.Pages[i].Annotations.Add(link);
                link.VisualRectangle = new PDFDisplayRectangle(400, 120, 200, 20);

                // Create a named action and attach it to the link.
                namedAction = new PDFNamedAction();
                namedAction.NamedAction = PDFActionName.NextPage;
                link.Action = namedAction;

                /////////////
                // Last page
                /////////////
                document.Pages[i].Canvas.DrawRectangle(blackPen, 400, 160, 200, 20);
                slo.Y = 170;
                document.Pages[i].Canvas.DrawString("Go To Last Page", sao, slo);

                // Create a link annotation on top of the widget.
                link = new PDFLinkAnnotation();
                document.Pages[i].Annotations.Add(link);
                link.VisualRectangle = new PDFDisplayRectangle(400, 160, 200, 20);

                // Create a named action and attach it to the link.
                namedAction = new PDFNamedAction();
                namedAction.NamedAction = PDFActionName.LastPage;
                link.Action = namedAction;

                /////////////
                // Print document
                /////////////
                document.Pages[i].Canvas.DrawRectangle(blackPen, 400, 200, 200, 20);
                slo.Y = 210;
                document.Pages[i].Canvas.DrawString("Print Document", sao, slo);

                // Create a link annotation on top of the widget.
                link = new PDFLinkAnnotation();
                document.Pages[i].Annotations.Add(link);
                link.VisualRectangle = new PDFDisplayRectangle(400, 200, 200, 20);

                // Create a named action and attach it to the link.
                namedAction = new PDFNamedAction();
                namedAction.NamedAction = PDFActionName.Print;
                link.Action = namedAction;
            }
        }

        private static void CreateGoToActions(PDFFixedDocument document, PDFFont font)
        {
            PDFPen blackPen = new PDFPen(new PDFRgbColor(0, 0, 0), 1);
            PDFBrush blackBrush = new PDFBrush();

            font.Size = 12;
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = blackBrush;
            sao.Font = font;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Middle;

            Random rnd = new Random();
            for (int i = 0; i < document.Pages.Count; i++)
            {
                int destinationPage = rnd.Next(document.Pages.Count);

                document.Pages[i].Canvas.DrawString("Go To actions:", font, blackBrush, 400, 240);

                document.Pages[i].Canvas.DrawRectangle(blackPen, 400, 260, 200, 20);
                slo.X = 500;
                slo.Y = 270;
                document.Pages[i].Canvas.DrawString("Go To page: " + (destinationPage + 1).ToString(), sao, slo);

                // Create a link annotation on top of the widget.
                PDFLinkAnnotation link = new PDFLinkAnnotation();
                document.Pages[i].Annotations.Add(link);
                link.VisualRectangle = new PDFDisplayRectangle(400, 260, 200, 20);

                // Create a GoTo action and attach it to the link.
                PDFPageDirectDestination pageDestination = new PDFPageDirectDestination();
                pageDestination.Page = document.Pages[destinationPage];
                pageDestination.Left = 0;
                pageDestination.Top = 0;
                pageDestination.Zoom = 0; // Keep current zoom
                PDFGoToAction gotoPageAction = new PDFGoToAction();
                gotoPageAction.Destination = pageDestination;
                link.Action = gotoPageAction;
            }
        }

        private static void CreateRemoteGoToActions(PDFFixedDocument document, PDFFont font)
        {
            PDFPen blackPen = new PDFPen(new PDFRgbColor(0, 0, 0), 1);
            PDFBrush blackBrush = new PDFBrush();

            font.Size = 12;
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = blackBrush;
            sao.Font = font;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Middle;

            Random rnd = new Random();
            for (int i = 0; i < document.Pages.Count; i++)
            {
                int destinationPage = rnd.Next(document.Pages.Count);

                document.Pages[i].Canvas.DrawString("Go To Remote actions:", font, blackBrush, 400, 300);

                document.Pages[i].Canvas.DrawRectangle(blackPen, 400, 320, 200, 20);
                slo.X = 500;
                slo.Y = 330;
                document.Pages[i].Canvas.DrawString("Go To page " + (destinationPage + 1).ToString() + " in sample.pdf", sao, slo);

                // Create a link annotation on top of the widget.
                PDFLinkAnnotation link = new PDFLinkAnnotation();
                document.Pages[i].Annotations.Add(link);
                link.VisualRectangle = new PDFDisplayRectangle(400, 320, 200, 20);

                // Create a GoToR action and attach it to the link.
                PDFPageNumberDestination pageDestination = new PDFPageNumberDestination();
                pageDestination.PageNumber = destinationPage;
                pageDestination.Left = 0;
                pageDestination.Top = 792;
                pageDestination.Zoom = 0; // Keep current zoom
                PDFRemoteGoToAction remoteGoToAction = new PDFRemoteGoToAction();
                remoteGoToAction.FileName = "sample.pdf";
                remoteGoToAction.Destination = pageDestination;
                link.Action = remoteGoToAction;
            }
        }

        private static void CreateLaunchActions(PDFFixedDocument document, PDFFont font)
        {
            PDFPen blackPen = new PDFPen(new PDFRgbColor(0, 0, 0), 1);
            PDFBrush blackBrush = new PDFBrush();

            font.Size = 12;
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = blackBrush;
            sao.Font = font;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Middle;

            for (int i = 0; i < document.Pages.Count; i++)
            {
                document.Pages[i].Canvas.DrawString("Launch actions:", font, blackBrush, 400, 360);

                document.Pages[i].Canvas.DrawRectangle(blackPen, 400, 380, 200, 20);
                slo.X = 500;
                slo.Y = 390;
                document.Pages[i].Canvas.DrawString("Launch samples explorer", sao, slo);

                // Create a link annotation on top of the widget.
                PDFLinkAnnotation link = new PDFLinkAnnotation();
                document.Pages[i].Annotations.Add(link);
                link.VisualRectangle = new PDFDisplayRectangle(400, 380, 200, 20);

                // Create a launch action and attach it to the link.
                PDFLaunchAction launchAction = new PDFLaunchAction();
                launchAction.FileName = "O2S.Components.PDF4NET.SamplesExplorer.Win.exe";
                link.Action = launchAction;
            }
        }

        private static void CreateUriActions(PDFFixedDocument document, PDFFont font)
        {
            PDFPen blackPen = new PDFPen(new PDFRgbColor(0, 0, 0), 1);
            PDFBrush blackBrush = new PDFBrush();

            font.Size = 12;
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = blackBrush;
            sao.Font = font;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Middle;

            for (int i = 0; i < document.Pages.Count; i++)
            {
                document.Pages[i].Canvas.DrawString("Uri actions:", font, blackBrush, 400, 420);

                document.Pages[i].Canvas.DrawRectangle(blackPen, 400, 440, 200, 20);
                slo.X = 500;
                slo.Y = 450;
                document.Pages[i].Canvas.DrawString("Go to o2sol.com", sao, slo);

                // Create a link annotation on top of the widget.
                PDFLinkAnnotation link = new PDFLinkAnnotation();
                document.Pages[i].Annotations.Add(link);
                link.VisualRectangle = new PDFDisplayRectangle(400, 440, 200, 20);

                // Create an uri action and attach it to the link.
                PDFUriAction uriAction = new PDFUriAction();
                uriAction.URI = "http://www.o2sol.com";
                link.Action = uriAction;
            }
        }

        private static void CreateJavaScriptActions(PDFFixedDocument document, PDFFont font)
        {
            PDFPen blackPen = new PDFPen(new PDFRgbColor(0, 0, 0), 1);
            PDFBrush blackBrush = new PDFBrush();

            font.Size = 12;
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = blackBrush;
            sao.Font = font;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Middle;

            for (int i = 0; i < document.Pages.Count; i++)
            {
                document.Pages[i].Canvas.DrawString("JavaScript actions:", font, blackBrush, 400, 480);

                document.Pages[i].Canvas.DrawRectangle(blackPen, 400, 500, 200, 20);
                slo.X = 500;
                slo.Y = 510;
                document.Pages[i].Canvas.DrawString("Click me", sao, slo);

                // Create a link annotation on top of the widget.
                PDFLinkAnnotation link = new PDFLinkAnnotation();
                document.Pages[i].Annotations.Add(link);
                link.VisualRectangle = new PDFDisplayRectangle(400, 500, 200, 20);

                // Create a Javascript action and attach it to the link.
                PDFJavaScriptAction jsAction = new PDFJavaScriptAction();
                jsAction.Script = "app.alert({cMsg: \"JavaScript action: you are now on page " + (i + 1) + "\", cTitle: \"O2S.Components.PDF4NET Actions Sample\"});";
                link.Action = jsAction;
            }
        }

        private static void CreateDocumentActions(PDFFixedDocument document)
        {
            // Create an action that will open the document at the last page with 200% zoom.
            PDFPageDirectDestination pageDestination = new PDFPageDirectDestination();
            pageDestination.Page = document.Pages[document.Pages.Count - 1];
            pageDestination.Zoom = 200;
            pageDestination.Top = 0;
            pageDestination.Left = 0;
            PDFGoToAction openAction = new PDFGoToAction();
            openAction.Destination = pageDestination;
            document.OpenAction = openAction;

            // Create an action that is executed when the document is closed.
            PDFJavaScriptAction jsCloseAction = new PDFJavaScriptAction();
            jsCloseAction.Script = "app.alert({cMsg: \"The document will close now.\", cTitle: \"O2S.Components.PDF4NET Actions Sample\"});";
            document.BeforeCloseAction = jsCloseAction;

            // Create an action that is executed before the document is printed.
            PDFJavaScriptAction jsBeforePrintAction = new PDFJavaScriptAction();
            jsBeforePrintAction.Script = "app.alert({cMsg: \"The document will be printed.\", cTitle: \"O2S.Components.PDF4NET Actions Sample\"});";
            document.BeforePrintAction = jsBeforePrintAction;

            // Create an action that is executed after the document is printed.
            PDFJavaScriptAction jsAfterPrintAction = new PDFJavaScriptAction();
            jsAfterPrintAction.Script = "app.alert({cMsg: \"The document has been printed.\", cTitle: \"O2S.Components.PDF4NET Actions Sample\"});";
            document.AfterPrintAction = jsAfterPrintAction;
        }
    }
}