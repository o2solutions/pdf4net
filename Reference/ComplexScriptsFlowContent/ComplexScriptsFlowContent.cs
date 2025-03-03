using O2S.Components.PDF4NET.FlowDocument;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.FormattedContent;
using O2S.Components.PDF4NET.Graphics.Text;
using System;

namespace O2S.Components.PDF4NET.Samples
{
    public class ComplexScriptsFlowContent
    {
        static void Main(string[] args)
        {
            PDFFlowDocument document = new PDFFlowDocument();
            PDFStandardFont titleFont = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 16);

            FlowContentArabic(document, titleFont);
            FlowContentBengali(document, titleFont);
            FlowContentDevanagari(document, titleFont);
            FlowContentGujarati(document, titleFont);
            FlowContentGurmukhi(document, titleFont);
            FlowContentHebrew(document, titleFont);
            FlowContentKannada(document, titleFont);
            FlowContentKashmiri(document, titleFont);
            FlowContentKhmer(document, titleFont);
            FlowContentKurdishSorani(document, titleFont);
            FlowContentLao(document, titleFont);
            FlowContentMalayalam(document, titleFont);
            FlowContentMyanmarBurmese(document, titleFont);
            FlowContentOriya(document, titleFont);
            FlowContentPersian(document, titleFont);
            FlowContentSindhi(document, titleFont);
            FlowContentTamil(document, titleFont);
            FlowContentTelugu(document, titleFont);
            FlowContentThai(document, titleFont);
            FlowContentUrduNastaliq(document, titleFont);
            FlowContentUyghur(document, titleFont);
            
            document.Save("ComplexScriptsFlowContent.pdf");

            Console.WriteLine("File saved with success to current folder.");
        }


        public static void FlowContentArabic(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont arialFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\arial.ttf", 12, true, fontFeatures);

            string text = "المادة 1\r\nيولد جميع الناس أحرارًا متساوين في الكرامة والحقوق. وقد وهبوا عقلاً وضميرًا وعليهم أن يعامل بعضهم بعضًا بروح الإخاء." + "\r\n\r\n" +
    "المادة 2\r\nلكل إنسان حق التمتع بكافة الحقوق والحريات الواردة في هذا الإعلان، دون أي تمييز، كالتمييز بسبب العنصر أو اللون أو الجنس أو اللغة أو الدين أو الرأي السياسي أو أي رأي آخر، أو الأصل الوطني أو الإجتماعي أو الثروة أو الميلاد أو أي وضع آخر، دون أية تفرقة بين الرجال والنساء. وفضلاً عما تقدم فلن يكون هناك أي تمييز أساسه الوضع السياسي أو القانوني أو الدولي لبلد أو البقعة التي ينتمي إليها الفرد سواء كان هذا البلد أو تلك البقعة مستقلاً أو تحت الوصاية أو غير متمتع بالحكم الذاتي أو كانت سيادته خاضعة لأي قيد من القيود.";

            PDFFlowTextContent titleContent = new PDFFlowTextContent("Arabic", titleFont);
            document.AddContent(titleContent);

            PDFFormattedContent fc = new PDFFormattedContent(text, arialFont);
            fc.Paragraphs[0].TextDirection = PDFTextDirection.RightToLeft;
            fc.Paragraphs[0].HorizontalAlign = PDFStringHorizontalAlign.Right;
            PDFFlowTextContent textContent = new PDFFlowTextContent(fc);
            document.AddContent(textContent);
        }

        public static void FlowContentBengali(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont bengaliFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansBengali-Regular.ttf", 12, true, fontFeatures);

            string text = "ধারা ১\r\nসমস্ত মানুষ স্বাধীনভাবে সমান মর্যাদা এবং অধিকার নিয়ে জন্মগ্রহণ করে। তাঁদের বিবেক এবং বুদ্ধি আছে; সুতরাং সকলেরই একে অপরের প্রতি ভ্রাতৃত্বসুলভ মনোভাব নিয়ে আচরণ করা উচিত।" + "\r\n\r\n" +
                "ধারা ২\r\nএ ঘোষণায় উল্লেখিত স্বাধীনতা এবং অধিকারসমূহে গোত্র, ধর্ম, বর্ণ, শিক্ষা, ভাষা, রাজনৈতিক বা অন্যবিধ মতামত, জাতীয় বা সামাজিক উত্‍পত্তি, জন্ম, সম্পত্তি বা অন্য কোন মর্যাদা নির্বিশেষে প্রত্যেকের‌ই সমান অধিকার থাকবে।\r\n" +
                "কোন দেশ বা ভূখণ্ডের রাজনৈতিক, সীমানাগত বা আন্তর্জাতিক মর্যাদার ভিত্তিতে তার কোন অধিবাসীর প্রতি কোনরূপ বৈষম্য করা হবেনা; সে দেশ বা ভূখণ্ড স্বাধীন‌ই হোক, হোক অছিভূক্ত, অস্বায়ত্বশাসিত কিংবা সার্বভৌমত্বের অন্য কোন সীমাবদ্ধতায় বিরাজমান।";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Bengali", titleFont);
            document.AddContent(titleContent);

            PDFFlowTextContent textContent = new PDFFlowTextContent(text, bengaliFont);
            document.AddContent(textContent);
        }

        public static void FlowContentDevanagari(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont devanagariFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansDevanagari-Regular.ttf", 12, true, fontFeatures);

            string text = "अनुच्छेद १.\r\nसभी मनुष्यों को गौरव और अधिकारों के मामले में जन्मजात स्वतन्त्रता और समानता प्राप्त है । उन्हें बुद्धि और अन्तरात्मा की देन प्राप्त है और परस्पर उन्हें भाईचारे के भाव से बर्ताव करना चाहिए ।\r\n\r\n" +
                "अनुच्छेद २.\r\nसभी को इस घोषणा में सन्निहित सभी अधिकारों और आज़ादियों को प्राप्त करने का हक़ है और इस मामले में जाति, वर्ण, लिंग, भाषा, धर्म, राजनीति या अन्य विचार-प्रणाली, किसी देश या समाज विशेष में जन्म, सम्पत्ति या किसी प्रकार की अन्य मर्यादा आदि के कारण भेदभाव का विचार न किया जाएगा । इसके अतिरिक्त, चाहे कोई देश या प्रदेश स्वतन्त्र हो, संरक्षित हो, या स्त्रशासन रहित हो या परिमित प्रभुसत्ता वाला हो, उस देश या प्रदेश की राजनैतिक, क्षेत्रीय या अन्तर्राष्ट्रीय स्थिति के आधार पर वहां के निवासियों के प्रति कोई फ़रक़ न रखा जाएगा ।";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Devanagari", titleFont);
            document.AddContent(titleContent);

            PDFFlowTextContent textContent = new PDFFlowTextContent(text, devanagariFont);
            document.AddContent(textContent);
        }

        public static void FlowContentGujarati(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont gujaratiFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansGujarati-Regular.ttf", 12, true, fontFeatures);

            string text = "અનુચ્છેદ ૧:\r\nપ્રતિષ્ઠા અને અધિકારોની દૃષ્ટિએ સર્વ માનવો જન્મથી સ્વતંત્ર અને સમાન હોય છે. તેમનામાં વિચારશક્તિ અને અંતઃકરણ હોય છે અને તેમણે પરસ્પર બંધુત્વની ભાવનાથી વર્તવું જોઇએ.\r\n\r\n" +
                "અનુચ્છેદ ૨:\r\nદરેક વ્યક્તિને જાતિ, રંગ, લિંગ, ભાષા, ધર્મે, રાજકીય અથવા બીજા અભિપ્રાય, રાષ્ટ્રીય અથવા સામાજિક ઉદ્ભવસ્થાન, મિલકત, જન્મ અથવા મોભા જેવા કોઇપણ જાતના ભેદભાવ વગર આ ધોષણામાં રજૂ કરવામાં આવેલા સધળા અધિકારો અને સ્વતંત્રતા ભોગવવાનો હક્ક છે. વધુમાં કોઇપણ વ્યક્તિ તે સ્વતંત્ર, ટ્રસ્ટ હેઠળના સ્વશાસન હેઠળ ન હોય તેવા અથવા સાર્વભામત્વની બીજી કોઇપણ મર્યાદા હેઠળ આવેલા દેશ અથવા પ્રદેશની હોય તો પણ રાજકીય, હફમવવિષયક અથવા આંતરરાષ્ટ્રીય મોભાના ધોરણે તેની સાથે કોઇપણ ભેદભાવ રાખવામાં આવશે નહિ.";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Gujarati", titleFont);
            document.AddContent(titleContent);

            PDFFlowTextContent textContent = new PDFFlowTextContent(text, gujaratiFont);
            document.AddContent(textContent);
        }

        public static void FlowContentGurmukhi(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont gurmukhiFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansGurmukhi-Regular.ttf", 12, true, fontFeatures);

            string text = "ਆਰਟੀਕਲ: 1\r\nਸਾਰਾ ਮਨੁੱਖੀ ਪਰਿਵਾਰ ਆਪਣੀ ਮਹਿਮਾ, ਸ਼ਾਨ ਅਤੇ ਹੱਕਾਂ ਦੇ ਪੱਖੋਂ ਜਨਮ ਤੋਂ ਹੀ ਆਜ਼ਾਦ ਹੈ ਅਤੇ ਸੁਤੇ ਸਿੱਧ ਸਾਰੇ ਲੋਕ ਬਰਾਬਰ ਹਨ । ਉਨ੍ਹਾਂ ਸਭਨਾ ਨੂੰ ਤਰਕ ਅਤੇ ਜ਼ਮੀਰ ਦੀ ਸੌਗਾਤ ਮਿਲੀ ਹੋਈ ਹੈ ਅਤੇ ਉਨ੍ਹਾਂ ਨੂੰ ਭਰਾਤਰੀਭਾਵ ਦੀ ਭਾਵਨਾ ਰਖਦਿਆਂ ਆਪਸ ਵਿਚ ਵਿਚਰਣਾ ਚਾਹੀਦਾ ਹੈ ।\r\n\r\n" +
                "ਆਰਟੀਕਲ: 2\r\nਹਰੇਕ ਵਿਅਕਤੀ ਨੂੰ ਭਾਵੇਂ ਉਸ ਦੀ ਕੋਈ ਨਸਲ, ਰੰਗ, ਲਿੰਗ, ਭਾਸ਼ਾ, ਧਰਮ, ਰਾਜਨੀਤਕ ਵਿਚਾਰਧਾਰਾ ਜਾਂ ਕੋਈ ਹੋਰ ਵਿਚਾਰਧਾਰਾ ਹੋਏ, ਭਾਵੇਂ ਉਸ ਦੀ ਕੋਈ ਵੀ ਜਾਇਦਾਦ ਹੋਵੇ ਅਤੇ ਭਾਵੇਂ ਉਸ ਦਾ ਕਿਤੇ ਵੀ ਜਨਮ ਹੋਇਆ ਹੋਵੇ ਤੇ ਉਸਦਾ ਕੋਈ ਵੀ ਰੁਤਬਾ ਹੋਵੇ, ਉਹ ਐਲਾਨਨਾਮੇ ਵਿਚ ਮਿਲੇ ਅਧਿਕਾਰਾਂ ਤੇ ਆਜ਼ਾਦੀਆਂ ਨੂੰ ਪ੍ਰਾਪਤ ਕਰਨ ਦਾ ਹੱਕ ਰਖਦਾ ਹੈ । ਇਸ ਤੋਂ ਵੀ ਅੱਗੇ ਇਸ ਗੱਲ ਦਾ ਕੋਈ ਭੇਦ ਭਾਵ ਨਹੀਂ ਰਖਿਆ ਜਾਏਗਾ ਕਿ ਉਹ ਵਿਅਕਤੀ ਕਿਹੜੇ ਮੁਲਕ ਦਾ ਹੈ ਅਤੇ ਉਸ ਮੁਲਕ ਦਾ ਅੰਤਰਰਾਸ਼ਟਰੀ ਰੁਤਬਾ ਕਿਹੋ ਜਿਹਾ ਹੈ । ਇਸ ਗੱਲ ਦਾ ਵੀ ਖਿਆਲ ਨਹੀਂ ਰਖਿਆ ਜਾਏਗਾ ਕਿ ਉਹ ਵਿਅਕਤੀ ਕਿਸੇ ਆਜ਼ਾਦ ਮੁਲਕ ਦਾ ਹੈ, ਜਾਂ ਉਹ ਮੁਲਕ ਕਿਸੇ ਟਰੱਸਟ ਅਧੀਨ ਹੈ ਜਾਂ ਉਸ ਦਾ ਆਪਣਾ ਸਵੈਸ਼ਾਸਨ ਨਹੀਂ ਅਤੇ ਜਾਂ ਉਹ ਕਿਸੇ ਅਜਿਹੇ ਇਲਾਕੇ ਵਿਚ ਰਹਿੰਦਾ ਹੈ ਜਿਸ ਦੀ ਪ੍ਰਭੂਸੱਤਾ ਸੀਮਤ ਹੈ ।";

            document.StartNewPage();
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Gurmukhi", titleFont);
            document.AddContent(titleContent);

            PDFFlowTextContent textContent = new PDFFlowTextContent(text, gurmukhiFont);
            document.AddContent(textContent);
        }

        public static void FlowContentHebrew(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont hebrewFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\arial.ttf", 12, true, fontFeatures);

            string text = "סעיף א.\r\nכל בני אדם נולדו בני חורין ושווים בערכם ובזכויותיהם. כולם חוננו בתבונה ובמצפון, לפיכך חובה עליהם לנהוג איש ברעהו ברוח של אחוה." + "\r\n\r\n" +
                "סעיף ב.\r\nכל אדם זכאי לזכויות ולחרויות שנקבעו בהכרזש זו ללא הפליה כלשהיא מטעמי גזע, צבע, מין, לשון, דח, דעה פוליטית או דעה בבעיות אחרות, בגלל מוצא לאומי או חברתי, קנין, לידה או מעמד אחר. גדולה מזו, לא יופלה אדם על פי מעמדה המדיני, על פי סמכותה או על פי מעמדה הבינלאומי של המדינה או הארץ שאליה הוא שייך, דין שהארץ היא עצמאית, ובין שהיא נתונה לנאמנות, בין שהיא נטולת שלטון עצמי ובין שריבונותה מוגבלת כל הגבלה אחרת.";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Hebrew", titleFont);
            document.AddContent(titleContent);

            PDFFormattedContent fc = new PDFFormattedContent(text, hebrewFont);
            fc.Paragraphs[0].TextDirection = PDFTextDirection.RightToLeft;
            fc.Paragraphs[0].HorizontalAlign = PDFStringHorizontalAlign.Right;
            PDFFlowTextContent textContent = new PDFFlowTextContent(fc);
            document.AddContent(textContent);
        }

        public static void FlowContentKannada(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont kannadaFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansKannada-Regular.ttf", 12, true, fontFeatures);

            string text = "ಮಾನವ ಕುಟುಂಬದ ಸಮಸ್ತ ಸದಸ್ಯರ ಸಹಜ ಗೌರವವನ್ನೂ ಸಮಾನವೂ ಅನನ್ಯಹಾರ್ಯವೂ ಆದ ಹಕ್ಕುಗಳನ್ನು ಅಂಗೀಕರಿಸುವುದು ಪ್ರಪಂಚದಲ್ಲಿ ಸ್ವಾತಂತ್ರ್ಯದ ಧರ್ಮಶಾಂತತೆಗಳ ತಳಹದಿಯಾಗಿರುವುದರಿಂದಲೂ.\r\n" +
                "ಮಾನವ ಹಕ್ಕುಗಳಗೆ ತೋರಿಸಲ್ಪಟ್ವ ಉಪೇಕ್ಷೆ ತಿರಸ್ಕಾರಗಳು, ಮಾನವನ ಅಂತಃಕರಣವನ್ನು ದಾರುಣಗೊಳಿಸಿದಂತಹ ಕ್ರೂರಕೃತ್ಯಗಳಾಗಿ ಪರಿಣಮಿಸಿರುವುದರಿಂದಲೂ, ಮತ್ತು ಯಾವ ಪ್ರಪಂಚದಲ್ಲಿ ಮನುಷ್ಯ ಜೀವಿಗಳು ವಾಕ್‌ಸ್ವಾತಂತ್ರ್ಯ ವಿಶ್ವಾಸ ಸ್ವಾತಂತ್ರ್ಯಗಳನ್ನು ಅನುಭವಿಸುವವೋ ಯಾವ ಪ್ರಪಂಚದಲ್ಲಿ ಅಂಜಿಕೆ ಮತ್ತು ಅಭಾವಗಳಿಂದ ಮುಕ್ತವಾಗಿರುವುದು ಸಾಮಾನ್ಯ ಜನತೆಯ ಮಹದಾಶಯವೆಂಬುದಾಗಿ ಸಾರಲ್ಪಟ್ಟಿರುವುದೋ ಅಂಥಾ ಪ್ರಪಂಚದಾಗಮನವಾಗಿರುವುದರಿಂದಲೂ.";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Kannada", titleFont);
            document.AddContent(titleContent);

            PDFFlowTextContent textContent = new PDFFlowTextContent(text, kannadaFont);
            document.AddContent(textContent);
        }

        public static void FlowContentKashmiri(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont kashmiriFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoNastaliqUrdu-Regular.ttf", 12, true, fontFeatures);

            string text = "سٲری اِنسان چھِ آزاد زامٕتؠ۔ وؠقار تہٕ حۆقوٗق چھِ ہِوی۔ تِمَن چھُ سوچ سَمَج عَطا کَرنہٕ آمُت تہٕ تِمَن پَزِ بٲے بَرادٔری ہٕنٛدِس جَذباتَس تَحَت اکھ أکِس اکار بَکار یُن ۔";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Kashmiri", titleFont);
            document.AddContent(titleContent);

            PDFFormattedContent fc = new PDFFormattedContent(text, kashmiriFont);
            fc.Paragraphs[0].TextDirection = PDFTextDirection.RightToLeft;
            fc.Paragraphs[0].HorizontalAlign = PDFStringHorizontalAlign.Right;
            PDFFlowTextContent textContent = new PDFFlowTextContent(fc);
            document.AddContent(textContent);
        }

        public static void FlowContentKhmer(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont khmerFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansKhmer-Regular.ttf", 12, true, fontFeatures);

            string text = "មាត្រា ១\r\nមនុស្សទាំងអស់ កើតមកមានសេរីភាព និងសមភាព ក្នុងផ្នែកសេចក្ដីថ្លៃថ្នូរនិងសិទ្ធិ។ មនុស្ស មានវិចារណញ្ញាណនិងសតិសម្បជញ្ញៈជាប់ពីកំណើត ហើយគប្បីប្រព្រឹត្ដចំពោះគ្នាទៅវិញទៅមក ក្នុង ស្មារតីភាតរភាពជាបងប្អូន។\r\n\r\n" +
                "មាត្រា ២\r\nមនុស្សម្នាក់ៗ អាចប្រើប្រាស់សិទ្ធិនិងសេរីភាពទាំងអស់ ដែលមានចែងក្នុងសេចក្ដីប្រកាសនេះ ដោយគ្មានការប្រកាន់បែងចែកបែបណាមួយ មានជាអាទិ៍ ពូជសាសន៍ ពណ៌សម្បុរ ភេទ ភាសា សាសនា មតិនយោបាយ ឬមតិផ្សេងៗទៀត ដើមកំណើតជាតិ ឬសង្គម ទ្រព្យសម្បត្ដិ កំណើត ឬស្ថានភាព ដទៃៗទៀតឡើយ។ លើសពីនេះ មិនត្រូវធ្វើការប្រកាន់បែងចែកណាមួយ ដោយសំអាងទៅលើឋានៈខាងនយោបាយ ខាងដែនសមត្ថកិច្ច ឬខាងអន្ដរជាតិរបស់ប្រទេស ឬដែនដីដែលបុគ្គលណាម្នាក់រស់នៅ ទោះបីជាប្រទេស ឬដែនដីនោះឯករាជ្យក្ដី ស្ថិតក្រោមអាណាព្យាបាលក្ដី ឬគ្មានស្វ័យគ្រប់គ្រងក្ដី ឬស្ថិតក្រោមការដាក់ កម្រិតផ្សេងទៀតណាមួយ ដល់អធិបតេយ្យភាពក្ដី។";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Khmer", titleFont);
            document.AddContent(titleContent);

            PDFFlowTextContent textContent = new PDFFlowTextContent(text, khmerFont);
            document.AddContent(textContent);
        }

        public static void FlowContentKurdishSorani(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont kurdishSoraniFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\arial.ttf", 12, true, fontFeatures);

            string text = "هەموو مرۆڤ ئازاد و دوەقار و مافان دە وەکهەڤ تێن دنیایێ. ئەو خوەدی هش و شوئوورن و دڤێ لهەمبەر هەڤ بزهنیەتەکە براتیێ بلڤن.";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("KurdishSorani", titleFont);
            document.AddContent(titleContent);

            PDFFormattedContent fc = new PDFFormattedContent(text, kurdishSoraniFont);
            fc.Paragraphs[0].TextDirection = PDFTextDirection.RightToLeft;
            fc.Paragraphs[0].HorizontalAlign = PDFStringHorizontalAlign.Right;
            PDFFlowTextContent textContent = new PDFFlowTextContent(fc);
            document.AddContent(textContent);
        }

        public static void FlowContentLao(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont laoFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSerifLao-Regular.ttf", 12, true, fontFeatures);

            string text = "ມາດຕາ 1:\r\nມະນຸດເກີດມາມີສິດເສລີພາບ ແລະ ສະເໝີໜ້າກັນໃນທາງກຽດຕິສັກ ແລະ ທາງສິດດ້ວຍມະນຸດມີສະຕິສຳປັດຊັນຍະ(ຮູ້ດີຮູ້ຊົ່ວ)ແລະມີມະໂນທຳຈື່ງຕ້ອງປະພຶດຕົນຕໍ່ກັນໃນທາງພີ່ນ້ອງ.\r\n\r\n" +
                "ມາດຕາ 2:\r\nຂໍ້ 1.ຄົນຜູ້ໃດກໍ່ອ້າງຕົນໄດ້ວ່າ:ມີສິດ ແລະ ເສລີພາບທຸກຢ່າງທີ່ໄດ້ປ່າວຮ້ອງຢູ່ໃນປະກາດສະບັບນີ້ໂດຍບໍ່ເລືອກໜ້າ ບໍ່ຈຳກັດເຊື້ອຊາດ,ຜິວເນື້ອ,ເພດ,ສາສະໜາ ຄວາມຄິດເຫັນໃນດ້ານການເມືອງ ຫຼື ອື່ນໆ ກຳເນີດແຫ່ງຊາດຫຼື ສັງຄົມຖານະການມີຊັບສົມບັດມາກ ຫຼື ນ້ອຍ,ມີຕະກຸນ ຫຼື ຖານະອື່ນໆ. ຂໍ້ 2.ອີກປະການໜື່ງ ຈະບໍ່ຈຳກັດຢ່າງໃດໃນການແຕກຕ່າງກັນອັນເນື່ອງມາຈາກລະບຽບການເມືອງການປົກຄອງ ຫຼື ລະຫວ່າງຊາດຂອງປະເທດ ຫຼື ດິນແດນ ຊື່ງບຸກຄົນຜູ້ໃດຜູ້ໜື່ງສັງກັດຢູ່;ດິນແດນນັ້ນຈຳເປັນເອກະລາດຢູ່ໃນຄວາມອາລັກຂາຂອງມະຫາອຳນາດ ຫຼື ບໍ່ມີອິດສະຫຼະ ຫຼື ຖືກລົດອະທິປະໄຕລົງໂດຍຈຳກັດກໍ່ຕາມ.";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Lao", titleFont);
            document.AddContent(titleContent);

            PDFFlowTextContent textContent = new PDFFlowTextContent(text, laoFont);
            document.AddContent(textContent);
        }

        public static void FlowContentMalayalam(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont malayalamFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSerifMalayalam-Regular.ttf", 12, true, fontFeatures);

            string text = "വകുപ്പ്‌ 1.\r\nമനുഷ്യരെല്ലാവരും തുല്യാവകാശങ്ങളോടും അന്തസ്സോടും സ്വാതന്ത്ര്യത്തോടുംകൂടി ജനിച്ചിട്ടുള്ളവരാണ്‌. അന്യോന്യം ഭ്രാതൃഭാവത്തോടെ പെരുമാറുവാനാണ്‌ മനുഷ്യന്നു വിവേകബുദ്ധിയും മനസ്സാക്ഷിയും സിദ്ധമായിരിക്കുന്നത്‌.\r\n\r\n" +
                "വകുപ്പ്‌ 2.\r\nജാതി, മതം, നിറം, ഭാഷ, സ്ത്രീപുരുഷഭേദം, രാഷ്ട്രീയാഭിപ്രായം സ്വത്ത്‌, കുലം എന്നിവയെ കണക്കാക്കാതെ ഈ പ്രഖ്യാപനത്തില്‍ പറയുന്ന അവകാശങ്ങള്‍ക്കും സ്വാതന്ത്ര്യത്തിനും സര്‍വ്വജനങ്ങളും അര്‍ഹരാണ്‌. രാഷ്ട്രീയ സ്ഥിതിയെ അടിസ്ഥാനമാക്കി (സ്വതന്ത്രമോ, പരിമിത ഭരണാധികാരത്തോടു കൂടിയതോ ഏതായാലും വേണ്ടതില്ല) ഈ പ്രഖ്യാപനത്തിലെ അവകാശങ്ങളെ സംബന്ധിച്ചേടത്തോളം യാതൊരു വ്യത്യാസവും യാതൊരാളോടും കാണിക്കാന്‍ പാടുള്ളതല്ല.";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Malayalam", titleFont);
            document.AddContent(titleContent);

            PDFFlowTextContent textContent = new PDFFlowTextContent(text, malayalamFont);
            document.AddContent(textContent);
        }

        public static void FlowContentMyanmarBurmese(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont myanmarBurmeseFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansMyanmarLatin-Regular.ttf", 12, true, fontFeatures);

            string text = "အပိုဒ် ၁\r\nလူတိုင်းသည် တူညီ လွတ်လပ်သော ဂုဏ်သိက္ခာဖြင့် လည်းကောင်း၊ တူညီလွတ်လပ်သော အခွင့်အရေးများဖြင့် လည်းကောင်း၊ မွေးဖွားလာသူများ ဖြစ်သည်။ ထိုသူတို့၌ ပိုင်းခြား ဝေဖန်တတ်သော ဉာဏ်နှင့် ကျင့်ဝတ် သိတတ်သော စိတ်တို့ရှိကြ၍ ထိုသူတို့သည် အချင်းချင်း မေတ္တာထား၍ ဆက်ဆံကျင့်သုံးသင့်၏။\r\n\r\n" +
                "အပိုဒ် ၂\r\nလူတိုင်းသည် လူ့အခွင့် အရေး ကြေညာစာတမ်းတွင် ဖော်ပြထားသည့် အခွင့်အရေး အားလုံး၊ လွတ်လပ်ခွင့် အားလုံးတို့ကို ပိုင်ဆိုင် ခံစားခွင့်ရှိသည်။ လူမျိုးနွယ်အားဖြင့် ဖြစ်စေ၊ အသားအရောင်အားဖြင့် ဖြစ်စေ၊ ကျား၊ မ၊ သဘာဝအားဖြင့် ဖြစ်စေ၊ ဘာသာစကားအားဖြင့် ဖြစ်စေ၊ ကိုးကွယ်သည့် ဘာသာအားဖြင့် ဖြစ်စေ၊ နိုင်ငံရေးယူဆချက်၊ သို့တည်းမဟုတ် အခြားယူဆချက်အားဖြင့် ဖြစ်စေ၊ နိုင်ငံနှင့် ဆိုင်သော၊ သို့တည်းမဟုတ် လူမှုအဆင့်အတန်းနှင့် ဆိုင်သော ဇစ်မြစ် အားဖြင့်ဖြစ်စေ၊ ပစ္စည်း ဥစ္စာ ဂုဏ်အားဖြင့် ဖြစ်စေ၊ မျိုးရိုးဇာတိအားဖြင့် ဖြစ်စေ၊ အခြား အဆင့်အတန်း အားဖြင့် ဖြစ်စေ ခွဲခြားခြင်းမရှိစေရ။ ထို့ပြင် လူတစ်ဦး တစ်ယောက် နေထိုင်ရာ နိုင်ငံ၏ သို့တည်းမဟုတ် နယ်မြေဒေသ၏ နိုင်ငံရေးဆိုင်ရာ ဖြစ်စေ စီရင် ပိုင်ခွင့်ဆိုင်ရာ ဖြစ်စေ တိုင်းပြည် အချင်းချင်း ဆိုင်ရာဖြစ်စေ၊ အဆင့်အတန်း တစ်ခုခုကို အခြေပြု၍ သော်လည်းကောင်း၊ ဒေသနယ်မြေတစ်ခုသည် အချုပ်အခြာ အာဏာပိုင် လွတ်လပ်သည့် နယ်မြေ၊ သို့တည်းမဟုတ် ကုလသမဂ္ဂ ထိန်းသိမ်း စောင့်ရှောက် ထားရသည့် နယ်မြေ၊ သို့တည်းမဟုတ် ကိုယ်ပိုင် အုပ်ချုပ်ခွင့် အာဏာတို့ တစိတ်တဒေသလောက်သာ ရရှိသည့် နယ်မြေ စသဖြင့် ယင်းသို့ သော နယ်မြေများ ဖြစ်သည်၊ ဖြစ်သည် ဟူသော အကြောင်းကို အထောက်အထား ပြု၍ သော်လည်းကောင်း ခွဲခြားခြင်း လုံးဝ မရှိစေရ။";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Myanmar Burmese", titleFont);
            document.AddContent(titleContent);

            PDFFlowTextContent textContent = new PDFFlowTextContent(text, myanmarBurmeseFont);
            document.AddContent(textContent);
        }

        public static void FlowContentOriya(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont oriyaFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansOriya-Regular.ttf", 12, true, fontFeatures);

            string text = "ଭାରତୀୟ ମହାକାଶ ଗବେଷଣା ସଂସ୍ଥା ବା ଇସ୍ରୋ ହେଉଛି ଭାରତ ସରକାରଙ୍କ ପ୍ରମୁଖ ମହାକାଶ ପ୍ରାଧିକରଣ । ଏହା ପୃଥିବୀର ଛଅଟି ବଡ ସରକାରୀ ମହାକାଶ ପ୍ରାଧିକରଣ ମଧ୍ୟରୁ ଅନ୍ୟତମ ଯଥା ।";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Oriya", titleFont);
            document.AddContent(titleContent);

            PDFFlowTextContent textContent = new PDFFlowTextContent(text, oriyaFont);
            document.AddContent(textContent);
        }

        public static void FlowContentPersian(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont persianFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\arial.ttf", 12, true, fontFeatures);

            string text = "تمام افراد بشر آزاد بدنیا میایند و از لحاظ حیثیت و حقوق با هم برابرند. همه دارای عقل و وجدان میباشند و باید نسبت بیکدیگر با روح برادری رفتار کنند." + "\r\n" +
                "ر کس میتواند بدون هیچگونه تمایز مخصوصا از حیث نژاد، رنگ، جنس، زبان، مذهب، عقیدهٔ سیاسی یا هر عقیده دیگر و همچنین ملیت، وضع اجتماعی، ثروت، ولادت یا هر موقعیت دیگر، از تمام حقوق و کلیهٔ آزادی‌هائیکه در اعلامیه ذکر حاضر شده است، بهره‌مند گردد.";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Persian", titleFont);
            document.AddContent(titleContent);

            PDFFormattedContent fc = new PDFFormattedContent(text, persianFont);
            fc.Paragraphs[0].TextDirection = PDFTextDirection.RightToLeft;
            fc.Paragraphs[0].HorizontalAlign = PDFStringHorizontalAlign.Right;
            PDFFlowTextContent textContent = new PDFFlowTextContent(fc);
            document.AddContent(textContent);
        }

        public static void FlowContentSindhi(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont sindhiFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\arial.ttf", 12, true, fontFeatures);

            string text = "آرٽيڪل 1.\r\nسمورا ينسان آزاد ۽ عزت ۽ حقن جي حوالي کان برابر پيدا ٿيا آهن. انهن کي عقل ۽ ضمير حاصل ٿيو آهي⹁ ان ڪري انهن کي هڪ ٻئي سان ڀائيچاري وارو سلو ڪ اختيار ڪرڻ گهرجي." + "\r\n\r\n" +
                "آرٽيڪل 2.\r\nهر فرد انهن سمورين انساني آزادين ۽ حقن جو حقدار آهي⹁ جيڪي هن اعلان ۾ بيان ڪيل آهن ۽ ان حق تي رنگ⹁ نسل⹁ جنس⹁ زبان⹁ مذهب ۽ سياسي متڀپد جو يا ڪنهن نه قسم جي عقيدي⹁ قوم⹁ سماج⹁ دولت يا خانداني حيثيت جو ڪوئي فرق نه پوندو⹁ ان کان سو اءِ جنهن ماڪ يا علائقي سان اهو فرد تعلق رکي ٿو⹁ ان جي سياسي ڪيفيت يا اختيار جو دائرو بين القوامي حيثيت جي بنياد تي ان سان ڪوئي فرق وارو سلوڪ اختيار نه ڪيو ويندو⹁ ڀلي اهو ملڪ آزاد هجي يا ڪاڻيارو يا غير مختيار هجي يا سياسي اختيار جي حوالي سان ڪنھن ٻين پابنديءَ جو شڪار هجي.";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Sindhi", titleFont);
            document.AddContent(titleContent);

            PDFFormattedContent fc = new PDFFormattedContent(text, sindhiFont);
            fc.Paragraphs[0].TextDirection = PDFTextDirection.RightToLeft;
            fc.Paragraphs[0].HorizontalAlign = PDFStringHorizontalAlign.Right;
            PDFFlowTextContent textContent = new PDFFlowTextContent(fc);
            document.AddContent(textContent);
        }

        public static void FlowContentTamil(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont tamilFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansTamil-Regular.ttf", 12, true, fontFeatures);

            string text = "உறுப்புரை 1\r\nமனிதப் பிறிவியினர் சகலரும் சுதந்திரமாகவே பிறக்கின்றனர்; அவர்கள் மதிப்பிலும், உரிமைகளிலும் சமமானவர்கள், அவர்கள் நியாயத்தையும் மனச்சாட்சியையும் இயற்பண்பாகப் பெற்றவர்கள். அவர்கள் ஒருவருடனொருவர் சகோதர உணர்வுப் பாங்கில் நடந்துகொள்ளல் வேண்டும்.\r\n\r\n" +
                "உறுப்புரை 2\r\nஇனம், நிறம், பால், மொழி, மதம், அரசியல் அல்லது வேறு அபிப்பிராயமுடைமை, தேசிய அல்லது சமூகத் தோற்றம், ஆதனம், பிறப்பு அல்லது பிற அந்தஸ்து என்பன போன்ற எத்தகைய வேறுபாடுமின்றி, இப்பிரகடனத்தில் தரப்பட்டுள்ள எல்லா உரிமைகளுக்கும் சுதந்திரங்களுக்கும் எல்லோரும் உரித்துடையவராவர். மேலும், எவரும் அவருக்குரித்துள்ள நாட்டின் அல்லது ஆள்புலத்தின் அரசியல், நியாயாதிக்க அல்லது நாட்டிடை அந்தஸ்தின் அடிப்படையில் — அது தனியாட்சி நாடாக, நம்பிக்கைப் பொறுப்பு நாடாக, தன்னாட்சியற்ற நாடாக அல்லது இறைமை வேறேதேனும் வகையில் மட்டப்படுத்தப்பட்ட நாடாக இருப்பினுஞ்சரி — வேறுபாடெதுவும் காட்டப்படுதலாகாது.";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Tamil", titleFont);
            document.AddContent(titleContent);

            PDFFlowTextContent textContent = new PDFFlowTextContent(text, tamilFont);
            document.AddContent(textContent);
        }

        public static void FlowContentTelugu(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont teluguFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSansTelugu-Regular.ttf", 12, true, fontFeatures);

            string text = "ప్రతిపత్తిస్వత్వముల విషయమున మానవులెల్లరును జన్మతః స్వతంత్రులును సమానులును నగుదురు. వారు వివేచన-అంతఃకరణ సంపన్నులగుటచే పరస్పరము భ్రాతృభావముతో వర్తింపవలయును.";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Telugu", titleFont);
            document.AddContent(titleContent);

            PDFFlowTextContent textContent = new PDFFlowTextContent(text, teluguFont);
            document.AddContent(textContent);
        }

        public static void FlowContentThai(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont thaiFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoSerifThai-Regular.ttf", 12, true, fontFeatures);

            string text = "ข้อ 1\r\nมนุษย์ทั้งหลายเกิดมามีอิสระและเสมอภาคกันในเกียรติศักด[เกียรติศักดิ์]และสิทธิ ต่างมีเหตุผลและมโนธรรม และควรปฏิบัติต่อกันด้วยเจตนารมณ์แห่งภราดรภาพ" + "\r\n\r\n" +
                "ข้อ 2\r\nทุกคนย่อมมีสิทธิและอิสรภาพบรรดาที่กำหนดไว้ในปฏิญญานี้ โดยปราศจากความแตกต่างไม่ว่าชนิดใด ๆ ดังเช่น เชื้อชาติ ผิว เพศ ภาษา ศาสนา ความคิดเห็นทางการเมืองหรือทางอื่น เผ่าพันธุ์แห่งชาติ หรือสังคม ทรัพย์สิน กำเนิด หรือสถานะอื่น ๆ อนึ่งจะไม่มีความแตกต่างใด ๆ ตามมูลฐานแห่งสถานะทางการเมือง ทางการศาล หรือทางการระหว่างประเทศของประเทศหรือดินแดนที่บุคคลสังกัด ไม่ว่าดินแดนนี้จะเป็นเอกราช อยู่ในความพิทักษ์มิได้ปกครองตนเอง หรืออยู่ภายใต้การจำกัดอธิปไตยใด ๆ ทั้งสิ้น";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Thai", titleFont);
            document.AddContent(titleContent);

            PDFFlowTextContent textContent = new PDFFlowTextContent(text, thaiFont);
            document.AddContent(textContent);
        }

        public static void FlowContentUrduNastaliq(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont urduNastaliqFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoNastaliqUrdu-Regular.ttf", 12, true, fontFeatures);

            string text = "دفعہ ۱۔ تمام انسان آزاد اور حقوق و عزت کے اعتبار سے برابر پیدا ہوئے ہیں۔ انہیں ضمیر اور عقل ودیعت ہوئی ہے۔ اس لئے انہیں ایک دوسرے کے ساتھ بھائی چارے کا سلوک کرنا چاہیئے۔" + "\r\n" +
                "دفعہ ۲۔ ہر شخص ان تمام آزادیوں اور حقوق کا مستحق ہے جو اس اعلان میں بیان کئے گئے ہیں، اور اس حق پر نسل، رنگ، جنس، زبان، مذہب اور سیاسی تفریق کا یا کسی قسم کے عقیدے، قوم، معاشرے، دولت یا خاندانی حیثیت وغیرہ کا کوئی اثر نہ پڑے گا۔ اس کے علاوہ جس علاقے یا ملک سے جو شخص تعلق رکھتا ہے اس کی سیاسی کیفیت دائرہ اختیار یا بین الاقوامی حیثیت کی بنا پر اس سے کوئی امتیازی سلوک نہیں کیا جائے گا۔ چاہے وہ ملک یا علاقہ آزاد ہو یا تولیتی ہو یا غیر مختار ہو یا سیاسی اقتدار کے لحاظ سے کسی دوسری بندش کا پابند ہو۔";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Urdu", titleFont);
            document.AddContent(titleContent);

            PDFFormattedContent fc = new PDFFormattedContent(text, urduNastaliqFont);
            fc.Paragraphs[0].TextDirection = PDFTextDirection.RightToLeft;
            fc.Paragraphs[0].HorizontalAlign = PDFStringHorizontalAlign.Right;
            fc.Paragraphs[0].LineSpacingMode = PDFFormattedParagraphLineSpacing.Multiple;
            fc.Paragraphs[0].LineSpacing = 1.5;
            PDFFlowTextContent textContent = new PDFFlowTextContent(fc);
            document.AddContent(textContent);
        }

        public static void FlowContentUyghur(PDFFlowDocument document, PDFFont titleFont)
        {
            PDFBrush blackBrush = new PDFBrush();
            PDFTrueTypeFontFeatures fontFeatures = new PDFTrueTypeFontFeatures();
            fontFeatures.EnableComplexScripts = true;
            PDFUnicodeTrueTypeFont uyghurFont = new PDFUnicodeTrueTypeFont("..\\..\\..\\..\\..\\SupportFiles\\NotoNaskhArabic-Regular.ttf", 12, true, fontFeatures);

            string text = "1 ماددا\r\nھەممە ئادەم زانىدىنلا ئەركىن، ئىززەت-ھۆرمەت ۋە ھوقۇقتا باپباراۋەر بولۇپ تۇغۇلغان. ئۇلار ئەقىلغە ۋە ۋىجدانغا ئىگە ھەمدە بىر-بىرىگە قېرىنداشلىق مۇناسىۋىتىگە خاس روھ بىلەن موئامىلە قىلىشى كېرەك." + "\r\n\r\n" +
                "2 ماددا\r\nھەممە ئادەم مۇشۇ خىتابنامىدە قەيت قىلىنغان بارلىق ھوقۇق ۋە ئەركىنلىكتىن بەھرىمەن بولۇش سالاھىيىتىگە ئىگە. ئۇلار ئىرقى، رەڭگى، جىنسى، تىلى، دىنى، سىياسىي قارىشى ياكى باشقا قارىشى، دۆلەت تەۋەلىكى ياكى ئىجتىمائىي كېلىپ چىقىشى، مۈلكى، تۇغۇلۇشى ياكى باشقا سالاھىيىتى جەھەتتىن قىلچە پەرقلەنمەيدۇ. ئۇنىڭ ئۇستىگە ھەممە ئادەم ئوزى تەۋە دۆلەت ياكى زېمىننىڭ سياسىي، مەمۇرىي لاكى خەلقئارا ئورنىنىڭ ئوخشاش بولماسلىقى بىلەن پەرقلەنمەيدۇ. بۇ زېمىننىڭ مۇستەقىل زېمىن، ۋاكالىتەن باشقۇرۇلۇۋاتقان زېمىن، ئاپتونومىيىسىز زېمىن ياكى باشقا ھەرقانداق ىگىلىك ھوقۇقىغا چەك قويۇلغان ھالەتتىكى زېمىن بولۇشىدىن قەتئىينەزەر.";

            document.AddSpace(12);
            PDFFlowTextContent titleContent = new PDFFlowTextContent("Uyghur", titleFont);
            document.AddContent(titleContent);

            PDFFormattedContent fc = new PDFFormattedContent(text, uyghurFont);
            fc.Paragraphs[0].TextDirection = PDFTextDirection.RightToLeft;
            fc.Paragraphs[0].HorizontalAlign = PDFStringHorizontalAlign.Right;
            fc.Paragraphs[0].LineSpacingMode = PDFFormattedParagraphLineSpacing.Multiple;
            fc.Paragraphs[0].LineSpacing = 1.5;
            PDFFlowTextContent textContent = new PDFFlowTextContent(fc);
            document.AddContent(textContent);
        }
    }
}
