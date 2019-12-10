using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Content;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// ContentExtraction sample.
    /// </summary>
    public class ContentExtraction
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream input)
        {
            // Load the input file.
            PDFFixedDocument document = new PDFFixedDocument(input);

            ExtractTextAndHighlight(document);

            ExtractTextAndHighlightGlyphs(document);

            ExtractImagesAndHighlight(document);

            // Compress the page graphic content.
            for (int i = 0; i < document.Pages.Count; i++)
            {
                document.Pages[i].Canvas.CompressAndClose();
            }

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "contentextraction.pdf") };
            return output;
        }

        /// <summary>
        /// Extracts text fragments from the first page and highlights the fragment boundaries.
        /// </summary>
        /// <param name="document"></param>
        private static void ExtractTextAndHighlight(PDFFixedDocument document)
        {
            PDFRgbColor penColor = new PDFRgbColor();
            PDFPen pen = new PDFPen(penColor, 0.5);
            Random rnd = new Random();
            byte[] rgb = new byte[3];

            PDFContentExtractor ce = new PDFContentExtractor(document.Pages[0]);
            PDFTextFragmentCollection tfc = ce.ExtractTextFragments();
            for (int i = 0; i < tfc.Count; i++)
            {
                rnd.NextBytes(rgb);
                penColor.R = rgb[0];
                penColor.G = rgb[1];
                penColor.B = rgb[2];

                PDFPath boundingPath = new PDFPath();
                boundingPath.StartSubpath(tfc[i].FragmentCorners[0].X, tfc[i].FragmentCorners[0].Y);
                boundingPath.AddLineTo(tfc[i].FragmentCorners[1].X, tfc[i].FragmentCorners[1].Y);
                boundingPath.AddLineTo(tfc[i].FragmentCorners[2].X, tfc[i].FragmentCorners[2].Y);
                boundingPath.AddLineTo(tfc[i].FragmentCorners[3].X, tfc[i].FragmentCorners[3].Y);
                boundingPath.CloseSubpath();

                document.Pages[0].Canvas.DrawPath(pen, boundingPath);
            }
        }

        /// <summary>
        /// Extracts text fragments from the 2nd page and highlights the glyphs in the fragment.
        /// </summary>
        /// <param name="document"></param>
        private static void ExtractTextAndHighlightGlyphs(PDFFixedDocument document)
        {
            PDFRgbColor penColor = new PDFRgbColor();
            PDFPen pen = new PDFPen(penColor, 0.5);
            Random rnd = new Random();
            byte[] rgb = new byte[3];

            PDFContentExtractor ce = new PDFContentExtractor(document.Pages[1]);
            PDFTextFragmentCollection tfc = ce.ExtractTextFragments();
            PDFTextFragment tf = tfc[1];
            for (int i = 0; i < tf.Glyphs.Count; i++)
            {
                rnd.NextBytes(rgb);
                penColor.R = rgb[0];
                penColor.G = rgb[1];
                penColor.B = rgb[2];

                PDFPath boundingPath = new PDFPath();
                boundingPath.StartSubpath(tf.Glyphs[i].GlyphCorners[0].X, tf.Glyphs[i].GlyphCorners[0].Y);
                boundingPath.AddLineTo(tf.Glyphs[i].GlyphCorners[1].X, tf.Glyphs[i].GlyphCorners[1].Y);
                boundingPath.AddLineTo(tf.Glyphs[i].GlyphCorners[2].X, tf.Glyphs[i].GlyphCorners[2].Y);
                boundingPath.AddLineTo(tf.Glyphs[i].GlyphCorners[3].X, tf.Glyphs[i].GlyphCorners[3].Y);
                boundingPath.CloseSubpath();

                document.Pages[1].Canvas.DrawPath(pen, boundingPath);
            }
        }

        /// <summary>
        /// Extracts text fragments from the 3rd page and highlights the glyphs in the fragment.
        /// </summary>
        /// <param name="document"></param>
        private static void ExtractImagesAndHighlight(PDFFixedDocument document)
        {
            PDFPen pen = new PDFPen(new PDFRgbColor(255, 0, 192), 0.5);
            PDFBrush brush = new PDFBrush(new PDFRgbColor(0, 0, 0));
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.Helvetica, 8);
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = brush;
            sao.Font = helvetica;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.Width = 1000;

            PDFContentExtractor ce = new PDFContentExtractor(document.Pages[2]);
            PDFVisualImageCollection eic = ce.ExtractImages(false);
            for (int i = 0; i < eic.Count; i++)
            {
                string imageProperties = string.Format("Image ID: {0}\nPixel width: {1} pixels\nPixel height: {2} pixels\n" +
                    "Display width: {3} points\nDisplay height: {4} points\nHorizonal Resolution: {5} dpi\nVertical Resolution: {6} dpi",
                    eic[i].ImageID, eic[i].Width, eic[i].Height, eic[i].DisplayWidth, eic[i].DisplayHeight, eic[i].DpiX, eic[i].DpiY);

                PDFPath boundingPath = new PDFPath();
                boundingPath.StartSubpath(eic[i].ImageCorners[0].X, eic[i].ImageCorners[0].Y);
                boundingPath.AddLineTo(eic[i].ImageCorners[1].X, eic[i].ImageCorners[1].Y);
                boundingPath.AddLineTo(eic[i].ImageCorners[2].X, eic[i].ImageCorners[2].Y);
                boundingPath.AddLineTo(eic[i].ImageCorners[3].X, eic[i].ImageCorners[3].Y);
                boundingPath.CloseSubpath();

                document.Pages[2].Canvas.DrawPath(pen, boundingPath);
                slo.X = eic[i].ImageCorners[3].X + 1;
                slo.Y = eic[i].ImageCorners[3].Y + 1;
                document.Pages[2].Canvas.DrawString(imageProperties, sao, slo);
            }
        }
    }
}