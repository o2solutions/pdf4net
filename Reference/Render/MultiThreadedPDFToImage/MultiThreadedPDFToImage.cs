using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Rendering;
using O2S.Components.PDF4NET.Rendering.RenderingSurfaces;

namespace O2S.Components.PDF4NET.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            PDFFixedDocument document = new PDFFixedDocument("..\\..\\..\\..\\..\\..\\SupportFiles\\cluj.pdf");

            PDFRendererSettings settings = new PDFRendererSettings();
            settings.DpiX = 300;
            settings.DpiY = 300;
            PDFPageRenderer renderer = new PDFPageRenderer(document.Pages[0]);
            settings.RenderingSurface = renderer.CreateRenderingSurface<PDFRgbaRenderingSurface<byte>>(settings.DpiX, settings.DpiY);

            settings.RenderThreadCount = 0;
            RenderPage(renderer, settings);

            settings.RenderThreadCount = 2;
            RenderPage(renderer, settings);

            settings.RenderThreadCount = 4;
            RenderPage(renderer, settings);
        }

        private static void RenderPage(PDFPageRenderer renderer, PDFRendererSettings settings)
        {
            DateTime start, end;
            TimeSpan total = new TimeSpan();
            int runCount = 3;

            for (int i = 0; i < runCount; i++)
            {
                start = DateTime.Now;

                renderer.ConvertPageToImage(settings);

                end = DateTime.Now;
                total = total + (end - start);

                settings.RenderingSurface.Save(string.Format($"ThreadCount.{settings.RenderThreadCount}.Pass.{i + 1}.tif"), PDFPageImageFormat.Tiff);
            }

            Console.WriteLine($"Thread count: {settings.RenderThreadCount} - Runs: {runCount} - Average duration: {total / runCount}");

            Console.WriteLine();
        }
    }
}
