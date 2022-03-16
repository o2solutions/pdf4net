using O2S.Components.PDF4NET.Rendering;
using O2S.Components.PDF4NET.Rendering.RenderingSurfaces;
using System;
using System.IO;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class PDF2MultipageColorTiff
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\..\\SupportFiles\\";

            FileStream fs = File.OpenRead(supportPath + "PDF4NET.pdf");
            PDFFixedDocument document = new PDFFixedDocument(fs);
            fs.Close();

            PDFDocumentRenderer documentRenderer = new PDFDocumentRenderer(document);

            PDFRendererSettings settings = new PDFRendererSettings(144, 144);
            settings.RenderingSurface = new PDFRgbRenderingSurface(1224, 1584);

            // Output will be a 24bit RGB multipage TIFF
            FileStream tiffStream = File.Create("PDF4NET.tif");
            documentRenderer.ConvertToMultipageImage("0-3", settings, PDFPageImageFormat.TiffLzwCompressed, tiffStream);
            tiffStream.Flush();
            tiffStream.Close();
        }
    }
}
