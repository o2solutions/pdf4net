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
    /// MultipleDigitalSignatures sample.
    /// </summary>
    public class MultipleDigitalSignatures
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

            using (FileStream output = File.Create("MultipleDigitalSignatures.pdf"))
            {
                document.Save(output);
            }

            // For the second signature the document must be opened in incremental update mode 
            // by passing the PDFDocumentFeatures object to PDFFixedDocument constructor
            PDFDocumentFeatures df = new PDFDocumentFeatures();
            // Do not load file attachments, new file attachments cannot be added.
            df.EnableDocumentFileAttachments = false;
            // Load form fields to support signing.
            df.EnableDocumentFormFields = true;
            // Do not load embedded JavaScript code, new JavaScript code at document level cannot be added.
            df.EnableDocumentJavaScriptFragments = false;
            // Do not load the named destinations, new named destinations cannot be created.
            df.EnableDocumentNamedDestinations = false;
            // Do not load the document outlines, new outlines cannot be created.
            df.EnableDocumentOutline = false;
            // Do not load annotations, new annotations cannot be added to existing pages.
            df.EnablePageAnnotations = true;
            // Do not load the page graphics, new graphics cannot be added to existing pages.
            df.EnablePageGraphics = false;
            // Incremental update mode requires the changes to be added to the input file
            input = File.OpenRead("MultipleDigitalSignatures.pdf");
            document = new PDFFixedDocument(input, df);
            input.Close();

            signField = new PDFSignatureField("sign2");
            document.Pages[0].Fields.Add(signField);
            signField.Widgets[0].VisualRectangle = new PDFDisplayRectangle(150, 350, 200, 60);
            signature = new PDFCmsDigitalSignature();
            signature.SignatureDigestAlgorithm = PDFDigitalSignatureDigestAlgorithm.Sha256;
            signature.Certificate = certificate;
            signature.ContactInfo = "techsupport@o2sol.com";
            signature.Location = "Cluj Napoca";
            signature.Name = "O2 Solutions Support";
            signature.Reason = "Simple signature";
            signField.Signature = signature;

            // The same file used as input must also be used as output as the Save method saves only the changes and not the entire file.
            using (FileStream output = File.Open("MultipleDigitalSignatures.pdf", FileMode.Open))
            {
                document.Save(output);
            }
        }
    }
}