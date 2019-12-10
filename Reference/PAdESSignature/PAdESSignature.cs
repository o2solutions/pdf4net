using System;
using O2S.Components.PDF4NET;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using O2S.Components.PDF4NET.Forms;
using O2S.Components.PDF4NET.DigitalSignatures;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// PAdESSignature sample.
    /// </summary>
    public class PAdESSignature
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream formStream, X509Certificate2 certificate)
        {
            PDFFixedDocument document = new PDFFixedDocument(formStream);

            document.PDFVersion = PDFVersion.Version17;
            document.VersionExtension = new PDFVersionExtension("/ESIC", 2, PDFVersion.Version17);

            PDFSignatureField signField = document.Form.Fields["signhere"] as PDFSignatureField;
            PDFPadesDigitalSignature signature = new PDFPadesDigitalSignature();
            signature.SignatureDigestAlgorithm = PDFDigitalSignatureDigestAlgorithm.Sha256;
            signature.Certificate = certificate;
            signature.ContactInfo = "techsupport@o2sol.com";
            signature.Location = "Cluj Napoca";
            signature.Name = "O2 Solutions Support";
            signature.Reason = "PAdES signature";
            signField.Signature = signature;

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "padessignature.pdf") };
            return output;
        }
    }
}