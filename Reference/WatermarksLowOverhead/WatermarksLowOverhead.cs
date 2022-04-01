using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Core;
using O2S.Components.PDF4NET.Graphics;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class WatermarksLowOverhead
    {
        static void Main(string[] args)
        {
            FileStream pdfStream = File.OpenRead("..\\..\\..\\..\\..\\SupportFiles\\content.pdf");
            PDFFileEx pdfFile = new PDFFileEx(pdfStream);
			pdfStream.Close();

            PDFPageCanvas pageCanvas = pdfFile.GetPageCanvas(0, PDFPageCanvasPosition.UnderExistingPageContent);
            DrawWatermarkUnderPageContent(pageCanvas);
            pageCanvas.CompressAndClose();

            pageCanvas = pdfFile.GetPageCanvas(1, PDFPageCanvasPosition.OverExistingPageContent);
            DrawWatermarkOverPageContent(pageCanvas);
            pageCanvas.CompressAndClose();

            pageCanvas = pdfFile.GetPageCanvas(2, PDFPageCanvasPosition.OverExistingPageContent);
            DrawWatermarkWithTransparency(pageCanvas);
            pageCanvas.CompressAndClose();

            pdfFile.Save("WatermarksLowOverhead.pdf");

            Console.WriteLine("File saved with success to current folder.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageCanvas"></param>
        private static void DrawWatermarkUnderPageContent(PDFPageCanvas pageCanvas)
        {
            PDFBrush redBrush = new PDFBrush(new PDFRgbColor(192, 0, 0));
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 36);

            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = redBrush;
            sao.Font = helvetica;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.X = 130;
            slo.Y = 670;
            slo.Rotation = 60;
            pageCanvas.DrawString("Sample watermark under page content", sao, slo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageCanvas"></param>
        private static void DrawWatermarkOverPageContent(PDFPageCanvas pageCanvas)
        {
            PDFBrush redBrush = new PDFBrush(new PDFRgbColor(192, 0, 0));
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 32);

            // Draw the watermark over page content.
            // Page content under the watermark will be masked.
            pageCanvas.DrawString("Sample watermark over page content", helvetica, redBrush, 20, 335);

            pageCanvas.SaveGraphicsState();

            // Draw the watermark over page content but using the Multiply blend mode.
            // The watermak will appear as if drawn under the page content, useful when watermarking scanned documents.
            // If the watermark is drawn under page content for scanned documents, it will not be visible because the scanned image will block it.
            PDFExtendedGraphicState gs1 = new PDFExtendedGraphicState();
            gs1.BlendMode = PDFBlendMode.Multiply;
            pageCanvas.SetExtendedGraphicState(gs1);
            pageCanvas.DrawString("Sample watermark over page content", helvetica, redBrush, 20, 385);

            // Draw the watermark over page content but using the Luminosity blend mode.
            // Both the page content and the watermark will be visible.
            PDFExtendedGraphicState gs2 = new PDFExtendedGraphicState();
            gs2.BlendMode = PDFBlendMode.Luminosity;
            pageCanvas.SetExtendedGraphicState(gs2);
            pageCanvas.DrawString("Sample watermark over page content", helvetica, redBrush, 20, 435);

            pageCanvas.RestoreGraphicsState();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageCanvas"></param>
        private static void DrawWatermarkWithTransparency(PDFPageCanvas pageCanvas)
        {
            PDFBrush redBrush = new PDFBrush(new PDFRgbColor(192, 0, 0));
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 36);

            pageCanvas.SaveGraphicsState();

            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = redBrush;
            sao.Font = helvetica;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.X = 130;
            slo.Y = 670;
            slo.Rotation = 60;

            // Draw the watermark over page content but setting the transparency to a value lower than 1.
            // The page content will be partially visible through the watermark.
            PDFExtendedGraphicState gs1 = new PDFExtendedGraphicState();
            gs1.FillAlpha = 0.3;
            pageCanvas.SetExtendedGraphicState(gs1);
            pageCanvas.DrawString("Sample watermark over page content", sao, slo);

            pageCanvas.RestoreGraphicsState();
        }

    }
}
