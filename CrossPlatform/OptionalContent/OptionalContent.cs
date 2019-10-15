using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Canvas.OptionalContent;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// OptionalContent sample.
    /// </summary>
    public class OptionalContent
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run()
        {
            PDFFixedDocument document = new PDFFixedDocument();
            document.OptionalContentProperties = new PDFOptionalContentProperties();

            PDFStandardFont helveticaBold  = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 18);
            PDFBrush blackBrush = new PDFBrush();
            PDFBrush greenBrush = new PDFBrush(PDFRgbColor.DarkGreen);
            PDFBrush yellowBrush = new PDFBrush(PDFRgbColor.Yellow);
            PDFPen bluePen = new PDFPen(PDFRgbColor.DarkBlue, 5);
            PDFPen redPen = new PDFPen(PDFRgbColor.DarkRed, 5);

            PDFPage page = document.Pages.Add();
            page.Canvas.DrawString("Simple optional content: the green rectangle", helveticaBold, blackBrush, 20, 50);

            PDFOptionalContentGroup ocgPage1 = new PDFOptionalContentGroup();
            ocgPage1.Name = "Page 1 - Green Rectangle";
            page.Canvas.BeginOptionalContentGroup(ocgPage1);
            page.Canvas.DrawRectangle(bluePen, greenBrush, 20, 100, 570, 400);
            page.Canvas.EndOptionalContentGroup();

            page = document.Pages.Add();
            page.Canvas.DrawString("Multipart optional content: the green rectangles", helveticaBold, blackBrush, 20, 50);

            PDFOptionalContentGroup ocgPage2 = new PDFOptionalContentGroup();
            ocgPage2.Name = "Page 2 - Green Rectangles";
            page.Canvas.BeginOptionalContentGroup(ocgPage2);
            page.Canvas.DrawRectangle(bluePen, greenBrush, 20, 200, 570, 200);
            page.Canvas.EndOptionalContentGroup();

            page.Canvas.DrawRectangle(redPen, yellowBrush, 250, 90, 110, 680);

            page.Canvas.BeginOptionalContentGroup(ocgPage2);
            page.Canvas.DrawRectangle(bluePen, greenBrush, 20, 500, 570, 200);
            page.Canvas.EndOptionalContentGroup();

            page = document.Pages.Add();
            page.Canvas.DrawString("Imbricated optional content: the green and yellow rectangles", helveticaBold, blackBrush, 20, 50);

            PDFOptionalContentGroup ocgPage31 = new PDFOptionalContentGroup();
            ocgPage31.Name = "Page 3 - Green Rectangle";
            page.Canvas.BeginOptionalContentGroup(ocgPage31);
            page.Canvas.DrawRectangle(bluePen, greenBrush, 20, 100, 570, 600);

            PDFOptionalContentGroup ocgPage32 = new PDFOptionalContentGroup();
            ocgPage32.Name = "Page 3 - Yellow Rectangle";
            page.Canvas.BeginOptionalContentGroup(ocgPage32);
            page.Canvas.DrawRectangle(redPen, yellowBrush, 100, 200, 400, 300);
            page.Canvas.EndOptionalContentGroup(); // ocgPage32

            page.Canvas.EndOptionalContentGroup(); // ocgPage31

            page = document.Pages.Add();
            page.Canvas.DrawString("Multipage optional content: the green rectangles on page 4 & 5", helveticaBold, blackBrush, 20, 50);

            PDFOptionalContentGroup ocgPage45 = new PDFOptionalContentGroup();
            ocgPage45.Name = "Page 4 & 5 - Green Rectangles";
            page.Canvas.BeginOptionalContentGroup(ocgPage45);
            page.Canvas.DrawRectangle(bluePen, greenBrush, 20, 200, 570, 200);
            page.Canvas.EndOptionalContentGroup();

            page.Canvas.DrawRectangle(redPen, yellowBrush, 250, 90, 110, 680);

            page.Canvas.BeginOptionalContentGroup(ocgPage45);
            page.Canvas.DrawRectangle(bluePen, greenBrush, 20, 500, 570, 200);
            page.Canvas.EndOptionalContentGroup();

            page = document.Pages.Add();
            page.Canvas.DrawString("Multipage optional content: continued", helveticaBold, blackBrush, 20, 50);

            page.Canvas.BeginOptionalContentGroup(ocgPage45);
            page.Canvas.DrawRectangle(bluePen, greenBrush, 20, 200, 570, 200);
            page.Canvas.EndOptionalContentGroup();

            page.Canvas.DrawRectangle(redPen, yellowBrush, 250, 90, 110, 680);

            page.Canvas.BeginOptionalContentGroup(ocgPage45);
            page.Canvas.DrawRectangle(bluePen, greenBrush, 20, 500, 570, 200);
            page.Canvas.EndOptionalContentGroup();

            // Build the display tree for the optional content, 
            // how its structure and relationships between optional content groups are presented to the user.
            PDFOptionalContentDisplayTreeNode ocgPage1Node = new PDFOptionalContentDisplayTreeNode(ocgPage1);
            document.OptionalContentProperties.DisplayTree.Nodes.Add(ocgPage1Node);
            PDFOptionalContentDisplayTreeNode ocgPage2Node = new PDFOptionalContentDisplayTreeNode(ocgPage2);
            document.OptionalContentProperties.DisplayTree.Nodes.Add(ocgPage2Node);
            PDFOptionalContentDisplayTreeNode ocgPage31Node = new PDFOptionalContentDisplayTreeNode(ocgPage31);
            document.OptionalContentProperties.DisplayTree.Nodes.Add(ocgPage31Node);
            PDFOptionalContentDisplayTreeNode ocgPage32Node = new PDFOptionalContentDisplayTreeNode(ocgPage32);
            ocgPage31Node.Nodes.Add(ocgPage32Node);
            PDFOptionalContentDisplayTreeNode ocgPage45Node = new PDFOptionalContentDisplayTreeNode(ocgPage45);
            document.OptionalContentProperties.DisplayTree.Nodes.Add(ocgPage45Node);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "optionalcontent.pdf") };
            return output;
        }
    }
}