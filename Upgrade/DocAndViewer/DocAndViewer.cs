using System;
using System.Drawing;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Core.Cos;
using O2S.Components.PDF4NET.Graphics;
//using O2S.Components.PDF4NET.Graphics.Shapes;
using O2S.Components.PDF4NET.Graphics.Fonts;

namespace O2S.Samples.PDF4NET.DocAndViewer
{
    /// <summary>
    /// This sample will show how to set the document information
    /// and the way the viewer will behave when will open the document.
    /// It also shows how to create custom properties for the document.
    /// </summary>
    class DocAndViewer
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Create the pdf document
            //PDF4NET v5: PDFDocument pdfDoc = new PDFDocument();
            PDFFixedDocument pdfDoc = new PDFFixedDocument();

            // Set the document information
            pdfDoc.DocumentInformation = new PDFDocumentInformation();
            pdfDoc.DocumentInformation.Author = "O2 Solutions (http://www.o2sol.com)";
            pdfDoc.DocumentInformation.Title = "Sample document";
            pdfDoc.DocumentInformation.Subject = "The abilities of the PDF4NET library";
            pdfDoc.DocumentInformation.Keywords = "pdf4net, pdf, .net, sample";
            pdfDoc.DocumentInformation.Creator = "DocAndViewer";

            // Set viewer preferences
            // Change HideMenubar to false in order to 
            // access the Preferences menu item.
            pdfDoc.ViewerPreferences = new PDFViewerPreferences();
            pdfDoc.ViewerPreferences.HideMenubar = false;
            pdfDoc.ViewerPreferences.HideToolbar = true;
            pdfDoc.ViewerPreferences.HideWindowUI = true;
            //PDF4NET v5: pdfDoc.ViewerPreferences.DisplayDocTitle = true;
            pdfDoc.ViewerPreferences.DisplayDocumentTitle = true;

            // Set up custom properties
            //PDF4NET v5: PDFMetadataSchema is no longer supported in PDF4NET 10
            //PDFMetadataSchema ms = new PDFMetadataSchema();
            //ms["Company"] = "O2 Solutions";
            //ms["Website"] = "http://www.o2sol.com/";
            //ms["Product"] = "PDF4NET Library";
            //ms.StoreSchemaInDocInfo = true;

            //// Add schema to document
            //pdfDoc.Metadata = new PDFXMPMetadata();
            //pdfDoc.Metadata.MetadataSchemas.Add(ms);

            // Store custom properties
            pdfDoc.DocumentInformation.CosDictionary["/Company"] = new PDFCosString("O2 Solutions");
            pdfDoc.DocumentInformation.CosDictionary["/Website"] = new PDFCosString("https://o2sol.com/");
            pdfDoc.DocumentInformation.CosDictionary["/Product"] = new PDFCosString("PDF4NET");
            // Store custom XMP metadata
            pdfDoc.XmpMetadata = new PDFXmpMetadata();
            pdfDoc.XmpMetadata.Metadata = "<custommetadata>Custom metadata</custommetadata>";

            // Create one page
            //PDF4NET v5: PDFPage pdfPage = pdfDoc.AddPage();
            PDFPage pdfPage = pdfDoc.Pages.Add();

            // Create the graphic objects 
            //PDF4NET v5: PDFFont fontText = new PDFFont(PDFFontFace.Helvetica, 12);
            PDFStandardFont fontText = new PDFStandardFont(PDFStandardFontFace.Helvetica, 12);
            //PDF4NET v5: PDFFont fontTitle = new PDFFont(PDFFontFace.Helvetica, 12);
            PDFStandardFont fontTitle = new PDFStandardFont(PDFStandardFontFace.Helvetica, 12);
            fontTitle.Bold = true;
            PDFBrush brush = new PDFBrush(new PDFRgbColor());

            // Write on the page the current settings
            //PDF4NET v5: pdfPage.Canvas.DrawText("Document information", fontTitle, null, brush, 20, 20, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Document information", fontTitle, brush, 20, 20);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Author: " + pdfDoc.DocumentInformation.Author, fontText, null, brush, 20, 35, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Author: " + pdfDoc.DocumentInformation.Author, fontText, brush, 20, 35);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Title: " + pdfDoc.DocumentInformation.Title, fontText, null, brush, 20, 50, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Title: " + pdfDoc.DocumentInformation.Title, fontText, brush, 20, 50);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Subject: " + pdfDoc.DocumentInformation.Subject, fontText, null, brush, 20, 65, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Subject: " + pdfDoc.DocumentInformation.Subject, fontText, brush, 20, 65);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Keywords: " + pdfDoc.DocumentInformation.Keywords, fontText, null, brush, 20, 80, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Keywords: " + pdfDoc.DocumentInformation.Keywords, fontText, brush, 20, 80);
            //PDF4NET v5: pdfPage.Canvas.DrawText("Creator: " + pdfDoc.DocumentInformation.Creator, fontText, null, brush, 20, 95, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Creator: " + pdfDoc.DocumentInformation.Creator, fontText, brush, 20, 95);

            //PDF4NET v5: pdfPage.Canvas.DrawText("Viewer preferences", fontTitle, null, brush, 20, 120, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("Viewer preferences", fontTitle, brush, 20, 120);
            //PDF4NET v5: pdfPage.Canvas.DrawText("HideMenubar: " + pdfDoc.ViewerPreferences.HideMenubar, fontText, null, brush, 20, 135, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("HideMenubar: " + pdfDoc.ViewerPreferences.HideMenubar, fontText, brush, 20, 135);
            //PDF4NET v5: pdfPage.Canvas.DrawText("HideToolbar: " + pdfDoc.ViewerPreferences.HideToolbar, fontText, null, brush, 20, 150, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("HideToolbar: " + pdfDoc.ViewerPreferences.HideToolbar, fontText, brush, 20, 150);
            //PDF4NET v5: pdfPage.Canvas.DrawText("HideWindowUI: " + pdfDoc.ViewerPreferences.HideWindowUI, fontText, null, brush, 20, 165, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("HideWindowUI: " + pdfDoc.ViewerPreferences.HideWindowUI, fontText, brush, 20, 165);
            //PDF4NET v5: pdfPage.Canvas.DrawText("DisplayDocTitle: " + pdfDoc.ViewerPreferences.DisplayDocTitle, fontText, null, brush, 20, 180, 0, PDFTextAlign.TopLeft);
            pdfPage.Canvas.DrawString("DisplayDocTitle: " + pdfDoc.ViewerPreferences.DisplayDocumentTitle, fontText, brush, 20, 180);

            // Save the document to disk
            pdfDoc.Save("Sample_DocAndViewer.pdf"); 
        }
    }
}
