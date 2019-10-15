using System;
using System.IO;
using System.Reflection;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Samples;
using O2S.Components.PDF4NET.Standards;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class PDFA
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\SupportFiles\\";

            
            FileStream iccInput = new FileStream(supportPath + "rgb.icc", FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream ttfInput = new FileStream(supportPath + "verdana.ttf", FileMode.Open, FileAccess.Read, FileShare.Read);
            SampleOutputInfo[] output = O2S.Components.PDF4NET.Samples.PDFA.Run(iccInput, ttfInput);
            iccInput.Dispose();
            ttfInput.Dispose();
            

            PDFAFormat[] pdfaFormats = new PDFAFormat[] { PDFAFormat.PDFA1b, PDFAFormat.PDFA2u, PDFAFormat.PDFA3u };
            for (int i = 0; i < output.Length; i++)
            {
				FileStream outStream = File.OpenWrite(output[i].FileName);
                PDFAFormatter.Save(output[i].Document as PDFFixedDocument, outStream, pdfaFormats[i]);
                outStream.Flush();
				outStream.Dispose();
            }

            Console.WriteLine("File(s) saved with success to current folder.");
        }
    }
}
