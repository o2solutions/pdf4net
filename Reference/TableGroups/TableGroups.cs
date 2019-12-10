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
    /// TableGroups sample.
    /// </summary>
    public class TableGroups
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream verdanaFontStream, Stream verdanaBoldFontStream, Stream data)
        {
            PDFAnsiTrueTypeFont verdana = new PDFAnsiTrueTypeFont(verdanaFontStream, 1, true);
            PDFAnsiTrueTypeFont verdanaBold = new PDFAnsiTrueTypeFont(verdanaBoldFontStream, 1, true);

            PDFFlowDocument document = new PDFFlowDocument();

            PDFFlowContent header = BuildHeader(verdanaBold);
            document.AddContent(header);

            PDFFlowContent attendantsSection = BuildCountriesList(verdana, verdanaBold, data);
            document.AddContent(attendantsSection);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "tablegroups.pdf") };
            return output;
        }

        private static PDFFlowContent BuildHeader(PDFAnsiTrueTypeFont verdanaBold)
        {
            PDFAnsiTrueTypeFont headerFont = new PDFAnsiTrueTypeFont(verdanaBold);
            headerFont.Size = 16;

            PDFFlowTableContent headerTable = new PDFFlowTableContent(1);
            PDFFlowTableRow row = headerTable.Rows.AddRowWithCells("Continents, countries and populations");

            (row.Cells[0] as PDFFlowTableStringCell).Font = headerFont;
            row.Cells[0].HorizontalAlign = PDFGraphicAlign.Center;
            row.MinHeight = 40;

            return headerTable;
        }

        private static PDFFlowContent BuildCountriesList(PDFAnsiTrueTypeFont verdana, PDFAnsiTrueTypeFont verdanaBold, Stream data)
        {
            PDFAnsiTrueTypeFont textFont = new PDFAnsiTrueTypeFont(verdana);
            textFont.Size = 10;

            PDFAnsiTrueTypeFont headerFont = new PDFAnsiTrueTypeFont(verdanaBold);
            headerFont.Size = 12;

            PDFFlowTableContent countriesTable = new PDFFlowTableContent(2);
            countriesTable.Border = new PDFPen(PDFRgbColor.Black, 0.5);
            countriesTable.MinRowHeight = 15;
            (countriesTable.DefaultCell as PDFFlowTableStringCell).Font = textFont;
            countriesTable.Columns[0].VerticalAlign = PDFGraphicAlign.Center;
            countriesTable.Columns[1].VerticalAlign = PDFGraphicAlign.Center;
            countriesTable.Columns[1].HorizontalAlign = PDFGraphicAlign.Far;

            string continent = "";
            long total = 0;
            PDFFlowTableRow row = null;
            StreamReader sr = new StreamReader(data);
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] items = line.Split('|');
                long pop = long.Parse(items[2], System.Globalization.CultureInfo.InvariantCulture);
                total = total + pop;

                if (continent != items[0])
                {
                    // Add group footer
                    if (continent != "")
                    {
                        row = countriesTable.Rows.AddRowWithCells("Total population for " + continent + ": " + total.ToString("#,##0"));
                        row.Cells[0].ColSpan = 2;
                        row.Cells[0].HorizontalAlign = PDFGraphicAlign.Far;
                        (row.Cells[0] as PDFFlowTableStringCell).Font = headerFont;
                    }
                    continent = items[0];
                    total = 0;

                    // Add group header
                    row = countriesTable.Rows.AddRowWithCells(continent);
                    row.Cells[0].ColSpan = 2;
                    row.Background = new PDFBrush(PDFRgbColor.LightGray);
                    (row.Cells[0] as PDFFlowTableStringCell).Font = headerFont;
                }
                row = countriesTable.Rows.AddRowWithCells(items[1], pop.ToString("#,##0"));
                line = sr.ReadLine();
            }
            row = countriesTable.Rows.AddRowWithCells("Total population for " + continent + ": " +  total.ToString("#,##0"));
            row.Cells[0].ColSpan = 2;
            row.Cells[0].HorizontalAlign = PDFGraphicAlign.Far;
            (row.Cells[0] as PDFFlowTableStringCell).Font = headerFont;

            return countriesTable;
        }
    }
}