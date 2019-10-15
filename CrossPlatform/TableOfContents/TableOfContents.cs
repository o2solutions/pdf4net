using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.FlowDocument;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.FormattedContent;
using O2S.Components.PDF4NET.Canvas.Text;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// TableOfContents sample.
    /// </summary>
    public class TableOfContents
    {
        private static string text1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras commodo elementum odio, non venenatis risus efficitur a. " +
            "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Fusce sit amet purus eget sem tristique faucibus. " +
            "Nam ut felis vel ex ullamcorper pretium at quis nisl. Nam ac lacus tincidunt, vulputate sapien vel, tempus sem. Aliquam vel ligula dui. " +
            "Vivamus porttitor nunc vitae mi interdum, vitae ullamcorper turpis bibendum. Vestibulum sagittis lorem ante, at tincidunt arcu suscipit eu. " +
            "Morbi augue eros, tristique a consectetur ac, egestas nec turpis. Praesent non purus quis sem consequat tempor sed ac augue. Integer at mauris ac ipsum bibendum aliquam vitae id mi.";
        private static string text2 = "Praesent efficitur tortor in ligula mattis scelerisque. Fusce in placerat augue. Mauris pretium, dui ac accumsan aliquet, justo sem posuere purus, " +
            "sit amet tristique mi tortor malesuada lorem. Sed congue sem a neque tristique tristique et a odio. Curabitur quis aliquam turpis, tincidunt ullamcorper velit. " +
            "Phasellus posuere, justo auctor convallis luctus, mi tortor interdum lorem, ac tempor nisi lorem in erat. Maecenas dapibus tristique lacus id egestas. " +
            "Vivamus id risus vitae velit porta lacinia. Aliquam erat volutpat. Nulla facilisi. Donec tempor arcu eu rhoncus fringilla.";
        private static string text3 = "Vivamus ullamcorper ligula sit amet interdum imperdiet. Nulla facilisi. Suspendisse et euismod elit. Quisque vitae magna nunc. " +
            "Mauris condimentum at magna blandit semper. Pellentesque in lacus odio. Sed nec molestie lacus, eget scelerisque lorem.";
        private static string text4 = "Etiam rutrum tellus at auctor vehicula. Mauris consequat, tortor vitae finibus efficitur, tellus arcu feugiat leo, in condimentum elit felis ut risus. " +
            "Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Fusce tincidunt libero sem, ut hendrerit turpis dapibus ut. " +
            "Donec lacinia luctus scelerisque. Sed vulputate egestas accumsan. Cras volutpat enim neque, malesuada varius lorem volutpat eget. Mauris lobortis risus ut leo malesuada, " +
            "in volutpat felis finibus. Proin a gravida velit. Ut lorem urna, sollicitudin sit amet nibh at, vestibulum pharetra mauris. Maecenas metus mi, dapibus in erat at, " +
            "congue tincidunt sapien. Vestibulum in pellentesque risus, id accumsan mauris. Donec non ex consequat, pretium ante at, suscipit lacus. Fusce ac consectetur erat. " +
            "Pellentesque maximus justo quis ante ornare condimentum. ";
        private static string text5 = "Mauris quis ante ut sem euismod venenatis at ut massa. Donec gravida velit mauris. Duis suscipit tortor a leo ultricies vehicula. " +
            "Nam condimentum porttitor finibus. Interdum et malesuada fames ac ante ipsum primis in faucibus. Fusce euismod maximus faucibus. Cras venenatis ante mi, nec ultricies tellus elementum in. ";
        private static string text6 = "Duis aliquam ultricies felis ut pharetra. Aliquam vulputate, elit placerat feugiat finibus, metus odio feugiat elit, ut egestas purus nisl vel nulla. " +
            "Nullam vel laoreet purus, in accumsan justo. Morbi rhoncus tellus sem, sed dapibus lacus varius et. In convallis arcu non orci efficitur, varius consequat ipsum eleifend. " +
            "In dapibus mattis maximus. Maecenas quis mi nec mauris maximus scelerisque vel non odio. ";
        private static string text7 = "Proin accumsan orci a nulla gravida tincidunt. Nulla et nisl eget diam rhoncus euismod. Maecenas tellus eros, semper vitae pharetra a, tincidunt ut dolor. " +
            "Nullam tempor at sapien vel efficitur. Duis vel aliquet felis, vitae tincidunt dolor. Sed tortor urna, dictum eu leo quis, feugiat eleifend ligula. Quisque vitae nisi venenatis, " +
            "pretium augue id, consequat velit. Sed dignissim justo velit, id faucibus leo scelerisque sed. In vestibulum blandit ipsum et rhoncus. Aliquam erat lorem, interdum vitae ligula at, " +
            "vulputate feugiat nunc. Fusce condimentum quis ligula ac dictum. Aliquam et viverra purus. Duis sollicitudin dolor eget diam pretium tempus. Nullam in magna eu tortor facilisis placerat non " +
            "vitae eros. Ut vitae magna dictum felis lacinia aliquam facilisis nec sem. ";
        private static string text8 = "Suspendisse potenti. Vivamus maximus mi consequat lectus tincidunt consectetur. Proin vulputate velit lectus, eu lobortis quam lobortis congue. Sed gravida magna non " +
            "eleifend malesuada. Donec tincidunt lorem et semper dignissim. Fusce ut ex vestibulum urna lobortis aliquet in lobortis ex. Integer vehicula erat sed quam dictum varius id sed magna. " +
            "Cras maximus lacus est, ut elementum neque faucibus et. Praesent malesuada egestas scelerisque. Donec interdum ex maximus, auctor nisl non, ornare enim. ";
        private static string text9 = "Nulla finibus quis felis non iaculis. Maecenas fringilla placerat enim non pellentesque. Proin justo orci, elementum ut porttitor in, scelerisque vel nisl. " +
            "Nam sit amet pellentesque justo, et molestie dolor. Cras ipsum justo, facilisis eget diam non, lacinia iaculis libero. Curabitur convallis, velit nec finibus mattis, " +
            "tellus erat elementum ligula, quis viverra quam sapien et enim. Morbi tempor fringilla mattis. ";
        private static string text10 = "Aenean porttitor, augue pretium semper tincidunt, justo orci volutpat odio, malesuada convallis lacus lorem at nisi. Nulla at dolor tincidunt, tempor orci et, blandit metus. " +
            "Pellentesque malesuada augue et odio interdum, sit amet laoreet odio sagittis. Maecenas porttitor consectetur eros nec tempor. Morbi ut pharetra nunc. Phasellus non massa congue, varius tortor nec, " +
            "maximus massa. Cras erat mauris, pulvinar eu nibh ac, scelerisque maximus sem. Nam sed fringilla dolor, finibus tincidunt purus. Sed in dui ut enim interdum sagittis. Cras neque quam, " +
            "ultricies euismod dignissim sit amet, elementum eget eros. Donec in sem vel nunc vulputate pharetra.Fusce rhoncus turpis id turpis aliquet pharetra. Vivamus tristique eros lectus, eget venenatis nulla dictum et. " +
            "Vestibulum volutpat mi eu consequat blandit. Quisque ornare pellentesque tellus, in congue turpis viverra vel. Donec quis velit non nulla aliquet maximus. Maecenas ultricies nisi dui, non dapibus libero tincidunt ut. " +
            "Quisque vel interdum diam, ultricies aliquet nisi. Vivamus dui erat, tincidunt quis nibh et, aliquet ultricies erat. Nullam sit amet sodales nibh, a gravida diam. Fusce efficitur ultrices pellentesque. " +
            "Pellentesque a suscipit justo. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nam lectus tellus, semper ut vehicula vitae, ullamcorper id sem. " +
            "Cras quis ipsum et ligula rutrum dignissim at sit amet leo. Etiam ut tortor in velit feugiat commodo a ut nunc. Proin nec efficitur augue. Phasellus non erat non dolor bibendum viverra in ut nunc. " +
            "Maecenas et sollicitudin nisi, in imperdiet mi. Sed luctus quam felis, a efficitur eros pellentesque ut. Integer suscipit dignissim quam sit amet feugiat. Morbi in odio quis ligula ultrices convallis. " +
            "Duis a dui tristique, pulvinar tellus vel, tristique ex. Sed metus velit, ornare sit amet felis at, finibus gravida ante. Nunc felis massa, viverra eget pellentesque ac, sollicitudin non odio. " +
            "Aliquam dictum nulla mauris, finibus venenatis dolor suscipit at. Donec sagittis consequat diam, non varius dolor ullamcorper et. Proin dictum magna eget massa posuere tincidunt. " +
            "Vivamus ut libero vel diam maximus posuere sagittis maximus mauris. Donec luctus, diam in porttitor interdum, nibh elit ultricies sem, eu porta nulla sapien id nisi. Mauris odio odio, " +
            "mattis quis enim et, laoreet consequat ligula. Praesent feugiat lacus sagittis, laoreet massa sit amet, luctus ipsum. Suspendisse id malesuada velit. Etiam sit amet risus diam. " +
            "Vestibulum non ligula vitae nunc bibendum ornare id ut ante. Morbi at orci mollis, commodo dui et, bibendum augue. Curabitur nibh arcu, vulputate eu sollicitudin et, egestas sed dui. " +
            "Mauris ante enim, cursus et scelerisque eu, vestibulum et neque. Sed gravida ultricies ante sit amet efficitur. Cras est augue, auctor vel commodo sit amet, consectetur at quam. " +
            "Phasellus vulputate convallis neque, vitae bibendum mi rutrum in. Pellentesque pharetra ultricies urna, vitae semper nulla congue non. Praesent venenatis ullamcorper risus, non luctus purus. " +
            "Integer rutrum magna id pulvinar viverra. Aliquam et scelerisque turpis. Quisque sed nisl eu orci congue tempus nec in tellus. Nam eget magna lacus. Nunc eu sapien in velit ultrices tincidunt. " +
            "Curabitur purus libero, viverra non mollis non, hendrerit sit amet tellus. Maecenas congue ut lectus et gravida. Nam commodo lacus at leo sollicitudin gravida. " +
            "Nullam felis ante, dapibus a laoreet a, sagittis id dolor. Sed eget risus id eros faucibus aliquet. Sed rhoncus nibh quam, at congue massa convallis ac. Nullam lobortis ex mauris, " +
            "nec viverra lacus fringilla sed.Pellentesque at sapien quis lectus ultrices fringilla a eu dolor. Pellentesque imperdiet ipsum a odio laoreet vehicula. Aenean vestibulum in dolor non suscipit. " +
            "Curabitur sed felis non mi malesuada mattis quis quis est. Maecenas finibus dolor et libero semper, et posuere sem interdum. Aenean posuere eleifend sapien, ac bibendum lorem egestas id. " +
            "Integer vehicula, quam in laoreet feugiat, neque elit scelerisque dui, eget facilisis dui turpis vel sapien. ";

        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run()
        {
            PDFStandardFont heading1Font = new PDFStandardFont(PDFStandardFontFace.HelveticaBold, 16);
            PDFStandardFont heading2Font = new PDFStandardFont(heading1Font);
            heading2Font.Size = 14;
            PDFStandardFont heading3Font = new PDFStandardFont(heading1Font);
            heading3Font.Size = 12;

            PDFFlowDocument doc = new PDFFlowDocument();

            // Add an intro page to the document.
            PDFFormattedContent fc = new PDFFormattedContent("DEMO DOCUMENT\r\nwith automatically generated\r\nTable of Contents");
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font = new PDFStandardFont(heading1Font);
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font.Size = 24;
            fc.Paragraphs[0].HorizontalAlign = PDFStringHorizontalAlign.Center;
            PDFFlowTextContent ftc = new PDFFlowTextContent(fc);
            doc.AddContent(ftc);
            doc.StartNewPage();

            // Enable/disable the autonumbering of document headings
            bool autoNumber = true;

            // Setup the flow document content.
            // Heading content objects are used for the generation of table of contents.
            fc = new PDFFormattedContent("Chapter One");
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font = heading1Font;
            fc.Paragraphs[0].SpacingBefore = fc.Paragraphs[0].SpacingAfter = 12;
            PDFFlowHeadingContent fhc = new PDFFlowHeadingContent(fc);
            fhc.AutoNumber = autoNumber;
            doc.AddContent(fhc);

            fc = new PDFFormattedContent();
            PDFFormattedParagraph fp = new PDFFormattedParagraph(text1);
            fp.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            fp.FirstLineIndent = 18;
            fc.Paragraphs.Add(fp);
            ftc = new PDFFlowTextContent(fc);
            doc.AddContent(ftc);

            fc = new PDFFormattedContent("Section One");
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font = heading2Font;
            fc.Paragraphs[0].SpacingBefore = fc.Paragraphs[0].SpacingAfter = 12;
            fhc = new PDFFlowHeadingContent(fc);
            fhc.Level = 2;
            fhc.AutoNumber = autoNumber;
            doc.AddContent(fhc);

            fc = new PDFFormattedContent();
            fp = new PDFFormattedParagraph(text2);
            fp.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            fp.FirstLineIndent = 18;
            fc.Paragraphs.Add(fp);
            ftc = new PDFFlowTextContent(fc);
            doc.AddContent(ftc);

            fc = new PDFFormattedContent("Module One");
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font = heading3Font;
            fc.Paragraphs[0].SpacingBefore = fc.Paragraphs[0].SpacingAfter = 12;
            fhc = new PDFFlowHeadingContent(fc);
            fhc.Level = 3;
            fhc.AutoNumber = autoNumber;
            doc.AddContent(fhc);

            fc = new PDFFormattedContent();
            fp = new PDFFormattedParagraph(text3);
            fp.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            fp.FirstLineIndent = 18;
            fc.Paragraphs.Add(fp);
            ftc = new PDFFlowTextContent(fc);
            doc.AddContent(ftc);

            fc = new PDFFormattedContent("Module Two");
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font = heading3Font;
            fc.Paragraphs[0].SpacingBefore = fc.Paragraphs[0].SpacingAfter = 12;
            fhc = new PDFFlowHeadingContent(fc);
            fhc.Level = 3;
            fhc.AutoNumber = autoNumber;
            doc.AddContent(fhc);

            fc = new PDFFormattedContent();
            fp = new PDFFormattedParagraph(text4);
            fp.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            fp.FirstLineIndent = 18;
            fc.Paragraphs.Add(fp);
            ftc = new PDFFlowTextContent(fc);
            doc.AddContent(ftc);

            fc = new PDFFormattedContent("Section Two");
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font = heading2Font;
            fc.Paragraphs[0].SpacingBefore = fc.Paragraphs[0].SpacingAfter = 12;
            fhc = new PDFFlowHeadingContent(fc);
            fhc.Level = 2;
            fhc.AutoNumber = autoNumber;
            doc.AddContent(fhc);

            fc = new PDFFormattedContent();
            fp = new PDFFormattedParagraph(text5);
            fp.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            fp.FirstLineIndent = 18;
            fc.Paragraphs.Add(fp);
            ftc = new PDFFlowTextContent(fc);
            doc.AddContent(ftc);

            fc = new PDFFormattedContent("Module Three");
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font = heading3Font;
            fc.Paragraphs[0].SpacingBefore = fc.Paragraphs[0].SpacingAfter = 12;
            fhc = new PDFFlowHeadingContent(fc);
            fhc.Level = 3;
            fhc.AutoNumber = autoNumber;
            doc.AddContent(fhc);

            fc = new PDFFormattedContent();
            fp = new PDFFormattedParagraph(text6);
            fp.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            fp.FirstLineIndent = 18;
            fc.Paragraphs.Add(fp);
            ftc = new PDFFlowTextContent(fc);
            doc.AddContent(ftc);

            fc = new PDFFormattedContent("Module Four");
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font = heading3Font;
            fc.Paragraphs[0].SpacingBefore = fc.Paragraphs[0].SpacingAfter = 12;
            fhc = new PDFFlowHeadingContent(fc);
            fhc.Level = 3;
            fhc.AutoNumber = autoNumber;
            doc.AddContent(fhc);

            fc = new PDFFormattedContent();
            fp = new PDFFormattedParagraph(text7);
            fp.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            fp.FirstLineIndent = 18;
            fc.Paragraphs.Add(fp);
            ftc = new PDFFlowTextContent(fc);
            doc.AddContent(ftc);

            fc = new PDFFormattedContent("Chapter Two");
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font = heading1Font;
            fc.Paragraphs[0].SpacingBefore = fc.Paragraphs[0].SpacingAfter = 12;
            fhc = new PDFFlowHeadingContent(fc);
            fhc.AutoNumber = autoNumber;
            doc.AddContent(fhc);

            fc = new PDFFormattedContent();
            fp = new PDFFormattedParagraph(text8);
            fp.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            fp.FirstLineIndent = 18;
            fc.Paragraphs.Add(fp);
            ftc = new PDFFlowTextContent(fc);
            doc.AddContent(ftc);

            fc = new PDFFormattedContent("Section Three");
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font = heading2Font;
            fc.Paragraphs[0].SpacingBefore = fc.Paragraphs[0].SpacingAfter = 12;
            fhc = new PDFFlowHeadingContent(fc);
            fhc.Level = 2;
            fhc.AutoNumber = autoNumber;
            doc.AddContent(fhc);

            fc = new PDFFormattedContent();
            fp = new PDFFormattedParagraph(text9);
            fp.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            fp.FirstLineIndent = 18;
            fc.Paragraphs.Add(fp);
            ftc = new PDFFlowTextContent(fc);
            doc.AddContent(ftc);

            fc = new PDFFormattedContent("Module Five");
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font = heading3Font;
            fc.Paragraphs[0].SpacingBefore = fc.Paragraphs[0].SpacingAfter = 12;
            fhc = new PDFFlowHeadingContent(fc);
            fhc.Level = 3;
            fhc.AutoNumber = autoNumber;
            doc.AddContent(fhc);

            fc = new PDFFormattedContent();
            fp = new PDFFormattedParagraph(text10);
            fp.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            fp.FirstLineIndent = 18;
            fc.Paragraphs.Add(fp);
            ftc = new PDFFlowTextContent(fc);
            doc.AddContent(ftc);

            fc = new PDFFormattedContent("Module Six");
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font = heading3Font;
            fc.Paragraphs[0].SpacingBefore = fc.Paragraphs[0].SpacingAfter = 12;
            fhc = new PDFFlowHeadingContent(fc);
            fhc.Level = 3;
            fhc.AutoNumber = autoNumber;
            doc.AddContent(fhc);

            fc = new PDFFormattedContent();
            fp = new PDFFormattedParagraph(text1);
            fp.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            fp.FirstLineIndent = 18;
            fc.Paragraphs.Add(fp);
            ftc = new PDFFlowTextContent(fc);
            doc.AddContent(ftc);

            fc = new PDFFormattedContent("Section Four");
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font = heading2Font;
            fc.Paragraphs[0].SpacingBefore = fc.Paragraphs[0].SpacingAfter = 12;
            fhc = new PDFFlowHeadingContent(fc);
            fhc.Level = 2;
            fhc.AutoNumber = autoNumber;
            doc.AddContent(fhc);

            fc = new PDFFormattedContent();
            fp = new PDFFormattedParagraph(text2);
            fp.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            fp.FirstLineIndent = 18;
            fc.Paragraphs.Add(fp);
            ftc = new PDFFlowTextContent(fc);
            doc.AddContent(ftc);

            fc = new PDFFormattedContent("Module Seven");
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font = heading3Font;
            fc.Paragraphs[0].SpacingBefore = fc.Paragraphs[0].SpacingAfter = 12;
            fhc = new PDFFlowHeadingContent(fc);
            fhc.Level = 3;
            fhc.AutoNumber = autoNumber;
            doc.AddContent(fhc);

            fc = new PDFFormattedContent();
            fp = new PDFFormattedParagraph(text3);
            fp.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            fp.FirstLineIndent = 18;
            fc.Paragraphs.Add(fp);
            ftc = new PDFFlowTextContent(fc);
            doc.AddContent(ftc);

            fc = new PDFFormattedContent("Module Eight");
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font = heading3Font;
            fc.Paragraphs[0].SpacingBefore = fc.Paragraphs[0].SpacingAfter = 12;
            fhc = new PDFFlowHeadingContent(fc);
            fhc.Level = 3;
            fhc.AutoNumber = autoNumber;
            doc.AddContent(fhc);

            fc = new PDFFormattedContent();
            fp = new PDFFormattedParagraph(text4);
            fp.HorizontalAlign = PDFStringHorizontalAlign.Justified;
            fp.FirstLineIndent = 18;
            fc.Paragraphs.Add(fp);
            ftc = new PDFFlowTextContent(fc);
            doc.AddContent(ftc);

            // Setup the document's table of contents.
            PDFFlowDocumentTOCSettings tocSettings = new PDFFlowDocumentTOCSettings();
            // Generate the table of contents as document outline.
            tocSettings.GenerateDocumentOutline = true;
            // Generate the table of contents as a separate page in the document.
            tocSettings.GenerateContentsPage = true;
            tocSettings.ContentsTextFont = new PDFStandardFont(PDFStandardFontFace.Helvetica, 10);
            tocSettings.ContentsTextColor = new PDFBrush(PDFRgbColor.Black);
            // Insert the TOC page at position 1 (after the first page of the document).
            tocSettings.ContentsPagePosition = 1;
            // Visually connect the TOC entries with the page numbers using dots
            tocSettings.ContentsEntryFiller = '.';
            // Create a title for the TOC
            fc = new PDFFormattedContent("TABLE OF CONTENTS");
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font = new PDFStandardFont(heading1Font);
            (fc.Paragraphs[0].Blocks[0] as PDFFormattedTextBlock).Font.Size = 24;
            fc.Paragraphs[0].HorizontalAlign = PDFStringHorizontalAlign.Center;
            fc.Paragraphs[0].SpacingAfter = 24;
            tocSettings.ContentsTitle = new PDFFlowTextContent(fc);
            // Indent the entries in the TOC
            if (autoNumber)
            {
                tocSettings.ContentsHeadingIndent = 10;
            }
            doc.GenerateTableOfContents(tocSettings);

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(doc, "tableofcontents.pdf") };
            return output;
        }
    }
}