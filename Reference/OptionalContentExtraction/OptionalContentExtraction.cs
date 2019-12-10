using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Core;
using O2S.Components.PDF4NET.Content;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// OptionalContentExtraction sample.
    /// </summary>
    public class OptionalContentExtraction
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream input)
        {
            PDFFile file = new PDFFile(input);

            PDFFixedDocument document = new PDFFixedDocument();
            PDFPage page = document.Pages.Add();

            PDFPageOptionalContent oc1 = file.ExtractPageOptionalContentGroup(4, "1");
            page.Canvas.DrawFormXObject(oc1, 0, 0, page.Width / 2, page.Height / 2);
            PDFPageOptionalContent oc2 = file.ExtractPageOptionalContentGroup(4, "2");
            page.Canvas.DrawFormXObject(oc2, page.Width / 2, 0, page.Width / 2, page.Height / 2);
            PDFPageOptionalContent oc3 = file.ExtractPageOptionalContentGroup(4, "3");
            page.Canvas.DrawFormXObject(oc3, 0, page.Height / 2, page.Width / 2, page.Height / 2);
            PDFPageOptionalContent oc4 = file.ExtractPageOptionalContentGroup(4, "4");
            page.Canvas.DrawFormXObject(oc4, page.Width / 2, page.Height / 2, page.Width / 2, page.Height / 2);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "optionalcontentextraction.pdf") };
            return output;
        }
    }
}