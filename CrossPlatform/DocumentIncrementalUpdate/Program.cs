using System;
using System.IO;
using System.Reflection;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Samples;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class DocumentIncrementalUpdate
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\SupportFiles\\";

            
            File.Copy(supportPath + "content.pdf", "documentincrementalupdate.pdf", true);
            FileStream incrementalUpdateInput = 
                new FileStream("documentincrementalupdate.pdf", FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
            O2S.Components.PDF4NET.Samples.DocumentIncrementalUpdate.Run(incrementalUpdateInput);
            incrementalUpdateInput.Flush();
            incrementalUpdateInput.Dispose();

            Console.WriteLine("File(s) saved with success to current folder.");
        }
    }
}
