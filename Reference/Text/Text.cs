using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.Text;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Text sample.  
    /// </summary>
    public class Text
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run()
        {
            PDFFixedDocument document = new PDFFixedDocument();
            PDFStandardFont helveticaBold = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 16);

            PDFPage page = document.Pages.Add();
            DrawTextLines(page, helveticaBold);

            page = document.Pages.Add();
            DrawTextWrap(page, helveticaBold);

            page = document.Pages.Add();
            DrawTextRenderingModes(page, helveticaBold);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "text.pdf") };
            return output;
        }

        private static void DrawTextLines(PDFPage page, PDFStandardFont titleFont)
        {
            PDFBrush brush = new PDFBrush();
            PDFPen redPen = new PDFPen(PDFRgbColor.Red, 0.5);
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.Helvetica, 12);

            page.Canvas.DrawString("Text lines", titleFont, brush, 20, 50);

            page.Canvas.DrawLine(redPen, 20, 70, 150, 70);
            page.Canvas.DrawLine(redPen, 20, 70, 20, 80);
            page.Canvas.DrawString("Simple text line with default top left text alignment and no rotation", helvetica, brush, 20, 70);

            page.Canvas.DrawString("Text align", helvetica, brush, 20, 110);

            redPen.DashPattern = new double[] { 1, 1 };
            page.Canvas.DrawLine(redPen, 20, 125, 590, 125);
            page.Canvas.DrawLine(redPen, 20, 165, 590, 165);
            page.Canvas.DrawLine(redPen, 20, 205, 590, 205);
            page.Canvas.DrawLine(redPen, 20, 125, 20, 205);
            page.Canvas.DrawLine(redPen, 305, 125, 305, 205);
            page.Canvas.DrawLine(redPen, 590, 125, 590, 205);

            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = brush;
            sao.Font = helvetica;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();

            // Top left aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Left;
            slo.VerticalAlign = PDFStringVerticalAlign.Top;
            slo.X = 20;
            slo.Y = 125;
            page.Canvas.DrawString("Top Left", sao, slo);

            // Top center aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Top;
            slo.X = 305;
            slo.Y = 125;
            page.Canvas.DrawString("Top Center", sao, slo);

            // Top right aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Right;
            slo.VerticalAlign = PDFStringVerticalAlign.Top;
            slo.X = 590;
            slo.Y = 125;
            page.Canvas.DrawString("Top Right", sao, slo);

            // Middle left aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Left;
            slo.VerticalAlign = PDFStringVerticalAlign.Middle;
            slo.X = 20;
            slo.Y = 165;
            page.Canvas.DrawString("Middle Left", sao, slo);

            // Middle center aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Middle;
            slo.X = 305;
            slo.Y = 165;
            page.Canvas.DrawString("Middle Center", sao, slo);

            // Middle right aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Right;
            slo.VerticalAlign = PDFStringVerticalAlign.Middle;
            slo.X = 590;
            slo.Y = 165;
            page.Canvas.DrawString("Middle Right", sao, slo);

            // Bottom left aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Left;
            slo.VerticalAlign = PDFStringVerticalAlign.Bottom;
            slo.X = 20;
            slo.Y = 205;
            page.Canvas.DrawString("Bottom Left", sao, slo);

            // Bottom center aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Bottom;
            slo.X = 305;
            slo.Y = 205;
            page.Canvas.DrawString("Bottom Center", sao, slo);

            // Bottom right aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Right;
            slo.VerticalAlign = PDFStringVerticalAlign.Bottom;
            slo.X = 590;
            slo.Y = 205;
            page.Canvas.DrawString("Bottom Right", sao, slo);

            page.Canvas.DrawString("Text rotation", helvetica, brush, 20, 250);

            redPen.DashPattern = new double[] { 1, 1 };
            page.Canvas.DrawLine(redPen, 20, 265, 590, 265);
            page.Canvas.DrawLine(redPen, 20, 305, 590, 305);
            page.Canvas.DrawLine(redPen, 20, 345, 590, 345);
            page.Canvas.DrawLine(redPen, 20, 265, 20, 345);
            page.Canvas.DrawLine(redPen, 305, 265, 305, 345);
            page.Canvas.DrawLine(redPen, 590, 265, 590, 345);

            slo.Rotation = 30;
            // Top left aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Left;
            slo.VerticalAlign = PDFStringVerticalAlign.Top;
            slo.X = 20;
            slo.Y = 265;
            page.Canvas.DrawString("Top Left", sao, slo);

            // Top center aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Top;
            slo.X = 305;
            slo.Y = 265;
            page.Canvas.DrawString("Top Center", sao, slo);

            // Top right aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Right;
            slo.VerticalAlign = PDFStringVerticalAlign.Top;
            slo.X = 590;
            slo.Y = 265;
            page.Canvas.DrawString("Top Right", sao, slo);

            // Middle left aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Left;
            slo.VerticalAlign = PDFStringVerticalAlign.Middle;
            slo.X = 20;
            slo.Y = 305;
            page.Canvas.DrawString("Middle Left", sao, slo);

            // Middle center aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Middle;
            slo.X = 305;
            slo.Y = 305;
            page.Canvas.DrawString("Middle Center", sao, slo);

            // Middle right aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Right;
            slo.VerticalAlign = PDFStringVerticalAlign.Middle;
            slo.X = 590;
            slo.Y = 305;
            page.Canvas.DrawString("Middle Right", sao, slo);

            // Bottom left aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Left;
            slo.VerticalAlign = PDFStringVerticalAlign.Bottom;
            slo.X = 20;
            slo.Y = 345;
            page.Canvas.DrawString("Bottom Left", sao, slo);

            // Bottom center aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Bottom;
            slo.X = 305;
            slo.Y = 345;
            page.Canvas.DrawString("Bottom Center", sao, slo);

            // Bottom right aligned text
            slo.HorizontalAlign = PDFStringHorizontalAlign.Right;
            slo.VerticalAlign = PDFStringVerticalAlign.Bottom;
            slo.X = 590;
            slo.Y = 345;
            page.Canvas.DrawString("Bottom Right", sao, slo);

            page.Canvas.CompressAndClose();
        }

        private static void DrawTextWrap(PDFPage page, PDFStandardFont titleFont)
        {
            PDFBrush brush = new PDFBrush();
            PDFPen redPen = new PDFPen(PDFRgbColor.Red, 0.5);
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.Helvetica, 12);

            page.Canvas.DrawString("Text wrapping", titleFont, brush, 20, 50);

            page.Canvas.DrawLine(redPen, 20, 70, 20, 150);
            page.Canvas.DrawLine(redPen, 300, 70, 300, 150);
            page.Canvas.DrawLine(redPen, 20, 70, 300, 70);

            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = brush;
            sao.Font = helvetica;

            // Height is not set, text has no vertical limit.
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            slo.VerticalAlign = PDFStringVerticalAlign.Top;
            slo.X = 20;
            slo.Y = 70;
            slo.Width = 280;
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Sed vel euismod risus. Fusce viverra, nisi auctor ullamcorper porttitor, " +
                "ipsum lacus lobortis metus, sit amet dictum lacus velit nec diam. " +
                "Morbi arcu diam, euismod a auctor nec, aliquam in lectus." +
                "Ut ultricies iaculis augue sit amet adipiscing. Aenean blandit tortor a nisi " +
                "dignissim fermentum id adipiscing mauris. Aenean libero turpis, varius nec ultricies " +
                "faucibus, pretium quis lectus. Morbi mollis lorem vel erat condimentum mattis mollis " +
                "nulla sollicitudin. Nunc ut massa id felis laoreet feugiat eget at eros.";
            page.Canvas.DrawString(text, sao, slo);

            page.Canvas.DrawLine(redPen, 310, 70, 310, 147);
            page.Canvas.DrawLine(redPen, 590, 70, 590, 147);
            page.Canvas.DrawLine(redPen, 310, 70, 590, 70);
            page.Canvas.DrawLine(redPen, 310, 147, 590, 147);

            // Height is set, text is limited on vertical.
            slo.X = 310;
            slo.Y = 70;
            slo.Width = 280;
            slo.Height = 77;
            page.Canvas.DrawString(text, sao, slo);

            PDFPath clipPath = new PDFPath();
            clipPath.AddRectangle(310, 160, 280, 77);
            page.Canvas.DrawPath(redPen, clipPath);

            page.Canvas.SaveGraphicsState();
            page.Canvas.SetClip(clipPath);

            // Height is not set but text is cliped on vertical.
            slo.X = 310;
            slo.Y = 160;
            slo.Width = 280;
            slo.Height = 0;
            page.Canvas.DrawString(text, sao, slo);

            page.Canvas.RestoreGraphicsState();

            page.Canvas.DrawLine(redPen, 10, 400, 300, 400);
            page.Canvas.DrawLine(redPen, 20, 300, 20, 500);
            // Wrapped text is always rotated around top left corner, no matter the text alignment
            page.Canvas.DrawRectangle(redPen, 20, 400, 280, 80, 30);
            slo.X = 20;
            slo.Y = 400;
            slo.Width = 280;
            slo.Height = 80;
            slo.Rotation = 30;
            page.Canvas.DrawString(text, sao, slo);

            page.Canvas.DrawLine(redPen, 310, 600, 590, 600);
            page.Canvas.DrawLine(redPen, 450, 450, 450, 750);

            // Rotation around the center of the box requires some affine transformations.
            page.Canvas.SaveGraphicsState();
            page.Canvas.TranslateTransform(450, 600);
            page.Canvas.RotateTransform(30);
            page.Canvas.DrawRectangle(redPen, -140, -40, 280, 80);
            slo.X = -140;
            slo.Y = -40;
            slo.Width = 280;
            slo.Height = 80;
            slo.Rotation = 0;
            page.Canvas.DrawString(text, sao, slo);

            page.Canvas.RestoreGraphicsState();
        }

        private static void DrawTextRenderingModes(PDFPage page, PDFStandardFont titleFont)
        {
            PDFBrush brush = new PDFBrush();
            PDFPen redPen = new PDFPen(PDFRgbColor.Red, 0.5);
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.Helvetica, 12);
            PDFStandardFont helveticaBold = new PDFStandardFont(PDFStandardFontFace.Helvetica, 80);

            page.Canvas.DrawString("Text rendering modes", titleFont, brush, 20, 50);

            page.Canvas.DrawString("Fill text", helvetica, brush, 20, 90);
            page.Canvas.DrawString("Stroke text", helvetica, brush, 20, 160);
            page.Canvas.DrawString("Fill and stroke text", helvetica, brush, 20, 230);
            page.Canvas.DrawString("Invisible text", helvetica, brush, 20, 300);
            page.Canvas.DrawString("Fill and clip text", helvetica, brush, 20, 370);
            page.Canvas.DrawString("Stroke and clip text", helvetica, brush, 20, 440);
            page.Canvas.DrawString("Fill, stroke and clip text", helvetica, brush, 20, 510);
            page.Canvas.DrawString("Clip text", helvetica, brush, 20, 580);

            // Fill text - text interior is filled because only the brush is available for drawing. 
            page.Canvas.DrawString("A B C", helveticaBold, brush, 300, 90);

            // Stroke text - text outline is stroked becuase only the pen is available for drawing.
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.X = 300;
            slo.Y = 160;
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Font = helveticaBold;
            sao.Pen = redPen;
            sao.Brush = null;
            page.Canvas.DrawString("A B C", sao, slo);

            // Fill and stroke text - text interior is filled and text outline is stroked 
            // because both pen and brush are available.
            slo.Y = 230;
            sao.Pen = redPen;
            sao.Brush = brush;
            page.Canvas.DrawString("A B C", sao, slo);

            // Invisible text - text is not displayed because both pen and brush are not available.
            slo.Y = 300;
            sao.Pen = null;
            sao.Brush = null;
            page.Canvas.DrawString("A B C", sao, slo);

            // Fill and clip text - text interior is filled and then text outline is added to current clipping path.
            page.Canvas.SaveGraphicsState();
            helveticaBold.TextRenderingMode = PDFTextRenderingMode.FillAndClipText;
            slo.Y = 370;
            sao.Pen = null;
            sao.Brush = brush;
            page.Canvas.DrawString("A B C", sao, slo);
            DrawHorizontalLines(page.Canvas, redPen, slo.X, slo.Y, 250, 70);
            page.Canvas.RestoreGraphicsState();

            // Stroke and clip text - text outline is stroked and then text outline is added to current clipping path.
            page.Canvas.SaveGraphicsState();
            helveticaBold.TextRenderingMode = PDFTextRenderingMode.StrokeAndClipText;
            slo.Y = 440;
            sao.Pen = redPen;
            sao.Brush = null;
            page.Canvas.DrawString("A B C", sao, slo);
            DrawHorizontalLines(page.Canvas, redPen, slo.X, slo.Y, 250, 70);
            page.Canvas.RestoreGraphicsState();

            // Fill, Stroke and clip text - text interior is filled, text outline is stroked and then text outline is added to current clipping path.
            page.Canvas.SaveGraphicsState();
            helveticaBold.TextRenderingMode = PDFTextRenderingMode.FillStrokeAndClipText;
            slo.Y = 510;
            sao.Pen = redPen;
            sao.Brush = brush;
            page.Canvas.DrawString("A B C", sao, slo);
            DrawHorizontalLines(page.Canvas, redPen, slo.X, slo.Y, 250, 70);
            page.Canvas.RestoreGraphicsState();

            // Clip text - text outline is added to current clipping path.
            page.Canvas.SaveGraphicsState();
            helveticaBold.TextRenderingMode = PDFTextRenderingMode.ClipText;
            slo.Y = 580;
            sao.Pen = redPen;
            sao.Brush = brush;
            page.Canvas.DrawString("A B C", sao, slo);
            DrawHorizontalLines(page.Canvas, redPen, slo.X, slo.Y, 250, 70);
            page.Canvas.RestoreGraphicsState();
        }

        private static void DrawHorizontalLines(PDFCanvas g, PDFPen pen, double x, double y, double width, double height)
        {
            for (double i = 0; i < height; i = i + 5)
            {
                g.DrawLine(pen, x, y + i, x + width, y + i);
            }
        }
    }
}