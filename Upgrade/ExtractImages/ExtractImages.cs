using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Content;
//using O2S.Components.PDF4NET.PDFFile;

namespace O2S.Samples.PDF4NET
{
    class ExtractImages
    {
        static void Main(string[] args)
        {
            // Load the PDF file. 
            //PDF4NET v5: PDFDocument doc = new PDFDocument("..\\SupportFiles\\Images.pdf");
            PDFFixedDocument doc = new PDFFixedDocument("..\\..\\..\\..\\..\\SupportFiles\\content.pdf");

            //for (int i = 0; i < doc.Pages.Count; i++)
            //{
                // Convert the pages to PDFImportedPage to get access to ExtractImages method.
                //PDF4NET v5: PDFImportedPage ip = doc.Pages[i] as PDFImportedPage;
                PDFContentExtractor ce = new PDFContentExtractor(doc.Pages[2]);
                //PDF4NET v5: Bitmap[] images = ip.ExtractImages();
                PDFVisualImageCollection images = ce.ExtractImages(true);
                // Save the page images to disk, if there are any.
                for (int j = 0; j < images.Count; j++)
                {
                    //PDF4NET v5: images[j].Save("image" + i.ToString() + j.ToString() + ".png", ImageFormat.Png);
                    FileStream fs = File.OpenWrite("image" + j.ToString() + ".png");
                    images[j].Save(fs, PDFVisualImageSaveFormat.Png);
                    fs.Flush();
                    fs.Close();  
                }
            //}
        }
    }
}
