using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// FileAttachments sample.
    /// </summary>
    public class FileAttachments
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream s1, Stream s2)
        {
            PDFFixedDocument document = new PDFFixedDocument();
            document.DisplayMode = PDFDisplayMode.UseAttachments;

            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.Helvetica, 16);
            PDFBrush blackBrush = new PDFBrush();
            PDFPage page = document.Pages.Add();
            page.Canvas.DrawString("This document contains 2 file attachments:", helvetica, blackBrush, 50, 50);
            page.Canvas.DrawString("1. fileattachments.cs.html", helvetica, blackBrush, 50, 70);
            page.Canvas.DrawString("2. fileattachments.vb.html", helvetica, blackBrush, 50, 90);

            byte[] fileData1 = new byte[s1.Length];
            s1.Read(fileData1, 0, fileData1.Length);
            PDFDocumentFileAttachment fileAttachment1 = new PDFDocumentFileAttachment();
            fileAttachment1.Payload = fileData1;
            fileAttachment1.FileName = "fileattachments.cs.html";
            fileAttachment1.Description = "C# Source Code for FileAttachments sample";
            document.FileAttachments.Add(fileAttachment1);

            byte[] fileData2 = new byte[s2.Length];
            s2.Read(fileData2, 0, fileData2.Length);
            PDFDocumentFileAttachment fileAttachment2 = new PDFDocumentFileAttachment();
            fileAttachment2.Payload = fileData1;
            fileAttachment2.FileName = "fileattachments.vb.html";
            fileAttachment2.Description = "VB.NET Source Code for FileAttachments sample";
            document.FileAttachments.Add(fileAttachment2);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "fileattachments.pdf") };
            return output;
        }
    }
}