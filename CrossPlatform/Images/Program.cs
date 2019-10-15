using System;
using System.IO;
using System.Reflection;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Samples;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class Images
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\SupportFiles\\";

            
            FileStream imageStream = new FileStream(supportPath + "image.jpg", FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream cmykImageStream = new FileStream(supportPath + "cmyk.tif", FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream softMaskStream = new FileStream(supportPath + "softmask.png", FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream stencilMaskStream = new FileStream(supportPath + "stencilmask.png", FileMode.Open, FileAccess.Read, FileShare.Read);
            SampleOutputInfo[] output = O2S.Components.PDF4NET.Samples.Images.Run(imageStream, cmykImageStream, softMaskStream, stencilMaskStream);
            imageStream.Dispose();
            cmykImageStream.Dispose();
            softMaskStream.Dispose();
            stencilMaskStream.Dispose();
            

            for (int i = 0; i < output.Length; i++)
            {
				FileStream outStream = File.OpenWrite(output[i].FileName);
                output[i].Document.Save(outStream, output[i].SecurityHandler);
				outStream.Flush();
				outStream.Dispose();
            }

            Console.WriteLine("File(s) saved with success to current folder.");
        }
    }
}
