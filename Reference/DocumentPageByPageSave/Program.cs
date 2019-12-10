using System;
using System.IO;
using System.Reflection;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Samples;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class DocumentPageByPageSave
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\SupportFiles\\";

            
            FileStream documentPageByPageSaveOutput = 
                new FileStream("documentpagebypagesave.pdf", FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            O2S.Components.PDF4NET.Samples.DocumentPageByPageSave.Run(documentPageByPageSaveOutput);
            documentPageByPageSaveOutput.Flush();
            documentPageByPageSaveOutput.Dispose();

            Console.WriteLine("File(s) saved with success to current folder.");
        }
    }
}
