using O2S.Components.PDF4NET.Rendering;
using O2S.Components.PDF4NET.Rendering.RenderingSurfaces;
using System;
using System.IO;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class PDF2GrayImage
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\..\\SupportFiles\\";

            FileStream fs = File.OpenRead(supportPath + "PDF4NET.pdf");
            PDFFixedDocument document = new PDFFixedDocument(fs);
            fs.Close();

            PDFPageRenderer pageRenderer = new PDFPageRenderer(document.Pages[0]);

            PDFRendererSettings settings = new PDFRendererSettings(144, 144);
            settings.RenderingSurface = pageRenderer.CreateRenderingSurface<PDFGray8RenderingSurface>(settings.DpiX, settings.DpiY);

            // Output will be a 8bit Gray PNG
            FileStream pngStream = File.Create("PDF4NET.Page.0.png");
            pageRenderer.ConvertPageToImage(pngStream, PDFPageImageFormat.Png, settings);
            pngStream.Flush();
            pngStream.Close();
        }
    }
}
