using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Content;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// BatesNumbers sample.
    /// </summary>
    public class BatesNumbers
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream input)
        {
            // Load the input file.
            PDFFixedDocument document = new PDFFixedDocument(input);

            PDFBatesNumberAppearance bna = new PDFBatesNumberAppearance();
            bna.Location = new PDFPoint(25, 5);
            bna.Brush = new PDFBrush(PDFRgbColor.DarkRed);

            PDFBatesNumberProvider bnp = new PDFBatesNumberProvider();
            bnp.Prefix = "O2S";
            bnp.Suffix = "PDF4NET";
            bnp.StartNumber = 1;

            PDFBatesNumber.WriteBatesNumber(document, bnp, bna);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "batesnumbers.pdf") };
            return output;
        }
    }
}