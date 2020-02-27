using System;
using System.IO;
using System.Reflection;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Core.Security;
using O2S.Components.PDF4NET.Samples;
using O2S.Components.PDF4NET.Utilities;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class MergeAndEncrypt
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\SupportFiles\\";

            PDFMerger merger = new PDFMerger();
            merger.AppendFile(supportPath + "content.pdf");
            merger.AppendFile(supportPath + "formfill.pdf");
            merger.AppendFile(supportPath + "encrypted.pdf", "pdf4net");

            PDFAesSecurityHandler aes256e = new PDFAesSecurityHandler();
            aes256e.KeySize = 256;
            aes256e.UseEnhancedPasswordValidation = true;
            aes256e.UserPassword = "pdfmerger";
            merger.Save("mergeandencrypt.pdf", aes256e);

            Console.WriteLine("Merged file saved with success to current folder.");
        }
    }
}
