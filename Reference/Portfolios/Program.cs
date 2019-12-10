using System;
using System.IO;
using System.Reflection;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Samples;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class Portfolios
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\SupportFiles\\";

            
            FileStream imagesStream = new FileStream(supportPath + "image.jpg", FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream pdfStream = new FileStream(supportPath + "content.pdf", FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream csStream = new FileStream(supportPath + "portfolios_cs.html", FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream vbStream = new FileStream(supportPath + "portfolios_vb.html", FileMode.Open, FileAccess.Read, FileShare.Read);
            SampleOutputInfo[] output = O2S.Components.PDF4NET.Samples.Portfolios.Run(imagesStream, pdfStream, csStream, vbStream);
            imagesStream.Dispose();
            pdfStream.Dispose();
            csStream.Dispose();
            vbStream.Dispose();
            

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
