using O2S.Components.PDF4NET.Rendering;
using O2S.Components.PDF4NET.Rendering.RenderingSurfaces;
using O2S.Components.PDF4NET.Rendering.Imaging;
using System;
using System.IO;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class PDF2MultipageBlackAndWhiteTiff
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\..\\SupportFiles\\";

            FileStream fs = File.OpenRead(supportPath + "PDF4NET.pdf");
            PDFFixedDocument document = new PDFFixedDocument(fs);
            fs.Close();

            PDFDocumentRenderer documentRenderer = new PDFDocumentRenderer(document);

            PDFRendererSettings settings = new PDFRendererSettings(144, 144);
            PDFBlackWhiteRenderingSurface bwSurface = new PDFBlackWhiteRenderingSurface();
            bwSurface.BinarizationFilter = new PDFFloydSteinbergDitheringFilter();
            settings.RenderingSurface = bwSurface;

            // Output will be a 1bit B/W CCIT G4 compressed multipage TIFF
            FileStream tiffStream = File.Create("PDF4NET.tif");
            documentRenderer.ConvertToMultipageImage("0-3", settings, PDFPageImageFormat.Tiff, tiffStream);
            tiffStream.Flush();
            tiffStream.Close();
        }
    }
}
