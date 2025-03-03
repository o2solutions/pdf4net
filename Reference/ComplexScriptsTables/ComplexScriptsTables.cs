using O2S.Components.PDF4NET.FlowDocument;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.Text;
using System;

namespace O2S.Components.PDF4NET.Samples
{
    public class ComplexScriptsTables
    {
        static void Main(string[] args)
        {
            PDFFlowDocument document = new PDFFlowDocument();

            ArabicFlowTable(document);
            BengaliFlowTable(document);
            DevanagariFlowTable(document);
            GujaratiFlowTable(document);
            GurmukhiFlowTable(document);
            HebrewFlowTable(document);
            KannadaFlowTable(document);
            KashmiriFlowTable(document);
            KhmerFlowTable(document);
            KurdishSoraniFlowTable(document);
            LaoFlowTable(document);
            MalayalamFlowTable(document);
            MyanmarBurmeseFlowTable(document);
            OriyaFlowTable(document);
            PersianFlowTable(document);
            SindhiFlowTable(document);
            TamilFlowTable(document);
            TeluguFlowTable(document);
            ThaiFlowTable(document);
            UrduNastaliqFlowTable(document);
            UyghurFlowTable(document);
            
            document.Save("ComplexScriptsTables.pdf");

            Console.WriteLine("File saved with success to current folder.");
        }
    

        public static void ArabicFlowTable(PDFFlowDocument document)
        {
            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont arialFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\arial.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Arabic", arialFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 20;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = arialFont;
            defaultCell.TextDirection = PDFTextDirection.RightToLeft;
            defaultCell.HorizontalAlign = PDFGraphicAlign.Far;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("ألأبجدية ٱلعربية", "سَأَلَ", "مأمور");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("معنى", "حَتَّى", "قلوب");
            row = table.Rows.AddRowWithCells("تاريخ", "رَسْمِيًا", "العَرَبِيَّة");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("أَفْعًى", "عَادَةً", "عَيْن");
            row = table.Rows.AddRowWithCells("اِنْتِبَاه", "اَلْمُدِير", "مَا ٱسْمُكَ");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void BengaliFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont bengaliFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansBengali-Regular.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Bengali", bengaliFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 20;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = bengaliFont;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("বাংলা বর্ণমালা", "বাংলা লিপি", "করা");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("কড়া", "করতাল", "গরম");
            row = table.Rows.AddRowWithCells("ব্যাখ্যা", "সন্ধ্যা", "ব্যথা");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("অ্যাটর্নি", "এ্যাডভোকেট", "বাকি");
            row = table.Rows.AddRowWithCells("শুনঽঽঽ", "হাঁপান", "কেউ");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void DevanagariFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont devanagariFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansDevanagari-Regular.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Devanagari", devanagariFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 20;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = devanagariFont;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("देवनागरी", "शक्ति", "वस्तु");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("कहना", "पकवान", "मुँह");
            row = table.Rows.AddRowWithCells("साँप", "ऑफ़िस", "अँगरेज़ी");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("योग्य", "राष्ट्र", "ख़ारीदारी");
            row = table.Rows.AddRowWithCells("हिंदी", "पंजाब", "दुःखी");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void GujaratiFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont gujaratiFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansGujarati-Regular.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Gujarati", gujaratiFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 20;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = gujaratiFont;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("ગુજરાતી લિપિ", "ઘર", "ઘરપર");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("ઘરકામ", "પકડ઼ે", "વરસાદ");
            row = table.Rows.AddRowWithCells("ટિકિટ", "રૂપિયો", "ધૂય");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("કૉફી", "થાળી", "પપૈયું");
            row = table.Rows.AddRowWithCells("ચૌદ", "ઓક્ટોપસ", "ઓળો");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void GurmukhiFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont gurmukhiFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansGurmukhi-Regular.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Gurmukhi", gurmukhiFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 20;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = gurmukhiFont;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("ਗੁਰਮੁਖੀ", "ਜਾਲ਼", "ਓਹਾਇਓ");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("ਉਤਸੁਕ", "ਕਿਹੜਾ", "ਕੁਹੜਾ");
            row = table.Rows.AddRowWithCells("ਕਹਿਣਾ", "ਵਹੁਟੀ", "ਮੂੰਡਾ");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("ਸ਼ਾਂਤ", "ਲੰਮੀ", "ਬਤਾਊਂ");
            row = table.Rows.AddRowWithCells("ਐਨਕ", "ਵੀਕਐਂਡ", "ਆਦਮੀ");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void HebrewFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont hebrewFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\arial.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Hebrew", hebrewFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 20;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = hebrewFont;
            defaultCell.TextDirection = PDFTextDirection.RightToLeft;
            defaultCell.HorizontalAlign = PDFGraphicAlign.Far;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("אָלֶף־בֵּית עִבְרִי", "לִסְגֹּר", "אַבְטָחָה");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("אמץ", "אויר", "חלקה");
            row = table.Rows.AddRowWithCells("אישה", "אלוה", "אֵזוֹר");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("אוֹתְיוֹם", "עֵץ", "עוֹלָם");
            row = table.Rows.AddRowWithCells("בעיה", "גַּבְרִיאֵל", "אַנְגְּלִית");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void KannadaFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont kannadaFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansKannada-Regular.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Kannada", kannadaFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 20;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = kannadaFont;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("ಎಲ್ಲಾ", "ಮಾನವರೂ", "ಸ್ವತಂತ್ರರಾಗಿಯೇ");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("ಜನಿಸಿದ್ದಾರೆ", "ಹಾಗೂ", "ಘನತೆ ಮತ್ತು");
            row = table.Rows.AddRowWithCells("ಹಕ್ಕುಗಳಲ್ಲಿ", "ಸಮಾನರಾಗಿದ್ದಾರೆ", "ವಿವೇಕ ಮತ್ತು");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("ಅಂತಃಕರಣಗಳನ್ನು", "ಪಡೆದವರಾದ್ದರಿಂದ", "ಅವರು");
            row = table.Rows.AddRowWithCells("ಪರಸ್ಪರ", "ಸಹೋದರ", "ಭಾವದಿಂದ");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void KashmiriFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont kashmiriFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoNastaliqUrdu-Regular.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Kashmiri", kashmiriFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 40;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = kashmiriFont;
            defaultCell.TextDirection = PDFTextDirection.RightToLeft;
            defaultCell.HorizontalAlign = PDFGraphicAlign.Far;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("کٲشُر", "اَنْگریٖزی", "پَنہٕ پونْپُر ");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("اوٚنْگٕج", "اِنسان", "آتھوار");
            row = table.Rows.AddRowWithCells("عَکٕس", "عٲقٟل", "کرْٕم");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("وانْدُر", "کانْتُر", "بؠنتھٕر");
            row = table.Rows.AddRowWithCells("پونؠ", "بادَم", "کیْوٚم");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void KhmerFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont khmerFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansKhmer-Regular.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Khmer", khmerFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 30;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = khmerFont;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("អក្សរខ្មែរ", "ប្រយ័ត្ន", "សប្ដាហ៍");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("រេហ៍ពល", "កេរ្តិ៍ ", "បរិបូណ៌");
            row = table.Rows.AddRowWithCells("អាត្មន៑", "កិរិយា", "ក៏");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("ដម", "ពាម", "ខាត់");
            row = table.Rows.AddRowWithCells("ហ្វ៊ីស៉ិក", "ចង្អៀត", "ក្អាត់");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void KurdishSoraniFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont kurdishSoraniFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\arial.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("KurdishSorani", kurdishSoraniFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 20;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = kurdishSoraniFont;
            defaultCell.TextDirection = PDFTextDirection.RightToLeft;
            defaultCell.HorizontalAlign = PDFGraphicAlign.Far;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("زمانێ سۆرانی", "مرۆڤ", "سفر");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("وشک", "مامر", "چووی");
            row = table.Rows.AddRowWithCells("بنەوشە", "قەیچی", "شەو");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("ئافرەت", "ئەمڕۆ", "ئێرانی");
            row = table.Rows.AddRowWithCells("زانستگە", "ئەمڕۆ", "ئاشتی");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void LaoFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont laoFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSerifLao-Regular.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Lao", laoFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 20;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = laoFont;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("ອັກສອນລາວ", "ລະດັບ", "ໂຕະ");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("ໂຕ", "ຫິມະ", "ເຜິ້ງ");
            row = table.Rows.AddRowWithCells("ທະເລ", "ແມັດ", "ເພາະ");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("ເຄີຍ", "ໂພ່ນ", "ເຮືອນ");
            row = table.Rows.AddRowWithCells("ຄວາຍ", "ຊາຽ", "ຈອກ");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void MalayalamFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont malayalamFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSerifMalayalam-Regular.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Malayalam", malayalamFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 20;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = malayalamFont;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("മലയാളലിപി", "പാലു്", "കട്ടയാക്");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("ഐശീല്ം", "എ്ന്നാ", "എങ്ങനെ");
            row = table.Rows.AddRowWithCells("നേരെ", "ടൗൺ", "ചൈന");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("സൗന്ദര്യം", "എല്ലാ", "ഓടുക");
            row = table.Rows.AddRowWithCells("സിമേഈ", "ഋഷി", "വില്ലൻ");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void MyanmarBurmeseFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont myanmarBurmeseFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansMyanmarLatin-Regular.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Myanmar Burmese", myanmarBurmeseFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 40;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = myanmarBurmeseFont;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("မြန်မာအက္ခရာ", "နှစ်", "ဆိုး");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("ဆိုင်", "နွမ်း", "စံပယ်");
            row = table.Rows.AddRowWithCells("မြေပုံ", "ထောပတ်သီး", "ပျော့တယ်");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("ကြောင်", "ပျော်တယ်", "ဩဂုတ်");
            row = table.Rows.AddRowWithCells("ပေါ့တယ်", "ပြတင်းပေါက်", "သန်းခေါင်");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void OriyaFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont oriyaFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansOriya-Regular.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Oriya", oriyaFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 20;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = oriyaFont;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("ଓଡ଼ିଆ ଅକ୍ଷର", "ଅଣ୍ଡା", "ଆଠ");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("ଇଟା", "ଗାଈ", "ଚଉଡା");
            row = table.Rows.AddRowWithCells("ଐରାଵତ", "ଔଷଧ", "ଖାଇବା");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("ଶୁଙ୍ଘିବା", "ରାଜ୍ଞୀ", "ଠିକ");
            row = table.Rows.AddRowWithCells("କାରଣ", "ବାନ୍ଧିବା", "ବଲ୍ଲରି");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void PersianFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont persianFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\arial.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Persian", persianFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 20;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = persianFont;
            defaultCell.TextDirection = PDFTextDirection.RightToLeft;
            defaultCell.HorizontalAlign = PDFGraphicAlign.Far;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("الفبای فارسی", "لزوماً", "اصلاً");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("گازِ طبیعی", "نشانهِٔ سَجاوَندی", "زئوس");
            row = table.Rows.AddRowWithCells("سؤال", "اومدن", "ایرانی");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("معنوی", "عربی", "فائده");
            row = table.Rows.AddRowWithCells("مؤثر", "مسئول", "سوئیس");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void SindhiFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont sindhiFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\arial.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Sindhi", sindhiFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 20;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = sindhiFont;
            defaultCell.TextDirection = PDFTextDirection.RightToLeft;
            defaultCell.HorizontalAlign = PDFGraphicAlign.Far;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("سنڌي", "لوڻ", "قلعو");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("برابر", "متان", "شينهن");
            row = table.Rows.AddRowWithCells("شَڪَرِ", "شُڪْرُ", "شُڪُرُ");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("پَنئُن", "پڙھڻ", "لاهور");
            row = table.Rows.AddRowWithCells("ورسپت", "ڇٽڻ", "ڳئون");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void TamilFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont tamilFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansTamil-Regular.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Tamil", tamilFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 20;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = tamilFont;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("தமிழ்", "மனிதப்", "கிரி");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("கீரி", "குடம்", "அழகு");
            row = table.Rows.AddRowWithCells("கூடம்", "கெடு", "கொடு");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("கௌதாரி", "ஊது", "ஔகாரம்");
            row = table.Rows.AddRowWithCells("ஆண்", "ஒன்று", "பெரீஇஇய");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void TeluguFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont teluguFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansTelugu-Regular.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Telugu", teluguFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 20;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = teluguFont;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("తెలుగు లిపి", "గద్ది", "గోరు");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("బూడిద", "గొంతునొప్పి", "గాలి");
            row = table.Rows.AddRowWithCells("పిట్ట", "నైఋతి", "ఔషధము");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("ఊదా", "ఈక", "ఝంఝ");
            row = table.Rows.AddRowWithCells("రేణువు", "అంగము", "సింహ");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void ThaiFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont thaiFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSerifThai-Regular.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Thai", thaiFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 20;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = thaiFont;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("อักษรไทย", "ถนน", "นคร");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("เมฆ", "เกอะ", "เมีย");
            row = table.Rows.AddRowWithCells("เขียว", "เรื่อย", "จั่วโมง");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("ควาย", "แพง", "น้ำแข็ง");
            row = table.Rows.AddRowWithCells("ซ็อกเก็ต", "เจี๊ยะ", "เฌอ");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void UrduNastaliqFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont urduNastaliqFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoNastaliqUrdu-Regular.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Urdu Nastaliq", urduNastaliqFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 40;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = urduNastaliqFont;
            defaultCell.TextDirection = PDFTextDirection.RightToLeft;
            defaultCell.HorizontalAlign = PDFGraphicAlign.Far;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("اُردُو حُرُوفِ تَہَجِّی", "شَکتی", "وَستُو");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("کَہنا", "پکوان", "ورت");
            row = table.Rows.AddRowWithCells("نہایت", "کھدیوت", "چای");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("روئے زمین", "گائے", "کیسا");
            row = table.Rows.AddRowWithCells("ایک", "شِعر", "شُعلہ");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }

        public static void UyghurFlowTable(PDFFlowDocument document)
        {
            document.StartNewPage();

            PDFBrush lightGrayBrush = new PDFBrush(PDFRgbColor.LightGray);
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont uyghurFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoNaskhArabic-Regular.ttf", 12, true, fontFeatures);

            PDFFlowTextContent textContent = new PDFFlowTextContent("Uyghur", uyghurFont);
            document.AddContent(textContent);

            PDFFlowTableContent table = new PDFFlowTableContent(3);
            table.MinRowHeight = 25;
            PDFFlowTableStringCell defaultCell = new PDFFlowTableStringCell();
            defaultCell.Font = uyghurFont;
            defaultCell.TextDirection = PDFTextDirection.RightToLeft;
            defaultCell.HorizontalAlign = PDFGraphicAlign.Far;
            defaultCell.VerticalAlign = PDFGraphicAlign.Center;
            defaultCell.InnerMargins = new PDFFlowContentMargins(2);
            table.DefaultCell = defaultCell;

            PDFFlowTableRow row = table.Rows.AddRowWithCells("ئۇيغۇر ئەرەب يېزىقى", "يېڭىسار", "بەختىيار");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("بېنزىن", "ئىرادە", "دېڭىز");
            row = table.Rows.AddRowWithCells("گۆش   ", "تۆت", "بۇرۇن");
            row.Background = lightGrayBrush;
            row = table.Rows.AddRowWithCells("جاڭيۇ", "ئۇلۇغ", "مەسئۇل");
            row = table.Rows.AddRowWithCells("نائۈمىت", "داشۈئې", "ئۆيمۇئۆي");
            row.Background = lightGrayBrush;
            document.AddContent(table);
        }
    }
}
