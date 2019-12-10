using System;
using O2S.Components.PDF4NET;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using O2S.Components.PDF4NET.Forms;
using O2S.Components.PDF4NET.DigitalSignatures;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// DocumentTimeStamp sample.
    /// </summary>
    public class DocumentTimeStamp
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream formStream, SignatureTimestampNeeded onTimeStamp)
        {
            PDFFixedDocument document = new PDFFixedDocument(formStream);

            PDFSignatureField signField = document.Form.Fields["signhere"] as PDFSignatureField;
            signField.Signature = new PDFDocumentTimeStamp();
            signField.Signature.TimestampDigestAlgorithm = PDFDigitalSignatureDigestAlgorithm.Sha256;
            signField.Signature.OnSignatureTimestampNeeded += onTimeStamp;

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "documenttimestamp.pdf") };
            return output;
        }
    }
}