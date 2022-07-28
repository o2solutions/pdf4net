using System;
using System.Collections.Generic;
using O2S.Components.PDF4NET.Graphics;

namespace O2S.Components.PDF4NET.Samples.PieChart
{
    public class PieChart
    {
        public PieChart()
        {
            parts = new List<PiePart>();
        }

        private List<PiePart> parts;

        public List<PiePart> Parts
        {
            get { return parts; }
        }

        /// <summary>
        /// Renders the chart on the specified graphics.
        /// </summary>
        /// <param name="graphics">Graphics surface where the chart will be rendered.</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Render(PDFCanvas graphics, double x, double y, double width, double height)
        {
            if (parts.Count == 0)
            {
                throw new InvalidOperationException("Pie chart has no parts.");
            }

            double partsTotal = GetPartsTotal();

            double startAngle = 90, sweepAngle, bisector = 0;

            for (int i = 0; i < parts.Count; i++)
            {
                sweepAngle = -360 * parts[i].Quantity / partsTotal;
                bisector += sweepAngle / 2;

                if (parts[i].ExplodeOffset > 0)
                {
                    graphics.SaveGraphicsState();

                    double angleFromX = (90 + bisector) * Math.PI / 180;

                    double shiftX = parts[i].ExplodeOffset * Math.Cos(angleFromX);
                    double shiftY = parts[i].ExplodeOffset * Math.Sin(angleFromX);

                    graphics.TranslateTransform(shiftX, -shiftY);
                }

                if (parts[i].DonutHeight > 0)
                {
                    graphics.DrawDonut(parts[i].Outline, parts[i].Fill, x, y, width, height, startAngle, sweepAngle, parts[i].DonutHeight);
                }
                else
                {
                    graphics.DrawPie(parts[i].Outline, parts[i].Fill, x, y, width, height, startAngle, sweepAngle);
                }

                if (parts[i].ExplodeOffset > 0)
                {
                    graphics.RestoreGraphicsState();
                }

                bisector += sweepAngle / 2;
                startAngle += sweepAngle;
            }

        }

        private double GetPartsTotal()
        {
            double total = 0;

            for (int i = 0; i < parts.Count; i++)
            {
                total += parts[i].Quantity;
            }

            return total;
        }
    }
}
