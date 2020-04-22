using System;
using System.Drawing;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.Fonts;

namespace O2S.Samples.PDF4NET.Barcodes
{
    /// <summary>
    /// This sample shows how to display barcodes in a PDF document.
    /// </summary>
    class Barcodes
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Create the PDF document
            //PDF4NET v5: PDFDocument doc = new PDFDocument();
            PDFFixedDocument doc = new PDFFixedDocument();

            // Create the helper graphic objects.
            //PDF4NET v5: PDFFont titleFont = new PDFFont(PDFFontFace.Helvetica, 10);
            PDFStandardFont titleFont = new PDFStandardFont(PDFStandardFontFace.Helvetica, 10);
            titleFont.Bold = true;
            //PDF4NET v5: PDFFont textFont = new PDFFont(PDFFontFace.Helvetica, 8);
            PDFStandardFont textFont = new PDFStandardFont(PDFStandardFontFace.Helvetica, 8);
            //PDF4NET v5: PDFBrush brush = new PDFBrush(new PDFRgbColor(Color.Black));
            PDFBrush brush = new PDFBrush(PDFRgbColor.Black);

            // First page for linear barcodes.
            //PDF4NET v5: PDFPage page = doc.AddPage();
            PDFPage page = doc.Pages.Add();
            page.Canvas.DrawText("1D/Linear barcodes", titleFont, null, brush, 20, 50);

            page.Canvas.DrawText("1. Codabar", textFont, null, brush, 20, 70);
            PDFCodabarBarcode cb = new PDFCodabarBarcode("0123456789");
            page.Canvas.DrawBarcode(cb, 20, 80);

            page.Canvas.DrawText("2. Code 11", textFont, null, brush, 20, 140);
            PDFCode11Barcode c11 = new PDFCode11Barcode("0123456789");
            page.Canvas.DrawBarcode(c11, 20, 150);

            page.Canvas.DrawText("3. Code 128A", textFont, null, brush, 20, 210);
            PDFCode128ABarcode c128a = new PDFCode128ABarcode("CODE128A");
            page.Canvas.DrawBarcode(c128a, 20, 220);

            page.Canvas.DrawText("4. Code 128B", textFont, null, brush, 20, 280);
            PDFCode128BBarcode c128b = new PDFCode128BBarcode("CODE128B");
            page.Canvas.DrawBarcode(c128b, 20, 290);

            page.Canvas.DrawText("5. Code 128C", textFont, null, brush, 20, 350);
            PDFCode128CBarcode c128c = new PDFCode128CBarcode("0123456789");
            page.Canvas.DrawBarcode(c128c, 20, 360);

            page.Canvas.DrawText("6. Code 25", textFont, null, brush, 20, 420);
            PDFCode25Barcode c25 = new PDFCode25Barcode("0123456789");
            page.Canvas.DrawBarcode(c25, 20, 430);

            page.Canvas.DrawText("7. Code 25 Interleaved", textFont, null, brush, 20, 490);
            PDFCode25InterleavedBarcode c25i = new PDFCode25InterleavedBarcode("0123456789");
            page.Canvas.DrawBarcode(c25i, 20, 500);

            page.Canvas.DrawText("8. Code 39", textFont, null, brush, 20, 560);
            PDFCode39Barcode c39 = new PDFCode39Barcode("CODE39");
            page.Canvas.DrawBarcode(c39, 20, 570);

            page.Canvas.DrawText("9. Code 39 Extended", textFont, null, brush, 20, 630);
            PDFCode39ExtendedBarcode c39x = new PDFCode39ExtendedBarcode("C39Ext");
            page.Canvas.DrawBarcode(c39x, 20, 640);

            page.Canvas.DrawText("10. Code 93", textFont, null, brush, 20, 700);
            PDFCode93Barcode c93 = new PDFCode93Barcode("CODE93");
            page.Canvas.DrawBarcode(c93, 20, 710);

            page.Canvas.DrawText("11. Code 93 Extended", textFont, null, brush, 200, 70);
            PDFCode93ExtendedBarcode c93x = new PDFCode93ExtendedBarcode("C93Ext");
            page.Canvas.DrawBarcode(c93x, 200, 80);

            page.Canvas.DrawText("12. COOP 25", textFont, null, brush, 200, 140);
            //PDF4NET v5: PDFCOOP25Barcode coop25 = new PDFCOOP25Barcode("0123456789");
            PDFCoop25Barcode coop25 = new PDFCoop25Barcode("0123456789");
            page.Canvas.DrawBarcode(coop25, 200, 150);

            page.Canvas.DrawText("13. EAN-13", textFont, null, brush, 200, 210);
            //PDF4NET v5: PDFEAN13Barcode ean13 = new PDFEAN13Barcode("012345678901");
            PDFEan13Barcode ean13 = new PDFEan13Barcode("012345678901");
            page.Canvas.DrawBarcode(ean13, 200, 220);

            page.Canvas.DrawText("14. EAN-8", textFont, null, brush, 200, 280);
            //PDF4NET v5: PDFEAN8Barcode ean8 = new PDFEAN8Barcode("0123456");
            PDFEan8Barcode ean8 = new PDFEan8Barcode("0123456");
            page.Canvas.DrawBarcode(ean8, 200, 290);

            page.Canvas.DrawText("15. IATA 25", textFont, null, brush, 200, 350);
            //PDF4NET v5: PDFIATA25Barcode i25 = new PDFIATA25Barcode("0123456789");
            PDFIata25Barcode i25 = new PDFIata25Barcode("0123456789");
            page.Canvas.DrawBarcode(i25, 200, 360);

            page.Canvas.DrawText("16. ISBN", textFont, null, brush, 200, 420);
            //PDF4NET v5: PDFISBNBarcode isbn = new PDFISBNBarcode("123456789");
            PDFIsbnBarcode isbn = new PDFIsbnBarcode("123456789");
            page.Canvas.DrawBarcode(isbn, 200, 430);

            page.Canvas.DrawText("17. ISMN", textFont, null, brush, 200, 490);
            //PDF4NET v5: PDFISMNBarcode ismn = new PDFISMNBarcode("123456789");
            PDFIsmnBarcode ismn = new PDFIsmnBarcode("123456789");
            page.Canvas.DrawBarcode(ismn, 200, 500);

            page.Canvas.DrawText("18. ISSN", textFont, null, brush, 200, 560);
            //PDF4NET v5: PDFISSNBarcode issn = new PDFISSNBarcode("123456789");
            PDFIssnBarcode issn = new PDFIssnBarcode("123456789");
            page.Canvas.DrawBarcode(issn, 200, 570);

            page.Canvas.DrawText("19. JAN-13", textFont, null, brush, 200, 630);
            //PDF4NET v5: PDFJAN13Barcode jan13 = new PDFJAN13Barcode("1234567890");
            PDFJan13Barcode jan13 = new PDFJan13Barcode("1234567890");
            page.Canvas.DrawBarcode(jan13, 200, 640);

            page.Canvas.DrawText("20. Matrix 25", textFont, null, brush, 200, 700);
            PDFMatrix25Barcode m25 = new PDFMatrix25Barcode("0123456789");
            page.Canvas.DrawBarcode(m25, 200, 710);

            page.Canvas.DrawText("21. Msi/Plessey", textFont, null, brush, 350, 70);
            //PDF4NET v5: PDFMSIPlesseyBarcode msi = new PDFMSIPlesseyBarcode("0123456789");
            PDFMsiPlesseyBarcode msi = new PDFMsiPlesseyBarcode("0123456789");
            page.Canvas.DrawBarcode(msi, 350, 80);

            page.Canvas.DrawText("22. Planet", textFont, null, brush, 350, 140);
            PDFPlanetBarcode planet = new PDFPlanetBarcode("012345678901");
            page.Canvas.DrawBarcode(planet, 350, 150);

            page.Canvas.DrawText("23. Postnet", textFont, null, brush, 350, 210);
            PDFPostNetBarcode postnet = new PDFPostNetBarcode("012345678");
            page.Canvas.DrawBarcode(postnet, 350, 220);

            page.Canvas.DrawText("24. RM4SCC", textFont, null, brush, 350, 280);
            //PDF4NET v5: PDFRM4SCCBarcode rm4scc = new PDFRM4SCCBarcode("RM4SCC");
            PDFRm4sccBarcode rm4scc = new PDFRm4sccBarcode("RM4SCC");
            page.Canvas.DrawBarcode(rm4scc, 350, 290);

            page.Canvas.DrawText("25. SCC-14", textFont, null, brush, 350, 350);
            //PDF4NET v5: PDFSCC14Barcode scc14 = new PDFSCC14Barcode("0123456789012");
            PDFScc14Barcode scc14 = new PDFScc14Barcode("0123456789012");
            page.Canvas.DrawBarcode(scc14, 350, 360);

            page.Canvas.DrawText("26. SSCC-18", textFont, null, brush, 350, 420);
            //PDF4NET v5: PDFSSCC18Barcode sscc18 = new PDFSSCC18Barcode("00000012331234567");
            PDFSscc18Barcode sscc18 = new PDFSscc18Barcode("00000012331234567");
            page.Canvas.DrawBarcode(sscc18, 350, 430);

            page.Canvas.DrawText("27. UPC-A", textFont, null, brush, 350, 490);
            //PDF4NET v5: PDFUPCABarcode upca = new PDFUPCABarcode("87567816412");
            PDFUpcaBarcode upca = new PDFUpcaBarcode("87567816412");
            upca.Supplement = "59999";
            upca.SupplementYDimension = 20;
            //PDF4NET v5: upca.SupplementDisplayLocation = BarcodeTextLocation.Above;
            upca.SupplementTextPosition = PDFBarcodeTextPosition.Top;
            page.Canvas.DrawBarcode(upca, 350, 500);

            page.Canvas.DrawText("28. UPC-E", textFont, null, brush, 350, 560);
            //PDF4NET v5: PDFUPCEBarcode upce = new PDFUPCEBarcode("0425261");
            PDFUpceBarcode upce = new PDFUpceBarcode("0425261");
            page.Canvas.DrawBarcode(upce, 350, 570);

            // Second page for linear barcodes.
            //PDF4NET v5: page = doc.AddPage();
            page = doc.Pages.Add();
            page.Canvas.DrawText("1D/Linear barcodes (continued)", titleFont, null, brush, 20, 50);

            page.Canvas.DrawText("29. Singapore Post", textFont, null, brush, 20, 70);
            PDFSingaporePostBarcode singPost = new PDFSingaporePostBarcode("0123456789");
            page.Canvas.DrawBarcode(singPost, 20, 80);

            page.Canvas.DrawText("30. Royal Dutch TPG Post", textFont, null, brush, 20, 140);
            PDFKixBarcode kix = new PDFKixBarcode("0123456789");
            page.Canvas.DrawBarcode(kix, 20, 150);

            page.Canvas.DrawText("31. PZN", textFont, null, brush, 20, 210);
            //PDF4NET v5: PDFPZNBarcode pzn = new PDFPZNBarcode("123456");
            PDFPznBarcode pzn = new PDFPznBarcode("123456");
            page.Canvas.DrawBarcode(pzn, 20, 220);

            page.Canvas.DrawText("32. Deutsche Post Identcode", textFont, null, brush, 20, 280);
            PDFIdentcodeBarcode identcode = new PDFIdentcodeBarcode("01234567890");
            page.Canvas.DrawBarcode(identcode, 20, 290);

            page.Canvas.DrawText("33. Deutsche Post Leitcode", textFont, null, brush, 20, 350);
            PDFLeitcodeBarcode leitcode = new PDFLeitcodeBarcode("0123456789012");
            page.Canvas.DrawBarcode(leitcode, 20, 360);

            page.Canvas.DrawText("34. USPS Facing Identification Mark", textFont, null, brush, 20, 420);
            //PDF4NET v5: PDFUSPSFIMBarcode fim = new PDFUSPSFIMBarcode("A");
            PDFUspsFimBarcode fim = new PDFUspsFimBarcode("A");
            page.Canvas.DrawBarcode(fim, 20, 430);

            page.Canvas.DrawText("35. USPS Horizontal Bars", textFont, null, brush, 20, 490);
            //PDF4NET v5: PDFUSPSHorizontalBarcode hb = new PDFUSPSHorizontalBarcode("111");
            PDFUspsHorizontalBarcode hb = new PDFUspsHorizontalBarcode("111");
            page.Canvas.DrawBarcode(hb, 20, 500);

            page.Canvas.DrawText("36. USPS Package Identification Code", textFont, null, brush, 20, 560);
            //PDF4NET v5: PDFUSPSPICBarcode pic = new PDFUSPSPICBarcode("910123456789012345678");
            PDFUspsPicBarcode pic = new PDFUspsPicBarcode("910123456789012345678");
            page.Canvas.DrawBarcode(pic, 20, 570);

            page.Canvas.DrawText("37. FedEx Ground 96", textFont, null, brush, 20, 630);
            PDFFedExGround96Barcode fg96 = new PDFFedExGround96Barcode("960123456789012345678");
            page.Canvas.DrawBarcode(fg96, 20, 640);

            page.Canvas.DrawText("38. Pharmacode", textFont, null, brush, 20, 700);
            PDFPharmacodeBarcode pharma = new PDFPharmacodeBarcode("12345");
            page.Canvas.DrawBarcode(pharma, 20, 710);

            page.Canvas.DrawText("39. Code 32 - Italian Pharmacode", textFont, null, brush, 200, 70);
            PDFCode32Barcode c32 = new PDFCode32Barcode("12345678");
            page.Canvas.DrawBarcode(c32, 200, 80);

            page.Canvas.DrawText("40. UCC/EAN 128", textFont, null, brush, 200, 140);
            //PDF4NET v5: PDFEAN128Barcode ean128 = new PDFEAN128Barcode("0123456789");
            PDFEan128Barcode ean128 = new PDFEan128Barcode("0123456789");
            ean128.ApplicationIdentifier = "101";
            page.Canvas.DrawBarcode(ean128, 200, 150);

            // Create the 3rd page to display 2D barcodes.
            //PDF4NET v5: page = doc.AddPage();
            page = doc.Pages.Add();

            page.Canvas.DrawText("2D/Bidimensional barcodes", titleFont, null, brush, 20, 50);

            page.Canvas.DrawText("1. Codablock F", textFont, null, brush, 20, 70);
            PDFCodablockFBarcode cf = new PDFCodablockFBarcode();
            cf.Rows = 5;
            cf.Columns = 7;
            cf.Data = "1234567890";
            page.Canvas.DrawBarcode(cf, 20, 80);

            page.Canvas.DrawText("2. Code 16K", textFont, null, brush, 20, 140);
            PDFCode16KBarcode c16k = new PDFCode16KBarcode();
            c16k.Rows = 0;
            c16k.Data = "Abcd-1234567890-wxyZ";
            page.Canvas.DrawBarcode(c16k, 20, 150);

            page.Canvas.DrawText("3. DataMatrix", textFont, null, brush, 20, 210);
            PDFDataMatrixBarcode dm = new PDFDataMatrixBarcode();
            //PDF4NET v5: dm.Encoding = DataMatrixEncoding.ASCII;
            dm.DataEncoding = DataMatrixEncoding.ASCII;
            //PDF4NET v5: dm.SymbolSize = DataMatrixSymbolSize.Auto;
            dm.BarcodeSize = DataMatrixBarcodeSize.Auto;
            dm.Data = "ABCDabcd";
            dm.XDimension = 3;
            page.Canvas.DrawBarcode(dm, 20, 220);

            page.Canvas.DrawText("4. MicroPDF417", textFont, null, brush, 20, 280);
            //PDF4NET v5: PDFMicroPDF417Barcode mpdf417 = new PDFMicroPDF417Barcode();
            PDF417MicroBarcode mpdf417 = new PDF417MicroBarcode();
            mpdf417.CompactionMode = PDF417DataCompactionMode.Text;
            mpdf417.Data = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZAB";
            mpdf417.XDimension = 1;
            mpdf417.YDimension = 2.5f;
            mpdf417.BarcodeSize = PDF417MicroBarcodeSize.Rows20Columns4;
            page.Canvas.DrawBarcode(mpdf417, 20, 290);

            page.Canvas.DrawText("5. PDF417", textFont, null, brush, 20, 370);
            //PDF4NET v5: PDF417Barcode pdf417 = new PDF417Barcode();
            PDF417RegularBarcode pdf417 = new PDF417RegularBarcode();
            pdf417.CompactionMode = PDF417DataCompactionMode.Text;
            pdf417.Data = "ABCDEF";
            pdf417.Rows = 5;
            pdf417.Columns = 5;
            pdf417.XDimension = 1;
            pdf417.YDimension = 10;
            pdf417.ErrorCorrectionLevel = PDF417ErrorCorrectionLevel.Level2;
            page.Canvas.DrawBarcode(pdf417, 20, 380);

            doc.Save("Sample_Barcodes.pdf");
        }
    }
}


