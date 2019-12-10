using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Canvas.Svg;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Svg to PDF conversion sample.
    /// </summary>
    public class SvgToPDF
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream input)
        {
            PDFFixedDocument document = new PDFFixedDocument();
            PDFPage page = document.Pages.Add();

            PDFSvgDrawing svg = new PDFSvgDrawing(input);
            page.Canvas.DrawFormXObject(svg, 20, 20, page.Width - 40, page.Width - 40);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "svgtopdf.pdf") };
            return output;
        }
    }
}