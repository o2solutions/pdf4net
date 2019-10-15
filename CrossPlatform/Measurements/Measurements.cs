using System;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Spatial;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Measurements sample.
    /// </summary>
    public class Measurements
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run()
        {
            // Create the pdf document
            PDFFixedDocument document = new PDFFixedDocument();
            // Create a new page in the document
            PDFPage page = document.Pages.Add();

            PDFPen blackPen = new PDFPen(PDFRgbColor.Black, 1);
            PDFPen redPen = new PDFPen(PDFRgbColor.Red, 4);
            PDFPen greenPen = new PDFPen(PDFRgbColor.Green, 2);
            PDFBrush blackBrush = new PDFBrush(PDFRgbColor.Black);
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.Helvetica, 16);

            // Draw viewport border.
            page.Canvas.DrawRectangle(blackPen, 50, 50, 500, 500);
            // Draw the line to be measured.
            page.Canvas.DrawLine(greenPen, 70, 70, 530, 530);
            // Draw point A (line start) in the viewport.
            page.Canvas.DrawLine(redPen, 60, 70, 80, 70);
            page.Canvas.DrawLine(redPen, 70, 60, 70, 80);
            // Draw point B (line end) in the viewport.
            page.Canvas.DrawLine(redPen, 520, 530, 540, 530);
            page.Canvas.DrawLine(redPen, 530, 520, 530, 540);

            page.Canvas.DrawString("A", helvetica, blackBrush, 85, 65);
            page.Canvas.DrawString("B", helvetica, blackBrush, 505, 525);
            page.Canvas.DrawString("Viewport", helvetica, blackBrush, 50, 560);
            helvetica.Size = 10;
            page.Canvas.DrawString(
                "Open the file with Adobe Acrobat and measure the distance from A to B using the Distance tool.", 
                helvetica, blackBrush, 50, 580);
            page.Canvas.DrawString("The measured distance should be 9 mi 186 ft 1 1/4 in.", 
                helvetica, blackBrush, 50, 590);

            // Create a viewport that matches the rectangle above.
            PDFViewport vp = new PDFViewport();
            vp.Name = "Sample viewport";
            PDFPoint ll = page.ConvertVisualPointToStandardPoint(new PDFPoint(50, 50));
            PDFPoint ur = page.ConvertVisualPointToStandardPoint(new PDFPoint(550, 550));
            vp.Bounds = new PDFStandardRectangle(ll, ur);

            // Add the viewport to the page
            page.Viewports = new PDFViewportCollection();
            page.Viewports.Add(vp);

            // Create a rectilinear measure for the viewport (CAD drawing for example).
            PDFRectilinearMeasure rlm = new PDFRectilinearMeasure();
            // Attach the measure to the viewport.
            vp.Measure = rlm;
            // Set the measure scale: 1 inch (72 points) in PDF corresponds to 1 mile
            rlm.ScaleRatio = "1 in = 1 mi";

            // Create a number format that controls the display of units for X axis.
            PDFNumberFormat xNumberFormat = new PDFNumberFormat();
            xNumberFormat.MeasureUnit = "mi";
            xNumberFormat.ConversionFactor = 1/72.0; // Conversion from user space units to miles
            xNumberFormat.FractionDisplay = PDFFractionDisplay.Decimal;
            xNumberFormat.Precision = 100000;
            rlm.X = new PDFNumberFormatCollection();
            rlm.X.Add(xNumberFormat);

            // Create a chain of number formats that control the display of units for distance.
            rlm.Distance = new PDFNumberFormatCollection();
            PDFNumberFormat miNumberFormat = new PDFNumberFormat();
            miNumberFormat.MeasureUnit = "mi";
            miNumberFormat.ConversionFactor = 1; // Initial unit is miles; no conversion needed
            rlm.Distance.Add(miNumberFormat);
            PDFNumberFormat ftNumberFormat = new PDFNumberFormat();
            ftNumberFormat.MeasureUnit = "ft";
            ftNumberFormat.ConversionFactor = 5280; // Conversion from miles to feet
            rlm.Distance.Add(ftNumberFormat);
            PDFNumberFormat inNumberFormat = new PDFNumberFormat();
            inNumberFormat.MeasureUnit = "in";
            inNumberFormat.ConversionFactor = 12; // Conversion from feet to inches
            inNumberFormat.FractionDisplay = PDFFractionDisplay.Fraction;
            inNumberFormat.Denominator = 8; // Fractions of inches rounded to nearest 1/8
            rlm.Distance.Add(inNumberFormat);

            // Create a number format that controls the display of units area.
            PDFNumberFormat areaNumberFormat = new PDFNumberFormat();
            areaNumberFormat.MeasureUnit = "acres";
            areaNumberFormat.ConversionFactor = 640; // Conversion from square miles to acres
            rlm.Area = new PDFNumberFormatCollection();
            rlm.Area.Add(xNumberFormat);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "measurements.pdf") };
            return output;
        }
    }
}