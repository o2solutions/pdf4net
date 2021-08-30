using O2S.Components.PDF4NET.Rendering;
using O2S.Components.PDF4NET.Rendering.RenderingSurfaces;
using O2S.Components.PDF4NET.Rendering.Imaging;
using System;
using System.IO;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class PDF2BlackAndWhiteImage
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\..\\SupportFiles\\";

            FileStream fs = File.OpenRead(supportPath + "PDF4NET.pdf");
            PDFFixedDocument document = new PDFFixedDocument(fs);
            fs.Close();

            PDFPageRenderer pageRenderer = new PDFPageRenderer(document.Pages[0]);

            PDFRendererSettings settings = new PDFRendererSettings(144, 144);
            PDFBlackWhiteRenderingSurface bwSurface = pageRenderer.CreateRenderingSurface<PDFBlackWhiteRenderingSurface>(settings.DpiX, settings.DpiY);
            // Use a simple threshold filter for conversion to B/W
            // Everything below 128 becomes black, everything above 128 becomes white
            bwSurface.BinarizationFilter = new PDFThresholdFilter(128); 
            settings.RenderingSurface = bwSurface;

            // Output will be a 1bit B/W PNG
            FileStream pngStream = File.Create("PDF4NET.Page.0.Dithering-Off.png");
            pageRenderer.ConvertPageToImage(pngStream, PDFPageImageFormat.Png, settings);
            pngStream.Flush();
            pngStream.Close();

            // Use a dithering filter for conversion to B/W
            bwSurface.BinarizationFilter = new PDFFloydSteinbergDitheringFilter();

            // Output will be a 1bit B/W PNG
            pngStream = File.Create("PDF4NET.Page.0.Dithering-On.png");
            pageRenderer.ConvertPageToImage(pngStream, PDFPageImageFormat.Png, settings);
            pngStream.Flush();
            pngStream.Close();
        }
    }
}
