using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.Operators;
using O2S.Components.PDF4NET.Transforms;
using System;
using System.Collections.Generic;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Transform for filtering the page content
    /// </summary>
    public class PDFSeparateContentTransform : PDFPageTransform
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="separationName">Names of separation color to be used as filter for keeping/removing content</param>
        /// <param name="keepSeparation">True if the content displayed using the separation color is kept and the remaining content is discarded. 
        /// False if the content displayed using the separation color is discarded and the remaining content is kept.</param>
        public PDFSeparateContentTransform(string separationName, bool keepSeparation)
        {
            this.separationName = separationName;
            this.keepSeparation = keepSeparation;
            isStrokeSeparationActive = false;
            isFillSeparationActive = false;
            operators = new List<PDFContentStreamOperator>();
            strokeSeparationStack = new Stack<bool>();
            strokeSeparationStack.Push(false);
            fillSeparationStack = new Stack<bool>();
            fillSeparationStack.Push(false);
        }

        private string separationName;
        private bool keepSeparation;
        private bool isStrokeSeparationActive, isFillSeparationActive;
        // Cached path creation operators
        private List<PDFContentStreamOperator> operators;
        // Stacks for keeping track of separation activation across save/restore graphic state operations
        private Stack<bool> fillSeparationStack, strokeSeparationStack;

        protected override void TransformOperator(PDFContentStreamOperator input, List<PDFContentStreamOperator> output)
        {
            PDFContentStreamOperator op = input;

            switch (input.Type)
            {
                case PDFContentStreamOperatorType.SaveGraphicsState:
                    strokeSeparationStack.Push(isStrokeSeparationActive);
                    fillSeparationStack.Push(isFillSeparationActive);
                    break;
                case PDFContentStreamOperatorType.RestoreGraphicsState:
                    isStrokeSeparationActive = strokeSeparationStack.Pop();
                    isFillSeparationActive = fillSeparationStack.Pop();
                    break;
                case PDFContentStreamOperatorType.MoveTo:
                case PDFContentStreamOperatorType.LineTo:
                case PDFContentStreamOperatorType.CCurveTo:
                case PDFContentStreamOperatorType.VCurveTo:
                case PDFContentStreamOperatorType.YCurveTo:
                case PDFContentStreamOperatorType.Rectangle:
                case PDFContentStreamOperatorType.CloseSubpath:
                    operators.Add(input);
                    op = null;
                    break;
                case PDFContentStreamOperatorType.SetRgbFill:
                case PDFContentStreamOperatorType.SetCmykFill:
                case PDFContentStreamOperatorType.SetGrayFill:
                    isFillSeparationActive = false;
                    break;
                case PDFContentStreamOperatorType.SetRgbStroke:
                case PDFContentStreamOperatorType.SetCmykStroke:
                case PDFContentStreamOperatorType.SetGrayStroke:
                    isStrokeSeparationActive = false;
                    break;
                case PDFContentStreamOperatorType.SetFillColorSpace:
                    PDFSetFillColorSpaceOperator fillColorSpaceOperator = input as PDFSetFillColorSpaceOperator;
                    PDFSeparationColorSpace fillSepCs = fillColorSpaceOperator.ColorSpace as PDFSeparationColorSpace;
                    isFillSeparationActive = (fillSepCs != null) && (fillSepCs.Colorant == separationName);
                    break;
                case PDFContentStreamOperatorType.SetStrokeColorSpace:
                    PDFSetStrokeColorSpaceOperator strokeColorSpaceOperator = input as PDFSetStrokeColorSpaceOperator;
                    PDFSeparationColorSpace strokeSepCs = strokeColorSpaceOperator.ColorSpace as PDFSeparationColorSpace;
                    isStrokeSeparationActive = (strokeSepCs != null) && (strokeSepCs.Colorant == separationName);
                    break;
                case PDFContentStreamOperatorType.SetClipNonZero:
                case PDFContentStreamOperatorType.SetClipEvenOdd:
                    output.AddRange(operators);
                    operators.Clear();
                    break;
                case PDFContentStreamOperatorType.EndPath:
                    if (operators.Count > 0)
                    {
                        op = null;
                        operators.Clear();
                    }
                    else
                    {
                        // we had a sequence "path W/W* n", points already cleared by W/W*, n needs to be kept
                    }
                    break;
                case PDFContentStreamOperatorType.Stroke:
                case PDFContentStreamOperatorType.CloseStroke:
                    // The path painting operator is discarded and the path points are cleared
                    if ((isStrokeSeparationActive && !keepSeparation) ||
                        (!isStrokeSeparationActive && keepSeparation))
                    {
                        if (operators.Count > 0)
                        {
                            op = null;
                        }
                        else // we had a sequence "path W/W* S/s", points already cleared by W, S/s needs to be replaced by n
                        {
                            op = new PDFContentStreamOperator(PDFContentStreamOperatorType.EndPath);
                        }
                    }
                    else
                    {
                        output.AddRange(operators);
                    }
                    operators.Clear();
                    break;
                case PDFContentStreamOperatorType.FillNonZero:
                case PDFContentStreamOperatorType.FillNonZero2:
                case PDFContentStreamOperatorType.FillOddEven:
                    // The path painting operator is discarded and the path points are cleared
                    if ((isFillSeparationActive && !keepSeparation) ||
                        (!isFillSeparationActive && keepSeparation))
                    {
                        if (operators.Count > 0)
                        {
                            op = null;
                        }
                        else // we had a sequence "path W/W* f/f*", points already cleared by W, f/f* needs to be replaced by n
                        {
                            op = new PDFContentStreamOperator(PDFContentStreamOperatorType.EndPath);
                        }
                    }
                    else
                    {
                        output.AddRange(operators);
                    }
                    operators.Clear();
                    break;
                case PDFContentStreamOperatorType.CloseFillNonZeroStroke:
                case PDFContentStreamOperatorType.CloseFillEvenOddStroke:
                case PDFContentStreamOperatorType.FillNonZeroStroke:
                case PDFContentStreamOperatorType.FillEvenOddStroke:
                    int discardContent = 0;
                    // The path painting operator is transformed into no-op when the path needs to be discarded
                    if ((isStrokeSeparationActive && !keepSeparation) ||
                        (!isStrokeSeparationActive && keepSeparation))
                    {
                        discardContent += 1;
                    }
                    if ((isFillSeparationActive && !keepSeparation) ||
                        (!isFillSeparationActive && keepSeparation))
                    {
                        discardContent += 2;
                    }
                    switch (discardContent)
                    {
                        case 3: // Discard all
                            if (operators.Count > 0)
                            {
                                op = null;
                            }
                            else // we had a sequence "path W/W* B/B*/b/b*", points already cleared by W, B/B*/b/b* needs to be replaced by n
                            {
                                op = new PDFContentStreamOperator(PDFContentStreamOperatorType.EndPath);
                            }
                            break;
                        case 2: // Discard fill
                            if ((input.Type == PDFContentStreamOperatorType.CloseFillNonZeroStroke) ||
                                (input.Type == PDFContentStreamOperatorType.CloseFillEvenOddStroke))
                            {
                                op = new PDFContentStreamOperator(PDFContentStreamOperatorType.CloseStroke);
                            }
                            else
                            {
                                op = new PDFContentStreamOperator(PDFContentStreamOperatorType.Stroke);
                            }
                            break;
                        case 1: // Discard stroke
                            if ((input.Type == PDFContentStreamOperatorType.CloseFillNonZeroStroke) ||
                                (input.Type == PDFContentStreamOperatorType.FillNonZeroStroke))
                            {
                                op = new PDFContentStreamOperator(PDFContentStreamOperatorType.FillNonZero);
                            }
                            else
                            {
                                op = new PDFContentStreamOperator(PDFContentStreamOperatorType.FillOddEven);
                            }
                            break;
                        case 0:
                            output.AddRange(operators);
                            break;
                    }
                    operators.Clear();
                    break;
                case PDFContentStreamOperatorType.DisplayXObject:
                    PDFDisplayImageXObjectOperator diop = input as PDFDisplayImageXObjectOperator;
                    if (diop != null)
                    {
                        PDFSeparationColorSpace imageSepCs = diop.Image.ColorSpace as PDFSeparationColorSpace;
                        bool isImageSeparationActive = (imageSepCs != null) && (imageSepCs.Colorant == separationName);
                        if ((isImageSeparationActive && !keepSeparation) ||
                            (!isImageSeparationActive && keepSeparation))
                        {
                            op = null;
                        }
                    }
                    break;
                case PDFContentStreamOperatorType.ShowText:
                case PDFContentStreamOperatorType.ShowText2:
                case PDFContentStreamOperatorType.ShowText3:
                case PDFContentStreamOperatorType.ShowText4:
                    // The text showing operator is simply discarded
                    if ((isFillSeparationActive && !keepSeparation) ||
                        (!isFillSeparationActive && keepSeparation))
                    {
                        op = null;
                    }
                    break;
            }

            if (op != null)
            {
                output.Add(op);
            }
        }
    }

    /// <summary>
    /// Separates content of a PDF file based on separation color.
    /// </summary>
    public class ContentSeparator
    {
        /// <summary>
        /// Initializes a new <see cref="ContentSeparator"/> object with a path to input PDF file.
        /// </summary>
        /// <param name="pdfFile"></param>
        /// <param name="separationName">Name of separation that acts as filter for content</param>
        public ContentSeparator(string pdfFile, string separationName)
        {
            this.pdfFile = pdfFile;
            this.separationName = separationName;
        }

        private string pdfFile;

        private string separationName;

        public void KeepSeparationDiscardMainContent(string outputPdfFile)
        {
            PerformSeparation(outputPdfFile, true);
        }

        public void KeepMainDiscardSeparationContent(string outputPdfFile)
        {
            PerformSeparation(outputPdfFile, false);
        }

        private void PerformSeparation(string outputPdfFile, bool keepSeparation)
        {
			FileStream input = File.OpenRead(pdfFile)
            PDFFixedDocument document = new PDFFixedDocument(input);
            input.Close();

            PDFPageTransformer pageTransformer = new PDFPageTransformer(document.Pages[0]);
            PDFSeparateContentTransform sct = new PDFSeparateContentTransform(separationName, keepSeparation);

            pageTransformer.ApplyTransform(sct);

            using (FileStream output = File.Create(outputPdfFile))
            {
                document.Save(output);
                output.Flush();
            }
        }
    }
}
