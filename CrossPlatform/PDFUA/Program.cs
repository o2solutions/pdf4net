using System;
using System.IO;
using System.Reflection;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Samples;

namespace O2S.Components.PDF4NET.Samples..NetCore
{
    class PDFUA
    {
        static void Main(string[] args)
        {
            string supportPath = ".\\..\\..\\..\\..\\..\\Support\\";
            
            FileStream logoStream = new FileStream(supportPath + "logo.png", FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream verdanaStream = new FileStream(supportPath + "verdana.ttf", FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream verdanaBoldStream = new FileStream(supportPath + "verdanab.ttf", FileMode.Open, FileAccess.Read, FileShare.Read);
            SampleOutputInfo output = O2S.Components.PDF4NET.Samples.PDFUA.Run(verdanaStream, verdanaBoldStream, logoStream);
            logoStream.Dispose();
            verdanaStream.Dispose();
            verdanaBoldStream.Dispose();

			FileStream outStream = File.OpenWrite(output.FileName);
            PDFUAFormatter.Save(output.Document as PDFFixedDocument, outStream, PDFUAFormat.PDFUA1);
            outStream.Flush();
			outStream.Dispose();

            Console.WriteLine("File(s) saved with success to current folder.");
        }
    }
}
