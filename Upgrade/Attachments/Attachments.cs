using System;
using System.Drawing;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.Fonts;
//using O2S.Components.PDF4NET.Graphics.Shapes;

namespace O2S.Samples.PDF4NET
{
	/// <summary>
	/// This sample shows how to work with document attachments using PDF4NET library.
	/// </summary>
    class Attachments
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Create a document with 2 file attachments.
            CreateAttachments();

            // Display attachments in a PDF file.
            DisplayAttachments();
        }

        /// <summary>
        /// Creates a PDF file that contains 2 file attachments.
        /// </summary>
        private static void CreateAttachments()
        {
            // Create the pdf document
            //PDF4NET v5: PDFDocument doc = new PDFDocument();
            PDFFixedDocument doc = new PDFFixedDocument();

            // Create a blank page
            //PDF4NET v5: PDFPage page = doc.AddPage();
            PDFPage page = doc.Pages.Add();
            // Print instructions about how to view the attachments in the PDF file.
            PDFBrush brush = new PDFBrush(new PDFRgbColor(0, 0, 0));
            //PDF4NET v5: PDFFont font = new PDFFont();
            PDFStandardFont font = new PDFStandardFont();
            //PDF4NET v5: page.Canvas.DrawText("This document contains 2 file attachments.", font, null, brush, 50, 50);
            page.Canvas.DrawString("This document contains 2 file attachments.", font, brush, 50, 50);
            //PDF4NET v5: page.Canvas.DrawText("In the Acrobat/Reader menu click on View > " +
            //PDF4NET v5:     "Navigation tabs > Attachments to view them.", font, null, brush, 50, 60);
            page.Canvas.DrawString("In the Acrobat/Reader menu click on View > " +
                "Navigation tabs > Attachments to view them.", font, brush, 50, 60);

            // Create an attachment for 'xfasampleform.pdf' file
            //PDF4NET v5: PDFDocumentAttachment attachment = new PDFDocumentAttachment();
            PDFDocumentFileAttachment attachment = new PDFDocumentFileAttachment();
            //PDF4NET v5: attachment.FileName = "..\\SupportFiles\\xfasampleform.pdf";
            attachment.FileName = "sample.pdf";
            attachment.Payload = File.ReadAllBytes("..\\..\\..\\..\\..\\SupportFiles\\sample.pdf");
            attachment.MimeType = "application/pdf";
            attachment.Description = "Sample PDF file";
            // Add the attachment to document.
            //PDF4NET v5: doc.Attachments.Add(attachment);
            doc.FileAttachments.Add(attachment);

            // Create an attachment for 'auto1.jpg' file
            //PDF4NET v5: attachment = new PDFDocumentAttachment();
            attachment = new PDFDocumentFileAttachment();
            //PDF4NET v5: attachment.FileName = "..\\SupportFiles\\auto1.jpg";
            attachment.FileName = "auto1.jpg";
            attachment.Payload = File.ReadAllBytes("..\\..\\..\\..\\..\\SupportFiles\\auto1.jpg");
            attachment.MimeType = "image/jpg";
            attachment.Description = "Lexus - Minority Report";
            // Add the attachment to document.
            doc.FileAttachments.Add(attachment);

            // Save the document to disk
            doc.Save("Sample_Attachments.pdf");
        }

        private static void DisplayAttachments()
        {
            // Load the PDF file that contains the attachments 
            // (use the document created by previous function)
            //PDF4NET v5: PDFDocument doc = new PDFDocument("Sample_Attachments.pdf");
            PDFFixedDocument doc = new PDFFixedDocument("Sample_Attachments.pdf");
            // Display the attachments in the document
            //PDF4NET v5: for (int i = 0; i < doc.Attachments.Count; i++)
            for (int i = 0; i < doc.FileAttachments.Count; i++)
            {
                //PDF4NET v5: Console.WriteLine("Attachment: {0}; Description: {1}; Creation Date: {2}",
                //PDF4NET v5:     doc.Attachments[i].FileName, doc.Attachments[i].Description, doc.Attachments[i].CreationDate);
                Console.WriteLine("Attachment: {0}; Description: {1}; Creation Date: {2}",
                    doc.FileAttachments[i].FileName, doc.FileAttachments[i].Description, doc.FileAttachments[i].CreationDate);
                // doc.Attachments[i].Payload contains the attachment content. 
                // It can be saved to disk if needed.
            }
        }
    }
}
