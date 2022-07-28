using O2S.Components.PDF4NET.Rendering;
using O2S.Components.PDF4NET.Rendering.RenderingSurfaces;
using System;
using System.IO;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class HighDpiPDF2Image
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\..\\SupportFiles\\";

            FileStream fs = File.OpenRead(supportPath + "PDF4NET.pdf");
            PDFFixedDocument document = new PDFFixedDocument(fs);
            fs.Close();

            PDFPageRenderer pageRenderer = new PDFPageRenderer(document.Pages[0]);

            PDFRendererSettings settings = new PDFRendererSettings(6400, 6400);
            settings.RenderingSurface = pageRenderer.CreateRenderingSurface<PDFArgbStripRenderingSurface<int>>(settings.DpiX, settings.DpiY);

            // Output will be a 32bit 52889*74845 pixels RGBA TIFF
            FileStream pngStream = File.Create("PDF4NET.Page.0.tiff");
            pageRenderer.ConvertPageToImage(pngStream, PDFPageImageFormat.Tiff, settings);
            pngStream.Flush();
            pngStream.Close();
        }
    }
}
