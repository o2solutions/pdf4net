using System;
using System.Collections.Generic;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Transforms;

namespace ChangeTransparencyAndBlendMode
{
    class Program
    {
        static void Main(string[] args)
        {
            ChangeTransparencyAndBlendModeTransform tr = new ChangeTransparencyAndBlendModeTransform();
            tr.EnableExtendedOperatorInformation = true;

            PDFFixedDocument document = new PDFFixedDocument("Sample.pdf");
            PDFPageTransformer pageTransformer = new PDFPageTransformer(document.Pages[0]);
            pageTransformer.ApplyTransform(tr);
            document.Save("Sample_Transformed.pdf");
        }
    }
}
