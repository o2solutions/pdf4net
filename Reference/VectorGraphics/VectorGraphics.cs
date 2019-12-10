using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.PDFFunctions;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// VectorGraphics sample.
    /// </summary>
    public class VectorGraphics
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        /// <param name="iccStream"></param>
        public static SampleOutputInfo[] Run(Stream iccStream)
        {
            PDFFixedDocument document = new PDFFixedDocument();
            PDFStandardFont helveticaBoldTitle = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 16);
            PDFStandardFont helveticaSection = new PDFStandardFont(PDFStandardFontFace.Helvetica, 10);

            PDFPage page = document.Pages.Add();
            DrawLines(page, helveticaBoldTitle, helveticaSection);

            page = document.Pages.Add();
            DrawRectangles(page, helveticaBoldTitle, helveticaSection);

            page = document.Pages.Add();
            DrawRoundRectangles(page, helveticaBoldTitle, helveticaSection);

            page = document.Pages.Add();
            DrawEllipses(page, helveticaBoldTitle, helveticaSection);

            page = document.Pages.Add();
            DrawArcsAndPies(page, helveticaBoldTitle, helveticaSection);

            page = document.Pages.Add();
            DrawBezierCurves(page, helveticaBoldTitle, helveticaSection);

            page = document.Pages.Add();
            DrawAffineTransformations(page, helveticaBoldTitle, helveticaSection);

            page = document.Pages.Add();
            DrawColorsAndColorSpaces(page, helveticaBoldTitle, helveticaSection, iccStream);

            page = document.Pages.Add();
            DrawShadings(page, helveticaBoldTitle, helveticaSection);

            page = document.Pages.Add();
            DrawPatterns(page, helveticaBoldTitle, helveticaSection);

            page = document.Pages.Add();
            DrawFormXObjects(page, helveticaBoldTitle, helveticaSection);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "vectorgraphics.pdf") };
            return output;
        }

        private static void DrawLines(PDFPage page, PDFFont titleFont, PDFFont sectionFont)
        {
            PDFBrush brush = new PDFBrush();
            PDFPen blackPen = new PDFPen(PDFRgbColor.Black, 1);
            PDFPen bluePen = new PDFPen(PDFRgbColor.LightBlue, 16);

            page.Canvas.DrawString("Lines", titleFont, brush, 20, 50);

            page.Canvas.DrawString("Line styles:", sectionFont, brush, 20, 70);
            page.Canvas.DrawString("Solid", sectionFont, brush, 20, 90);
            page.Canvas.DrawLine(blackPen, 100, 95, 400, 95);
            page.Canvas.DrawString("Dashed", sectionFont, brush, 20, 110);
            blackPen.DashPattern = new double[] { 3, 3 };
            page.Canvas.DrawLine(blackPen, 100, 115, 400, 115);

            page.Canvas.DrawString("Line cap styles:", sectionFont, brush, 20, 150);
            page.Canvas.DrawString("Flat", sectionFont, brush, 20, 175);
            page.Canvas.DrawLine(bluePen, 100, 180, 400, 180);
            blackPen.DashPattern = null;
            page.Canvas.DrawLine(blackPen, 100, 180, 400, 180);
            page.Canvas.DrawString("Square", sectionFont, brush, 20, 195);
            bluePen.LineCap = PDFLineCap.Square;
            page.Canvas.DrawLine(bluePen, 100, 200, 400, 200);
            blackPen.DashPattern = null;
            page.Canvas.DrawLine(blackPen, 100, 200, 400, 200);
            page.Canvas.DrawString("Round", sectionFont, brush, 20, 215);
            bluePen.LineCap = PDFLineCap.Round;
            page.Canvas.DrawLine(bluePen, 100, 220, 400, 220);
            blackPen.DashPattern = null;
            page.Canvas.DrawLine(blackPen, 100, 220, 400, 220);

            page.Canvas.DrawString("Line join styles:", sectionFont, brush, 20, 250);
            page.Canvas.DrawString("Miter", sectionFont, brush, 20, 280);
            PDFPath miterPath = new PDFPath();
            miterPath.StartSubpath(150, 320);
            miterPath.AddLineTo(250, 260);
            miterPath.AddLineTo(350, 320);
            bluePen.LineCap = PDFLineCap.Flat;
            bluePen.LineJoin = PDFLineJoin.Miter;
            page.Canvas.DrawPath(bluePen, miterPath);

            page.Canvas.DrawString("Bevel", sectionFont, brush, 20, 360);
            PDFPath bevelPath = new PDFPath();
            bevelPath.StartSubpath(150, 400);
            bevelPath.AddLineTo(250, 340);
            bevelPath.AddLineTo(350, 400);
            bluePen.LineCap = PDFLineCap.Flat;
            bluePen.LineJoin = PDFLineJoin.Bevel;
            page.Canvas.DrawPath(bluePen, bevelPath);

            page.Canvas.DrawString("Round", sectionFont, brush, 20, 440);
            PDFPath roundPath = new PDFPath();
            roundPath.StartSubpath(150, 480);
            roundPath.AddLineTo(250, 420);
            roundPath.AddLineTo(350, 480);
            bluePen.LineCap = PDFLineCap.Flat;
            bluePen.LineJoin = PDFLineJoin.Round;
            page.Canvas.DrawPath(bluePen, roundPath);

            page.Canvas.DrawString("Random lines clipped to rectangle", sectionFont, brush, 20, 520);
            PDFPath clipPath = new PDFPath();
            clipPath.AddRectangle(20, 550, 570, 230);

            page.Canvas.SaveGraphicsState();
            page.Canvas.SetClip(clipPath);

            PDFRgbColor randomColor = new PDFRgbColor();
            PDFPen randomPen = new PDFPen(randomColor, 1);
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                randomColor.R = (byte)rnd.Next(256);
                randomColor.G = (byte)rnd.Next(256);
                randomColor.B = (byte)rnd.Next(256);

                page.Canvas.DrawLine(randomPen, rnd.NextDouble() * page.Width, 550 + rnd.NextDouble() * 250, rnd.NextDouble() * page.Width, 550 + rnd.NextDouble() * 250);
            }

            page.Canvas.RestoreGraphicsState();

            page.Canvas.DrawPath(blackPen, clipPath);

            page.Canvas.CompressAndClose();
        }

        private static void DrawRectangles(PDFPage page, PDFFont titleFont, PDFFont sectionFont)
        {
            PDFBrush brush = new PDFBrush();
            PDFPen blackPen = new PDFPen(PDFRgbColor.Black, 1);
            PDFPen redPen = new PDFPen(PDFRgbColor.Red, 1);

            PDFRgbColor randomPenColor = new PDFRgbColor();
            PDFPen randomPen = new PDFPen(randomPenColor, 1);
            PDFRgbColor randomBrushColor = new PDFRgbColor();
            PDFBrush randomBrush = new PDFBrush(randomBrushColor);

            page.Canvas.DrawString("Rectangles", titleFont, brush, 20, 50);

            page.Canvas.DrawLine(blackPen, 20, 150, 300, 150);
            page.Canvas.DrawLine(blackPen, 80, 70, 80, 350);
            page.Canvas.DrawRectangle(redPen, 80, 150, 180, 100);

            page.Canvas.DrawLine(blackPen, 320, 150, 600, 150);
            page.Canvas.DrawLine(blackPen, 380, 70, 380, 350);
            page.Canvas.DrawRectangle(redPen, 380, 150, 180, 100, 30);

            page.Canvas.DrawString("Random rectangles clipped to view", sectionFont, brush, 20, 385);
            PDFPath rectPath = new PDFPath();
            rectPath.AddRectangle(20, 400, 570, 300);

            page.Canvas.SaveGraphicsState();
            page.Canvas.SetClip(rectPath);

            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                randomPenColor.R = (byte)rnd.Next(256);
                randomPenColor.G = (byte)rnd.Next(256);
                randomPenColor.B = (byte)rnd.Next(256);

                randomBrushColor.R = (byte)rnd.Next(256);
                randomBrushColor.G = (byte)rnd.Next(256);
                randomBrushColor.B = (byte)rnd.Next(256);

                int mode = rnd.Next(3);
                double left = rnd.NextDouble() * page.Width;
                double top = 380 + rnd.NextDouble() * 350;
                double width = rnd.NextDouble() * page.Width;
                double height = rnd.NextDouble() * 250;
                double orientation = rnd.Next(360);
                switch (mode)
                {
                    case 0:
                        // Stroke rectangle outline
                        page.Canvas.DrawRectangle(randomPen, left, top, width, height, orientation);
                        break;
                    case 1:
                        // Fill rectangle interior
                        page.Canvas.DrawRectangle(randomBrush, left, top, width, height, orientation);
                        break;
                    case 2:
                        // Stroke and fill rectangle
                        page.Canvas.DrawRectangle(randomPen, randomBrush, left, top, width, height, orientation);
                        break;
                }
            }

            page.Canvas.RestoreGraphicsState();

            page.Canvas.DrawPath(blackPen, rectPath);

            page.Canvas.CompressAndClose();
        }

        private static void DrawRoundRectangles(PDFPage page, PDFFont titleFont, PDFFont sectionFont)
        {
            PDFBrush brush = new PDFBrush();
            PDFPen blackPen = new PDFPen(PDFRgbColor.Black, 1);
            PDFPen redPen = new PDFPen(PDFRgbColor.Red, 1);

            PDFRgbColor randomPenColor = new PDFRgbColor();
            PDFPen randomPen = new PDFPen(randomPenColor, 1);
            PDFRgbColor randomBrushColor = new PDFRgbColor();
            PDFBrush randomBrush = new PDFBrush(randomBrushColor);

            page.Canvas.DrawString("Round rectangles", titleFont, brush, 20, 50);

            page.Canvas.DrawLine(blackPen, 20, 150, 300, 150);
            page.Canvas.DrawLine(blackPen, 80, 70, 80, 350);
            page.Canvas.DrawRoundRectangle(redPen, 80, 150, 180, 100, 20, 20);

            page.Canvas.DrawLine(blackPen, 320, 150, 600, 150);
            page.Canvas.DrawLine(blackPen, 380, 70, 380, 350);
            page.Canvas.DrawRoundRectangle(redPen, 380, 150, 180, 100, 20, 20, 30);

            page.Canvas.DrawString("Random round rectangles clipped to view", sectionFont, brush, 20, 385);
            PDFPath roundRectPath = new PDFPath();
            roundRectPath.AddRoundRectangle(20, 400, 570, 300, 20, 20);

            page.Canvas.SaveGraphicsState();
            page.Canvas.SetClip(roundRectPath);

            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                randomPenColor.R = (byte)rnd.Next(256);
                randomPenColor.G = (byte)rnd.Next(256);
                randomPenColor.B = (byte)rnd.Next(256);

                randomBrushColor.R = (byte)rnd.Next(256);
                randomBrushColor.G = (byte)rnd.Next(256);
                randomBrushColor.B = (byte)rnd.Next(256);

                int mode = rnd.Next(3);
                double left = rnd.NextDouble() * page.Width;
                double top = 380 + rnd.NextDouble() * 350;
                double width = rnd.NextDouble() * page.Width;
                double height = rnd.NextDouble() * 250;
                double orientation = rnd.Next(360);
                switch (mode)
                {
                    case 0:
                        // Stroke rectangle outline
                        page.Canvas.DrawRoundRectangle(randomPen, left, top, width, height, width * 0.1, height * 0.1, orientation);
                        break;
                    case 1:
                        // Fill rectangle interior
                        page.Canvas.DrawRoundRectangle(randomBrush, left, top, width, height, width * 0.1, height * 0.1, orientation);
                        break;
                    case 2:
                        // Stroke and fill rectangle
                        page.Canvas.DrawRoundRectangle(randomPen, randomBrush, left, top, width, height, width * 0.1, height * 0.1, orientation);
                        break;
                }
            }

            page.Canvas.RestoreGraphicsState();

            page.Canvas.DrawPath(blackPen, roundRectPath);

            page.Canvas.CompressAndClose();
        }

        private static void DrawEllipses(PDFPage page, PDFFont titleFont, PDFFont sectionFont)
        {
            PDFBrush brush = new PDFBrush();
            PDFPen blackPen = new PDFPen(PDFRgbColor.Black, 1);
            PDFPen redPen = new PDFPen(PDFRgbColor.Red, 1);

            PDFRgbColor randomPenColor = new PDFRgbColor();
            PDFPen randomPen = new PDFPen(randomPenColor, 1);
            PDFRgbColor randomBrushColor = new PDFRgbColor();
            PDFBrush randomBrush = new PDFBrush(randomBrushColor);

            page.Canvas.DrawString("Ellipses", titleFont, brush, 20, 50);

            page.Canvas.DrawLine(blackPen, 20, 150, 300, 150);
            page.Canvas.DrawLine(blackPen, 80, 70, 80, 350);
            page.Canvas.DrawEllipse(redPen, 80, 150, 180, 100);

            page.Canvas.DrawLine(blackPen, 320, 150, 600, 150);
            page.Canvas.DrawLine(blackPen, 380, 70, 380, 350);
            page.Canvas.DrawEllipse(redPen, 380, 150, 180, 100, 30);

            page.Canvas.DrawString("Random ellipses clipped to view", sectionFont, brush, 20, 385);
            PDFPath ellipsePath = new PDFPath();
            ellipsePath.AddEllipse(20, 400, 570, 300);

            page.Canvas.SaveGraphicsState();
            page.Canvas.SetClip(ellipsePath);

            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                randomPenColor.R = (byte)rnd.Next(256);
                randomPenColor.G = (byte)rnd.Next(256);
                randomPenColor.B = (byte)rnd.Next(256);

                randomBrushColor.R = (byte)rnd.Next(256);
                randomBrushColor.G = (byte)rnd.Next(256);
                randomBrushColor.B = (byte)rnd.Next(256);

                int mode = rnd.Next(3);
                double left = rnd.NextDouble() * page.Width;
                double top = 380 + rnd.NextDouble() * 350;
                double width = rnd.NextDouble() * page.Width;
                double height = rnd.NextDouble() * 250;
                double orientation = rnd.Next(360);
                switch (mode)
                {
                    case 0:
                        // Stroke ellipse outline
                        page.Canvas.DrawEllipse(randomPen, left, top, width, height, orientation);
                        break;
                    case 1:
                        // Fill ellipse interior
                        page.Canvas.DrawEllipse(randomBrush, left, top, width, height, orientation);
                        break;
                    case 2:
                        // Stroke and fill ellipse
                        page.Canvas.DrawEllipse(randomPen, randomBrush, left, top, width, height, orientation);
                        break;
                }
            }

            page.Canvas.RestoreGraphicsState();

            page.Canvas.DrawPath(blackPen, ellipsePath);

            page.Canvas.CompressAndClose();
        }

        private static void DrawArcsAndPies(PDFPage page, PDFFont titleFont, PDFFont sectionFont)
        {
            PDFBrush brush = new PDFBrush();
            PDFPen blackPen = new PDFPen(PDFRgbColor.Black, 1);
            PDFPen redPen = new PDFPen(PDFRgbColor.Red, 1);

            PDFRgbColor randomPenColor = new PDFRgbColor();
            PDFPen randomPen = new PDFPen(randomPenColor, 1);
            PDFRgbColor randomBrushColor = new PDFRgbColor();
            PDFBrush randomBrush = new PDFBrush(randomBrushColor);

            page.Canvas.DrawString("Arcs", titleFont, brush, 20, 50);
            page.Canvas.DrawString("Pies", titleFont, brush, 310, 50);

            page.Canvas.DrawLine(blackPen, 20, 210, 300, 210);
            page.Canvas.DrawLine(blackPen, 160, 70, 160, 350);
            page.Canvas.DrawLine(blackPen, 310, 210, 590, 210);
            page.Canvas.DrawLine(blackPen, 450, 70, 450, 350);

            blackPen.DashPattern = new double[] { 2, 2 };
            page.Canvas.DrawLine(blackPen, 20, 70, 300, 350);
            page.Canvas.DrawLine(blackPen, 20, 350, 300, 70);
            page.Canvas.DrawLine(blackPen, 310, 70, 590, 350);
            page.Canvas.DrawLine(blackPen, 310, 350, 590, 70);

            page.Canvas.DrawArc(redPen, 30, 80, 260, 260, 0, 135);
            page.Canvas.DrawPie(redPen, 320, 80, 260, 260, 45, 270);

            page.Canvas.DrawString("Random arcs and pies clipped to view", sectionFont, brush, 20, 385);
            PDFPath rectPath = new PDFPath();
            rectPath.AddRectangle(20, 400, 570, 300);

            page.Canvas.SaveGraphicsState();
            page.Canvas.SetClip(rectPath);

            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                randomPenColor.R = (byte)rnd.Next(256);
                randomPenColor.G = (byte)rnd.Next(256);
                randomPenColor.B = (byte)rnd.Next(256);

                randomBrushColor.R = (byte)rnd.Next(256);
                randomBrushColor.G = (byte)rnd.Next(256);
                randomBrushColor.B = (byte)rnd.Next(256);

                int mode = rnd.Next(4);
                double left = rnd.NextDouble() * page.Width;
                double top = 380 + rnd.NextDouble() * 350;
                double width = rnd.NextDouble() * page.Width;
                double height = rnd.NextDouble() * 250;
                double startAngle = rnd.Next(360);
                double sweepAngle = rnd.Next(360);
                switch (mode)
                {
                    case 0:
                        // Stroke arc outline
                        page.Canvas.DrawArc(randomPen, left, top, width, height, startAngle, sweepAngle);
                        break;
                    case 1:
                        // Stroke pie outline
                        page.Canvas.DrawPie(randomPen, left, top, width, height, startAngle, sweepAngle);
                        break;
                    case 2:
                        // Fill pie interior
                        page.Canvas.DrawPie(randomBrush, left, top, width, height, startAngle, sweepAngle);
                        break;
                    case 3:
                        // Stroke and fill pie
                        page.Canvas.DrawPie(randomPen, randomBrush, left, top, width, height, startAngle, sweepAngle);
                        break;
                }
            }

            page.Canvas.RestoreGraphicsState();

            blackPen.DashPattern = null;
            page.Canvas.DrawPath(blackPen, rectPath);

            page.Canvas.CompressAndClose();
        }

        private static void DrawBezierCurves(PDFPage page, PDFFont titleFont, PDFFont sectionFont)
        {
            PDFBrush brush = new PDFBrush();
            PDFPen blackPen = new PDFPen(PDFRgbColor.Black, 1);
            PDFPen redPen = new PDFPen(PDFRgbColor.Red, 1);
            PDFBrush blueBrush = new PDFBrush(PDFRgbColor.DarkBlue);

            PDFRgbColor randomPenColor = new PDFRgbColor();
            PDFPen randomPen = new PDFPen(randomPenColor, 1);

            page.Canvas.DrawString("Bezier curves", titleFont, brush, 20, 50);

            page.Canvas.DrawLine(blackPen, 20, 210, 600, 210);
            page.Canvas.DrawLine(blackPen, 306, 70, 306, 350);
            page.Canvas.DrawRectangle(blueBrush, 39, 339, 2, 2);
            page.Canvas.DrawRectangle(blueBrush, 279, 79, 2, 2);
            page.Canvas.DrawRectangle(blueBrush, 499, 299, 2, 2);
            page.Canvas.DrawRectangle(blueBrush, 589, 69, 2, 2);
            page.Canvas.DrawBezier(redPen, 40, 340, 280, 80, 500, 300, 590, 70);

            page.Canvas.DrawString("Random bezier curves clipped to view", sectionFont, brush, 20, 385);
            PDFPath rectPath = new PDFPath();
            rectPath.AddRectangle(20, 400, 570, 300);

            page.Canvas.SaveGraphicsState();
            page.Canvas.SetClip(rectPath);

            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                randomPenColor.R = (byte)rnd.Next(256);
                randomPenColor.G = (byte)rnd.Next(256);
                randomPenColor.B = (byte)rnd.Next(256);

                double x1 = rnd.NextDouble() * page.Width;
                double y1 = 380 + rnd.NextDouble() * 350;
                double x2 = rnd.NextDouble() * page.Width;
                double y2 = 380 + rnd.NextDouble() * 350;
                double x3 = rnd.NextDouble() * page.Width;
                double y3 = 380 + rnd.NextDouble() * 350;
                double x4 = rnd.NextDouble() * page.Width;
                double y4 = 380 + rnd.NextDouble() * 350;

                page.Canvas.DrawBezier(randomPen, x1, y1, x2, y2, x3, y3, x4, y4);
            }

            page.Canvas.RestoreGraphicsState();

            blackPen.DashPattern = null;
            page.Canvas.DrawPath(blackPen, rectPath);

            page.Canvas.CompressAndClose();
        }

        private static void DrawAffineTransformations(PDFPage page, PDFFont titleFont, PDFFont sectionFont)
        {
            PDFBrush brush = new PDFBrush();
            PDFPen blackPen = new PDFPen(PDFRgbColor.Black, 1);
            PDFPen redPen = new PDFPen(PDFRgbColor.Red, 1);
            PDFPen bluePen = new PDFPen(PDFRgbColor.Blue, 1);
            PDFPen greenPen = new PDFPen(PDFRgbColor.Green, 1);

            page.Canvas.DrawString("Affine transformations", titleFont, brush, 20, 50);

            page.Canvas.DrawLine(blackPen, 0, page.Height / 2, page.Width, page.Height / 2);
            page.Canvas.DrawLine(blackPen, page.Width / 2, 0, page.Width / 2, page.Height);

            page.Canvas.SaveGraphicsState();

            // Move the coordinate system in the center of the page.
            page.Canvas.TranslateTransform(page.Width / 2, page.Height / 2);

            // Draw a rectangle with the center at (0, 0)
            page.Canvas.DrawRectangle(redPen, -page.Width / 4, -page.Height / 8, page.Width / 2, page.Height / 4);

            // Rotate the coordinate system with 30 degrees.
            page.Canvas.RotateTransform(30);

            // Draw the same rectangle with the center at (0, 0)
            page.Canvas.DrawRectangle(greenPen, -page.Width / 4, -page.Height / 8, page.Width / 2, page.Height / 4);

            // Scale the coordinate system with 1.5
            page.Canvas.ScaleTransform(1.5, 1.5);

            // Draw the same rectangle with the center at (0, 0)
            page.Canvas.DrawRectangle(bluePen, -page.Width / 4, -page.Height / 8, page.Width / 2, page.Height / 4);

            page.Canvas.RestoreGraphicsState();

            page.Canvas.CompressAndClose();
        }

        private static void DrawColorsAndColorSpaces(PDFPage page, PDFFont titleFont, PDFFont sectionFont, Stream iccStream)
        {
            PDFBrush brush = new PDFBrush();

            page.Canvas.DrawString("Colors and colorspaces", titleFont, brush, 20, 50);

            page.Canvas.DrawString("DeviceRGB", sectionFont, brush, 20, 70);
            PDFPen rgbPen = new PDFPen(PDFRgbColor.DarkRed, 4);
            PDFBrush rgbBrush = new PDFBrush(PDFRgbColor.LightGoldenrodYellow);
            page.Canvas.DrawRectangle(rgbPen, rgbBrush, 20, 85, 250, 100);

            page.Canvas.DrawString("DeviceCMYK", sectionFont, brush, 340, 70);
            PDFPen cmykPen = new PDFPen(new PDFCmykColor(1, 0.5, 0, 0.1), 4);
            PDFBrush cmykBrush = new PDFBrush(new PDFCmykColor(0, 0.5, 0.43, 0));
            page.Canvas.DrawRectangle(cmykPen, cmykBrush, 340, 85, 250, 100);

            page.Canvas.DrawString("DeviceGray", sectionFont, brush, 20, 200);
            PDFPen grayPen = new PDFPen(new PDFGrayColor(0.1), 4);
            PDFBrush grayBrush = new PDFBrush(new PDFGrayColor(0.75));
            page.Canvas.DrawRectangle(grayPen, grayBrush, 20, 215, 250, 100);

            page.Canvas.DrawString("Indexed", sectionFont, brush, 340, 200);
            PDFIndexedColorSpace indexedColorSpace = new PDFIndexedColorSpace();
            indexedColorSpace.ColorCount = 2;
            indexedColorSpace.BaseColorSpace = new PDFRgbColorSpace();
            indexedColorSpace.ColorTable = new byte[] { 192, 0, 0, 0, 0, 128 };
            PDFIndexedColor indexedColor0 = new PDFIndexedColor(indexedColorSpace);
            indexedColor0.ColorIndex = 0;
            PDFIndexedColor indexedColor1 = new PDFIndexedColor(indexedColorSpace);
            indexedColor1.ColorIndex = 1;
            PDFPen indexedPen = new PDFPen(indexedColor0, 4);
            PDFBrush indexedBrush = new PDFBrush(indexedColor1);
            page.Canvas.DrawRectangle(indexedPen, indexedBrush, 340, 215, 250, 100);

            page.Canvas.DrawString("CalGray", sectionFont, brush, 20, 330);
            PDFCalGrayColorSpace calGrayColorSpace = new PDFCalGrayColorSpace();
            PDFCalGrayColor calGrayColor1 = new PDFCalGrayColor(calGrayColorSpace);
            calGrayColor1.Gray = 0.6;
            PDFCalGrayColor calGrayColor2 = new PDFCalGrayColor(calGrayColorSpace);
            calGrayColor2.Gray = 0.2;
            PDFPen calGrayPen = new PDFPen(calGrayColor1, 4);
            PDFBrush calGrayBrush = new PDFBrush(calGrayColor2);
            page.Canvas.DrawRectangle(calGrayPen, calGrayBrush, 20, 345, 250, 100);

            page.Canvas.DrawString("CalRGB", sectionFont, brush, 340, 330);
            PDFCalRgbColorSpace calRgbColorSpace = new PDFCalRgbColorSpace();
            PDFCalRgbColor calRgbColor1 = new PDFCalRgbColor(calRgbColorSpace);
            calRgbColor1.Red = 0.1;
            calRgbColor1.Green = 0.5;
            calRgbColor1.Blue = 0.25;
            PDFCalRgbColor calRgbColor2 = new PDFCalRgbColor(calRgbColorSpace);
            calRgbColor2.Red = 0.6;
            calRgbColor2.Green = 0.1;
            calRgbColor2.Blue = 0.9;
            PDFPen calRgbPen = new PDFPen(calRgbColor1, 4);
            PDFBrush calRgbBrush = new PDFBrush(calRgbColor2);
            page.Canvas.DrawRectangle(calRgbPen, calRgbBrush, 340, 345, 250, 100);

            page.Canvas.DrawString("L*a*b", sectionFont, brush, 20, 460);
            PDFLabColorSpace labColorSpace = new PDFLabColorSpace();
            PDFLabColor labColor1 = new PDFLabColor(labColorSpace);
            labColor1.L = 90;
            labColor1.A = -40;
            labColor1.B = 120;
            PDFLabColor labColor2 = new PDFLabColor(labColorSpace);
            labColor2.L = 45;
            labColor2.A = 90;
            labColor2.B = -34;
            PDFPen labPen = new PDFPen(labColor1, 4);
            PDFBrush labBrush = new PDFBrush(labColor2);
            page.Canvas.DrawRectangle(labPen, labBrush, 20, 475, 250, 100);

            page.Canvas.DrawString("Icc", sectionFont, brush, 340, 460);
            PDFIccColorSpace iccColorSpace = new PDFIccColorSpace();
            byte[] iccData = new byte[iccStream.Length];
            iccStream.Read(iccData, 0, iccData.Length);
            iccColorSpace.IccProfile = iccData;
            iccColorSpace.AlternateColorSpace = new PDFRgbColorSpace();
            iccColorSpace.ColorComponents = 3;
            PDFIccColor iccColor1 = new PDFIccColor(iccColorSpace);
            iccColor1.ColorComponents = new double[] { 0.45, 0.1, 0.22 };
            PDFIccColor iccColor2 = new PDFIccColor(iccColorSpace);
            iccColor2.ColorComponents = new double[] { 0.21, 0.76, 0.31 };
            PDFPen iccPen = new PDFPen(iccColor1, 4);
            PDFBrush iccBrush = new PDFBrush(iccColor2);
            page.Canvas.DrawRectangle(iccPen, iccBrush, 340, 475, 250, 100);

            page.Canvas.DrawString("Separation", sectionFont, brush, 20, 590);
            PDFExponentialFunction tintTransform = new PDFExponentialFunction();
            tintTransform.Domain = new double[] { 0, 1 };
            tintTransform.Range = new double[] { 0, 1, 0, 1, 0, 1, 0, 1 };
            tintTransform.Exponent = 1;
            tintTransform.C0 = new double[] { 0, 0, 0, 0 };
            tintTransform.C1 = new double[] { 1, 0.5, 0, 0.1 };

            PDFSeparationColorSpace separationColorSpace = new PDFSeparationColorSpace();
            separationColorSpace.AlternateColorSpace = new PDFCmykColorSpace();
            separationColorSpace.Colorant = "Custom Blue";
            separationColorSpace.TintTransform = tintTransform;

            PDFSeparationColor separationColor1 = new PDFSeparationColor(separationColorSpace);
            separationColor1.Tint = 0.23;
            PDFSeparationColor separationColor2 = new PDFSeparationColor(separationColorSpace);
            separationColor2.Tint = 0.74;

            PDFPen separationPen = new PDFPen(separationColor1, 4);
            PDFBrush separationBrush = new PDFBrush(separationColor2);
            page.Canvas.DrawRectangle(separationPen, separationBrush, 20, 605, 250, 100);

            page.Canvas.DrawString("Pantone", sectionFont, brush, 340, 590);
            PDFPen pantonePen = new PDFPen(PDFPantoneColor.ReflexBlue, 4);
            PDFBrush pantoneBrush = new PDFBrush(PDFPantoneColor.RhodamineRed);
            page.Canvas.DrawRectangle(pantonePen, pantoneBrush, 340, 605, 250, 100);

            page.Canvas.CompressAndClose();
        }

        private static void DrawShadings(PDFPage page, PDFFont titleFont, PDFFont sectionFont)
        {
            PDFBrush brush = new PDFBrush();
            PDFPen blackPen = new PDFPen(PDFRgbColor.Black, 1);

            PDFRgbColor randomPenColor = new PDFRgbColor();
            PDFPen randomPen = new PDFPen(randomPenColor, 1);
            PDFRgbColor randomBrushColor = new PDFRgbColor();
            PDFBrush randomBrush = new PDFBrush(randomBrushColor);

            page.Canvas.DrawString("Shadings", titleFont, brush, 20, 50);

            page.Canvas.DrawString("Horizontal", sectionFont, brush, 25, 70);

            PDFAxialShading horizontalShading = new PDFAxialShading();
            horizontalShading.StartColor = new PDFRgbColor(255, 0, 0);
            horizontalShading.EndColor = new PDFRgbColor(0, 0, 255);
            horizontalShading.StartPoint = new PDFPoint(25, 90);
            horizontalShading.EndPoint = new PDFPoint(175, 90);

            // Clip the shading to desired area.
            PDFPath hsArea = new PDFPath();
            hsArea.AddRectangle(25, 90, 150, 150);
            page.Canvas.SaveGraphicsState();
            page.Canvas.SetClip(hsArea);
            page.Canvas.DrawShading(horizontalShading);
            page.Canvas.RestoreGraphicsState();

            page.Canvas.DrawString("Vertical", sectionFont, brush, 225, 70);

            PDFAxialShading verticalShading = new PDFAxialShading();
            verticalShading.StartColor = new PDFRgbColor(255, 0, 0);
            verticalShading.EndColor = new PDFRgbColor(0, 0, 255);
            verticalShading.StartPoint = new PDFPoint(225, 90);
            verticalShading.EndPoint = new PDFPoint(225, 240);

            // Clip the shading to desired area.
            PDFPath vsArea = new PDFPath();
            vsArea.AddRectangle(225, 90, 150, 150);
            page.Canvas.SaveGraphicsState();
            page.Canvas.SetClip(vsArea);
            page.Canvas.DrawShading(verticalShading);
            page.Canvas.RestoreGraphicsState();

            page.Canvas.DrawString("Diagonal", sectionFont, brush, 425, 70);

            PDFAxialShading diagonalShading = new PDFAxialShading();
            diagonalShading.StartColor = new PDFRgbColor(255, 0, 0);
            diagonalShading.EndColor = new PDFRgbColor(0, 0, 255);
            diagonalShading.StartPoint = new PDFPoint(425, 90);
            diagonalShading.EndPoint = new PDFPoint(575, 240);

            // Clip the shading to desired area.
            PDFPath dsArea = new PDFPath();
            dsArea.AddRectangle(425, 90, 150, 150);
            page.Canvas.SaveGraphicsState();
            page.Canvas.SetClip(dsArea);
            page.Canvas.DrawShading(diagonalShading);
            page.Canvas.RestoreGraphicsState();

            page.Canvas.DrawString("Extended shading", sectionFont, brush, 25, 260);

            PDFAxialShading extendedShading = new PDFAxialShading();
            extendedShading.StartColor = new PDFRgbColor(255, 0, 0);
            extendedShading.EndColor = new PDFRgbColor(0, 0, 255);
            extendedShading.StartPoint = new PDFPoint(225, 280);
            extendedShading.EndPoint = new PDFPoint(375, 280);
            extendedShading.ExtendStart = true;
            extendedShading.ExtendEnd = true;

            // Clip the shading to desired area.
            PDFPath esArea = new PDFPath();
            esArea.AddRectangle(25, 280, 550, 30);
            page.Canvas.SaveGraphicsState();
            page.Canvas.SetClip(esArea);
            page.Canvas.DrawShading(extendedShading);
            page.Canvas.RestoreGraphicsState();
            page.Canvas.DrawPath(blackPen, esArea);

            page.Canvas.DrawString("Limited shading", sectionFont, brush, 25, 330);

            PDFAxialShading limitedShading = new PDFAxialShading();
            limitedShading.StartColor = new PDFRgbColor(255, 0, 0);
            limitedShading.EndColor = new PDFRgbColor(0, 0, 255);
            limitedShading.StartPoint = new PDFPoint(225, 350);
            limitedShading.EndPoint = new PDFPoint(375, 350);
            limitedShading.ExtendStart = false;
            limitedShading.ExtendEnd = false;

            // Clip the shading to desired area.
            PDFPath lsArea = new PDFPath();
            lsArea.AddRectangle(25, 350, 550, 30);
            page.Canvas.SaveGraphicsState();
            page.Canvas.SetClip(lsArea);
            page.Canvas.DrawShading(limitedShading);
            page.Canvas.RestoreGraphicsState();
            page.Canvas.DrawPath(blackPen, lsArea);

            page.Canvas.DrawString("Multi-stop shading", sectionFont, brush, 25, 400);
            // Multi-stop shadings use a stitching function to combine the functions that define each gradient part.
            // Function for red to blue shading.
            PDFExponentialFunction redToBlueFunc = new PDFExponentialFunction();
            // Linear function
            redToBlueFunc.Exponent = 1;
            redToBlueFunc.Domain = new double[] { 0, 1 };
            // Red color for start
            redToBlueFunc.C0 = new double[] { 1, 0, 0 };
            // Blue color for start
            redToBlueFunc.C1 = new double[] { 0, 0, 1 };
            // Function for blue to green shading.
            PDFExponentialFunction blueToGreenFunc = new PDFExponentialFunction();
            // Linear function
            blueToGreenFunc.Exponent = 1;
            blueToGreenFunc.Domain = new double[] { 0, 1 };
            // Blue color for start
            blueToGreenFunc.C0 = new double[] { 0, 0, 1 };
            // Green color for start
            blueToGreenFunc.C1 = new double[] { 0, 1, 0 };

            //Stitching function for the shading.
            PDFStitchingFunction shadingFunction = new PDFStitchingFunction();
            shadingFunction.Functions.Add(redToBlueFunc);
            shadingFunction.Functions.Add(blueToGreenFunc);
            shadingFunction.Domain = new double[] { 0, 1 };
            shadingFunction.Encode = new double[] { 0, 1, 0, 1 };

            // Entire shading goes from 0 to 1 (100%).
            // We set the first shading (red->blue) to cover 30% (0 - 0.3) and
            // the second shading to cover 70% (0.3 - 1).
            shadingFunction.Bounds = new double[] { 0.3 };
            // The multistop shading
            PDFAxialShading multiStopShading = new PDFAxialShading();
            multiStopShading.StartPoint = new PDFPoint(25, 420);
            multiStopShading.EndPoint = new PDFPoint(575, 420);
            // The colorspace must match the colors specified in C0 & C1
            multiStopShading.ColorSpace = new PDFRgbColorSpace();
            multiStopShading.Function = shadingFunction;

            // Clip the shading to desired area.
            PDFPath mssArea = new PDFPath();
            mssArea.AddRectangle(25, 420, 550, 30);
            page.Canvas.SaveGraphicsState();
            page.Canvas.SetClip(mssArea);
            page.Canvas.DrawShading(multiStopShading);
            page.Canvas.RestoreGraphicsState();
            page.Canvas.DrawPath(blackPen, lsArea);

            page.Canvas.DrawString("Radial shading", sectionFont, brush, 25, 470);

            PDFRadialShading rs1 = new PDFRadialShading();
            rs1.StartColor = new PDFRgbColor(0, 255, 0);
            rs1.EndColor = new PDFRgbColor(255, 0, 255);
            rs1.StartCircleCenter = new PDFPoint(50, 500);
            rs1.StartCircleRadius = 10;
            rs1.EndCircleCenter = new PDFPoint(500, 570);
            rs1.EndCircleRadius = 100;

            page.Canvas.DrawShading(rs1);

            PDFRadialShading rs2 = new PDFRadialShading();
            rs2.StartColor = new PDFRgbColor(0, 255, 0);
            rs2.EndColor = new PDFRgbColor(255, 0, 255);
            rs2.StartCircleCenter = new PDFPoint(80, 600);
            rs2.StartCircleRadius = 10;
            rs2.EndCircleCenter = new PDFPoint(110, 690);
            rs2.EndCircleRadius = 100;

            page.Canvas.DrawShading(rs2);

            page.Canvas.CompressAndClose();
        }

        private static void DrawPatterns(PDFPage page, PDFFont titleFont, PDFFont sectionFont)
        {
            PDFBrush brush = new PDFBrush();
            PDFPen blackPen = new PDFPen(PDFRgbColor.Black, 1);

            PDFPen darkRedPen = new PDFPen(new PDFRgbColor(0xFF, 0x40, 0x40), 0.8);
            PDFPen darkOrangePen = new PDFPen(new PDFRgbColor(0xA6, 0x4B, 0x00), 0.8);
            PDFPen darkCyanPen = new PDFPen(new PDFRgbColor(0x00, 0x63, 0x63), 0.8);
            PDFPen darkGreenPen = new PDFPen(new PDFRgbColor(0x00, 0x85, 0x00), 0.8);
            PDFBrush lightRedBrush = new PDFBrush(new PDFRgbColor(0xFF, 0x73, 0x73));
            PDFBrush lightOrangeBrush = new PDFBrush(new PDFRgbColor(0xFF, 0x96, 0x40));
            PDFBrush lightCyanBrush = new PDFBrush(new PDFRgbColor(0x33, 0xCC, 0xCC));
            PDFBrush lightGreenBrush = new PDFBrush(new PDFRgbColor(0x67, 0xE6, 0x67));

            page.Canvas.DrawString("Patterns", titleFont, brush, 20, 50);

            page.Canvas.DrawString("Colored patterns", sectionFont, brush, 25, 70);

            // Create the pattern visual appearance.
            PDFColoredTilingPattern ctp = new PDFColoredTilingPattern(20, 20);
            // Red circle
            ctp.Canvas.DrawEllipse(darkRedPen, lightRedBrush, 1, 1, 8, 8);
            // Cyan square
            ctp.Canvas.DrawRectangle(darkCyanPen, lightCyanBrush, 11, 1, 8, 8);
            // Green diamond
            PDFPath diamondPath = new PDFPath();
            diamondPath.StartSubpath(1, 15);
            diamondPath.AddPolyLineTo(new PDFPoint[] { new PDFPoint(5, 11), new PDFPoint(9, 15), new PDFPoint(5, 19) });
            diamondPath.CloseSubpath();
            ctp.Canvas.DrawPath(darkGreenPen, lightGreenBrush, diamondPath);
            // Orange triangle
            PDFPath trianglePath = new PDFPath();
            trianglePath.StartSubpath(11, 19);
            trianglePath.AddPolyLineTo(new PDFPoint[] { new PDFPoint(15, 11), new PDFPoint(19, 19) });
            trianglePath.CloseSubpath();
            ctp.Canvas.DrawPath(darkOrangePen, lightOrangeBrush, trianglePath);

            // Create a pattern colorspace from the pattern object.
            PDFPatternColorSpace coloredPatternColorSpace = new PDFPatternColorSpace(ctp);
            // Create a color based on the pattern colorspace.
            PDFPatternColor coloredPatternColor = new PDFPatternColor(coloredPatternColorSpace);
            // The pen and brush use the pattern color like any other color.
            PDFPatternBrush patternBrush = new PDFPatternBrush(coloredPatternColor);
            PDFPatternPen patternPen = new PDFPatternPen(coloredPatternColor, 40);

            page.Canvas.DrawEllipse(patternBrush, 25, 90, 250, 200);
            page.Canvas.DrawRoundRectangle(patternPen, 310, 110, 250, 160, 100, 100);

            page.Canvas.DrawString("Uncolored patterns", sectionFont, brush, 25, 300);

            // Create the pattern visual appearance.
            PDFUncoloredTilingPattern uctp = new PDFUncoloredTilingPattern(20, 20);
            // A pen without color is used to create the pattern content.
            PDFPen noColorPen = new PDFPen(null, 0.8);
            // Circle
            uctp.Canvas.DrawEllipse(noColorPen, 1, 1, 8, 8);
            // Square
            uctp.Canvas.DrawRectangle(noColorPen, 11, 1, 8, 8);
            // Diamond
            diamondPath = new PDFPath();
            diamondPath.StartSubpath(1, 15);
            diamondPath.AddPolyLineTo(new PDFPoint[] { new PDFPoint(5, 11), new PDFPoint(9, 15), new PDFPoint(5, 19) });
            diamondPath.CloseSubpath();
            uctp.Canvas.DrawPath(noColorPen, diamondPath);
            // Triangle
            trianglePath = new PDFPath();
            trianglePath.StartSubpath(11, 19);
            trianglePath.AddPolyLineTo(new PDFPoint[] { new PDFPoint(15, 11), new PDFPoint(19, 19) });
            trianglePath.CloseSubpath();
            uctp.Canvas.DrawPath(noColorPen, trianglePath);

            // Create a pattern colorspace from the pattern object.
            PDFPatternColorSpace uncoloredPatternColorSpace = new PDFPatternColorSpace(uctp);
            // Create a color based on the pattern colorspace.
            PDFPatternColor uncoloredPatternColor = new PDFPatternColor(uncoloredPatternColorSpace);
            // The pen and brush use the pattern color like any other color.
            patternBrush = new PDFPatternBrush(uncoloredPatternColor);

            // Before using the uncolored pattern set the color that will be used to paint the pattern.
            patternBrush.UncoloredPatternPaintColor = new PDFRgbColor(0xFF, 0x40, 0x40);
            page.Canvas.DrawEllipse(patternBrush, 25, 320, 125, 200);
            patternBrush.UncoloredPatternPaintColor = new PDFRgbColor(0xA6, 0x4B, 0x00);
            page.Canvas.DrawEllipse(patternBrush, 175, 320, 125, 200);
            patternBrush.UncoloredPatternPaintColor = new PDFRgbColor(0x00, 0x63, 0x63);
            page.Canvas.DrawEllipse(patternBrush, 325, 320, 125, 200);
            patternBrush.UncoloredPatternPaintColor = new PDFRgbColor(0x00, 0x85, 0x00);
            page.Canvas.DrawEllipse(patternBrush, 475, 320, 125, 200);

            page.Canvas.DrawString("Shading patterns", sectionFont, brush, 25, 550);

            // Create the pattern visual appearance.
            PDFAxialShading horizontalShading = new PDFAxialShading();
            horizontalShading.StartColor = new PDFRgbColor(255, 0, 0);
            horizontalShading.EndColor = new PDFRgbColor(0, 0, 255);
            horizontalShading.StartPoint = new PDFPoint(25, 600);
            horizontalShading.EndPoint = new PDFPoint(575, 600);
            PDFShadingPattern sp = new PDFShadingPattern(horizontalShading);

            // Create a pattern colorspace from the pattern object.
            PDFPatternColorSpace shadingPatternColorSpace = new PDFPatternColorSpace(sp);
            // Create a color based on the pattern colorspace.
            PDFPatternColor shadingPatternColor = new PDFPatternColor(shadingPatternColorSpace);
            // The pen and brush use the pattern color like any other color.
            patternPen = new PDFPatternPen(shadingPatternColor, 40);

            page.Canvas.DrawEllipse(patternPen, 50, 600, 500, 150);

            page.Canvas.CompressAndClose();
        }

        private static void DrawFormXObjects(PDFPage page, PDFFont titleFont, PDFFont sectionFont)
        {
            PDFBrush brush = new PDFBrush();
            PDFPen blackPen = new PDFPen(PDFRgbColor.Black, 1);

            PDFRgbColor randomPenColor = new PDFRgbColor();
            PDFPen randomPen = new PDFPen(randomPenColor, 1);
            PDFRgbColor randomBrushColor = new PDFRgbColor();
            PDFBrush randomBrush = new PDFBrush(randomBrushColor);

            page.Canvas.DrawString("Form XObjects", titleFont, brush, 20, 50);
            page.Canvas.DrawString("Scaling", sectionFont, brush, 20, 70);

            // Create the XObject content - random rectangles
            PDFFormXObject xobject = new PDFFormXObject(300, 300);
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                randomPenColor.R = (byte)rnd.Next(256);
                randomPenColor.G = (byte)rnd.Next(256);
                randomPenColor.B = (byte)rnd.Next(256);

                randomBrushColor.R = (byte)rnd.Next(256);
                randomBrushColor.G = (byte)rnd.Next(256);
                randomBrushColor.B = (byte)rnd.Next(256);

                double left = rnd.NextDouble() * xobject.Width;
                double top = rnd.NextDouble() * xobject.Height;
                double width = rnd.NextDouble() * xobject.Width;
                double height = rnd.NextDouble() * xobject.Height;
                double orientation = rnd.Next(360);
                xobject.Canvas.DrawRectangle(randomPen, randomBrush, left, top, width, height, orientation);
            }

            xobject.Canvas.DrawRectangle(blackPen, 0, 0, xobject.Width, xobject.Height);
            xobject.Canvas.CompressAndClose();

            // Draw the form XObject 3 times on the page at different sizes.
            page.Canvas.DrawFormXObject(xobject, 3, 90, 100, 100);
            page.Canvas.DrawFormXObject(xobject, 106, 90, 200, 200);
            page.Canvas.DrawFormXObject(xobject, 309, 90, 300, 300);

            page.Canvas.DrawString("Flipping", sectionFont, brush, 20, 420);
            page.Canvas.DrawFormXObject(xobject, 20, 440, 150, 150);
            page.Canvas.DrawFormXObject(xobject, 200, 440, 150, 150, 0, PDFFlipDirection.VerticalFlip);
            page.Canvas.DrawFormXObject(xobject, 20, 620, 150, 150, 0, PDFFlipDirection.HorizontalFlip);
            page.Canvas.DrawFormXObject(xobject, 200, 620, 150, 150, 0, PDFFlipDirection.VerticalFlip | PDFFlipDirection.HorizontalFlip);

            page.Canvas.CompressAndClose();
        }
    }
}