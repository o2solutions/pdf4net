using System;
using System.IO;
using System.Reflection;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.DigitalSignatures;
using O2S.Components.PDF4NET.Forms;
using O2S.Components.PDF4NET.Samples;
using O2S.Components.PDF4NET.Utilities;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class SaveSignedCopy
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\SupportFiles\\";

            FileStream signedFile = File.OpenRead(supportPath + "PDF4NET.pdf");
            PDFFixedDocument document = new PDFFixedDocument(signedFile);
            PDFSignatureField signature1Field = document.Form.Fields["Signature1"] as PDFSignatureField;

            PDFComputedDigitalSignature signature1 = signature1Field.Signature as PDFComputedDigitalSignature;

            FileStream signedCopy = File.Create("PDF4NET.Signature1.Copy.pdf");
            signature1.SaveSignedCopy(signedFile, signedCopy);
            signedCopy.Flush();
            signedCopy.Close();

            Console.WriteLine("SignedCopy copy saved with success to current folder.");
        }
    }
}
