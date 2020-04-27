using System;
using System.IO;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Forms;
using O2S.Components.PDF4NET.DigitalSignatures;
using O2S.Components.PDF4NET.Graphics;
//using O2S.Components.PDF4NET.Security;

namespace O2S.Samples.PDF4NET
{
    /// <summary>
    /// This sample shows how to sign a PDF file using X.509 certificates.
    /// </summary>
    class DigitalSignature
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Create the pdf document
            //PDF4NET v5: PDFDocument doc = new PDFDocument();
            PDFFixedDocument doc = new PDFFixedDocument();

            // Create a blank page
            //PDF4NET v5: PDFPage page = doc.AddPage();
            PDFPage page = doc.Pages.Add();

            // Create the signature field.
            PDFSignatureField sign = new PDFSignatureField("Signature");
            //PDF4NET v5: sign.Widgets[0].DisplayRectangle = new DisplayRectangle(50, 100, 200, 40);
            sign.Widgets[0].DisplayRectangle = new PDFDisplayRectangle(50, 100, 200, 40);
            // Create the digital signature.
            //PDF4NET v5: sign.Signature = new PDFDigitalSignature();
            PDFCmsDigitalSignature ds = new PDFCmsDigitalSignature();
            // The certificate is loaded from disk, but it also can be loaded from a certificate store.
            ds.Certificate = new X509Certificate2("..\\..\\..\\..\\..\\SupportFiles\\O2SolutionsDemoCertificate.pfx", "P@ssw0rd!", X509KeyStorageFlags.Exportable);
            ds.Location = "Romania";
            ds.Reason = "For demo";
            ds.ContactInfo = "techsupport@o2sol.com";
            sign.Signature = ds;
            page.Fields.Add(sign);

            doc.Save("Sample_DigitalSign.pdf");
        }
    }
}
