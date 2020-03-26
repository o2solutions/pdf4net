using System;

namespace O2S.Components.PDF4NET.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            ContentSeparator cs = new ContentSeparator("..\\..\\..\\..\\..\\SupportFiles\\contentseparation.pdf", "cutcontour");
            
            cs.KeepSeparationDiscardMainContent("CutContour.pdf");
            cs.KeepMainDiscardSeparationContent("MainContent.pdf");
        }
    }
}

