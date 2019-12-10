using System;
using O2S.Components.PDF4NET;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using O2S.Components.PDF4NET.Forms;
using O2S.Components.PDF4NET.DigitalSignatures;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Annotations;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// DigitalSignatureWithCustomAppearance sample.
    /// </summary>
    public class DigitalSignatureWithCustomAppearance
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\SupportFiles\\";

            X509Certificate2 certificate = new X509Certificate2(supportPath + "O2SolutionsDemoCertificate.pfx", "P@ssw0rd!", X509KeyStorageFlags.Exportable);
            FileStream input = File.OpenRead(supportPath + "formfill.pdf");
            PDFFixedDocument document = new PDFFixedDocument(input);
            input.Close();

            // Sign the document
            PDFSignatureField signField = document.Form.Fields["signhere"] as PDFSignatureField;
            PDFCmsDigitalSignature signature = new PDFCmsDigitalSignature();
            signature.SignatureDigestAlgorithm = PDFDigitalSignatureDigestAlgorithm.Sha256;
            signature.Certificate = certificate;
            signature.ContactInfo = "techsupport@o2sol.com";
            signature.Location = "Cluj Napoca";
            signature.Name = "O2 Solutions Support";
            signature.Reason = "Simple signature";
            signField.Signature = signature;

            // Load the signature image
            FileStream signatureImageStream = File.OpenRead(supportPath + "signature.png");
            PDFPngImage signatureImage = new PDFPngImage(signatureImageStream);
            signatureImageStream.Close();
            // Create the signature custom appearance
            PDFAnnotationAppearance aa = new PDFAnnotationAppearance(signField.Widgets[0].VisualRectangle.Width, signField.Widgets[0].VisualRectangle.Height);
            aa.Canvas.DrawImage(signatureImage, 0, 0, aa.Width, aa.Height);
            // Set the custom appearance on the signature field
            signField.Widgets[0].NormalAppearance = aa;

            using (FileStream output = File.Create("DigitalSignatureWithCustomAppearance.pdf"))
            {
                document.Save(output);
            }

        }
    }
}