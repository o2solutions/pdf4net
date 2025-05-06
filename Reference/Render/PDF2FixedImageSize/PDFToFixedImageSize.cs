using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Rendering;

namespace O2S.Components.PDF4NET.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream pdfStream = File.OpenRead("..\\..\\..\\..\\..\\..\\SupportFiles\\PDF4NET.pdf");
            PDFFixedDocument document = new PDFFixedDocument(pdfStream);
            pdfStream.Dispose();

            PDFPageRenderer renderer = new PDFPageRenderer(document.Pages[0]);

            // Convert PDF page to fixed image size 1920x1080
            using (FileStream pngStream = File.OpenWrite("PDF4NET.Render-1920x1080.png"))
            {
                PDFRendererSettings settings = new PDFRendererSettings(96, 96);
                settings.OutputImageSize = new PDFSize(1920, 1080);
                renderer.ConvertPageToImage(pngStream, PDFPageImageFormat.Png, settings);
                pngStream.Flush();
            }

            // Convert PDF page to image size 1920xProportionalHeight
            using (FileStream pngStream = File.OpenWrite("PDF4NET.Render-1920xProportionalHeight.png"))
            {
                PDFRendererSettings settings = new PDFRendererSettings(96, 96);
                settings.OutputImageSize = new PDFSize(1920, 0);
                renderer.ConvertPageToImage(pngStream, PDFPageImageFormat.Png, settings);
                pngStream.Flush();
            }

            // Convert PDF page to image size ProportionalWidth x 1080
            using (FileStream pngStream = File.OpenWrite("PDF4NET.Render-ProportionalWidthx1080.png"))
            {
                PDFRendererSettings settings = new PDFRendererSettings(96, 96);
                settings.OutputImageSize = new PDFSize(0, 1080);
                renderer.ConvertPageToImage(pngStream, PDFPageImageFormat.Png, settings);
                pngStream.Flush();
            }

            Console.WriteLine("PDFToFixedImageSize sample completed with success.");
        }
    }
}
