using System;
using O2S.Components.PDF4NET;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using O2S.Components.PDF4NET.Forms;
using O2S.Components.PDF4NET.DigitalSignatures;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    /// <summary>
    /// CertifyingSignature sample.
    /// </summary>
    public class CertifyingSignature
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream formStream, X509Certificate2 certificate)
        {
            PDFFixedDocument document = new PDFFixedDocument(formStream);

            document.PDFVersion = PDFVersion.Version16;
            PDFSignatureField signField = document.Form.Fields["signhere"] as PDFSignatureField;
            PDFCmsDigitalSignature signature = new PDFCmsDigitalSignature();
            signature.SignatureDigestAlgorithm = PDFDigitalSignatureDigestAlgorithm.Sha256;
            signature.Certificate = certificate;
            signature.ContactInfo = "techsupport@o2sol.com";
            signature.Location = "Cluj Napoca";
            signature.Name = "O2 Solutions Support";
            signature.Reason = "Certifying signature";
            signField.Signature = signature;
            // Certify the document with the signature included in the field.
            document.CertifyDocument(signField, PDFDigitalSignatureAllowedChanges.AllowFormFilling);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "certifyingsignature.pdf") };
            return output;
        }
    }
}