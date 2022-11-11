using System;
using System.IO;

namespace O2S.Components.PDF4NET.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\SupportFiles\\";

            string taggedText = TaggedTextExtractor.ExtractText(supportPath + "invoice.pdf");

            Console.WriteLine(taggedText);
        }
    }
}
