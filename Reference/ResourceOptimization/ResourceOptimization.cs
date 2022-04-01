using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Core;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class ResourceOptimization
    {
        static void Main(string[] args)
        {
            PDFMergeWithoutResourceOptimization();
            PDFMergeWithResourceOptimization();
        }

        private static void PDFMergeWithoutResourceOptimization()
        {
            string fileName = "..\\..\\..\\..\\..\\SupportFiles\\content.pdf";
            PDFFixedDocument document = new PDFFixedDocument();

            for (int i = 0; i < 5; i++)
            {
                using (FileStream pdfStream = File.OpenRead(fileName))
                {
                    PDFFile pdfFile = new PDFFile(pdfStream);

                    PDFPage[] pages = pdfFile.ExtractPages(0, 4);
                    for (int j = 0; j < pages.Length; j++)
                    {
                        document.Pages.Add(pages[j]);
                    }
                }
            }

            document.Save("PDFMergeWithoutResourceOptimization.pdf");

            FileInfo fileInfo = new FileInfo("PDFMergeWithoutResourceOptimization.pdf");
            Console.WriteLine("PDF merge without resource optimization - output file size: {0}", fileInfo.Length);
        }

        private static void PDFMergeWithResourceOptimization()
        {
            string fileName = "..\\..\\..\\..\\..\\SupportFiles\\content.pdf";
            PDFFixedDocument document = new PDFFixedDocument();

            for (int i = 0; i < 5; i++)
            {
                using (FileStream pdfStream = File.OpenRead(fileName))
                {
                    PDFFile pdfFile = new PDFFile(pdfStream);

                    PDFPage[] pages = pdfFile.ExtractPages(0, 4);
                    for (int j = 0; j < pages.Length; j++)
                    {
                        document.Pages.Add(pages[j]);
                    }
                }
            }

            PDFResourceOptimizer resourceOptimizer = new PDFResourceOptimizer(document);
            resourceOptimizer.MergeFonts();
            resourceOptimizer.MergeImages();
            document.Save("PDFMergeWithResourceOptimization.pdf");

            FileInfo fileInfo = new FileInfo("PDFMergeWithResourceOptimization.pdf");
            Console.WriteLine("PDF merge with resource optimization - output file size: {0}", fileInfo.Length);
        }
    }
}
