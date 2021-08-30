using O2S.Components.PDF4NET.Rendering;
using O2S.Components.PDF4NET.Rendering.RenderingSurfaces;
using System;
using System.IO;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class SelectiveContentRendering
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\..\\SupportFiles\\"; 

            FileStream fs = File.OpenRead(supportPath + "PDF4NET.pdf");
            PDFFixedDocument document = new PDFFixedDocument(fs);
            fs.Close();

            PDFPageRenderer pageRenderer = new PDFPageRenderer(document.Pages[0]);

            PDFRendererSettings settings = new PDFRendererSettings(144, 144);
            // Render only text and vector graphics, do not render images
            settings.RenderAnnotations = true;
            settings.RenderFormFields = true;
            settings.RenderText = true;
            settings.RenderGraphics = true;
            settings.RenderImages = false;
            settings.RenderingSurface = pageRenderer.CreateRenderingSurface<PDFRgbRenderingSurface>(settings.DpiX, settings.DpiY);

            // Output will be a 24bit RGB PNG
            FileStream pngStream = File.Create("PDF4NET.Page.0.png");
            pageRenderer.ConvertPageToImage(pngStream, PDFPageImageFormat.Png, settings);
            pngStream.Flush();
            pngStream.Close();
        }
    }
}
