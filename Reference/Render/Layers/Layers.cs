using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Rendering;
using O2S.Components.PDF4NET.Rendering.RenderingSurfaces;

namespace O2S.Components.PDF4NET.Samples
{
    class Layers
    {
        public static void Main(string[] args)
        {
            FileStream pdfStream = File.OpenRead("..\\..\\..\\..\\..\\..\\SupportFiles\\layers.PDF");
            PDFFixedDocument document = new PDFFixedDocument(PDFStream);
            pdfStream.Dispose();

            PDFPageRenderer pageRenderer = new PDFPageRenderer(document.Pages[0]);

            PDFRendererSettings settings = new PDFRendererSettings(96, 96);
            settings.RenderingSurface = pageRenderer.CreateRenderingSurface<PDFArgbRenderingSurface<int>>(settings.DpiX, settings.DpiY);

            FileStream imageStream = File.Create("Layers.AllContent.tiff");
            // By default all page content is rendered, layers visibility is ignored.
            pageRenderer.ConvertPageToImage(imageStream, PDFPageImageFormat.Tiff, settings);
            imageStream.Flush();
            imageStream.Close();

            // Render only the layers that are displayed when the document is viewed.
            settings.LayerRenderTarget = PDFLayerRenderTarget.View;
            imageStream = File.Create("Layers.View.tiff");
            pageRenderer.ConvertPageToImage(imageStream, PDFPageImageFormat.Tiff, settings);
            imageStream.Flush();
            imageStream.Close();

            // Render only the layers that are displayed when the document is printed.
            settings.LayerRenderTarget = PDFLayerRenderTarget.Print;
            imageStream = File.Create("Layers.Print.tiff");
            pageRenderer.ConvertPageToImage(imageStream, PDFPageImageFormat.Tiff, settings);
            imageStream.Flush();
            imageStream.Close();

            Console.WriteLine("Layers sample completed.");
        }
    }
}
