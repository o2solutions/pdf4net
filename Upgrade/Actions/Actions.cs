using System;
using System.Drawing;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Actions;
using O2S.Components.PDF4NET.Destinations;
using O2S.Components.PDF4NET.Graphics;
//using O2S.Components.PDF4NET.Graphics.Shapes;
using O2S.Components.PDF4NET.Graphics.Fonts;

namespace O2S.Samples.PDF4NET.Actions
{
    /// <summary>
    /// This sample shows how to use the PDF actions.
    /// </summary>
    class Actions
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

            // Create the graphic objects 
            //PDF4NET v5: PDFFont fontText = new PDFFont(PDFFontFace.Helvetica, 12);
            PDFStandardFont fontText = new PDFStandardFont(PDFStandardFontFace.Helvetica, 12);

            PDFBrush blackBrush = new PDFBrush(new PDFRgbColor());

            // Create 3 pages
            //PDF4NET v5: PDFPage page = doc.AddPage();
            PDFPage page = doc.Pages.Add();

            //PDF4NET v5: page.Canvas.DrawText("Page 1", fontText, null, blackBrush, 20, 30);
            page.Canvas.DrawString("Page 1", fontText, blackBrush, 20, 30);

            //PDF4NET v5: page = doc.AddPage();
            page = doc.Pages.Add();

            //PDF4NET v5: page.Canvas.DrawText("Page 2", fontText, null, blackBrush, 20, 30);
            page.Canvas.DrawString("Page 2", fontText, blackBrush, 20, 30);

            //PDF4NET v5: page = doc.AddPage();
            page = doc.Pages.Add();

            //PDF4NET v5: page.Canvas.DrawText("Page 3", fontText, null, blackBrush, 20, 30);
            page.Canvas.DrawString("Page 3", fontText, blackBrush, 20, 30);

            /// URI Action
            // create a web action
            //PDF4NET v5: PDFURIAction uriAction = new PDFURIAction();
            PDFUriAction uriAction = new PDFUriAction();
            uriAction.URI = "http://www.o2sol.com/";

            // create a bookmark to point to the url above
            //PDF4NET v5: PDFBookmark url = new PDFBookmark();
            PDFOutlineItem url = new PDFOutlineItem();

            url.Title = "www.o2sol.com";
            url.Color = new PDFRgbColor();
            url.Action = uriAction;
            // add the bookmark to the document
            //PDF4NET v5: doc.Bookmarks.Add(url);
            doc.Outline.Add(url);
            /// URI Action

            /// Javascript Action
            // create a javascript action to print the document
            PDFJavaScriptAction jsAction = new PDFJavaScriptAction();
            jsAction.Script = "this.print(true);\n";

            // create a bookmark to point to execute the action
            //PDF4NET v5: PDFBookmark js = new PDFBookmark();
            PDFOutlineItem js = new PDFOutlineItem();

            js.Title = "Print me from JavaScript";
            js.Color = new PDFRgbColor();
            js.Action = jsAction;
            // add the bookmark to the document
            //PDF4NET v5: doc.Bookmarks.Add(url);
            doc.Outline.Add(js);
            /// Javascript Action

            /// OpenDocument action
            // Create an action to be executed when the document is opened
            // The action will open the document at the 
            // second page of the document using a 800% zoom
            //PDF4NET v5: PDFPageDestination pageDestination = new PDFPageDestination();
            PDFPageDirectDestination pageDestination = new PDFPageDirectDestination();

            pageDestination.Page = doc.Pages[1];
            //PDF4NET v5: pageDestination.MagnificationMode = PDFMagnificationMode.XYZ;
            pageDestination.ZoomMode= PDFDestinationZoomMode.XYZ;

            pageDestination.Left = 0;
            pageDestination.Top = 0;
            pageDestination.Zoom = 800;
            PDFGoToAction goToAction = new PDFGoToAction();
            goToAction.Destination = pageDestination;

            // set the action on the document
            doc.OpenAction = goToAction;
            /// OpenDocument action

            // Save the document to disk
            doc.Save("Sample_Actions.pdf");
        }
    }
}
