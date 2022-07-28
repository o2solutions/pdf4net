using System;
using O2S.Components.PDF4NET.Graphics;

namespace O2S.Components.PDF4NET.Samples.PieChart
{
    public class PiePart
    {
        public PiePart(double quantity)
        {
            Quantity = quantity;
        }

        private double quantity;

        public double Quantity 
        { 
            get => quantity;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Quantity must be greater than 0");
                }
                quantity = value;
            }
        }

        public PDFBrush Fill { get; set; }

        public PDFPen Outline { get; set; }

        private double explodeOffset;

        public double ExplodeOffset 
        { 
            get { return explodeOffset; }
            set
            {
                if (value < 0) 
                {
                    throw new ArgumentOutOfRangeException("ExplodeOffset must be greater than or equal to zero");
                }
                explodeOffset = value;
            }
        }

        private double donutHeight;

        public double DonutHeight
        {
            get { return donutHeight; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("DonutHeight must be greater than or equal to zero");
                }
                donutHeight = value;
            }
        }
    }
}
