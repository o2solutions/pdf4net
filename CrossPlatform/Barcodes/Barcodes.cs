using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Barcodes sample.
    /// </summary>
    public class Barcodes
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run()
        {
            PDFFixedDocument document = new PDFFixedDocument();
            PDFStandardFont titleFont = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 16);
            PDFStandardFont barcodeFont = new PDFStandardFont(PDFStandardFontFace.Helvetica, 12);

            PDFPage page = document.Pages.Add();
            DrawGenericBarcodes(page, titleFont, barcodeFont);

            page = document.Pages.Add();
            DrawPharmaBarcodes(page, titleFont, barcodeFont);

            page = document.Pages.Add();
            DrawEanUpcBarcodes(page, titleFont, barcodeFont);

            page = document.Pages.Add();
            DrawPostAndTransportantionBarcodes(page, titleFont, barcodeFont);

            page = document.Pages.Add();
            Draw2DBarcodes(page, titleFont, barcodeFont);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "barcodes.pdf") };
            return output;
        }

        private static void DrawGenericBarcodes(PDFPage page, PDFFont titleFont, PDFFont barcodeFont)
        {
            
            PDFBrush brush = new PDFBrush();
            PDFPen lightGrayPen = new PDFPen(PDFRgbColor.LightGray, 0.5);

            page.Canvas.DrawString("Generic barcodes", titleFont, brush, 40, 20);
            for (int i = 0; i < 7; i++)
            {
                page.Canvas.DrawLine(lightGrayPen, 40, 50 + 100 * i, 570, 50 + 100 * i);
            }
            page.Canvas.DrawLine(lightGrayPen, 306, 50, 306, 750);

            string[] barcodes = new string[] { "Codabar", "Code 11", "Code 25", "Code 25 Interleaved", "Code 39", "Code 39 Extended",
                "Code 93", "Code 93 Extended", "Code 128 A", "Code 128 B", "Code 128 C", "COOP 25", "Matrix 25", "MSI/Plessey" };
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = brush;
            sao.Font = barcodeFont;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Top;

            slo.X = 173;
            int sign = 1;
            for (int i = 0; i < barcodes.Length; i++)
            {
                slo.Y = 55 + 100 * (i / 2);

                page.Canvas.DrawString(barcodes[i], sao, slo);

                slo.X = slo.X + sign * 266;
                sign = -sign;
            }

            // Codabar
            PDFCodabarBarcode codabarBarcode = new PDFCodabarBarcode();
            codabarBarcode.Data = "523408943724";
            codabarBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(codabarBarcode, 173 - codabarBarcode.Width / 2, 70);

            // Code 11
            PDFCode11Barcode code11Barcode = new PDFCode11Barcode();
            code11Barcode.Data = "42376524534";
            code11Barcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(code11Barcode, 173 + 266 - code11Barcode.Width / 2, 70);

            // Code 25
            PDFCode25Barcode code25Barcode = new PDFCode25Barcode();
            code25Barcode.Data = "857621354312";
            code25Barcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(code25Barcode, 173 - code25Barcode.Width / 2, 170);

            // Code 25 Interleaved
            PDFCode25InterleavedBarcode code25InterleavedBarcode = new PDFCode25InterleavedBarcode();
            code25InterleavedBarcode.Data = "42376524534";
            code25InterleavedBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(code25InterleavedBarcode, 173 + 266 - code25InterleavedBarcode.Width / 2, 170);

            // Code 39
            PDFCode39Barcode code39Barcode = new PDFCode39Barcode();
            code39Barcode.Data = "6430784327";
            code39Barcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(code39Barcode, 173 - code39Barcode.Width / 2, 270);

            // Code 39 Extended
            PDFCode39ExtendedBarcode code39ExtendedBarcode = new PDFCode39ExtendedBarcode();
            code39ExtendedBarcode.Data = "8990436322";
            code39ExtendedBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(code39ExtendedBarcode, 173 + 266 - code39ExtendedBarcode.Width / 2, 270);

            // Code 93
            PDFCode93Barcode code93Barcode = new PDFCode93Barcode();
            code93Barcode.Data = "6345212344";
            code93Barcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(code93Barcode, 173 - code93Barcode.Width / 2, 370);

            // Code 39 Extended
            PDFCode93ExtendedBarcode code93ExtendedBarcode = new PDFCode93ExtendedBarcode();
            code93ExtendedBarcode.Data = "125436732";
            code93ExtendedBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(code93ExtendedBarcode, 173 + 266 - code93ExtendedBarcode.Width / 2, 370);

            // Code 128 A
            PDFCode128ABarcode code128ABarcode = new PDFCode128ABarcode();
            code128ABarcode.Data = "PDF4NET";
            code128ABarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(code128ABarcode, 173 - code128ABarcode.Width / 2, 470);

            // Code 128 B
            PDFCode128BBarcode code128BBarcode = new PDFCode128BBarcode();
            code128BBarcode.Data = "pdf4net";
            code128BBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(code128BBarcode, 173 + 266 - code128BBarcode.Width / 2, 470);

            // Code 128 C
            PDFCode128CBarcode code128CBarcode = new PDFCode128CBarcode();
            code128CBarcode.Data = "423409865432";
            code128CBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(code128CBarcode, 173 - code128CBarcode.Width / 2, 570);

            // COOP 25
            PDFCoop25Barcode coop25Barcode = new PDFCoop25Barcode();
            coop25Barcode.Data = "43256565543";
            coop25Barcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(coop25Barcode, 173 + 266 - coop25Barcode.Width / 2, 570);

            // Matrix 25
            PDFMatrix25Barcode matrix25Barcode = new PDFMatrix25Barcode();
            matrix25Barcode.Data = "500540024300";
            matrix25Barcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(matrix25Barcode, 173 - matrix25Barcode.Width / 2, 670);

            // MSI/Plessey
            PDFMsiPlesseyBarcode msiPlesseyBarcode = new PDFMsiPlesseyBarcode();
            msiPlesseyBarcode.Data = "1124332556";
            msiPlesseyBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(msiPlesseyBarcode, 173 + 266 - msiPlesseyBarcode.Width / 2, 670);

            page.Canvas.CompressAndClose();
        }

        private static void DrawPharmaBarcodes(PDFPage page, PDFFont titleFont, PDFFont barcodeFont)
        {
            PDFBrush brush = new PDFBrush();
            PDFPen lightGrayPen = new PDFPen(PDFRgbColor.LightGray, 0.5);

            page.Canvas.DrawString("Pharma barcodes (barcodes used in the pharmaceutical industry)", titleFont, brush, 40, 20);
            for (int i = 0; i < 2; i++)
            {
                page.Canvas.DrawLine(lightGrayPen, 40, 50 + 100 * i, 570, 50 + 100 * i);
            }
            page.Canvas.DrawLine(lightGrayPen, 306, 50, 306, 250);

            string[] barcodes = new string[] { "Code 32", "Pharmacode", "PZN (Pharma-Zentral-Nummer)" };
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = brush;
            sao.Font = barcodeFont;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Top;

            slo.X = 173;
            int sign = 1;
            for (int i = 0; i < barcodes.Length; i++)
            {
                slo.Y = 55 + 100 * (i / 2);

                page.Canvas.DrawString(barcodes[i], sao, slo);

                slo.X = slo.X + sign * 266;
                sign = -sign;
            }

            // Code 32
            PDFCode32Barcode code32Barcode = new PDFCode32Barcode();
            code32Barcode.Data = "54925174";
            code32Barcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(code32Barcode, 173 - code32Barcode.Width / 2, 70);

            // Pharmacode
            PDFPharmacodeBarcode pharmacodeBarcode = new PDFPharmacodeBarcode();
            pharmacodeBarcode.Data = "128128";
            pharmacodeBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(pharmacodeBarcode, 173 + 266 - pharmacodeBarcode.Width / 2, 70);

            // PZN 
            PDFPznBarcode pznBarcode = new PDFPznBarcode();
            pznBarcode.Data = "903271";
            pznBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(pznBarcode, 173 - pznBarcode.Width / 2, 170);

            page.Canvas.CompressAndClose();
        }

        private static void DrawEanUpcBarcodes(PDFPage page, PDFFont titleFont, PDFFont barcodeFont)
        {

            PDFBrush brush = new PDFBrush();
            PDFPen lightGrayPen = new PDFPen(PDFRgbColor.LightGray, 0.5);

            page.Canvas.DrawString("EAN/UPC barcodes", titleFont, brush, 40, 20);
            for (int i = 0; i < 7; i++)
            {
                page.Canvas.DrawLine(lightGrayPen, 40, 50 + 100 * i, 570, 50 + 100 * i);
            }
            page.Canvas.DrawLine(lightGrayPen, 306, 50, 306, 750);

            string[] barcodes = new string[] { "EAN 128", "EAN-13", "EAN-8", "ISBN", "ISMN", "ISSN", "JAN-13", "UPC-A", "UPC-E" };
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = brush;
            sao.Font = barcodeFont;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Top;

            slo.X = 173;
            int sign = 1;
            for (int i = 0; i < barcodes.Length; i++)
            {
                slo.Y = 55 + 100 * (i / 2);

                page.Canvas.DrawString(barcodes[i], sao, slo);

                slo.X = slo.X + sign * 266;
                sign = -sign;
            }

            // EAN 128
            PDFEan128Barcode ean128Barcode = new PDFEan128Barcode();
            ean128Barcode.Data = "WWW.O2SOL.COM";
            ean128Barcode.QuietZones.Left = 0;
            ean128Barcode.QuietZones.Right = 0;
            ean128Barcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            ean128Barcode.ApplicationIdentifier = "URL";
            page.Canvas.DrawBarcode(ean128Barcode, 173 - ean128Barcode.Width / 2, 70);

            // EAN-13
            PDFEan13Barcode ean13Barcode = new PDFEan13Barcode();
            ean13Barcode.Data = "437612735617";
            ean13Barcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(ean13Barcode, 173 + 266 - ean13Barcode.Width / 2, 70);

            // EAN-8
            PDFEan8Barcode ean8Barcode = new PDFEan8Barcode();
            ean8Barcode.Data = "5423731";
            ean8Barcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(ean8Barcode, 173 - ean8Barcode.Width / 2, 170);

            // ISBN
            PDFIsbnBarcode isbnBarcode = new PDFIsbnBarcode();
            isbnBarcode.Data = "436314378";
            isbnBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(isbnBarcode, 173 + 266 - isbnBarcode.Width / 2, 170);

            // ISMN
            PDFIsmnBarcode ismnBarcode = new PDFIsmnBarcode();
            ismnBarcode.Data = "437612489";
            ismnBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(ismnBarcode, 173 - ismnBarcode.Width / 2, 270);

            // ISSN
            PDFIssnBarcode issnBarcode = new PDFIssnBarcode();
            issnBarcode.Data = "546712341";
            issnBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(issnBarcode, 173 + 266 - issnBarcode.Width / 2, 270);

            // JAN-13
            PDFJan13Barcode jan13Barcode = new PDFJan13Barcode();
            jan13Barcode.Data = "1256127634";
            jan13Barcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(jan13Barcode, 173 - jan13Barcode.Width / 2, 370);

            // UPC-A
            PDFUpcaBarcode upcaBarcode = new PDFUpcaBarcode();
            upcaBarcode.Data = "12543267841";
            upcaBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(upcaBarcode, 173 + 266 - upcaBarcode.Width / 2, 370);

            // UPC-E
            PDFUpceBarcode upceBarcode = new PDFUpceBarcode();
            upceBarcode.Data = "1234532";
            upceBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(upceBarcode, 173 - upceBarcode.Width / 2, 470);

            page.Canvas.CompressAndClose();
        }

        private static void DrawPostAndTransportantionBarcodes(PDFPage page, PDFFont titleFont, PDFFont barcodeFont)
        {

            PDFBrush brush = new PDFBrush();
            PDFPen lightGrayPen = new PDFPen(PDFRgbColor.LightGray, 0.5);

            page.Canvas.DrawString("Post and transportation barcodes", titleFont, brush, 40, 20);
            for (int i = 0; i < 7; i++)
            {
                page.Canvas.DrawLine(lightGrayPen, 40, 50 + 100 * i, 570, 50 + 100 * i);
            }
            page.Canvas.DrawLine(lightGrayPen, 306, 50, 306, 750);

            string[] barcodes = new string[] { "FedEx Ground 96", "IATA 25", "Identcode", "Leitcode", "KIX", "Planet",
                "PostNet", "RM4SCC", "SCC-14", "SingaporePost", "SSCC-18", "USPS FIM", "USPS Horizontal", "USPS PIC" };
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = brush;
            sao.Font = barcodeFont;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Top;

            slo.X = 173;
            int sign = 1;
            for (int i = 0; i < barcodes.Length; i++)
            {
                slo.Y = 55 + 100 * (i / 2);

                page.Canvas.DrawString(barcodes[i], sao, slo);

                slo.X = slo.X + sign * 266;
                sign = -sign;
            }

            // FedEx Ground 96
            PDFFedExGround96Barcode fedexGround96Barcode = new PDFFedExGround96Barcode();
            fedexGround96Barcode.Data = "962343237687543423123";
            fedexGround96Barcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(fedexGround96Barcode, 173 - fedexGround96Barcode.Width / 2, 70);

            // IATA 25
            PDFIata25Barcode iata25Barcode = new PDFIata25Barcode();
            iata25Barcode.Data = "54366436563";
            iata25Barcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(iata25Barcode, 173 + 266 - iata25Barcode.Width / 2, 70);

            // Identcode
            PDFIdentcodeBarcode identcodeBarcode = new PDFIdentcodeBarcode();
            identcodeBarcode.Data = "12435678214";
            identcodeBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(identcodeBarcode, 173 - identcodeBarcode.Width / 2, 170);

            // Leitcode
            PDFLeitcodeBarcode leitcodeBarcode = new PDFLeitcodeBarcode();
            leitcodeBarcode.Data = "1243657687321";
            leitcodeBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(leitcodeBarcode, 173 + 266 - leitcodeBarcode.Width / 2, 170);

            // KIX
            PDFKixBarcode kixBarcode = new PDFKixBarcode();
            kixBarcode.Data = "PDF4NET";
            kixBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(kixBarcode, 173 - kixBarcode.Width / 2, 270);

            // Planet
            PDFPlanetBarcode planetBarcode = new PDFPlanetBarcode();
            planetBarcode.Data = "645316643300";
            planetBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(planetBarcode, 173 + 266 - planetBarcode.Width / 2, 270);

            // PostNet
            PDFPostNetBarcode postNetBarcode = new PDFPostNetBarcode();
            postNetBarcode.Data = "04231454322";
            postNetBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(postNetBarcode, 173 - postNetBarcode.Width / 2, 370);

            // RM4SCC
            PDFRm4sccBarcode rm4sccBarcode = new PDFRm4sccBarcode();
            rm4sccBarcode.Data = "PDF4NET";
            rm4sccBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(rm4sccBarcode, 173 + 266 - rm4sccBarcode.Width / 2, 370);

            // SCC-14
            PDFScc14Barcode scc14Barcode = new PDFScc14Barcode();
            scc14Barcode.Data = "3255091205412";
            scc14Barcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(scc14Barcode, 173 - scc14Barcode.Width / 2, 470);

            // Singapore Post
            PDFSingaporePostBarcode singaporePostBarcode = new PDFSingaporePostBarcode();
            singaporePostBarcode.Data = "PDF4NET";
            singaporePostBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(singaporePostBarcode, 173 + 266 - singaporePostBarcode.Width / 2, 470);

            // SSCC-18
            PDFSscc18Barcode sscc18Barcode = new PDFSscc18Barcode();
            sscc18Barcode.Data = "09876543219832435";
            sscc18Barcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(sscc18Barcode, 173 - sscc18Barcode.Width / 2, 570);

            // USPS FIM
            PDFUspsFimBarcode uspsFimBarcode = new PDFUspsFimBarcode();
            uspsFimBarcode.Data = "A";
            uspsFimBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(uspsFimBarcode, 173 + 266 - uspsFimBarcode.Width / 2, 570);

            // USPS Horizontal
            PDFUspsHorizontalBarcode uspsHorizontalBarcode = new PDFUspsHorizontalBarcode();
            uspsHorizontalBarcode.Data = "1111";
            uspsHorizontalBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.None;
            page.Canvas.DrawBarcode(uspsHorizontalBarcode, 173 - uspsHorizontalBarcode.Width / 2, 670);

            // USPS PIC
            PDFUspsPicBarcode uspsPicBarcode = new PDFUspsPicBarcode();
            uspsPicBarcode.Data = "914354657901234354019";
            uspsPicBarcode.BarcodeTextPosition = PDFBarcodeTextPosition.Bottom;
            page.Canvas.DrawBarcode(uspsPicBarcode, 173 + 266 - uspsPicBarcode.Width / 2, 670);

            page.Canvas.CompressAndClose();
        }

        private static void Draw2DBarcodes(PDFPage page, PDFFont titleFont, PDFFont barcodeFont)
        {
            PDFBrush brush = new PDFBrush();
            PDFPen lightGrayPen = new PDFPen(PDFRgbColor.LightGray, 0.5);

            page.Canvas.DrawString("2D barcodes", titleFont, brush, 40, 20);
            for (int i = 0; i < 3; i++)
            {
                page.Canvas.DrawLine(lightGrayPen, 40, 50 + 150 * i, 570, 50 + 150 * i);
            }
            page.Canvas.DrawLine(lightGrayPen, 306, 50, 306, 500);

            string[] barcodes = new string[] { "Codablock F", "Code 16K", "PDF417", "Micro PDF417", "DataMatrix", "QR" };
            PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
            sao.Brush = brush;
            sao.Font = barcodeFont;
            PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
            slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
            slo.VerticalAlign = PDFStringVerticalAlign.Top;

            slo.X = 173;
            int sign = 1;
            for (int i = 0; i < barcodes.Length; i++)
            {
                slo.Y = 55 + 150 * (i / 2);

                page.Canvas.DrawString(barcodes[i], sao, slo);

                slo.X = slo.X + sign * 266;
                sign = -sign;
            }

            // Codablock F
            PDFCodablockFBarcode codablockFBarcode = new PDFCodablockFBarcode();
            codablockFBarcode.Data = "*** O2S.Components.PDF4NET ***";
            codablockFBarcode.Columns = 10;
            codablockFBarcode.Rows = 5;
            page.Canvas.DrawBarcode(codablockFBarcode, 173 - codablockFBarcode.Width / 2, 70);

            // Code 16K
            PDFCode16KBarcode code16KBarcode = new PDFCode16KBarcode();
            code16KBarcode.Data = "*** O2S.Components.PDF4NET ***";
            code16KBarcode.Rows = 6;
            page.Canvas.DrawBarcode(code16KBarcode, 173 + 266 - code16KBarcode.Width / 2, 70);

            // PDF 417
            PDF417RegularBarcode pdf417Barcode = new PDF417RegularBarcode();
            pdf417Barcode.Data = "*** O2S.Components.PDF4NET ***";
            pdf417Barcode.Columns = 10;
            pdf417Barcode.Rows = 0;
            page.Canvas.DrawBarcode(pdf417Barcode, 173 - pdf417Barcode.Width / 2, 220);

            // MicroPDF 417
            PDF417MicroBarcode microPDF417Barcode = new PDF417MicroBarcode();
            microPDF417Barcode.Data = "* O2S.Components.PDF4NET *";
            microPDF417Barcode.BarcodeSize = PDF417MicroBarcodeSize.Rows6Columns4;
            page.Canvas.DrawBarcode(microPDF417Barcode, 173 + 266 - microPDF417Barcode.Width / 2, 220);

            // DataMatrix
            PDFDataMatrixBarcode datamatrixBarcode = new PDFDataMatrixBarcode();
            datamatrixBarcode.Data = "*** O2S.Components.PDF4NET ***";
            datamatrixBarcode.XDimension = 2;
            datamatrixBarcode.BarcodeSize = DataMatrixBarcodeSize.Auto;
            page.Canvas.DrawBarcode(datamatrixBarcode, 173 - datamatrixBarcode.Width / 2, 370);

            // QR Barcode
            PDFQrBarcode qrBarcode = new PDFQrBarcode();
            qrBarcode.XDimension = 2;
            qrBarcode.Data = "PDF4NET: http://www.o2sol.com/";
            qrBarcode.CharacterSet = PDFQrBarcodeCharacterSet.ISO88591;
            page.Canvas.DrawBarcode(qrBarcode, 173 + 266 - qrBarcode.Width / 2, 370);

            page.Canvas.CompressAndClose();
        }
           
    }
}