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
    /// SimpleTable sample.
    /// </summary>
    public class SimpleTable
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream verdanaFontStream, Stream verdanaBoldFontStream, Stream data)
        {
            PDFAnsiTrueTypeFont verdana = new PDFAnsiTrueTypeFont(verdanaFontStream, 1, true);
            PDFAnsiTrueTypeFont verdanaBold = new PDFAnsiTrueTypeFont(verdanaBoldFontStream, 1, true);

            PDFFlowDocument document = new PDFFlowDocument();
            document.PageCreated += Document_PageCreated;

            PDFFlowContent header = BuildHeader(verdanaBold);
            document.AddContent(header);

            PDFFlowContent attendantsSection = BuildAttendantsList(verdana, verdanaBold, data);
            document.AddContent(attendantsSection);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "simpletable.pdf") };
            return output;
        }

        private static void Document_PageCreated(object sender, PDFFlowPageCreatedEventArgs e)
        {
            e.PageDefaults.Margins.Left = 18;
            e.PageDefaults.Margins.Right = 18;
            e.PageDefaults.Rotation = 90;
        }

        private static PDFFlowContent BuildHeader(PDFAnsiTrueTypeFont verdanaBold)
        {
            PDFAnsiTrueTypeFont headerFont = new PDFAnsiTrueTypeFont(verdanaBold);
            headerFont.Size = 36;

            PDFFlowTableContent headerTable = new PDFFlowTableContent(1);
            PDFFlowTableRow row = headerTable.Rows.AddRowWithCells("Conference attendants");

            (row.Cells[0] as PDFFlowTableStringCell).Font = headerFont;
            row.Cells[0].HorizontalAlign = PDFGraphicAlign.Center;
            row.MinHeight = 40;

            return headerTable;
        }

        private static PDFFlowContent BuildAttendantsList(PDFAnsiTrueTypeFont verdana, PDFAnsiTrueTypeFont verdanaBold, Stream data)
        {
            PDFAnsiTrueTypeFont textFont = new PDFAnsiTrueTypeFont(verdana);
            textFont.Size = 10;

            PDFAnsiTrueTypeFont headerFont = new PDFAnsiTrueTypeFont(verdanaBold);
            headerFont.Size = 12;

            PDFFlowTableContent attendantsTable = new PDFFlowTableContent(5);
            attendantsTable.Border = new PDFPen(PDFRgbColor.Black, 0.5);
            attendantsTable.MinRowHeight = 15;
            (attendantsTable.DefaultCell as PDFFlowTableStringCell).Font = textFont;
            attendantsTable.Columns[0].VerticalAlign = PDFGraphicAlign.Center;
            attendantsTable.Columns[0].Width = 120;
            attendantsTable.Columns[0].WidthIsRelativeToTable = false;
            attendantsTable.Columns[1].VerticalAlign = PDFGraphicAlign.Center;
            attendantsTable.Columns[1].Width = 210;
            attendantsTable.Columns[1].WidthIsRelativeToTable = false;
            attendantsTable.Columns[2].VerticalAlign = PDFGraphicAlign.Center;
            attendantsTable.Columns[2].Width = 100;
            attendantsTable.Columns[2].WidthIsRelativeToTable = false;
            attendantsTable.Columns[3].VerticalAlign = PDFGraphicAlign.Center;
            attendantsTable.Columns[3].Width = 190;
            attendantsTable.Columns[3].WidthIsRelativeToTable = false;
            attendantsTable.Columns[4].VerticalAlign = PDFGraphicAlign.Center;
            attendantsTable.Columns[4].Width = 130;
            attendantsTable.Columns[4].WidthIsRelativeToTable = false;

            PDFFlowTableRow row = attendantsTable.Rows.AddRowWithCells("Name", "Email", "Phone", "Company", "Country");
            for (int i = 0; i < row.Cells.Count; i++)
            {
                (row.Cells[i] as PDFFlowTableStringCell).Font = headerFont;
                (row.Cells[i] as PDFFlowTableStringCell).Color = new PDFBrush(PDFRgbColor.White);
                row.Cells[i].HorizontalAlign = PDFGraphicAlign.Center;
            }
            row.Background = new PDFBrush(PDFRgbColor.Black);

            int counter = 0;
            PDFBrush alternateBackground = new PDFBrush(PDFRgbColor.LightGray);
            StreamReader sr = new StreamReader(data);
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] items = line.Split('|');

                row = attendantsTable.Rows.AddRowWithCells(items);
                line = sr.ReadLine();

                if (counter % 2 == 0)
                {
                    row.Background = alternateBackground;
                }
                counter++;
            }

            return attendantsTable;
        }
    }
}