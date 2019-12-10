using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Redaction;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// DocumentIncrementalUpdate sample.
    /// </summary>
    public class DocumentIncrementalUpdate
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream input)
        {
            PDFDocumentFeatures df = new PDFDocumentFeatures();
            // Do not load file attachments, new file attachments cannot be added.
            df.EnableDocumentFileAttachments = false;
            // Do not load form fields, form fields cannot be filled and new form fields cannot be added.
            df.EnableDocumentFormFields = false;
            // Do not load embedded JavaScript code, new JavaScript code at document level cannot be added.
            df.EnableDocumentJavaScriptFragments = false;
            // Do not load the named destinations, new named destinations cannot be created.
            df.EnableDocumentNamedDestinations = false;
            // Do not load the document outlines, new outlines cannot be created.
            df.EnableDocumentOutline = false;
            // Do not load annotations, new annotations cannot be added to existing pages.
            df.EnablePageAnnotations = false;
            // Do not load the page graphics, new graphics cannot be added to existing pages.
            df.EnablePageGraphics = false;
            PDFFixedDocument document = new PDFFixedDocument(input, df);

            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 24);
            PDFBrush brush = new PDFBrush();

            // Add a new page with some content on it.
            PDFPage page = document.Pages.Add();
            page.Canvas.DrawString("New page added to an existing document.", helvetica, brush, 20, 50);

            // When document features have been specified at load time the document is automatically saved in incremental update mode.
            document.Save(input);
            
            return null;
        }
    }
}