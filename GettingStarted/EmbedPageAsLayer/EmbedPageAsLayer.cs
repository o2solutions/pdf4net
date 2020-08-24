using System;
using System.IO;
using O2S.Components.PDF4NET.Core;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.OptionalContent;

namespace O2S.Components.PDF4NET.Samples
{
    public class EmbedPageAsLayer
    {
        public static void Main(string[] args)
        {
            // Extract the page content from the source file.
            FileStream stream = File.OpenRead("input.pdf");
            PDFFile source = new PDFFile(stream);
            PDFPageContent pageContent = source.ExtractPageContent(0);
            stream.Close();

            PDFFixedDocument document = new PDFFixedDocument();
            document.OptionalContentProperties = new PDFOptionalContentProperties();
            PDFPage page = document.Pages.Add();

            // Create an optional content group (layer) for the extracted page content.
            PDFOptionalContentGroup ocg = new PDFOptionalContentGroup();
            ocg.Name = "Embedded page";
            ocg.VisibilityState = PDFOptionalContentGroupVisibilityState.AlwaysVisible;
            ocg.PrintState = PDFOptionalContentGroupPrintState.NeverPrint;
            // Draw the extracted page content in the layer
            page.Canvas.BeginOptionalContentGroup(ocg);
            page.Canvas.DrawFormXObject(pageContent, 0, 0, page.Width, page.Height);
            page.Canvas.EndOptionalContentGroup();

            // Build the display tree for the optional content
            PDFOptionalContentDisplayTreeNode ocgNode = new PDFOptionalContentDisplayTreeNode(ocg);
            document.OptionalContentProperties.DisplayTree.Nodes.Add(ocgNode);

            using (FileStream output = File.Create("EmbedPageAsLayer.pdf"))
            {
                document.Save(output); 
            }
        } 
    }
}
