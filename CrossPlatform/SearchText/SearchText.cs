using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Content;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Search text sample.
    /// </summary>
    public class SearchText
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream input)
        {
            PDFFixedDocument document = new PDFFixedDocument(input);
            PDFContentExtractor ce = new PDFContentExtractor(document.Pages[0]);

            // Simple search.
            PDFTextSearchResultCollection searchResults = ce.SearchText("at");
            HighlightSearchResults(document.Pages[0], searchResults, PDFRgbColor.Red);

            // Whole words search.
            searchResults = ce.SearchText("at", PDFTextSearchOptions.WholeWordSearch);
            HighlightSearchResults(document.Pages[0], searchResults, PDFRgbColor.Green);

            // Regular expression search, find all words that start with uppercase.
            searchResults = ce.SearchText("[A-Z][a-z]*", PDFTextSearchOptions.RegExSearch);
            HighlightSearchResults(document.Pages[0], searchResults, PDFRgbColor.Blue);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "searchtext.pdf") };
            return output;
        }

        private static void HighlightSearchResults(PDFPage page, PDFTextSearchResultCollection searchResults, PDFColor color)
        {
            PDFPen pen = new PDFPen(color, 0.5);

            for (int i = 0; i < searchResults.Count; i++)
            {
                PDFTextFragmentCollection tfc = searchResults[i].TextFragments;
                for (int j = 0; j < tfc.Count; j++)
                {
                    PDFPath path = new PDFPath();

                    path.StartSubpath(tfc[j].FragmentCorners[0].X, tfc[j].FragmentCorners[0].Y);
                    path.AddPolygon(tfc[j].FragmentCorners);

                    page.Canvas.DrawPath(pen, path);
                }
            }
        }
    }
}