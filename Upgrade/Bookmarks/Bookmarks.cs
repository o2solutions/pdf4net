using System;
using System.Drawing;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
//using O2S.Components.PDF4NET.Graphics.Shapes;
using O2S.Components.PDF4NET.Graphics.Fonts;
using O2S.Components.PDF4NET.Actions;
using O2S.Components.PDF4NET.Destinations;

namespace O2S.Samples.PDF4NET.Bookmarks
{
    /// <summary>
    /// This sample will show how to create a bookmarks/outlines tree
    /// for a document
    /// </summary>
    class Bookmarks
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Create the graphic objects 
            //PDF4NET v5: PDFFont fontChapter = new PDFFont(PDFFontFace.Helvetica, 20);
            PDFStandardFont fontChapter = new PDFStandardFont(PDFStandardFontFace.Helvetica, 20);
            fontChapter.Bold = true;
            //PDF4NET v5: PDFFont fontSection = new PDFFont(PDFFontFace.Helvetica, 16);
            PDFStandardFont fontSection = new PDFStandardFont(PDFStandardFontFace.Helvetica, 16);
            fontSection.Italic = true;
            //PDF4NET v5: PDFFont fontText = new PDFFont(PDFFontFace.Helvetica, 12);
            PDFStandardFont fontText = new PDFStandardFont(PDFStandardFontFace.Helvetica, 12);
            PDFBrush blackBrush = new PDFBrush(new PDFRgbColor());

            // Create the pdf document
            //PDF4NET v5: PDFDocument pdfDoc = new PDFDocument();
            PDFFixedDocument pdfDoc = new PDFFixedDocument();

            // Display the outlines when opening the document
            pdfDoc.DisplayMode = PDFDisplayMode.UseOutlines;

            // Create 10 pages
            for (int i = 0; i < 10; i++)
            {
                //PDF4NET v5: PDFPage pdfPage = pdfDoc.AddPage();
                PDFPage pdfPage = pdfDoc.Pages.Add();
                //PDF4NET v5: pdfPage.Canvas.DrawText("Chapter " + (i + 1).ToString(), fontChapter, null, blackBrush, 10, 10, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString("Chapter " + (i + 1).ToString(), fontChapter, blackBrush, 10, 10);
                //PDF4NET v5: pdfPage.Canvas.DrawText("Section " + (i + 1).ToString() + ".1", fontSection, null, blackBrush, 20, 32, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString("Section " + (i + 1).ToString() + ".1", fontSection, blackBrush, 20, 32);
                //PDF4NET v5: pdfPage.Canvas.DrawText("Paragraph " + (i + 1).ToString() + ".1.1", fontText, null, blackBrush, 30, 50, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString("Paragraph " + (i + 1).ToString() + ".1.1", fontText, blackBrush, 30, 50);
                //PDF4NET v5: pdfPage.Canvas.DrawText("Paragraph " + (i + 1).ToString() + ".1.2", fontText, null, blackBrush, 30, 200, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString("Paragraph " + (i + 1).ToString() + ".1.2", fontText, blackBrush, 30, 200);
                //PDF4NET v5: pdfPage.Canvas.DrawText("Paragraph " + (i + 1).ToString() + ".1.3", fontText, null, blackBrush, 30, 300, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString("Paragraph " + (i + 1).ToString() + ".1.3", fontText, blackBrush, 30, 300);
                //PDF4NET v5: pdfPage.Canvas.DrawText("Section " + (i + 1).ToString() + ".2", fontSection, null, blackBrush, 20, 400, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString("Section " + (i + 1).ToString() + ".2", fontSection, blackBrush, 20, 400);
                //PDF4NET v5: pdfPage.Canvas.DrawText("Paragraph " + (i + 1).ToString() + ".2.1", fontText, null, blackBrush, 30, 420, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString("Paragraph " + (i + 1).ToString() + ".2.1", fontText, blackBrush, 30, 420);
                //PDF4NET v5: pdfPage.Canvas.DrawText("Paragraph " + (i + 1).ToString() + ".2.2", fontText, null, blackBrush, 30, 570, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString("Paragraph " + (i + 1).ToString() + ".2.2", fontText, blackBrush, 30, 570);
                //PDF4NET v5: pdfPage.Canvas.DrawText("Paragraph " + (i + 1).ToString() + ".2.3", fontText, null, blackBrush, 30, 650, 0, PDFTextAlign.TopLeft);
                pdfPage.Canvas.DrawString("Paragraph " + (i + 1).ToString() + ".2.3", fontText, blackBrush, 30, 650);
            }

            // Create the bookmarks tree
            // Create a root outline
            //PDF4NET v5: PDFBookmark root = CreateBookmark("Bookmarks", new PDFRgbColor(Color.Black), PDFBookmarkDisplayStyle.Bold, pdfDoc.Pages[0]);
            PDFOutlineItem root = CreateBookmark("Bookmarks", PDFRgbColor.Black, PDFOutlineItemVisualStyle.Bold, pdfDoc.Pages[0]);
            //PDF4NET v5: pdfDoc.Bookmarks.Add(root);
            pdfDoc.Outline.Add(root);

            // Create document bookmarks 
            for (int i = 0; i < pdfDoc.Pages.Count; i++)
            {
                // Create chapter bookmark
                //PDF4NET v5: PDFBookmark chapter = CreateBookmark("Chapter " + (i + 1).ToString(), new PDFRgbColor(Color.Blue), PDFBookmarkDisplayStyle.Italic, pdfDoc.Pages[i]);
                PDFOutlineItem chapter = CreateBookmark("Chapter " + (i + 1).ToString(), PDFRgbColor.Blue, PDFOutlineItemVisualStyle.Italic, pdfDoc.Pages[i]);
                //PDF4NET v5: root.Bookmarks.Add(chapter);
                root.Items.Add(chapter);

                // Create section 1 bookmark
                //PDF4NET v5: PDFBookmark section1 = CreateBookmark("Section " + (i + 1).ToString() + ".1", new PDFRgbColor(Color.Green), PDFBookmarkDisplayStyle.Italic, pdfDoc.Pages[i]);
                PDFOutlineItem section1 = CreateBookmark("Section " + (i + 1).ToString() + ".1", PDFRgbColor.Green, PDFOutlineItemVisualStyle.Italic, pdfDoc.Pages[i]);
                //PDF4NET v5: chapter.Bookmarks.Add(section1);
                chapter.Items.Add(section1);

                // Create paragraph bookmarks
                //PDF4NET v5: PDFBookmark paragraph11 = CreateBookmark("Paragraph " + (i + 1).ToString() + ".1.1", new PDFRgbColor(Color.Red), PDFBookmarkDisplayStyle.Regular, pdfDoc.Pages[i]);
                PDFOutlineItem paragraph11 = CreateBookmark("Paragraph " + (i + 1).ToString() + ".1.1", PDFRgbColor.Red, PDFOutlineItemVisualStyle.Regular, pdfDoc.Pages[i]);
                //PDF4NET v5: section1.Bookmarks.Add(paragraph11);
                section1.Items.Add(paragraph11);

                //PDF4NET v5: PDFBookmark paragraph12 = CreateBookmark("Paragraph " + (i + 1).ToString() + ".1.2", new PDFRgbColor(Color.Red), PDFBookmarkDisplayStyle.Regular, pdfDoc.Pages[i]);
                PDFOutlineItem paragraph12 = CreateBookmark("Paragraph " + (i + 1).ToString() + ".1.2", PDFRgbColor.Red, PDFOutlineItemVisualStyle.Regular, pdfDoc.Pages[i]);
                //PDF4NET v5: section1.Bookmarks.Add(paragraph12);
                section1.Items.Add(paragraph12);

                //PDF4NET v5: PDFBookmark paragraph13 = CreateBookmark("Paragraph " + (i + 1).ToString() + ".1.3", new PDFRgbColor(Color.Red), PDFBookmarkDisplayStyle.Regular, pdfDoc.Pages[i]);
                PDFOutlineItem paragraph13 = CreateBookmark("Paragraph " + (i + 1).ToString() + ".1.3", PDFRgbColor.Red, PDFOutlineItemVisualStyle.Regular, pdfDoc.Pages[i]);
                //PDF4NET v5: section1.Bookmarks.Add(paragraph13);
                section1.Items.Add(paragraph13);
                section1.Expanded = true;

                // Create section 2 bookmark
                //PDF4NET v5: PDFBookmark section2 = CreateBookmark("Section " + (i + 1).ToString() + ".2", new PDFRgbColor(Color.Green), PDFBookmarkDisplayStyle.Italic, pdfDoc.Pages[i]);
                PDFOutlineItem section2 = CreateBookmark("Section " + (i + 1).ToString() + ".2", PDFRgbColor.Green, PDFOutlineItemVisualStyle.Italic, pdfDoc.Pages[i]);
                //PDF4NET v5: chapter.Bookmarks.Add(section2);
                chapter.Items.Add(section2);

                // Create paragraph bookmarks
                //PDF4NET v5: PDFBookmark paragraph21 = CreateBookmark("Paragraph " + (i + 1).ToString() + ".2.1", new PDFRgbColor(Color.Red), PDFBookmarkDisplayStyle.Regular, pdfDoc.Pages[i]);
                PDFOutlineItem paragraph21 = CreateBookmark("Paragraph " + (i + 1).ToString() + ".2.1", PDFRgbColor.Red, PDFOutlineItemVisualStyle.Regular, pdfDoc.Pages[i]);
                //PDF4NET v5: section2.Bookmarks.Add(paragraph21);
                section2.Items.Add(paragraph21);

                //PDF4NET v5: PDFBookmark paragraph22 = CreateBookmark("Paragraph " + (i + 1).ToString() + ".2.2", new PDFRgbColor(Color.Red), PDFBookmarkDisplayStyle.Regular, pdfDoc.Pages[i]);
                PDFOutlineItem paragraph22 = CreateBookmark("Paragraph " + (i + 1).ToString() + ".2.2", PDFRgbColor.Red, PDFOutlineItemVisualStyle.Regular, pdfDoc.Pages[i]);
                //PDF4NET v5: section2.Bookmarks.Add(paragraph22);
                section2.Items.Add(paragraph22);

                //PDF4NET v5: PDFBookmark paragraph23 = CreateBookmark("Paragraph " + (i + 1).ToString() + ".2.3", new PDFRgbColor(Color.Red), PDFBookmarkDisplayStyle.Regular, pdfDoc.Pages[i]);
                PDFOutlineItem paragraph23 = CreateBookmark("Paragraph " + (i + 1).ToString() + ".2.3", PDFRgbColor.Red, PDFOutlineItemVisualStyle.Regular, pdfDoc.Pages[i]);
                //PDF4NET v5: section2.Bookmarks.Add(paragraph23);
                section2.Items.Add(paragraph23);
                section2.Expanded = true;

                chapter.Expanded = true;
            }

            root.Expanded = true;

            // Save the document to disk
            pdfDoc.Save("Sample_Bookmarks.pdf");
        }
        /// <summary>
        /// Creates a new bookmark and adds it at the end of the collection.
        /// </summary>
        /// <param name="title">the title of the bookmark</param>
        /// <param name="bookmarkColor">a <see cref="PDFRgbColor"/> object specifying
        /// the color used to draw the bookmark in the bookmark tree.</param>
        /// <param name="visualStyle">a combination of <see cref="PDFOutlineItemVisualStyle"/>
        /// enumeration members, specifying the font style used to draw
        /// the bookmark title.</param>
        /// <param name="destinationPage">a <see cref="PDFPage"/> object 
        /// representing the destination of the bookmark.</param>
        /// <returns>a <see cref="PDFBookmark"/> object representing the
        /// newly created bookmark.</returns>
        public static PDFOutlineItem CreateBookmark(string title,  PDFRgbColor bookmarkColor, PDFOutlineItemVisualStyle visualStyle, PDFPage destinationPage)
        {
            //PDF4NET 5: PDFBookmark bookmark = new PDFBookmark();
            PDFOutlineItem bookmark = new PDFOutlineItem();
            bookmark.Title = title;
            bookmark.Color = bookmarkColor;
            //PDF4NET 5: bookmark.DisplayStyle = displayStyle;
            bookmark.VisualStyle = visualStyle;

            PDFGoToAction gotoAction = new PDFGoToAction();
            //PDF4NET 5: gotoAction.Destination = new PDFPageDestination();
            gotoAction.Destination = new PDFPageDirectDestination();
            //PDF4NET 5: gotoAction.Destination.Page = destinationPage;
            (gotoAction.Destination as PDFPageDirectDestination).Page = destinationPage;
            bookmark.Action = gotoAction;

            return bookmark;
        }
    }
}
