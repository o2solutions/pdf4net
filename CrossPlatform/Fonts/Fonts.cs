using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Fonts sample.
    /// </summary>
    public class Fonts
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run(Stream ttfStream)
        {
            PDFFixedDocument document = new PDFFixedDocument();

            PDFPage page = document.Pages.Add();
            DrawStandardFonts(page);

            page = document.Pages.Add();
            DrawStandardCjkFonts(page);

            page = document.Pages.Add();
            DrawTrueTypeFonts(page, ttfStream);

            page = document.Pages.Add();
            DisableTextCopy(page, ttfStream);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "fonts.pdf") };
            return output;
        }

        private static void DrawStandardFonts(PDFPage page)
        {
            PDFStandardFont titleFont = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 22);
            PDFBrush blackBrush = new PDFBrush(new PDFRgbColor());

            page.Canvas.DrawString("Standard fonts", titleFont, blackBrush, 20, 50);
            page.Canvas.DrawString("(Base 14 PDF fonts supported by any PDF viewer)", titleFont, blackBrush, 20, 75);

            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.Helvetica, 16);
            page.Canvas.DrawString("Helvetica - Lorem ipsum dolor sit amet, consectetur adipiscing elit.", helvetica, blackBrush, 20, 125);

            PDFStandardFont helveticaBold = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 16);
            page.Canvas.DrawString("Helvetica Bold - Lorem ipsum dolor sit amet, consectetur adipiscing elit.", helveticaBold, blackBrush, 20, 150);

            PDFStandardFont helveticaItalic = new PDFStandardFont(PDFStandardFontFace.HelveticaItalic, 16);
            page.Canvas.DrawString("Helvetica Italic - Lorem ipsum dolor sit amet, consectetur adipiscing elit.", helveticaItalic, blackBrush, 20, 175);

            PDFStandardFont helveticaBoldItalic = new PDFStandardFont(PDFStandardFontFace.HelveticaBoldItalic, 16);
            page.Canvas.DrawString("Helvetica Bold Italic - Lorem ipsum dolor sit amet, consectetur adipiscing elit.", helveticaBoldItalic, blackBrush, 20, 200);

            PDFStandardFont timesRoman = new PDFStandardFont(PDFStandardFontFace.TimesRoman, 16);
            page.Canvas.DrawString("Times Roman - Lorem ipsum dolor sit amet, consectetur adipiscing elit.", timesRoman, blackBrush, 20, 225);

            PDFStandardFont timesRomanBold = new PDFStandardFont(PDFStandardFontFace.TimesRomanBold, 16);
            page.Canvas.DrawString("Times Roman Bold - Lorem ipsum dolor sit amet, consectetur adipiscing elit.", timesRomanBold, blackBrush, 20, 250);

            PDFStandardFont timesRomanItalic = new PDFStandardFont(PDFStandardFontFace.TimesRomanItalic, 16);
            page.Canvas.DrawString("Times Roman Italic - Lorem ipsum dolor sit amet, consectetur adipiscing elit.", timesRomanItalic, blackBrush, 20, 275);

            PDFStandardFont timesRomanBoldItalic = new PDFStandardFont(PDFStandardFontFace.TimesRomanBoldItalic, 16);
            page.Canvas.DrawString("Times Roman Bold Italic - Lorem ipsum dolor sit amet, consectetur adipiscing elit.", timesRomanBoldItalic, blackBrush, 20, 300);

            PDFStandardFont courier = new PDFStandardFont(PDFStandardFontFace.Courier, 16);
            page.Canvas.DrawString("Courier - Lorem ipsum dolor sit amet, consectetur adipiscing elit.", courier, blackBrush, 20, 325);

            PDFStandardFont courierBold = new PDFStandardFont(PDFStandardFontFace.CourierBold, 16);
            page.Canvas.DrawString("Courier Bold - Lorem ipsum dolor sit amet, consectetur adipiscing elit.", courierBold, blackBrush, 20, 350);

            PDFStandardFont courierItalic = new PDFStandardFont(PDFStandardFontFace.CourierItalic, 16);
            page.Canvas.DrawString("Courier Italic - Lorem ipsum dolor sit amet, consectetur adipiscing elit.", courierItalic, blackBrush, 20, 375);

            PDFStandardFont courierBoldItalic = new PDFStandardFont(PDFStandardFontFace.CourierBoldItalic, 16);
            page.Canvas.DrawString("Courier Bold Italic - Lorem ipsum dolor sit amet, consectetur adipiscing elit.", courierBoldItalic, blackBrush, 20, 400);
        }

        private static void DrawStandardCjkFonts(PDFPage page)
        {
            PDFStandardFont titleFont = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 22);
            PDFBrush blackBrush = new PDFBrush(new PDFRgbColor());

            page.Canvas.DrawString("Standard CJK fonts", titleFont, blackBrush, 20, 50);
            page.Canvas.DrawString("(CJK fonts supported by Adobe Reader", titleFont, blackBrush, 20, 75);
            page.Canvas.DrawString(" using CJK language packs)", titleFont, blackBrush, 20, 100);

            PDFStandardFont heiseiKakuGothic = new PDFStandardFont(PDFStandardFontFace.HeiseiKakuGothicW5, 16);
            page.Canvas.DrawString("Heisei Kaku Gothic - サンプル日本語フォントデモテキスト.", heiseiKakuGothic, blackBrush, 20, 150);

            PDFStandardFont heiseiKakuGothicBold = new PDFStandardFont(PDFStandardFontFace.HeiseiKakuGothicW5Bold, 16);
            page.Canvas.DrawString("Heisei Kaku Gothic Bold - サンプル日本語フォントデモテキスト.", heiseiKakuGothicBold, blackBrush, 20, 175);

            PDFStandardFont heiseiKakuGothicItalic = new PDFStandardFont(PDFStandardFontFace.HeiseiKakuGothicW5Italic, 16);
            page.Canvas.DrawString("Heisei Kaku Gothic Italic - サンプル日本語フォントデモテキスト.", heiseiKakuGothicItalic, blackBrush, 20, 200);

            PDFStandardFont heiseiKakuGothicBoldItalic = new PDFStandardFont(PDFStandardFontFace.HeiseiKakuGothicW5BoldItalic, 16);
            page.Canvas.DrawString("Heisei Kaku Gothic Bold Italic - サンプル日本語フォントデモテキスト.", heiseiKakuGothicBoldItalic, blackBrush, 20, 225);

            PDFStandardFont heiseiMincho = new PDFStandardFont(PDFStandardFontFace.HeiseiMinchoW3, 16);
            page.Canvas.DrawString("Heisei Mincho - サンプル日本語フォントデモテキスト.", heiseiMincho, blackBrush, 20, 250);

            PDFStandardFont heiseiMinchoBold = new PDFStandardFont(PDFStandardFontFace.HeiseiMinchoW3Bold, 16);
            page.Canvas.DrawString("Heisei Mincho Bold - サンプル日本語フォントデモテキスト.", heiseiMinchoBold, blackBrush, 20, 275);

            PDFStandardFont heiseiMinchoItalic = new PDFStandardFont(PDFStandardFontFace.HeiseiMinchoW3Italic, 16);
            page.Canvas.DrawString("Heisei Mincho Italic - サンプル日本語フォントデモテキスト.", heiseiMinchoItalic, blackBrush, 20, 300);

            PDFStandardFont heiseiMinchoBoldItalic = new PDFStandardFont(PDFStandardFontFace.HeiseiMinchoW3BoldItalic, 16);
            page.Canvas.DrawString("Heisei Mincho Bold Italic - サンプル日本語フォントデモテキスト.", heiseiMinchoBoldItalic, blackBrush, 20, 325);

            PDFStandardFont hanyangSystemsGothicMedium = new PDFStandardFont(PDFStandardFontFace.HanyangSystemsGothicMedium, 16);
            page.Canvas.DrawString("Hanyang Systems Gothic Medium - 샘플 한국어 글꼴 데모 텍스트.", hanyangSystemsGothicMedium, blackBrush, 20, 350);

            PDFStandardFont hanyangSystemsGothicMediumBold = new PDFStandardFont(PDFStandardFontFace.HanyangSystemsGothicMediumBold, 16);
            page.Canvas.DrawString("Hanyang Systems Gothic Medium Bold - 샘플 한국어 글꼴 데모 텍스트.", hanyangSystemsGothicMediumBold, blackBrush, 20, 375);

            PDFStandardFont hanyangSystemsGothicMediumItalic = new PDFStandardFont(PDFStandardFontFace.HanyangSystemsGothicMediumItalic, 16);
            page.Canvas.DrawString("Hanyang Systems Gothic Medium Italic - 샘플 한국어 글꼴 데모 텍스트.", hanyangSystemsGothicMediumItalic, blackBrush, 20, 400);

            PDFStandardFont hanyangSystemsGothicMediumBoldItalic = new PDFStandardFont(PDFStandardFontFace.HanyangSystemsGothicMediumBoldItalic, 16);
            page.Canvas.DrawString("Hanyang Systems Gothic Medium Bold Italic - 샘플 한국어 글꼴 데모 텍스트.", hanyangSystemsGothicMediumBoldItalic, blackBrush, 20, 425);

            PDFStandardFont hanyangSystemsShinMyeongJoMedium = new PDFStandardFont(PDFStandardFontFace.HanyangSystemsShinMyeongJoMedium, 16);
            page.Canvas.DrawString("Hanyang Systems Shin Myeong Jo Medium - 샘플 한국어 글꼴 데모 텍스트.", hanyangSystemsShinMyeongJoMedium, blackBrush, 20, 450);

            PDFStandardFont hanyangSystemsShinMyeongJoMediumBold = new PDFStandardFont(PDFStandardFontFace.HanyangSystemsShinMyeongJoMediumBold, 16);
            page.Canvas.DrawString("Hanyang Systems Shin Myeong Jo Medium Bold - 샘플 한국어 글꼴 데모 텍스트.", hanyangSystemsShinMyeongJoMediumBold, blackBrush, 20, 475);

            PDFStandardFont hanyangSystemsShinMyeongJoMediumItalic = new PDFStandardFont(PDFStandardFontFace.HanyangSystemsShinMyeongJoMediumItalic, 16);
            page.Canvas.DrawString("Hanyang Systems Shin Myeong Jo Medium Italic - 샘플 한국어 글꼴 데모 텍스트.", hanyangSystemsShinMyeongJoMediumItalic, blackBrush, 20, 500);

            PDFStandardFont hanyangSystemsShinMyeongJoMediumBoldItalic = new PDFStandardFont(PDFStandardFontFace.HanyangSystemsShinMyeongJoMediumBoldItalic, 16);
            page.Canvas.DrawString("Hanyang Systems Shin Myeong Jo Medium Bold Italic - 샘플 한국어 글꼴 데모 텍스트.", hanyangSystemsShinMyeongJoMediumBoldItalic, blackBrush, 20, 525);

            PDFStandardFont monotypeSungLight = new PDFStandardFont(PDFStandardFontFace.MonotypeSungLight, 16);
            page.Canvas.DrawString("Monotype Sung Light - 中國字體樣本示範文本.", monotypeSungLight, blackBrush, 20, 550);

            PDFStandardFont monotypeSungLightBold = new PDFStandardFont(PDFStandardFontFace.MonotypeSungLightBold, 16);
            page.Canvas.DrawString("Monotype Sung Light Bold - 中國字體樣本示範文本.", monotypeSungLightBold, blackBrush, 20, 575);

            PDFStandardFont monotypeSungLightItalic = new PDFStandardFont(PDFStandardFontFace.MonotypeSungLightItalic, 16);
            page.Canvas.DrawString("Monotype Sung Light Italic - 中國字體樣本示範文本.", monotypeSungLightItalic, blackBrush, 20, 600);

            PDFStandardFont monotypeSungLightBoldItalic = new PDFStandardFont(PDFStandardFontFace.MonotypeSungLightBoldItalic, 16);
            page.Canvas.DrawString("Monotype Sung Light Bold Italic - 中國字體樣本示範文本.", monotypeSungLightBoldItalic, blackBrush, 20, 625);

            PDFStandardFont sinoTypeSongLight = new PDFStandardFont(PDFStandardFontFace.SinoTypeSongLight, 16);
            page.Canvas.DrawString("Sino Type Song Light - 中国字体样本示范文本.", sinoTypeSongLight, blackBrush, 20, 650);

            PDFStandardFont sinoTypeSongLightBold = new PDFStandardFont(PDFStandardFontFace.SinoTypeSongLightBold, 16);
            page.Canvas.DrawString("Sino Type Song Light Bold - 中国字体样本示范文本.", sinoTypeSongLightBold, blackBrush, 20, 675);

            PDFStandardFont sinoTypeSongLightItalic = new PDFStandardFont(PDFStandardFontFace.SinoTypeSongLightItalic, 16);
            page.Canvas.DrawString("Sino Type Song Light Italic - 中国字体样本示范文本.", sinoTypeSongLightItalic, blackBrush, 20, 700);

            PDFStandardFont sinoTypeSongLightBoldItalic = new PDFStandardFont(PDFStandardFontFace.SinoTypeSongLightBoldItalic, 16);
            page.Canvas.DrawString("Sino Type Song Light Bold Italic - 中国字体样本示范文本.", sinoTypeSongLightBoldItalic, blackBrush, 20, 725);
        }

        private static void DrawTrueTypeFonts(PDFPage page, Stream ttfStream)
        {
            PDFStandardFont titleFont = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 22);
            PDFBrush blackBrush = new PDFBrush(new PDFRgbColor());

            page.Canvas.DrawString("TrueType fonts", titleFont, blackBrush, 20, 50);
            page.Canvas.DrawString("(when embedded they should be supported", titleFont, blackBrush, 20, 75);
            page.Canvas.DrawString(" by any PDF viewer)", titleFont, blackBrush, 20, 100);

            PDFAnsiTrueTypeFont ansiVerdana = new PDFAnsiTrueTypeFont(ttfStream, 16, true);
            page.Canvas.DrawString("Verdana - Ansi TrueType font", ansiVerdana, blackBrush, 20, 150);
            page.Canvas.DrawString("Lorem ipsum dolor sit amet, consectetur adipiscing elit.", ansiVerdana, blackBrush, 20, 175);

            ttfStream.Position = 0;
            PDFUnicodeTrueTypeFont unicodeVerdana = new PDFUnicodeTrueTypeFont(ttfStream, 16, true);
            page.Canvas.DrawString("Verdana - Unicode TrueType font", unicodeVerdana, blackBrush, 20, 225);

            page.Canvas.DrawString("Russian - Пример русский текст демо шрифт.", unicodeVerdana, blackBrush, 20, 250);
            page.Canvas.DrawString("Greek - Δείγμα ελληνικό κείμενο demo γραμματοσειράς.", unicodeVerdana, blackBrush, 20, 275);
        }

        private static void DisableTextCopy(PDFPage page, Stream ttfStream)
        {
            PDFStandardFont titleFont = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 22);
            PDFBrush blackBrush = new PDFBrush(new PDFRgbColor());

            page.Canvas.DrawString("Draw text that cannot be copied and", titleFont, blackBrush, 20, 50);
            page.Canvas.DrawString("pasted in another applications", titleFont, blackBrush, 20, 75);

            ttfStream.Position = 0;
            PDFUnicodeTrueTypeFont f1 = new PDFUnicodeTrueTypeFont(ttfStream, 16, true);
            page.Canvas.DrawString("This text can be copied and pasted", f1, blackBrush, 20, 150);
            page.Canvas.DrawString("Lorem ipsum dolor sit amet, consectetur adipiscing elit.", f1, blackBrush, 20, 175);

            ttfStream.Position = 0;
            PDFUnicodeTrueTypeFont f2 = new PDFUnicodeTrueTypeFont(ttfStream, 16, true);
            f2.EnableTextCopy = false;
            page.Canvas.DrawString("This text cannot be copied and pasted.", f2, blackBrush, 20, 225);
            page.Canvas.DrawString("Praesent sed massa a est fringilla mattis. Aenean sit amet odio ac nunc.", f2, blackBrush, 20, 250);
        }
    }
}