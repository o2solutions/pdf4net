﻿using System;
using System.IO;
using System.Reflection;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Samples;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class SVGToPDF
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\SupportFiles\\";

            
            FileStream svgInput = new FileStream(supportPath + "tiger.svg", FileMode.Open, FileAccess.Read, FileShare.Read);
            SampleOutputInfo[] output = O2S.Components.PDF4NET.Samples.SvgToPDF.Run(svgInput);
            svgInput.Dispose();
            

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
