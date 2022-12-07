using System;
using System.Collections.Generic;
using System.Text;
using O2S.Components.PDF4NET.Content;
using O2S.Components.PDF4NET.LogicalStructure;

namespace O2S.Components.PDF4NET.Samples
{
    public class TaggedTextExtractor
    {
        /// <summary>
        /// Extracts the text from the given file in the order specified by the document structure tree.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ExtractText(string fileName)
        {
            string text = "";

            PDFFixedDocument document = new PDFFixedDocument(fileName);
            PDFStructureTree structureTree = document.StructureTree;
            if (structureTree != null)
            {
                List<PDFStructureElement> contentItemStructureElements = GetStructureElementsInReadingOrder(structureTree);

                List<PDFTextRun> documentTextFragments = GetDocumentTextRuns(document);

                documentTextFragments = GetTextRunsInReadingOrder(contentItemStructureElements, documentTextFragments);

                text = ConvertTextRunsToText(documentTextFragments);
            }

            return text;
        }

        private static List<PDFStructureElement> GetStructureElementsInReadingOrder(PDFStructureTree structureTree)
        {
            List<PDFStructureElement> contentItemElements = new List<PDFStructureElement>();
            PDFStructureElementCollection rootCollection = structureTree.StructureElements as PDFStructureElementCollection;
            if (rootCollection == null)
            {
                PDFStructureElement rootElement = structureTree.StructureElements as PDFStructureElement;
                if (rootElement != null)
                {
                    rootCollection = new PDFStructureElementCollection();
                    rootCollection.Add(rootElement);
                }
            }
            for (int i = 0; i < rootCollection.Count; i++)
            {
                CopyContentItemElements(rootCollection[i], contentItemElements);
            }

            return contentItemElements;
        }

        /// <summary>
        /// Copies the structure elements that represents content items (leaf nodes) to a list.
        /// The order of the elements in the list is the reading order.
        /// </summary>
        /// <param name="structureElements"></param>
        /// <param name="contentItemElements"></param>
        private static void CopyContentItemElements(PDFStructureElement structureElement, List<PDFStructureElement> contentItemElements)
        {
            if (structureElement == null)
            {
                // For situations when the structure tree is invalid
                return;
            }

            if ((structureElement.Children is PDFMarkedContentReference) ||
                (structureElement.Children is PDFMarkedContentSequenceIdentifier) ||
                (structureElement.Children is PDFObjectReference))
            {
                contentItemElements.Add(structureElement);
            }
            else if ((structureElement.Children is PDFStructureElementContentCollection contentCollection) && (contentCollection.Count > 0))
            {
                bool structureElementAdded = false;

                for (int i = 0; i < contentCollection.Count; i++)
                {
                    if (((contentCollection[i] is PDFMarkedContentReference) ||
                        (contentCollection[i] is PDFMarkedContentSequenceIdentifier) ||
                        (contentCollection[i] is PDFObjectReference)) && !structureElementAdded)
                    {
                        contentItemElements.Add(structureElement);
                        structureElementAdded = true;
                    }
                    else if (contentCollection[i] is PDFStructureElement)
                    {
                        CopyContentItemElements(contentCollection[i] as PDFStructureElement, contentItemElements);
                    }
                }
            }
            else if (structureElement.Children is PDFStructureElement childStructureElement)
            {
                CopyContentItemElements(childStructureElement, contentItemElements);
            }
        }

        /// <summary>
        /// Extracts the text runs from the entire document.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        private static List<PDFTextRun> GetDocumentTextRuns(PDFFixedDocument document)
        {
            PDFContentExtractionContext context = new PDFContentExtractionContext();
            List<PDFTextRun> textRuns = new List<PDFTextRun>();

            for (int i = 0; i < document.Pages.Count; i++)
            {
                PDFContentExtractor ce = new PDFContentExtractor(document.Pages[i]);
                PDFTextRunCollection tfc = ce.ExtractTextRuns(context);
                textRuns.AddRange(tfc);
            }

            return textRuns;
        }

        /// <summary>
        /// Filters the text runs in reading order
        /// </summary>
        /// <param name="contentItemStructureElements"></param>
        /// <param name="documentTextRuns"></param>
        /// <returns></returns>
        private static List<PDFTextRun> GetTextRunsInReadingOrder(List<PDFStructureElement> contentItemStructureElements, List<PDFTextRun> documentTextRuns)
        {
            List<PDFTextRun> textRuns = new List<PDFTextRun>();

            for (int i = 0; i < contentItemStructureElements.Count; i++)
            {
                for (int j = 0; j < documentTextRuns.Count; j++)
                {
                    if (contentItemStructureElements[i] == documentTextRuns[j].StructureElement)
                    {
                        textRuns.Add(documentTextRuns[j]);
                    }
                }
            }

            return textRuns;
        }

        /// <summary>
        /// Converts a list of text runs into text.
        /// </summary>
        /// <param name="textRuns"></param>
        /// <returns></returns>
        private static string ConvertTextRunsToText(List<PDFTextRun> textRuns)
        {
            double horizontalOffsetFactorForSpace = 0.13;
            double verticalOffsetFactorForNewLine = 0.3;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < textRuns.Count; i++)
            {
                if (i > 0)
                {
                    if ((Math.Abs(textRuns[i - 1].Corners[0].Y - textRuns[i].Corners[0].Y) > textRuns[i].TransformedFontSize * verticalOffsetFactorForNewLine) &&
                        (Math.Abs(textRuns[i - 1].Corners[3].Y - textRuns[i].Corners[3].Y) > textRuns[i].TransformedFontSize * verticalOffsetFactorForNewLine))
                    {
                        sb.Append("\r\n");
                    }
                    else
                    {
                        if (Math.Abs(textRuns[i].Corners[0].X - textRuns[i - 1].Corners[2].X) > textRuns[i].TransformedFontSize * horizontalOffsetFactorForSpace)
                        {
                            if ((textRuns[i].Text.Length == 0) || (textRuns[i].Text[0] != ' '))
                            {
                                sb.Append(" ");
                            }
                        }
                    }
                }

                sb.Append(textRuns[i].Text);
            }

            return sb.ToString();
        }
    }
}
