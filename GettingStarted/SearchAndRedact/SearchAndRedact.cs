using System;
using System.IO;
using O2S.Components.PDF4NET.Content;
using O2S.Components.PDF4NET.Redaction;

namespace O2S.Components.PDF4NET.Samples
{
    public class SearchAndRedact
    {
        public static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\SupportFiles\\";
            
            FileStream input = File.OpenRead(supportPath + "content.pdf");
            PDFFixedDocument document = new PDFFixedDocument(input);
			input.Close();

            PDFContentExtractor ce = new PDFContentExtractor(document.Pages[0]);
            PDFTextSearchResultCollection searchResults = ce.SearchText("lorem");

            if (searchResults.Count > 0)
            {
                PDFContentRedactor cr = new PDFContentRedactor(document.Pages[0]);

                cr.BeginRedaction();

                for (int i = 0; i < searchResults.Count; i++)
                {
                    cr.RedactArea(searchResults[i].VisualBounds);
                }

                cr.ApplyRedaction();
            }

            using(FileStream output = File.Create("RedactedSearchResults.pdf"))
			{
                document.Save(output);
			}
        }
    }
}
