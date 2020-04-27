using System;
using System.IO;
//using System.Text;
using O2S.Components.PDF4NET;
//using O2S.Components.PDF4NET.Functions;
using O2S.Components.PDF4NET.Graphics;
//using O2S.Components.PDF4NET.Graphics.Shapes;
//using O2S.Components.PDF4NET.Graphics.ColorSpaces;
using O2S.Components.PDF4NET.Graphics.Fonts;
using O2S.Components.PDF4NET.PDFFunctions;

namespace O2S.Samples.PDF4NET
{
    /// <summary>
    /// This sample shows how to work with various PDF colorspaces when creating a PDF document.
    /// </summary>
    class ColorSpaces
    {
        [STAThread]
        static void Main(string[] args)
        {
            //PDF4NET v5: PDFDocument doc = new PDFDocument();
            PDFFixedDocument doc = new PDFFixedDocument();

            //PDF4NET v5: PDFPage page = doc.AddPage();
            PDFPage page = doc.Pages.Add();
            DrawDeviceColorSpace(page);

            //PDF4NET v5: page = doc.AddPage();
            page = doc.Pages.Add();
            DrawIndexedColorSpace(page);

            //PDF4NET v5: page = doc.AddPage();
            page = doc.Pages.Add();
            DrawCalGrayColorSpace(page);

            //PDF4NET v5: page = doc.AddPage();
            page = doc.Pages.Add();
            DrawCalRgbColorSpace(page);

            //PDF4NET v5: page = doc.AddPage();
            page = doc.Pages.Add();
            DrawLabColorSpace(page);

            //PDF4NET v5: page = doc.AddPage();
            page = doc.Pages.Add();
            DrawICCColorSpace(page);

            //PDF4NET v5: page = doc.AddPage();
            page = doc.Pages.Add();
            DrawSeparationColorSpace(page);

            doc.Save("Sample_ColorSpaces.pdf");
        }

        /// <summary>
        /// Draws content on a page using colors created from a device colorspace.
        /// </summary>
        /// <param name="page">The page to draw to.</param>
        /// <remarks>RGB, CMYK and Gray are device colorspaces. 
        /// The PDFRgbColor, PDFCmykColor and PDFGrayColor classes create automatically the
        /// required colorspaces.</remarks>
        private static void DrawDeviceColorSpace(PDFPage page)
        {
            PDFRgbColor black = new PDFRgbColor(0, 0, 0);
            PDFBrush blackBrush = new PDFBrush(black);
            //PDF4NET v5: PDFFont font = new PDFFont(PDFFontFace.Helvetica, 16);
            PDFStandardFont font = new PDFStandardFont(PDFStandardFontFace.Helvetica, 16);

            //PDF4NET v5: page.Canvas.DrawText("Device colorspaces: RGB, CMYK and Gray", font, null, blackBrush, 50, 50);
            page.Canvas.DrawString("Device colorspaces: RGB, CMYK and Gray", font, blackBrush, 50, 50);

            // Draw RGB content.
            //PDF4NET v5: page.Canvas.DrawText("RGB", font, null, blackBrush, 50, 80);
            page.Canvas.DrawString("RGB", font, blackBrush, 50, 80);
            PDFRgbColor red = new PDFRgbColor(255, 0, 0);
            PDFRgbColor blue = new PDFRgbColor(0, 0, 255);
            PDFBrush redBrush = new PDFBrush(red);
            PDFPen bluePen = new PDFPen(blue, 5);
            page.Canvas.DrawRoundRectangle(bluePen, redBrush, 50, 100, 400, 150, 20, 20);

            // Draw CMYK content.
            //PDF4NET v5: page.Canvas.DrawText("CMYK", font, null, blackBrush, 50, 280);
            page.Canvas.DrawString("CMYK", font, blackBrush, 50, 280);
            PDFCmykColor cyan = new PDFCmykColor(1, 0, 0, 0);
            PDFCmykColor magenta = new PDFCmykColor(0, 1, 0, 0);
            PDFBrush cyanBrush = new PDFBrush(cyan);
            PDFPen magentaPen = new PDFPen(magenta, 5);
            page.Canvas.DrawRoundRectangle(magentaPen, cyanBrush, 50, 300, 400, 150, 20, 20);

            // Draw Gray content.
            //PDF4NET v5: page.Canvas.DrawText("Gray", font, null, blackBrush, 50, 480);
            page.Canvas.DrawString("Gray", font, blackBrush, 50, 480);
            PDFGrayColor lightGray = new PDFGrayColor(0.85);
            PDFGrayColor darkGray = new PDFGrayColor(0.1);
            PDFBrush lgBrush = new PDFBrush(lightGray);
            PDFPen dgPen = new PDFPen(darkGray, 5);
            page.Canvas.DrawRoundRectangle(dgPen, lgBrush, 50, 500, 400, 150, 20, 20);
        }

        /// <summary>
        /// Draws content on a page using colors created from an indexed colorspace.
        /// </summary>
        /// <param name="page">The page to draw to.</param>
        private static void DrawIndexedColorSpace(PDFPage page)
        {
            PDFRgbColor black = new PDFRgbColor(0, 0, 0);
            PDFBrush blackBrush = new PDFBrush(black);
            //PDF4NET v5: PDFFont font = new PDFFont(PDFFontFace.Helvetica, 16);
            PDFStandardFont font = new PDFStandardFont(PDFStandardFontFace.Helvetica, 16);

            //PDF4NET v5: page.Canvas.DrawText("Indexed colorspace with 2 colors", font, null, blackBrush, 50, 50);
            page.Canvas.DrawString("Indexed colorspace with 2 colors", font, blackBrush, 50, 50);

            // Create an indexed colorspace with 2 RGB colors, 24bits (3*8bytes) per color.
            PDFIndexedColorSpace ixCS = new PDFIndexedColorSpace();
            //PDF4NET v5: ixCS.MaxIndex = 1;
            ixCS.ColorCount = 2;
            ixCS.ColorTable = new byte[] { 255, 0, 0, 192, 0, 255 };
            PDFIndexedColor red = new PDFIndexedColor(ixCS);
            red.ColorIndex = 0;
            PDFIndexedColor violet = new PDFIndexedColor(ixCS);
            violet.ColorIndex = 1;
            PDFBrush redBrush = new PDFBrush(red);
            PDFPen violetPen = new PDFPen(violet, 5);
            page.Canvas.DrawRoundRectangle(violetPen, redBrush, 50, 100, 400, 150, 20, 20);
        }

        /// <summary>
        /// Draws content on a page using colors created from a calibrated gray colorspace.
        /// </summary>
        /// <param name="page">The page to draw to.</param>
        private static void DrawCalGrayColorSpace(PDFPage page)
        {
            PDFRgbColor black = new PDFRgbColor(0, 0, 0);
            PDFBrush blackBrush = new PDFBrush(black);
            //PDF4NET v5: PDFFont font = new PDFFont(PDFFontFace.Helvetica, 16);
            PDFStandardFont font = new PDFStandardFont(PDFStandardFontFace.Helvetica, 16);

            //PDF4NET v5: page.Canvas.DrawText("CalGray colorspace", font, null, blackBrush, 50, 50);
            page.Canvas.DrawString("CalGray colorspace", font, blackBrush, 50, 50);

            PDFCalGrayColorSpace calGrayCS = new PDFCalGrayColorSpace();
            PDFCalGrayColor dkGray = new PDFCalGrayColor(calGrayCS);
            dkGray.Gray = 0.1;
            PDFCalGrayColor ltGray = new PDFCalGrayColor(calGrayCS);
            ltGray.Gray = 0.8;
            PDFBrush dkBrush = new PDFBrush(dkGray);
            PDFPen ltPen = new PDFPen(ltGray, 5);
            page.Canvas.DrawRoundRectangle(ltPen, dkBrush, 50, 100, 400, 150, 20, 20);
        }

        /// <summary>
        /// Draws content on a page using colors created from a calibrated RGB colorspace.
        /// </summary>
        /// <param name="page">The page to draw to.</param>
        private static void DrawCalRgbColorSpace(PDFPage page)
        {
            PDFRgbColor black = new PDFRgbColor(0, 0, 0);
            PDFBrush blackBrush = new PDFBrush(black);
            //PDF4NET v5: PDFFont font = new PDFFont(PDFFontFace.Helvetica, 16);
            PDFStandardFont font = new PDFStandardFont(PDFStandardFontFace.Helvetica, 16);

            //PDF4NET v5: page.Canvas.DrawText("CalRGB colorspace", font, null, blackBrush, 50, 50);
            page.Canvas.DrawString("CalRGB colorspace", font, blackBrush, 50, 50);

            PDFCalRgbColorSpace calRgbCS = new PDFCalRgbColorSpace();
            PDFCalRgbColor red = new PDFCalRgbColor(calRgbCS);
            red.Red = 1;
            red.Green = 0;
            red.Blue = 0;
            PDFCalRgbColor blue = new PDFCalRgbColor(calRgbCS);
            blue.Red = 0;
            blue.Green = 0;
            blue.Blue = 1;
            PDFBrush blueBrush = new PDFBrush(blue);
            PDFPen redPen = new PDFPen(red, 5);
            page.Canvas.DrawRoundRectangle(redPen, blueBrush, 50, 100, 400, 150, 20, 20);
        }

        /// <summary>
        /// Draws content on a page using colors created from a calibrated Lab colorspace.
        /// </summary>
        /// <param name="page">The page to draw to.</param>
        private static void DrawLabColorSpace(PDFPage page)
        {
            PDFRgbColor black = new PDFRgbColor(0, 0, 0);
            PDFBrush blackBrush = new PDFBrush(black);
            //PDF4NET v5: PDFFont font = new PDFFont(PDFFontFace.Helvetica, 16);
            PDFStandardFont font = new PDFStandardFont(PDFStandardFontFace.Helvetica, 16);

            //PDF4NET v5: page.Canvas.DrawText("L*a*b* colorspace", font, null, blackBrush, 50, 50);
            page.Canvas.DrawString("L*a*b* colorspace", font, blackBrush, 50, 50);

            PDFLabColorSpace labCS = new PDFLabColorSpace();
            PDFLabColor labClr1 = new PDFLabColor(labCS);
            labClr1.L = 90;
            labClr1.A = 20;
            labClr1.B = -10;
            PDFLabColor labClr2 = new PDFLabColor(labCS);
            labClr2.L = 10;
            labClr2.A = 70;
            labClr2.B = -50;
            PDFBrush brush = new PDFBrush(labClr1);
            PDFPen pen = new PDFPen(labClr2, 5);
            page.Canvas.DrawRoundRectangle(pen, brush, 50, 100, 400, 150, 20, 20);
        }

        /// <summary>
        /// Draws content on a page using colors created from a calibrated ICC colorspace.
        /// </summary>
        /// <param name="page">The page to draw to.</param>
        private static void DrawICCColorSpace(PDFPage page)
        {
            PDFRgbColor black = new PDFRgbColor(0, 0, 0);
            PDFBrush blackBrush = new PDFBrush(black);
            //PDF4NET v5: PDFFont font = new PDFFont(PDFFontFace.Helvetica, 16);
            PDFStandardFont font = new PDFStandardFont(PDFStandardFontFace.Helvetica, 16);

            //PDF4NET v5: page.Canvas.DrawText("ICC colorspace", font, null, blackBrush, 50, 50);
            page.Canvas.DrawString("ICC colorspace", font, blackBrush, 50, 50);

            // Read the ICC profile from disk.
            FileStream fs = new FileStream("..\\..\\..\\..\\..\\SupportFiles\\rgb.icc", FileMode.Open, FileAccess.Read);
            byte[] profileData = new byte[fs.Length];
            fs.Read(profileData, 0, profileData.Length);
            fs.Close();

            //PDF4NET v5: PDFICCColorSpace iccCS = new PDFICCColorSpace();
            PDFIccColorSpace iccCS = new PDFIccColorSpace();
            iccCS.IccProfile = profileData;
            //PDF4NET v5: PDFICCColor red = new PDFICCColor(iccCS);
            PDFIccColor red = new PDFIccColor(iccCS);
            red.ColorComponents = new double[] { 192, 0, 0 };
            //PDF4NET v5: PDFICCColor blue = new PDFICCColor(iccCS);
            PDFIccColor blue = new PDFIccColor(iccCS);
            blue.ColorComponents = new double[] { 0, 0, 192 };
            PDFBrush blueBrush = new PDFBrush(blue);
            PDFPen redPen = new PDFPen(red, 5);
            page.Canvas.DrawRoundRectangle(redPen, blueBrush, 50, 100, 400, 150, 20, 20);
        }

        /// <summary>
        /// Draws content on a page using colors created from a separation colorspace.
        /// </summary>
        /// <param name="page">The page to draw to.</param>
        private static void DrawSeparationColorSpace(PDFPage page)
        {
            PDFRgbColor black = new PDFRgbColor(0, 0, 0);
            PDFBrush blackBrush = new PDFBrush(black);
            //PDF4NET v5: PDFFont font = new PDFFont(PDFFontFace.Helvetica, 16);
            PDFStandardFont font = new PDFStandardFont(PDFStandardFontFace.Helvetica, 16);

            //PDF4NET v5: page.Canvas.DrawText("Separation colorspace", font, null, blackBrush, 50, 50);
            page.Canvas.DrawString("Separation colorspace", font, blackBrush, 50, 50);

            //PDF4NET v5: PDFType2Function tintTransform = new PDFType2Function();
            PDFExponentialFunction tintTransform = new PDFExponentialFunction();
            tintTransform.C0 = new double[] { 0, 0, 0, 0 };
            tintTransform.C1 = new double[] { 0, 0.53f, 1, 0 };
            tintTransform.Exponent = 1;
            tintTransform.Domain = new double[] { 0, 1 };
            tintTransform.Range = new double[] { 0, 1, 0, 1, 0, 1, 0, 1 };
            PDFSeparationColorSpace separationCS = new PDFSeparationColorSpace();
            separationCS.Colorant = "PANTONE Orange 021 C";
            separationCS.TintTransform = tintTransform;
            PDFSeparationColor orange = new PDFSeparationColor(separationCS);
            orange.Tint = 0.9;

            //PDF4NET v5: tintTransform = new PDFType2Function();
            tintTransform = new PDFExponentialFunction();
            tintTransform.C0 = new double[] { 0, 0, 0, 0 };
            tintTransform.C1 = new double[] { 0, 0.75f, 0.9f, 0 };
            tintTransform.Exponent = 1;
            tintTransform.Domain = new double[] { 0, 1 };
            tintTransform.Range = new double[] { 0, 1, 0, 1, 0, 1, 0, 1 };
            separationCS = new PDFSeparationColorSpace();
            separationCS.Colorant = "PANTONE Warm Red C";
            separationCS.TintTransform = tintTransform;
            PDFSeparationColor warmRed = new PDFSeparationColor(separationCS);
            warmRed.Tint = 0.4;

            PDFBrush orangeBrush = new PDFBrush(orange);
            PDFPen warmRedPen = new PDFPen(warmRed, 5);
            page.Canvas.DrawRoundRectangle(warmRedPen, orangeBrush, 50, 100, 400, 150, 20, 20);
        }
    }
}


