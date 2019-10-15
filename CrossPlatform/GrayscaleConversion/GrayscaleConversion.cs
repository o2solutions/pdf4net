using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Transforms;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// GrayscaleConversion sample.
    /// </summary>
    public class GrayscaleConversion
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream input)
        {
            // Load the input file.
            PDFFixedDocument document = new PDFFixedDocument(input);

            PDFConvertToGrayTransform grayTransform = new PDFConvertToGrayTransform();
            PDFPageTransformer pageTransformer = new PDFPageTransformer(document.Pages[3]);
            pageTransformer.ApplyTransform(grayTransform);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "grayscaleconversion.pdf") };
            return output;
        }
    }
}