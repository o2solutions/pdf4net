using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Actions;
using O2S.Components.PDF4NET.FlowDocument;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.FormattedContent;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Invoice sample.
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream verdanaFontStream, Stream verdanaBoldFontStream, Stream logoImageStream)
        {
            PDFAnsiTrueTypeFont verdana = new PDFAnsiTrueTypeFont(verdanaFontStream, 10, true);
            PDFAnsiTrueTypeFont verdanaBold = new PDFAnsiTrueTypeFont(verdanaBoldFontStream, 10, true);
            PDFPngImage logoImage = new PDFPngImage(logoImageStream);

            PDFFlowDocument document = new PDFFlowDocument();

            PDFFlowContent header = BuildHeader(verdana, logoImage);
            document.AddContent(header);

            PDFFlowContent sellerSection = BuildSellerSection(verdana, verdanaBold);
            document.AddContent(sellerSection);

            PDFFlowContent invoiceInfoSection = BuildInvoiceInfoSection(verdana, verdanaBold);
            document.AddContent(invoiceInfoSection);

            PDFFlowContent buyerSection = BuildBuyerSection(verdana, verdanaBold);
            document.AddContent(buyerSection);

            PDFFlowContent invoiceItemsSection = BuildInvoiceItemsSection(verdana, verdanaBold);
            document.AddContent(invoiceItemsSection);

            PDFFlowContent endSection = BuildEndSection(verdana);
            document.AddContent(endSection);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "invoice.pdf") };
            return output;
        }

        private static PDFFlowContent BuildHeader(PDFAnsiTrueTypeFont verdana, PDFImage logoImage)
        {
            PDFFlowTableContent headerTable = new PDFFlowTableContent(2);
            PDFFlowTableRow row = headerTable.Rows.AddRowWithCells("Invoice", logoImage);

            PDFAnsiTrueTypeFont headerFont = new PDFAnsiTrueTypeFont(verdana);
            headerFont.Size = 36;
            (row.Cells[0] as PDFFlowTableStringCell).Font = headerFont;
            row.Cells[0].VerticalAlign = PDFGraphicAlign.Center;
            row.Cells[1].HorizontalAlign = PDFGraphicAlign.Far;
            (row.Cells[1] as PDFFlowTableImageCell).ImageWidth = 135;

            return headerTable;
        }

        private static PDFFlowContent BuildSellerSection(PDFAnsiTrueTypeFont verdana, PDFAnsiTrueTypeFont verdanaBold)
        {
            PDFAnsiTrueTypeFont labelFont = new PDFAnsiTrueTypeFont(verdanaBold);
            labelFont.Size = 12;
            PDFAnsiTrueTypeFont contentFont = new PDFAnsiTrueTypeFont(verdana);
            contentFont.Size = 12;

            PDFFormattedContent sellerInfo = new PDFFormattedContent();
            sellerInfo.Paragraphs.Add(new PDFFormattedTextBlock("DemoCompany LLC", contentFont));
            sellerInfo.Paragraphs.Add(new PDFFormattedTextBlock("3000 Alandala Road", contentFont));
            sellerInfo.Paragraphs.Add(new PDFFormattedTextBlock("Beverly Hills", contentFont));
            sellerInfo.Paragraphs.Add(new PDFFormattedTextBlock("CA 90210", contentFont));
            sellerInfo.Paragraphs.Add(new PDFFormattedTextBlock("United States", contentFont));
            sellerInfo.Paragraphs.Add(" ");

            PDFFormattedTextBlock labelPhone = new PDFFormattedTextBlock("Phone: ", labelFont);
            PDFFormattedTextBlock phone = new PDFFormattedTextBlock("+1-555-123-4567", contentFont);
            sellerInfo.Paragraphs.Add(labelPhone, phone);

            PDFFormattedTextBlock labelFax = new PDFFormattedTextBlock("Fax: ", labelFont);
            PDFFormattedTextBlock fax = new PDFFormattedTextBlock("+1-555-456-7890", contentFont);
            sellerInfo.Paragraphs.Add(labelFax, fax);

            PDFFormattedTextBlock labelEmail = new PDFFormattedTextBlock("Email: ", labelFont);
            PDFFormattedTextBlock email = new PDFFormattedTextBlock("support@o2sol.com", contentFont);
            email.TextColor = new PDFBrush(PDFRgbColor.Blue);
            email.Action = new PDFUriAction("mailto:support@o2sol.com");
            sellerInfo.Paragraphs.Add(labelEmail, email);

            PDFFormattedTextBlock labelWeb = new PDFFormattedTextBlock("Web: ", labelFont);
            PDFFormattedTextBlock web = new PDFFormattedTextBlock("www.o2sol.com", contentFont);
            web.TextColor = new PDFBrush(PDFRgbColor.Blue);
            web.Action = new PDFUriAction("http://www.o2sol.com");
            sellerInfo.Paragraphs.Add(labelWeb, web);

            for (int i = 0; i < sellerInfo.Paragraphs.Count; i++)
            {
                sellerInfo.Paragraphs[i].HorizontalAlign = PDFStringHorizontalAlign.Right;
            }
            PDFFlowTextContent sellerInfoText = new PDFFlowTextContent(sellerInfo);

            return sellerInfoText;
        }

        private static PDFFlowContent BuildInvoiceInfoSection(PDFAnsiTrueTypeFont verdana, PDFAnsiTrueTypeFont verdanaBold)
        {
            PDFAnsiTrueTypeFont labelFont = new PDFAnsiTrueTypeFont(verdanaBold);
            labelFont.Size = 12;
            PDFAnsiTrueTypeFont contentFont = new PDFAnsiTrueTypeFont(verdana);
            contentFont.Size = 12;

            PDFFlowTableContent invoiceInfoTable = new PDFFlowTableContent(2);
            invoiceInfoTable.Columns[0].Width = 120;
            invoiceInfoTable.Columns[0].WidthIsRelativeToTable = false;
            (invoiceInfoTable.DefaultCell as PDFFlowTableStringCell).Font = contentFont;
            PDFFlowTableRow row = invoiceInfoTable.Rows.AddRowWithCells(" ", " ");
            row = invoiceInfoTable.Rows.AddRowWithCells("Date", "15 March 2016");
            (row.Cells[0] as PDFFlowTableStringCell).Font = labelFont;
            row = invoiceInfoTable.Rows.AddRowWithCells("Invoice number:", "1234567890");
            (row.Cells[0] as PDFFlowTableStringCell).Font = labelFont;
            row = invoiceInfoTable.Rows.AddRowWithCells("Currency:", "USD (US Dollars)");
            (row.Cells[0] as PDFFlowTableStringCell).Font = labelFont;

            return invoiceInfoTable;
        }

        private static PDFFlowContent BuildBuyerSection(PDFAnsiTrueTypeFont verdana, PDFAnsiTrueTypeFont verdanaBold)
        {
            PDFAnsiTrueTypeFont headerFont = new PDFAnsiTrueTypeFont(verdana);
            headerFont.Size = 20;
            PDFAnsiTrueTypeFont labelFont = new PDFAnsiTrueTypeFont(verdanaBold);
            labelFont.Size = 12;
            PDFAnsiTrueTypeFont contentFont = new PDFAnsiTrueTypeFont(verdana);
            contentFont.Size = 12;

            PDFFormattedContent buyerInfo = new PDFFormattedContent();
            buyerInfo.Paragraphs.Add(new PDFFormattedTextBlock(" ", headerFont));
            buyerInfo.Paragraphs.Add(new PDFFormattedTextBlock("Invoice to:", headerFont));
            buyerInfo.Paragraphs.Add(new PDFFormattedTextBlock(" ", headerFont));
            buyerInfo.Paragraphs.Add(new PDFFormattedTextBlock("Contoso LLC", contentFont));
            buyerInfo.Paragraphs.Add(new PDFFormattedTextBlock("1000 Summer Road", contentFont));
            buyerInfo.Paragraphs.Add(new PDFFormattedTextBlock("London", contentFont));
            buyerInfo.Paragraphs.Add(new PDFFormattedTextBlock("1A2 3B4", contentFont));
            buyerInfo.Paragraphs.Add(new PDFFormattedTextBlock("United Kingdom", contentFont));
            buyerInfo.Paragraphs.Add(" ");

            PDFFormattedTextBlock labelVAT = new PDFFormattedTextBlock("Your VAT/Tax number: ", labelFont);
            PDFFormattedTextBlock vat = new PDFFormattedTextBlock("GB1234567890", contentFont);
            buyerInfo.Paragraphs.Add(labelVAT, vat);
            buyerInfo.Paragraphs.Add(new PDFFormattedTextBlock(" ", headerFont));

            PDFFlowTextContent buyerInfoText = new PDFFlowTextContent(buyerInfo);

            return buyerInfoText;
        }

        private static PDFFlowContent BuildInvoiceItemsSection(PDFAnsiTrueTypeFont verdana, PDFAnsiTrueTypeFont verdanaBold)
        {
            PDFAnsiTrueTypeFont labelFont = new PDFAnsiTrueTypeFont(verdanaBold);
            labelFont.Size = 12;
            PDFAnsiTrueTypeFont contentFont = new PDFAnsiTrueTypeFont(verdana);
            contentFont.Size = 12;

            PDFFlowTableContent invoiceInfoTable = new PDFFlowTableContent(5);
            invoiceInfoTable.MinRowHeight = 20;
            invoiceInfoTable.Columns[0].VerticalAlign = PDFGraphicAlign.Center;
            invoiceInfoTable.Columns[0].Width = 250;
            invoiceInfoTable.Columns[0].WidthIsRelativeToTable = false;
            invoiceInfoTable.Columns[1].HorizontalAlign = PDFGraphicAlign.Far;
            invoiceInfoTable.Columns[1].VerticalAlign = PDFGraphicAlign.Center;
            invoiceInfoTable.Columns[1].Width = 50;
            invoiceInfoTable.Columns[1].WidthIsRelativeToTable = false;
            invoiceInfoTable.Columns[2].VerticalAlign = PDFGraphicAlign.Center;
            invoiceInfoTable.Columns[2].HorizontalAlign = PDFGraphicAlign.Far;
            invoiceInfoTable.Columns[2].Width = 80;
            invoiceInfoTable.Columns[2].WidthIsRelativeToTable = false;
            invoiceInfoTable.Columns[3].HorizontalAlign = PDFGraphicAlign.Far;
            invoiceInfoTable.Columns[3].VerticalAlign = PDFGraphicAlign.Center;
            invoiceInfoTable.Columns[3].Width = 80;
            invoiceInfoTable.Columns[3].WidthIsRelativeToTable = false;
            invoiceInfoTable.Columns[4].HorizontalAlign = PDFGraphicAlign.Far;
            invoiceInfoTable.Columns[4].VerticalAlign = PDFGraphicAlign.Center;
            invoiceInfoTable.Columns[4].Width = 80;
            invoiceInfoTable.Columns[4].WidthIsRelativeToTable = false;
            (invoiceInfoTable.DefaultCell as PDFFlowTableStringCell).Font = contentFont;

            PDFFlowTableRow row = invoiceInfoTable.Rows.AddRowWithCells("Description", "Qty", "Price", "Total", "VAT/Tax");
            for (int i = 0; i < row.Cells.Count; i++)
            {
                (row.Cells[i] as PDFFlowTableStringCell).Font = labelFont;
                (row.Cells[i] as PDFFlowTableStringCell).Color = new PDFBrush(PDFRgbColor.White);
            }
            row.Background = new PDFBrush(PDFRgbColor.Black);
            row = invoiceInfoTable.Rows.AddRowWithCells("Sample green item", "1", "100.00", "100.00", "20.00");
            row.Background = new PDFBrush(PDFRgbColor.LightGray);
            row = invoiceInfoTable.Rows.AddRowWithCells("Big pink box", "3", "250.00", "750.00", "150.00");
            row = invoiceInfoTable.Rows.AddRowWithCells("Yellow glass bowl", "2", "200.00", "400.00", "80.00");
            row.Background = new PDFBrush(PDFRgbColor.LightGray);
            row = invoiceInfoTable.Rows.AddRowWithCells("Total", "", "", "1250.00", "250.00");
            row = invoiceInfoTable.Rows.AddRowWithCells("Total (including VAT/Tax)", "", "", "1500.00", "");
            (row.Cells[0] as PDFFlowTableStringCell).Font = labelFont;
            (row.Cells[3] as PDFFlowTableStringCell).Font = labelFont;

            return invoiceInfoTable;
        }

        private static PDFFlowContent BuildEndSection(PDFAnsiTrueTypeFont verdana)
        {
            PDFAnsiTrueTypeFont headerFont = new PDFAnsiTrueTypeFont(verdana);
            headerFont.Size = 20;
            PDFAnsiTrueTypeFont contentFont = new PDFAnsiTrueTypeFont(verdana);
            contentFont.Size = 12;

            PDFFormattedContent endInfo = new PDFFormattedContent();
            endInfo.Paragraphs.Add(new PDFFormattedTextBlock(" ", headerFont));
            endInfo.Paragraphs.Add(new PDFFormattedTextBlock("PAID IN FULL by credit card.", headerFont));
            endInfo.Paragraphs.Add(new PDFFormattedTextBlock(" ", headerFont));

            PDFFormattedTextBlock text1 = new PDFFormattedTextBlock("If you have any queries regarding this Invoice, please contact ", contentFont);
            PDFFormattedTextBlock email = new PDFFormattedTextBlock("sales@o2sol.com", contentFont);
            PDFFormattedTextBlock text2 = new PDFFormattedTextBlock(" quoting the Invoice Number above.", contentFont);
            email.TextColor = new PDFBrush(PDFRgbColor.Blue);
            email.Action = new PDFUriAction("mailto:sales@o2sol.com");
            endInfo.Paragraphs.Add(text1, email, text2);

            PDFFlowTextContent endInfoText = new PDFFlowTextContent(endInfo);

            return endInfoText;
        }
    }
}