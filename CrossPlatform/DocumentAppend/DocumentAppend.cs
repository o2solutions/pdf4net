using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Destinations;
using O2S.Components.PDF4NET.Actions;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// DocumentAppend sample.
    /// </summary>
    public class DocumentAppend
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream file1Input, Stream file2Input)
        {
            PDFFixedDocument document = new PDFFixedDocument();

            // The documents are merged by creating an empty PDF document and appending the file to it.
            // The outlines from the source file are also included in the merged file.
            document.AppendFile(file1Input);
            int count = document.Pages.Count;
            document.AppendFile(file2Input);

            // Create outlines that point to each merged file.
            PDFOutlineItem file1Outline = CreateOutline("First file", document.Pages[0]);
            document.Outline.Add(file1Outline);
            PDFOutlineItem file2Outline = CreateOutline("Second file", document.Pages[count]);
            document.Outline.Add(file2Outline);

            // Optionally we can add a new page at the beginning of the merged document.
            PDFPage page = new PDFPage();
            document.Pages.Insert(0, page);

            PDFOutlineItem blankPageOutline = CreateOutline("Blank page", page);
            document.Outline.Insert(0, blankPageOutline);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "documentappend.pdf") };
            return output;
        }

        private static PDFOutlineItem CreateOutline(string title, PDFPage page)
        {
            PDFPageDirectDestination pageDestination = new PDFPageDirectDestination();
            pageDestination.Page = page;
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
            outline.Title = title;
            outline.VisualStyle = PDFOutlineItemVisualStyle.Italic;
            outline.Action = gotoPage;

            return outline;
        }
    }
}