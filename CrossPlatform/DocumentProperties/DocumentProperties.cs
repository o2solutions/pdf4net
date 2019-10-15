using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// DocumentProperties sample.
    /// </summary>
    public class DocumentProperties
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run()
        {
            PDFFixedDocument document = new PDFFixedDocument();
            document.Pages.Add();
            // Display the document in full screen mode.
            document.DisplayMode = PDFDisplayMode.FullScreen;

            // Fill the document information.
            document.DocumentInformation = new PDFDocumentInformation();
            document.DocumentInformation.Author = "O2 Solutions";
            document.DocumentInformation.CreationDate = DateTime.Now;
            document.DocumentInformation.ModifyDate = DateTime.Now;
            document.DocumentInformation.Creator = "O2S.Components.PDF4NET DocumentProperties sample";
            document.DocumentInformation.Producer = "O2S.Components.PDF4NET";
            document.DocumentInformation.Title = "O2S.Components.PDF4NET DocumentProperties sample";
            document.DocumentInformation.Subject = "O2S.Components.PDF4NET sample code";
            document.DocumentInformation.Keywords = "pdf4net,pdf,sample";

            // Set custom metadata in the XMP metadata.
            document.XmpMetadata = new PDFXmpMetadata();
            // This custom metadata will appear as a child of 'xmpmeta' root node.
            document.XmpMetadata.Metadata = "<custom>Custom metadata</custom>";

            // Set the viewer preferences.
            document.ViewerPreferences = new PDFViewerPreferences();
            document.ViewerPreferences.CenterWindow = true;
            document.ViewerPreferences.DisplayDocumentTitle = true;
            document.ViewerPreferences.HideMenubar = true;
            document.ViewerPreferences.HideToolbar = true;
            document.ViewerPreferences.HideWindowUI = true;
            document.ViewerPreferences.PrintScaling = PDFPrintScaling.None;

            // Set the PDF version.
            document.PDFVersion = PDFVersion.Version15;

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "documentproperties.pdf") };
            return output;
        }
    }
}