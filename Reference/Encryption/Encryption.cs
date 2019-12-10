using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Content;
using O2S.Components.PDF4NET.Core.Security;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Encryption sample.
    /// </summary>
    public class Encryption
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream input)
        {
            PDFRc4SecurityHandler rc4_40 = new PDFRc4SecurityHandler();
            PDFFixedDocument document1 = EncryptRC4(40, rc4_40);
            PDFRc4SecurityHandler rc4_128 = new PDFRc4SecurityHandler();
            PDFFixedDocument document2 = EncryptRC4(128, rc4_128);

            PDFAesSecurityHandler aes128 = new PDFAesSecurityHandler();
            PDFFixedDocument document3 = EncryptAES(128, aes128);
            PDFAesSecurityHandler aes256 = new PDFAesSecurityHandler();
            PDFFixedDocument document4 = EncryptAES(256, aes256);
            PDFAesSecurityHandler aes256e = new PDFAesSecurityHandler();
            aes256e.UseEnhancedPasswordValidation = true;
            PDFFixedDocument document5 = EncryptAES(256, aes256e);
            PDFFixedDocument document6 = Decrypt(input);

            SampleOutputInfo[] output = new SampleOutputInfo[] 
                { 
                    new SampleOutputInfo(document1, "encryption.rc4.40bit.pdf", rc4_40),
                    new SampleOutputInfo(document2, "encryption.rc4.128bit.pdf", rc4_128),
                    new SampleOutputInfo(document3, "encryption.aes.128bit.pdf", aes128),
                    new SampleOutputInfo(document4, "encryption.aes.256bit.pdf", aes256),
                    new SampleOutputInfo(document5, "encryption.aes.256bit.enhanced.pdf", aes256e),
                    new SampleOutputInfo(document6, "encryption.decrypted.pdf"),
                };
            return output;
        }

        /// <summary>
        /// Generates a PDF document that is encrypted using RC4 method.
        /// </summary>
        /// <param name="keySize">The encryption key size.</param>
        /// <param name="rc4"></param>
        /// <returns></returns>
        private static PDFFixedDocument EncryptRC4(int keySize, PDFRc4SecurityHandler rc4)
        {
            PDFFixedDocument doc = new PDFFixedDocument();
            rc4.EnableContentExtractionForAccessibility = false;
            rc4.EnableDocumentAssembly = false;
            rc4.EnableDocumentChange = false;
            rc4.EnableContentExtraction = false;
            rc4.EnableFormsFill = false;
            rc4.EnableAnnotationsAndFieldsEdit = false;
            rc4.EnablePrint = false;
            rc4.EncryptMetadata = true;
            rc4.KeySize = keySize;
            rc4.UserPassword = "userpass";
            rc4.OwnerPassword = "ownerpass";

            PDFPage page = doc.Pages.Add();
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.HelveticaBoldItalic, 16);
            PDFBrush blackBrush = new PDFBrush();
            page.Canvas.DrawString(string.Format("Encryption: RC4 {0} bit", keySize), helvetica, blackBrush, 50, 100);

            return doc;
        }

        /// <summary>
        /// Generates a PDF document that is encrypted using AES method.
        /// </summary>
        /// <param name="keySize">The encryption key size.</param>
        /// <param name="aes"></param>
        /// <returns></returns>
        private static PDFFixedDocument EncryptAES(int keySize, PDFAesSecurityHandler aes)
        {
            PDFFixedDocument doc = new PDFFixedDocument();
            aes.EnableContentExtractionForAccessibility = false;
            aes.EnableDocumentAssembly = false;
            aes.EnableDocumentChange = false;
            aes.EnableContentExtraction = false;
            aes.EnableFormsFill = false;
            aes.EnableAnnotationsAndFieldsEdit = false;
            aes.EnablePrint = false;
            aes.EncryptMetadata = true;
            aes.KeySize = keySize;
            aes.UserPassword = "userpass";
            aes.OwnerPassword = "ownerpass";

            PDFPage page = doc.Pages.Add();
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.HelveticaBoldItalic, 16);
            PDFBrush blackBrush = new PDFBrush();

            string text = string.Format("Encryption: AES {0} bit", keySize);
            if ((aes.KeySize == 256) && aes.UseEnhancedPasswordValidation)
            {
                text = text + " with enhanced password validation (Acrobat X or later)";
            }
            page.Canvas.DrawString(text, helvetica, blackBrush, 50, 100);

            return doc;
        }

        /// <summary>
        /// Decrypts a PDF file
        /// </summary>
        /// <param name="input">Input stream.</param>
        /// <returns></returns>
        private static PDFFixedDocument Decrypt(Stream input)
        {
            PDFFixedDocument doc = new PDFFixedDocument(input, "pdf4net");

            PDFPage page = doc.Pages[0];
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.HelveticaBoldItalic, 16);
            PDFBrush blackBrush = new PDFBrush();
            page.Canvas.DrawString("Decrypted document", helvetica, blackBrush, 5, 5);

            return doc;
        }
    }
}