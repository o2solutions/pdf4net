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
    /// TableCellSpans sample.
    /// </summary>
    public class TableCellSpans
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream verdanaFontStream)
        {
            PDFAnsiTrueTypeFont textFont = new PDFAnsiTrueTypeFont(verdanaFontStream, 10, true);
            PDFAnsiTrueTypeFont headerFont = new PDFAnsiTrueTypeFont(textFont);
            headerFont.Size = 16;

            PDFFlowDocument document = new PDFFlowDocument();

            PDFFlowTableContent headerTable = new PDFFlowTableContent(1);
            PDFFlowTableRow row = headerTable.Rows.AddRowWithCells("Store sales by year");
            (row.Cells[0] as PDFFlowTableStringCell).Font = headerFont;
            row.Cells[0].HorizontalAlign = PDFGraphicAlign.Center;
            row.MinHeight = 40;
            document.AddContent(headerTable);

            PDFFlowTableContent itemsTable = new PDFFlowTableContent(4);
            (itemsTable.DefaultCell as PDFFlowTableStringCell).Font = textFont;
            itemsTable.Border = new PDFPen(PDFRgbColor.Black, 0.5);
            itemsTable.MinRowHeight = 15;
            itemsTable.Columns[2].VerticalAlign = PDFGraphicAlign.Center;
            itemsTable.Columns[3].VerticalAlign = PDFGraphicAlign.Center;
            itemsTable.Columns[3].HorizontalAlign = PDFGraphicAlign.Far;

            row = itemsTable.Rows.AddRowWithCells("Tablets", "iPad Air 2", "2013", "213,554");
            row.Cells[0].RowSpan = 12;
            row.Cells[1].RowSpan = 3;
            itemsTable.Rows.AddRowWithCells("2014", "123,443");
            itemsTable.Rows.AddRowWithCells("2015", "64,443");
            row = itemsTable.Rows.AddRowWithCells("iPad Pro", "2013", "342,443");
            row.Cells[0].RowSpan = 3;
            itemsTable.Rows.AddRowWithCells("2014", "56,332");
            itemsTable.Rows.AddRowWithCells("2015", "765,231");
            row = itemsTable.Rows.AddRowWithCells("Nexus 7", "2013", "432,541");
            row.Cells[0].RowSpan = 3;
            itemsTable.Rows.AddRowWithCells("2014", "213,871");
            itemsTable.Rows.AddRowWithCells("2015", "112,332");
            row = itemsTable.Rows.AddRowWithCells("Nexus 9", "2013", "342,434");
            row.Cells[0].RowSpan = 3;
            itemsTable.Rows.AddRowWithCells("2014", "231,778");
            itemsTable.Rows.AddRowWithCells("2015", "119,324");

            row = itemsTable.Rows.AddRowWithCells("Smartphones", "Samsung Galaxy S5", "2013", "1,543,321");
            row.Cells[0].RowSpan = 12;
            row.Cells[1].RowSpan = 3;
            itemsTable.Rows.AddRowWithCells("2014", "1,435,875");
            itemsTable.Rows.AddRowWithCells("2015", "1,876,324");
            row = itemsTable.Rows.AddRowWithCells("Samsung Galaxy S6", "2013", "1,432,134");
            row.Cells[0].RowSpan = 3;
            itemsTable.Rows.AddRowWithCells("2014", "1,232,432");
            itemsTable.Rows.AddRowWithCells("2015", "1,765,112");
            row = itemsTable.Rows.AddRowWithCells("iPhone 6", "2013", "1,433,665");
            row.Cells[0].RowSpan = 3;
            itemsTable.Rows.AddRowWithCells("2014", "2,443,245");
            itemsTable.Rows.AddRowWithCells("2015", "1,656,334");
            row = itemsTable.Rows.AddRowWithCells("iPhone 6 Plus", "2013", "994,123");
            row.Cells[0].RowSpan = 3;
            itemsTable.Rows.AddRowWithCells("2014", "443,546");
            itemsTable.Rows.AddRowWithCells("2015", "765,342");

            document.AddContent(itemsTable);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "tablecellspans.pdf") };
            return output;
        }
    }
}