using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Content;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Watermarks sample.
    /// </summary>
    public class Watermarks
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream input)
        {
            // Load the input file.
            PDFFixedDocument document = new PDFFixedDocument(input);

            DrawWatermarkUnderPageContent(document.Pages[0]);

            DrawWatermarkOverPageContent(document.Pages[1]);

            DrawWatermarkWithTransparency(document.Pages[2]);

            // Compress the page graphic content.
            for (int i = 0; i < document.Pages.Count; i++)
            {
                document.Pages[i].Canvas.CompressAndClose();
            }

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "watermarks.pdf") };
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        private static void DrawWatermarkUnderPageContent(PDFPage page)
        {
            PDFBrush redBrush = new PDFBrush(new PDFRgbColor(192, 0, 0));
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 36);

            // Set the page graphics to be located under existing page content.
            page.SetGraphicsPosition(PDFPageGraphicsPosition.UnderExistingPageContent);

            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = redBrush;
            sao.Font = helvetica;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.X = 130;
            slo.Y = 670;
            slo.Rotation = 60;
            page.Canvas.DrawString("Sample watermark under page content", sao, slo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        private static void DrawWatermarkOverPageContent(PDFPage page)
        {
            PDFBrush redBrush = new PDFBrush(new PDFRgbColor(192, 0, 0));
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 32);

            // The page graphics is located by default on top of existing page content.
            //page.SetGraphicsPosition(PDFPageGraphicsPosition.OverExistingPageContent);

            // Draw the watermark over page content.
            // Page content under the watermark will be masked.
            page.Canvas.DrawString("Sample watermark over page content", helvetica, redBrush, 20, 335);

            page.Canvas.SaveGraphicsState();

            // Draw the watermark over page content but using the Multiply blend mode.
            // The watermak will appear as if drawn under the page content, useful when watermarking scanned documents.
            // If the watermark is drawn under page content for scanned documents, it will not be visible because the scanned image will block it.
            PDFExtendedGraphicState gs1 = new PDFExtendedGraphicState();
            gs1.BlendMode = PDFBlendMode.Multiply;
            page.Canvas.SetExtendedGraphicState(gs1);
            page.Canvas.DrawString("Sample watermark over page content", helvetica, redBrush, 20, 385);

            // Draw the watermark over page content but using the Luminosity blend mode.
            // Both the page content and the watermark will be visible.
            PDFExtendedGraphicState gs2 = new PDFExtendedGraphicState();
            gs2.BlendMode = PDFBlendMode.Luminosity;
            page.Canvas.SetExtendedGraphicState(gs2);
            page.Canvas.DrawString("Sample watermark over page content", helvetica, redBrush, 20, 435);

            page.Canvas.RestoreGraphicsState();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        private static void DrawWatermarkWithTransparency(PDFPage page)
        {
            PDFBrush redBrush = new PDFBrush(new PDFRgbColor(192, 0, 0));
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 36);

            // The page graphics is located by default on top of existing page content.
            //page.SetGraphicsPosition(PDFPageGraphicsPosition.OverExistingPageContent);

            page.Canvas.SaveGraphicsState();

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
            page.Canvas.SetExtendedGraphicState(gs1);
            page.Canvas.DrawString("Sample watermark over page content", sao, slo);

            page.Canvas.RestoreGraphicsState();
        }
    }
}