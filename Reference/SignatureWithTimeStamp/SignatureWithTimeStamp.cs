using System;
using O2S.Components.PDF4NET;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using O2S.Components.PDF4NET.Forms;
using O2S.Components.PDF4NET.DigitalSignatures;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// SignatureWithTimeStamp sample.
    /// </summary>
    public class SignatureWithTimeStamp
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream formStream, X509Certificate2 certificate, SignatureTimestampNeeded onTimeStamp)
        {
            PDFFixedDocument document = new PDFFixedDocument(formStream);

            PDFSignatureField signField = document.Form.Fields["signhere"] as PDFSignatureField;
            PDFCmsDigitalSignature signature = new PDFCmsDigitalSignature();
            signature.SignatureDigestAlgorithm = PDFDigitalSignatureDigestAlgorithm.Sha256;
            signature.Certificate = certificate;
            signature.ContactInfo = "techsupport@o2sol.com";
            signature.Location = "Cluj Napoca";
            signature.Name = "O2 Solutions Support";
            signature.Reason = "Signature with timestamp";
            signature.OnSignatureTimestampNeeded += onTimeStamp;
            signField.Signature = signature;

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "signaturewithtimestamp.pdf") };
            return output;
        }
    }
}