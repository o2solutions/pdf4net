using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Content;
using O2S.Components.PDF4NET.Actions;
using O2S.Components.PDF4NET.Destinations;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Outlines sample.
    /// </summary>
    public class Outlines
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run()
        {
            PDFFixedDocument document = new PDFFixedDocument();
            document.DisplayMode = PDFDisplayMode.UseOutlines;

            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.Helvetica, 216);
            PDFBrush blackBrush = new PDFBrush();
            for (int i = 0; i < 10; i++)
            {
                PDFPage page = document.Pages.Add();
                page.Canvas.DrawString((i + 1).ToString(), helvetica, blackBrush, 50, 50);
            }

            PDFOutlineItem root = new PDFOutlineItem();
            root.Title = "Contents";
            root.VisualStyle = PDFOutlineItemVisualStyle.Bold;
            root.Color = new PDFRgbColor(255, 0, 0);
            document.Outline.Add(root);

            for (int i = 0; i < document.Pages.Count; i++)
            {
                // Create a destination to target page.
                PDFPageDirectDestination pageDestination = new PDFPageDirectDestination();
                pageDestination.Page = document.Pages[i];
                pageDestination.Top = 0;
                pageDestination.Left = 0;
                // Inherit current zoom
                pageDestination.Zoom = 0;

                // Create a go to action to be executed when the outline is clicked, 
                // the go to action goes to specified destination.
                PDFGoToAction gotoPage = new PDFGoToAction();
                gotoPage.Destination = pageDestination;

                // Create the outline in the table of contents
                PDFOutlineItem outline = new PDFOutlineItem();
                outline.Title = string.Format("Go to page {0}", i + 1);
                outline.VisualStyle = PDFOutlineItemVisualStyle.Italic;
                outline.Action = gotoPage;
                root.Items.Add(outline);
            }
            root.Expanded = true;

            // Create an outline that will launch a link in the browser.
            PDFUriAction uriAction = new PDFUriAction();
            uriAction.URI = "http://www.o2sol.com/";

            PDFOutlineItem webOutline = new PDFOutlineItem();
            webOutline.Title = "http://www.o2sol.com/";
            webOutline.Color = new PDFRgbColor(0, 0, 255);
            webOutline.Action = uriAction;
            document.Outline.Add(webOutline);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "outlines.pdf") };
            return output;
        }
    }
}