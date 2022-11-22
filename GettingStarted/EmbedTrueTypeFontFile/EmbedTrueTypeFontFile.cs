using System;
using System.IO;
using O2S.Components.PDF4NET.Core;
using O2S.Components.PDF4NET.Core.Cos;
using O2S.Components.PDF4NET.Core.Filters;

namespace O2S.Components.PDF4NET.Samples
{
    public class EmbedTrueTypeFontFile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputFile">Input PDF file</param>
        /// <param name="outputFile">Output PDF file</param>
        /// <param name="fontName">The font name to embed, must match the name specified in the PDF file</param>
        /// <param name="fontFile">Path to full font file that will be embedded</param>
        public static void Run(string inputFile, string outputFile, string fontName, string fontFile)
        {
            using (FileStream fontStream = File.OpenRead(fontFile))
            {
                PDFFileEx pdfFile = new PDFFileEx(inputFile);

                for (int i = 0; i < pdfFile.PageCount; i++)
                {
                    PDFCosDictionary cosPageDict = pdfFile.GetPageCosDictionary(i);

                    PDFCosDictionary cosResourcesDict = cosPageDict[PDFNames.Resources] as PDFCosDictionary;
                    if (cosResourcesDict != null)
                    {
                        EmbedTrueTypeFontInResources(cosResourcesDict, fontName, fontStream);
                    }
                }

                pdfFile.Save(outputFile);
            }
        }

        private static void EmbedTrueTypeFontInResources(PDFCosDictionary cosResourcesDict, string fontName, Stream fontStream) 
        { 
            PDFCosDictionary cosFontResourceDict = cosResourcesDict[PDFNames.Font] as PDFCosDictionary;
            if (cosFontResourceDict != null) 
            {
                string[] fontIDs = cosFontResourceDict.Keys;
                foreach (string fontID in fontIDs) 
                {
                    PDFCosDictionary cosFontDict = cosFontResourceDict[fontID] as PDFCosDictionary;
                    if (cosFontDict != null) 
                    {
                        PDFCosDictionary cosOriginalFontDict = cosFontDict;
                        PDFCosArray cosDescendantFontsArray = cosFontDict[PDFNames.DescendantFonts] as PDFCosArray;  
                        if ((cosDescendantFontsArray != null) && (cosDescendantFontsArray.Length == 1) && (cosDescendantFontsArray[0] is PDFCosDictionary))
                        {
                            cosFontDict = cosDescendantFontsArray[0] as PDFCosDictionary;
                        }

                        string subtype = cosFontDict.GetKeyValueAsString(PDFNames.Subtype, "");
                        if ((subtype == "/TrueType") || (subtype == "/CIDFontType2"))
                        {
                            string cosFontName = cosFontDict.GetKeyValueAsString(PDFNames.BaseFont, "");
                            if (cosFontName.StartsWith("/"))
                            {
                                cosFontName = cosFontName.Substring(1);
                            }
                            int plusIndex = cosFontName.IndexOf('+');
                            if (plusIndex > 0)
                            {
                                cosFontName = cosFontName.Substring(plusIndex + 1);
                            }
                            if (cosFontName == fontName)
                            {
                                PDFCosDictionary cosFontDescriptorDict = cosFontDict[PDFNames.FontDescriptor] as PDFCosDictionary;
                                if (cosFontDescriptorDict != null)
                                {
                                    PDFCosStream cosFontFile2Stream = cosFontDescriptorDict[PDFNames.FontFile2] as PDFCosStream;
                                    if (cosFontFile2Stream == null)
                                    {
                                        cosFontFile2Stream = new PDFCosStream();
                                        cosFontDescriptorDict[PDFNames.FontFile2] = cosFontFile2Stream;
                                    }

                                    cosFontFile2Stream.SetStreamContent(fontStream, PDFFilterType.FlateDecode);
                                    cosFontFile2Stream[PDFNames.Length1] = new PDFCosNumber(fontStream.Length);

                                    cosOriginalFontDict[PDFNames.BaseFont] = cosFontDict[PDFNames.BaseFont] = cosFontDescriptorDict[PDFNames.FontName] = new PDFCosName("/" + fontName);
                                }
                            }
                        }
                    }
                }
            }

            PDFCosDictionary cosXObjectResourcesDict = cosResourcesDict[PDFNames.XObject] as PDFCosDictionary; 
            if (cosXObjectResourcesDict != null)
            {
                string[] xObjectIDs = cosXObjectResourcesDict.Keys;
                foreach (string xObjectID in xObjectIDs)
                {
                    PDFCosStream cosXObjectStream = cosXObjectResourcesDict[xObjectID] as PDFCosStream;
                    if (cosXObjectStream != null ) 
                    {
                        PDFCosDictionary cosXObjectStreamResourcesDict = cosXObjectStream[PDFNames.Resources] as PDFCosDictionary;
                        if (cosXObjectStreamResourcesDict!= null ) 
                        {
                            EmbedTrueTypeFontInResources(cosXObjectStreamResourcesDict, fontName, fontStream);
                        }
                    }
                }
            }
        }
    }
}
