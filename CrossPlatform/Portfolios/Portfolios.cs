using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Portfolios;
using O2S.Components.PDF4NET.Core.Cos;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Portfolios sample.
    /// </summary>
    public class Portfolios
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        /// <param name="imageStream"></param>
        /// <param name="pdfStream"></param>
        /// <param name="csStream"></param>
        /// <param name="vbStream"></param>
        public static SampleOutputInfo[] Run(Stream imageStream, Stream pdfStream, Stream csStream, Stream vbStream)
        {
            PDFPortfolio portfolio = new PDFPortfolio();

            // Build the structure that describes how to files and folders in the portfolio are presented to the user.
            PDFPortfolioAttributeDefinitions portfolioAttributeDefinitions = new PDFPortfolioAttributeDefinitions();
            PDFPortfolioAttributeDefinition nameAttribute = new PDFPortfolioAttributeDefinition();
            nameAttribute.Name = "Name";
            nameAttribute.Type = PDFPortfolioAttributeDefinitionType.String;
            portfolioAttributeDefinitions["name"] = nameAttribute;
            PDFPortfolioAttributeDefinition typeAttribute = new PDFPortfolioAttributeDefinition();
            typeAttribute.Name = "Type";
            typeAttribute.Type = PDFPortfolioAttributeDefinitionType.String;
            portfolioAttributeDefinitions["type"] = typeAttribute;

            portfolio.AttributeDefinitions = portfolioAttributeDefinitions;

            // Setup the folders structure
            PDFPortfolioFolder root = new PDFPortfolioFolder();
            root.Name = "All files";
            root.PortfolioAttributes = new PDFPortfolioItemAttributes();
            root.PortfolioAttributes["name"] = new PDFCosString("All files");

            PDFPortfolioFolder imagesFolder = new PDFPortfolioFolder();
            imagesFolder.Name = "Images";
            imagesFolder.PortfolioAttributes = new PDFPortfolioItemAttributes();
            imagesFolder.PortfolioAttributes["name"] = new PDFCosString("Images (1)");
            root.Folders.Add(imagesFolder);

            PDFPortfolioFolder pdfFolder = new PDFPortfolioFolder();
            pdfFolder.Name = "PDFs";
            pdfFolder.PortfolioAttributes = new PDFPortfolioItemAttributes();
            pdfFolder.PortfolioAttributes["name"] = new PDFCosString("PDFs (1)");
            root.Folders.Add(pdfFolder);

            PDFPortfolioFolder htmlFolder = new PDFPortfolioFolder();
            htmlFolder.Name = "HTML";
            htmlFolder.PortfolioAttributes = new PDFPortfolioItemAttributes();
            htmlFolder.PortfolioAttributes["name"] = new PDFCosString("HTML (2)");
            root.Folders.Add(htmlFolder);

            portfolio.Folders.Add(root);

            // Setup the portfolio items
            PDFPortfolioItem imageFile = new PDFPortfolioItem();
            imageFile.Folder = imagesFolder;
            byte[] data = new byte[imageStream.Length];
            imageStream.Read(data, 0, data.Length);
            imageFile.Payload = data;
            imageFile.FileName = "image.jpg";
            imageFile.Attributes = new PDFPortfolioItemAttributes();
            imageFile.Attributes["name"] = new PDFCosString("image.jpg");
            imageFile.Attributes["type"] = new PDFCosString("JPEG image");
            portfolio.Items.Add(imageFile);

            PDFPortfolioItem pdfFile = new PDFPortfolioItem();
            pdfFile.Folder = pdfFolder;
            data = new byte[pdfStream.Length];
            pdfStream.Read(data, 0, data.Length);
            pdfFile.Payload = data;
            pdfFile.FileName = "content.pdf";
            pdfFile.Attributes = new PDFPortfolioItemAttributes();
            pdfFile.Attributes["name"] = new PDFCosString("content.pdf");
            pdfFile.Attributes["type"] = new PDFCosString("PDF file");
            portfolio.Items.Add(pdfFile);

            PDFPortfolioItem csFile = new PDFPortfolioItem();
            csFile.Folder = htmlFolder;
            data = new byte[csStream.Length];
            csStream.Read(data, 0, data.Length);
            csFile.Payload = data;
            csFile.FileName = "portfolios.cs.html";
            csFile.Attributes = new PDFPortfolioItemAttributes();
            csFile.Attributes["name"] = new PDFCosString("portfolios.cs.html");
            csFile.Attributes["type"] = new PDFCosString("HTML file");
            portfolio.Items.Add(csFile);

            PDFPortfolioItem vbFile = new PDFPortfolioItem();
            vbFile.Folder = htmlFolder;
            data = new byte[vbStream.Length];
            vbStream.Read(data, 0, data.Length);
            vbFile.Payload = data;
            vbFile.FileName = "portfolios.vb.html";
            vbFile.Attributes = new PDFPortfolioItemAttributes();
            vbFile.Attributes["name"] = new PDFCosString("portfolios.vb.html");
            vbFile.Attributes["type"] = new PDFCosString("HTML file");
            portfolio.Items.Add(vbFile);

            portfolio.StartupDocument = pdfFile;

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(portfolio, "portfolios.pdf") };
            return output;
        }
    }
}