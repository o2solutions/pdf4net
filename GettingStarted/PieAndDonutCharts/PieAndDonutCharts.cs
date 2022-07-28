using System;
using O2S.Components.PDF4NET.Graphics;

namespace O2S.Components.PDF4NET.Samples.PieChart
{
    public class PieAndDonutCharts
    {
        static void Main(string[] args)
        {
            PDFFixedDocument document = new PDFFixedDocument();
            PDFPage page = document.Pages.Add();

            PieChart donutChart = new PieChart();
            donutChart.Parts.Add(new PiePart(60) { Fill = new PDFBrush(PDFRgbColor.Red), DonutHeight = 25 });
            donutChart.Parts.Add(new PiePart(60) { Fill = new PDFBrush(PDFRgbColor.Blue), DonutHeight = 25 });
            donutChart.Parts.Add(new PiePart(240) { Fill = new PDFBrush(PDFRgbColor.Green), DonutHeight = 25 });

            donutChart.Render(page.Canvas, 50, 50, 200, 200);

            PieChart pieChart = new PieChart();
            pieChart.Parts.Add(new PiePart(60) { Fill = new PDFBrush(PDFRgbColor.Red), ExplodeOffset = 5 });
            pieChart.Parts.Add(new PiePart(90) { Fill = new PDFBrush(PDFRgbColor.Blue) });
            pieChart.Parts.Add(new PiePart(210) { Fill = new PDFBrush(PDFRgbColor.Green) });

            pieChart.Render(page.Canvas, 300, 50, 200, 200);

            page.Canvas.CompressAndClose();

            document.Save("PieAndDonutCharts.pdf");
        }
    }
}
