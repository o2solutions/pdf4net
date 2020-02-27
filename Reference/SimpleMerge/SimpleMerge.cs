using System;
using System.IO;
using System.Reflection;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Samples;
using O2S.Components.PDF4NET.Utilities;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class SimpleMerge
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\SupportFiles\\";

            PDFMerger.MergeFiles("simplemerge.pdf",
                supportPath + "content.pdf", supportPath + "formfill.pdf");

            Console.WriteLine("Merged file saved with success to current folder.");
        }
    }
}
