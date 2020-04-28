using System;
using System.Text;
using System.Drawing;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
//using O2S.Components.PDF4NET.Graphics.Shapes;
//using O2S.Components.PDF4NET.Security;
using O2S.Components.PDF4NET.Graphics.Fonts;
using O2S.Components.PDF4NET.Core.Security;

namespace O2S.Samples.PDF4NET.Encryption
{
    /// <summary>
    /// This sample shows how to use the pdf 
    /// security features of PDF4NET library
    /// </summary>
    class Encryption
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Create the pdf document
            //PDF4NET v5: PDFDocument pdfDoc = new PDFDocument();
            PDFFixedDocument pdfDoc = new PDFFixedDocument();

            // set the security options
            //PDF4NET v5: pdfDoc.SecurityManager = new PDFSecurityManager();
            PDFAesSecurityHandler aesSecurityHandler = new PDFAesSecurityHandler();
            // use 128 bit encryption
            //PDF4NET v5: pdfDoc.SecurityManager.KeySize = EncryptionKeySize.Use128BitKey;
            aesSecurityHandler.KeySize = 256;
            // set user password to "userpass"
            //PDF4NET v5: pdfDoc.SecurityManager.UserPassword = Encoding.ASCII.GetBytes("userpass");
            aesSecurityHandler.UserPassword = "userpass";
            // set owner password to "ownerpass"
            //PDF4NET v5: pdfDoc.SecurityManager.OwnerPassword = Encoding.ASCII.GetBytes("ownerpass");
            aesSecurityHandler.OwnerPassword = "ownerpass";
            // allow to print the pdf document
            //PDF4NET v5: pdfDoc.SecurityManager.AllowPrint = true;
            aesSecurityHandler.EnablePrint = true;
            // do not allow high quality print
            //PDF4NET v5: pdfDoc.SecurityManager.FullQualityPrint = false;
            aesSecurityHandler.HighQualityPrint = false;
            // do not alow to modify the document
            //PDF4NET v5: pdfDoc.SecurityManager.AllowModifyDocument = false;
            aesSecurityHandler.EnableDocumentChange = false;
            // do not allow to extract content (text and images) from the document
            //PDF4NET v5: pdfDoc.SecurityManager.AllowExtractContent = false;
            aesSecurityHandler.EnableContentExtraction = false;
            // do not allow to fill forms or to create annotations
            //PDF4NET v5: pdfDoc.SecurityManager.AllowInteractiveEdit = false;
            aesSecurityHandler.EnableAnnotationsAndFieldsEdit = false;
            // do not allow forms fill
            //PDF4NET v5: pdfDoc.SecurityManager.AllowFormsFill = false;
            aesSecurityHandler.EnableFormsFill = false;
            // allow to extract content in support for accessibility
            //PDF4NET v5: pdfDoc.SecurityManager.AllowAccessibilityExtractContent = true;
            aesSecurityHandler.EnableContentExtractionForAccessibility = true;
            // do not allow to assemble document
            //PDF4NET v5: pdfDoc.SecurityManager.AllowAssembleDocument = false;
            aesSecurityHandler.EnableDocumentAssembly = false;

            // Create one page
            //PDF4NET v5: PDFPage pdfPage = pdfDoc.AddPage();
            PDFPage pdfPage = pdfDoc.Pages.Add();

            // Draw "Encrypted Hello world" in the center of the page
            //PDF4NET v5:
            //pdfPage.Canvas.DrawText("Encrypted",
            //    new PDFFont(PDFFontFace.Helvetica, 100), new PDFPen(new PDFRgbColor(255, 0, 0), 1),
            //    new PDFBrush(new PDFRgbColor(0, 0, 255)), pdfPage.Width / 2, pdfPage.Height / 2 - 3,
            //    0, PDFTextAlign.BottomCenter);
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.X = pdfPage.Width / 2;
            slo.Y = pdfPage.Height / 2 - 3;
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Bottom;
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Font = new PDFStandardFont(PDFStandardFontFace.Helvetica, 100);
            sao.Pen = new PDFPen(new PDFRgbColor(255, 0, 0), 1);
            sao.Brush = new PDFBrush(new PDFRgbColor(0, 0, 255));
            pdfPage.Canvas.DrawString("Encrypted", sao, slo);
            slo.Y = pdfPage.Height / 2 + 3;
            slo.VerticalAlign = PDFStringVerticalAlign.Top;
            pdfPage.Canvas.DrawString("Hello world !", sao, slo); 

            // Save the document to disk
            //PDF4NET v5:pdfDoc.Save("Sample_Encryption.pdf");
            pdfDoc.Save("Sample_Encryption.pdf", aesSecurityHandler);
        }
    }
}
