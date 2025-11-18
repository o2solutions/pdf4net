using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using System;
using System.IO;

namespace O2S.Components.PDF4NET.Samples
{
    class Transparency
    {
        static void Main(string[] args)
        {
            PDFFixedDocument document = new PDFFixedDocument();
            PDFPage page = document.Pages.Add();

            PDFPen redPen = new PDFPen(PDFRgbColor.Red, 20);
            PDFBrush blueBrush = new PDFBrush(PDFRgbColor.DarkBlue);

            page.Canvas.DrawRectangle(blueBrush, 290, 20, 20, 60);

            // Transparent strokes
            PDFExtendedGraphicState gs1 = new PDFExtendedGraphicState();
            gs1.StrokeAlpha = 0.5;

            page.Canvas.SaveGraphicsState();
            page.Canvas.SetExtendedGraphicState(gs1);
            page.Canvas.DrawLine(redPen, 50, 50, 550, 50);
            page.Canvas.RestoreGraphicsState();

            page.Canvas.DrawLine(redPen, 300, 100, 300, 200);

            // Transparent fills
            PDFExtendedGraphicState gs2 = new PDFExtendedGraphicState();
            gs2.FillAlpha = 0.5;

            page.Canvas.SaveGraphicsState();
            page.Canvas.SetExtendedGraphicState(gs2);
            page.Canvas.DrawRectangle(blueBrush, 50, 100, 500, 100);
            page.Canvas.RestoreGraphicsState();

            page.Canvas.DrawRectangle(blueBrush, 50, 350, 500, 100);
            // Transparent images
            page.Canvas.SaveGraphicsState();
            page.Canvas.SetExtendedGraphicState(gs2);
            using (FileStream tiffStream = File.OpenRead("..\\..\\..\\..\\..\\SupportFiles\\cmyk.tif"))
            {
                page.Canvas.DrawImage(new PDFTiffImage(tiffStream), 50, 250, 500, 400);
            }
            page.Canvas.RestoreGraphicsState();

            document.Save("Transparency.PDF");

            Console.WriteLine("File saved with success to current folder.");
        }
    }
}
