using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Transforms;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// RemoveReplaceImages sample.
    /// </summary>
    public class RemoveReplaceImages
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream input)
        {
            // Load the input file.
            PDFFixedDocument document = new PDFFixedDocument(input);

            PDFReplaceImageTransform replaceImageTransform = new PDFReplaceImageTransform();
            replaceImageTransform.ReplaceImage += new EventHandler<PDFReplaceImageEventArgs>(HandleReplaceImage);
            PDFPageTransformer pageTransformer = new PDFPageTransformer(document.Pages[2]);
            pageTransformer.ApplyTransform(replaceImageTransform);
            replaceImageTransform.ReplaceImage -= new EventHandler<PDFReplaceImageEventArgs>(HandleReplaceImage);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "removereplaceimages.pdf") };
            return output;
        }

        private static void HandleReplaceImage(object sender, PDFReplaceImageEventArgs e)
        {
            if (e.OldImageID.Value == "/Im1")
            {
                // Replace the existing image with a checkers board.
                MemoryStream checkers = new MemoryStream(new byte[] { 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0 });
                PDFRawImage rawImage = new PDFRawImage(checkers);
                rawImage.Width = 5;
                rawImage.Height = 5;
                rawImage.BitsPerComponent = 8;
                rawImage.ColorSpace = new PDFGrayColorSpace();

                e.NewImage = rawImage;
            }
            else
            {
                if (e.OldImageID.Value == "/Im2")
                {
                    // Remove the image from the page by setting the new image (the replacement image) to null.
                    e.NewImage = null;
                }
            }
        }
    }
}