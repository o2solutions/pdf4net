using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Destinations;
using O2S.Components.PDF4NET.Actions;
using O2S.Components.PDF4NET.Core;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// DocumentSplit sample.
    /// </summary>
    public class DocumentSplit
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream input)
        {
            // The input file is split by extracting pages from source file and inserting them in new empty PDF documents.
            PDFFile file = new PDFFile(input);
            SampleOutputInfo[] output = new SampleOutputInfo[file.PageCount];

            for (int i = 0; i < file.PageCount; i++)
            {
                PDFFixedDocument document = new PDFFixedDocument();
                PDFPage page = file.ExtractPage(i);
                document.Pages.Add(page);

                output[i] = new SampleOutputInfo(document, string.Format("documentsplit.{0}.pdf", i + 1));
            }

            return output;
        }
    }
}