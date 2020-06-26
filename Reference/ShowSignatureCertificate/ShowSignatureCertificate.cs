using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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
            X509Certificate2 x509 = signature1.Certificate;

            //Print to console information contained in the certificate.
            Console.WriteLine("{0}Subject: {1}{0}", Environment.NewLine, x509.Subject);
            Console.WriteLine("{0}Issuer: {1}{0}", Environment.NewLine, x509.Issuer);
            Console.WriteLine("{0}Version: {1}{0}", Environment.NewLine, x509.Version);
            Console.WriteLine("{0}Valid Date: {1}{0}", Environment.NewLine, x509.NotBefore);
            Console.WriteLine("{0}Expiry Date: {1}{0}", Environment.NewLine, x509.NotAfter);
            Console.WriteLine("{0}Thumbprint: {1}{0}", Environment.NewLine, x509.Thumbprint);
            Console.WriteLine("{0}Serial Number: {1}{0}", Environment.NewLine, x509.SerialNumber);
            Console.WriteLine("{0}Friendly Name: {1}{0}", Environment.NewLine, x509.PublicKey.Oid.FriendlyName);
            Console.WriteLine("{0}Public Key Format: {1}{0}", Environment.NewLine, x509.PublicKey.EncodedKeyValue.Format(true));
            Console.WriteLine("{0}Raw Data Length: {1}{0}", Environment.NewLine, x509.RawData.Length);
            Console.WriteLine("{0}Certificate to string: {1}{0}", Environment.NewLine, x509.ToString(true)); 
        }
    }
}
