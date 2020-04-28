using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Core;
using O2S.Components.PDF4NET.Core.Security;
using O2S.Components.PDF4NET.Graphics;
//using O2S.Components.PDF4NET.Graphics.Shapes;
//using O2S.Components.PDF4NET.Security;
//using O2S.Components.PDF4NET.PDFFile;

namespace O2S.Samples.PDF4NET.EditPDF
{
    /// <summary>
    /// This sample shows the pdf editing capabilities of
    /// PDF4NET library. The following features are shown:
    /// Mixing 2 different documents, merge files, 
    /// encryption of existing files,
    /// page imposition and pdf file splitting.
    /// </summary>
    class EditPDF
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Documents mix
            MixFiles();

            // Apppend files
            AppendFiles();

            // Encrypt file
            EncryptFile();

            // Split file
            SplitFile();

            // Page imposition
            MultiPage();
        }

        // For this sample to work, the following files 
        // need to exist: unicode.pdf and multicolumntextandimages.pdf.
        // Compile the corresponding samples to get these files
        public static void MixFiles()
        {
            //PDF4NET v5: PDFFile unicodeFile = PDFFile.FromFile("Sample_Unicode.pdf");
            FileStream stm1 = File.OpenRead("..\\..\\..\\..\\..\\SupportFiles\\content.pdf");
            PDFFile file1 = new PDFFile(stm1);
            //PDF4NET v5: PDFFile mctiFile = PDFFile.FromFile("Sample_MultiColumnTextAndImages.pdf");
            FileStream stm2 = File.OpenRead("..\\..\\..\\..\\..\\SupportFiles\\sample.pdf");
            PDFFile file2 = new PDFFile(stm2);
            //PDF4NET v5: PDFImportedPage ip = null;
            PDFPage ip = null;

            //PDF4NET v5: PDFDocument doc = new PDFDocument();
            PDFFixedDocument doc = new PDFFixedDocument();

            for (int i = 0; i < 4; i++)
            {
                // extract the page
                ip = file1.ExtractPage(i);

                // add the page to new document
                doc.Pages.Add(ip);

                // extract the page
                ip = file2.ExtractPage(i);

                // add the page to new document
                doc.Pages.Add(ip);
            }

            // save the mixed document
            doc.Save("Sample_Mix.pdf");

            //PDF4NET v5: unicodeFile.Close();
            stm1.Close();
            //PDF4NET v5: mctiFile.Close();
            stm2.Close();
        }

        // For this sample to work, the following files 
        // need to exist: unicode.pdf and multicolumntextandimages.pdf.
        // Compile the corresponding samples to get these files
        public static void AppendFiles()
        {
            //PDF4NET v5: PDFFile.MergeFiles("Sample_Append.pdf", new string[] { "Sample_Unicode.pdf", "Sample_MultiColumnTextAndImages.pdf" });
            PDFMerger.MergeFiles("Sample_Append.pdf", 
                "..\\..\\..\\..\\..\\SupportFiles\\content.pdf", 
                "..\\..\\..\\..\\..\\SupportFiles\\sample.pdf");

            // or
            //PDFDocument doc = 
            //	PDFFile.MergeFiles( new string[]{ "unicode.pdf", "multicolumntextandimages.pdf" } );
            ////Serial number goes here
            //doc.SerialNumber = "serial number goes here";
            //doc.Save( stream );
        }

        // For this sample to work, the following file
        // need to exist: multicolumntextandimages.pdf.
        // Compile the corresponding sample to get this file
        public static void EncryptFile()
        {
            //PDF4NET v5:
            //PDFSecurityManager securityManager = new PDFSecurityManager();
            //securityManager.KeySize = EncryptionKeySize.Use128BitKey;
            //securityManager.UserPassword = Encoding.ASCII.GetBytes("userpass");
            //securityManager.OwnerPassword = Encoding.ASCII.GetBytes("ownerpass");
            //securityManager.AllowPrint = false;
            //securityManager.FullQualityPrint = true;
            //securityManager.AllowModifyDocument = false;
            //securityManager.AllowExtractContent = false;
            //securityManager.AllowInteractiveEdit = false;
            //securityManager.AllowFormsFill = true;
            //securityManager.AllowAccessibilityExtractContent = true;
            //securityManager.AllowAssembleDocument = false;

            //PDFFile.EncryptFile(securityManager,
            //    "Sample_MultiColumnTextAndImages.pdf", "Sample_MultiColumnTextAndImages-Secure.pdf");

            PDFFixedDocument document = new PDFFixedDocument("..\\..\\..\\..\\..\\SupportFiles\\content.pdf");
            PDFAesSecurityHandler aesSecurityHandler = new PDFAesSecurityHandler();
            aesSecurityHandler.KeySize = 256;
            aesSecurityHandler.UserPassword = "userpass";
            aesSecurityHandler.OwnerPassword = "ownerpass";
            aesSecurityHandler.EnablePrint = false;
            aesSecurityHandler.HighQualityPrint = true;
            aesSecurityHandler.EnableDocumentChange = false;
            aesSecurityHandler.EnableContentExtraction = false;
            aesSecurityHandler.EnableAnnotationsAndFieldsEdit = false;
            aesSecurityHandler.EnableFormsFill = true;
            aesSecurityHandler.EnableContentExtractionForAccessibility = true;
            aesSecurityHandler.EnableDocumentAssembly = false;
            document.Save("content-secure.pdf", aesSecurityHandler);

            // or
            //PDFDocument doc = 
            //	PDFFile.EncryptFile( securityManager, "multicolumntextandimages-secure.pdf" );
            ////Serial number goes here
            //doc.SerialNumber = "serial number goes here";
            //doc.Save( stream );
        }

        // For this sample to work, the following file
        // need to exist: unicode.pdf.
        // Compile the corresponding sample to get this file
        public static void SplitFile()
        {
            //PDF4NET v5: PDFFile.SplitFile("Sample_Unicode.pdf", "Sample_Unicode-page.pdf");
            FileStream stm = File.OpenRead("..\\..\\..\\..\\..\\SupportFiles\\content.pdf");
            PDFFile file = new PDFFile(stm);

            for (int i = 0; i < file.PageCount; i++)
            {
                PDFFixedDocument document = new PDFFixedDocument();
                document.Pages.Add(file.ExtractPage(i));
                document.Save(i + ".pdf");
            }
        }

        // For this sample to work, the following file 
        // needs to exist: multicolumntextandimages.pdf.
        // Compile the corresponding sample to get this file
        public static void MultiPage()
        {
            //PDF4NET v5: PDFFile mctiFile = PDFFile.FromFile("Sample_MultiColumnTextAndImages-Secure.pdf", Encoding.ASCII.GetBytes("userpass"));
            FileStream stm = File.OpenRead("..\\..\\..\\..\\..\\SupportFiles\\content.pdf");
            PDFFile file = new PDFFile(stm);
            // extract the content of first 4 pages
            //PDF4NET v5: PDFImportedContent[] ic = mctiFile.ExtractPagesContent("0-3");
            PDFPageContent[] pc = file.ExtractPageContent(0, 3);

            // create the new document
            //PDF4NET v5: PDFDocument doc = new PDFDocument();
            PDFFixedDocument doc = new PDFFixedDocument();
            // add a page to it
            //PDF4NET v5: PDFPage page = doc.AddPage();
            PDFPage page = doc.Pages.Add();

            // draw the imported content (4 pages) on the new page
            //PDF4NET v5: page.Canvas.DrawImportedContent(ic[0], 0, 0, page.Width / 2, page.Height / 2);
            page.Canvas.DrawFormXObject(pc[0], 0, 0, page.Width / 2, page.Height / 2);
            //PDF4NET v5: page.Canvas.DrawImportedContent(ic[1], page.Width / 2, 0, page.Width / 2, page.Height / 2);
            page.Canvas.DrawFormXObject(pc[1], page.Width / 2, 0, page.Width / 2, page.Height / 2);
            //PDF4NET v5: page.Canvas.DrawImportedContent(ic[2], 0, page.Height / 2, page.Width / 2, page.Height / 2);
            page.Canvas.DrawFormXObject(pc[2], 0, page.Height / 2, page.Width / 2, page.Height / 2);
            //PDF4NET v5: page.Canvas.DrawImportedContent(ic[3], page.Width / 2, page.Height / 2, page.Width / 2, page.Height / 2);
            page.Canvas.DrawFormXObject(pc[3], page.Width / 2, page.Height / 2, page.Width / 2, page.Height / 2);

            // save the mixed document
            doc.Save("Sample_Imposition.pdf");

            //PDF4NET v5: mctiFile.Close();
            stm.Close();
        }
    }
}
