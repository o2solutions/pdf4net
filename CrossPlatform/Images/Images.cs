using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Images sample.
    /// </summary>
    public class Images
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        /// <param name="imageStream"></param>
        /// <param name="cmykImageStream"></param>
        /// <param name="softMaskStream"></param>
        /// <param name="stencilMaskStream"></param>
        public static SampleOutputInfo[] Run(Stream imageStream, Stream cmykImageStream, Stream softMaskStream, Stream stencilMaskStream)
        {
            PDFFixedDocument document = new PDFFixedDocument();
            PDFStandardFont helveticaBoldTitle = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 16);
            PDFStandardFont helveticaSection = new PDFStandardFont(PDFStandardFontFace.Helvetica, 10);

            PDFPage page = document.Pages.Add();
            DrawImages(page, imageStream, helveticaBoldTitle, helveticaSection);

            page = document.Pages.Add();
            DrawImageMasks(page, imageStream, softMaskStream, stencilMaskStream, helveticaBoldTitle, helveticaSection);

            page = document.Pages.Add();
            DrawCmykTiff(page, cmykImageStream, helveticaBoldTitle);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "images.pdf") };
            return output;
        }

        private static void DrawImages(PDFPage page, Stream imageStream, PDFFont titleFont, PDFFont sectionFont)
        {
            PDFBrush brush = new PDFBrush();

            PDFJpegImage jpeg = new PDFJpegImage(imageStream);

            page.Canvas.DrawString("Images", titleFont, brush, 20, 50);

            page.Canvas.DrawString("Scaling:", sectionFont, brush, 20, 70);

            // Draw the image 3 times on the page at different sizes.
            page.Canvas.DrawImage(jpeg, 3, 90, 100, 0);
            page.Canvas.DrawImage(jpeg, 106, 90, 200, 0);
            page.Canvas.DrawImage(jpeg, 309, 90, 300, 0);

            page.Canvas.DrawString("Flipping:", sectionFont, brush, 20, 320);
            page.Canvas.DrawImage(jpeg, 20, 340, 260, 0);
            page.Canvas.DrawImage(jpeg, 310, 340, 260, 0, 0, PDFFlipDirection.VerticalFlip);
            page.Canvas.DrawImage(jpeg, 20, 550, 260, 0, 0, PDFFlipDirection.HorizontalFlip);
            page.Canvas.DrawImage(jpeg, 310, 550, 260, 0, 0, PDFFlipDirection.VerticalFlip | PDFFlipDirection.HorizontalFlip);

            page.Canvas.CompressAndClose();
        }

        private static void DrawImageMasks(PDFPage page, Stream imageStream, Stream softMaskStream, Stream stencilMaskStream, PDFFont titleFont, PDFFont sectionFont)
        {
            PDFBrush brush = new PDFBrush();

            page.Canvas.DrawString("Images Masks", titleFont, brush, 20, 50);

            page.Canvas.DrawString("Soft mask:", sectionFont, brush, 20, 70);
            PDFPngImage softMaskImage = new PDFPngImage(softMaskStream);
            PDFSoftMask softMask = new PDFSoftMask(softMaskImage);
            imageStream.Position = 0;
            PDFJpegImage softMaskJpeg = new PDFJpegImage(imageStream);
            softMaskJpeg.Mask = softMask;
            // Draw the image with a soft mask.
            page.Canvas.DrawImage(softMaskJpeg, 20, 90, 280, 0);

            page.Canvas.DrawString("Stencil mask:", sectionFont, brush, 320, 70);
            PDFPngImage stencilMaskImage = new PDFPngImage(stencilMaskStream);
            PDFStencilMask stencilMask = new PDFStencilMask(stencilMaskImage);
            imageStream.Position = 0;
            PDFJpegImage stencilMaskJpeg = new PDFJpegImage(imageStream);
            stencilMaskJpeg.Mask = stencilMask;
            // Draw the image with a stencil mask.
            page.Canvas.DrawImage(stencilMaskJpeg, 320, 90, 280, 0);

            page.Canvas.DrawString("Stencil mask painting:", sectionFont, brush, 20, 320);
            PDFBrush redBrush = new PDFBrush(PDFRgbColor.DarkRed);
            page.Canvas.DrawStencilMask(stencilMask, redBrush, 20, 340, 280, 0);
            PDFBrush blueBrush = new PDFBrush(PDFRgbColor.DarkBlue);
            page.Canvas.DrawStencilMask(stencilMask, blueBrush, 320, 340, 280, 0);
            PDFBrush greenBrush = new PDFBrush(PDFRgbColor.DarkGreen);
            page.Canvas.DrawStencilMask(stencilMask, greenBrush, 20, 550, 280, 0);
            PDFBrush yellowBrush = new PDFBrush(PDFRgbColor.YellowGreen);
            page.Canvas.DrawStencilMask(stencilMask, yellowBrush, 320, 550, 280, 0);

            page.Canvas.CompressAndClose();
        }

        private static void DrawCmykTiff(PDFPage page, Stream cmykImageStream, PDFFont titleFont)
        {
            PDFBrush brush = new PDFBrush();

            page.Canvas.DrawString("CMYK TIFF", titleFont, brush, 20, 50);

            PDFTiffImage cmykTiff = new PDFTiffImage(cmykImageStream);
            page.Canvas.DrawImage(cmykTiff, 20, 90, 570, 0);

            page.Canvas.CompressAndClose();
        }
    }
}