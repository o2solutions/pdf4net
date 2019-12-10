using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Core;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// PageImposition sample.
    /// </summary>
    public class PageImposition
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream input)
        {
            PDFFile file = new PDFFile(input);
            PDFPageContent[] content = file.ExtractPageContent(0, file.PageCount - 1);
            file = null;

            PDFFixedDocument document = new PDFFixedDocument();
            PDFPage page1 = document.Pages.Add();
            // Draw the same page content 4 times on the new page, the content is scaled to half and flipped.
            page1.Canvas.DrawFormXObject(content[0], 
                0, 0, page1.Width / 2, page1.Height / 2);
            page1.Canvas.DrawFormXObject(content[0], 
                page1.Width / 2, 0, page1.Width / 2, page1.Height / 2, 0, PDFFlipDirection.VerticalFlip);
            page1.Canvas.DrawFormXObject(content[0],
                0, page1.Height / 2, page1.Width / 2, page1.Height / 2, 0, PDFFlipDirection.HorizontalFlip);
            page1.Canvas.DrawFormXObject(content[0], 
                page1.Width / 2, page1.Height / 2, page1.Width / 2, page1.Height / 2,
                0, PDFFlipDirection.VerticalFlip | PDFFlipDirection.HorizontalFlip);

            PDFPage page2 = document.Pages.Add();
            // Draw 3 pages on the new page.
            page2.Canvas.DrawFormXObject(content[0],
                0, 0, page2.Width / 2, page2.Height / 2);
            page2.Canvas.DrawFormXObject(content[1],
                page2.Width / 2, 0, page2.Width / 2, page2.Height / 2);
            page2.Canvas.DrawFormXObject(content[2],
                0, page2.Height, page2.Height / 2, page2.Width, 90);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "pageimposition.pdf") };
            return output;
        }
    }
}