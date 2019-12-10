using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Tiff to PDF conversion sample.
    /// </summary>
    public class TiffToPDF
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream input)
        {
            PDFFixedDocument document = new PDFFixedDocument();
            PDFTiffImage tiff = new PDFTiffImage(input);

            for (int i = 0; i < tiff.FrameCount; i++)
            {
                tiff.ActiveFrame = i;
                PDFPage page = document.Pages.Add();
                page.Canvas.DrawImage(tiff, 0, 0, page.Width, page.Height);
            }

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "tifftopdf.pdf") };
            return output;
        }
    }
}