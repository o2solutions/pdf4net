using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Core;

namespace O2S.Components.PDF4NET.Samples
{

    /// <summary>
    /// Defines a custom page content analysis that exports the vector graphics from a page content stream as JSON.
    /// </summary>
    public class JsonExporter : PDFPageContentAnalysis
    {
        public JsonExporter(string jsonFileName)
        {
            this.jsonFileName = jsonFileName;
            indentLevel = 4;
            isPathStarted = false;

            pathBuilder = new StringBuilder();
            pathWriter = new StringWriter(pathBuilder, CultureInfo.InvariantCulture);
        }

        private StringBuilder pathBuilder;

        private StringWriter pathWriter;

        private string jsonFileName;

        private StreamWriter sw;

        private int indentLevel;

        private bool isPathStarted;

        private void WriteString(string id, string value, int indentLevel, TextWriter tw, bool isLastEntry)
        {
            tw.Write(" ".PadLeft(indentLevel) + "\"" + id + "\" : \"" + value + "\"");
            if (!isLastEntry)
            {
                tw.Write(",");
            }
            tw.WriteLine();
        }

        private void WriteNumber(string id, double value, int indentLevel, TextWriter tw, bool isLastEntry)
        {
            tw.Write(" ".PadLeft(indentLevel) + "\"" + id + "\" : " + String.Format(CultureInfo.InvariantCulture, "{0:0.###,###}", value));
            if (!isLastEntry)
            {
                tw.Write(",");
            }
            tw.WriteLine();
        }

        private void WriteArray(string id, double[] values, int indentLevel, TextWriter tw, bool isLastEntry)
        {
            tw.Write(" ".PadLeft(indentLevel) + "\"" + id + "\" : [");
            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0)
                {
                    tw.Write(", ");
                }
                tw.Write(String.Format(CultureInfo.InvariantCulture, "{0:0.###,###}", values[i]));
            }
            tw.Write(" ]");
            if (!isLastEntry)
            {
                tw.Write(",");
            }
            tw.WriteLine();
        }

        private void WriteObjectStart(string id, int indentLevel, TextWriter tw)
        {
            if (!string.IsNullOrEmpty(id))
            {
                tw.WriteLine(" ".PadLeft(indentLevel) + "\"" + id + "\" : ");
            }
            tw.WriteLine(" ".PadLeft(indentLevel) + "{");
        }

        private void WriteObjectEnd(int indentLevel, TextWriter tw, bool isLastEntry)
        {
            tw.Write(" ".PadLeft(indentLevel) + "}");
            if (!isLastEntry)
            {
                tw.Write(",");
            }
            tw.WriteLine();
        }

        private void WriteArrayStart(string id, int indentLevel, TextWriter tw)
        {
            if (!string.IsNullOrEmpty(id))
            {
                tw.WriteLine(" ".PadLeft(indentLevel) + "\"" + id + "\" : ");
            }
            tw.WriteLine(" ".PadLeft(indentLevel) + "[");
        }

        private void WriteArrayEnd(int indentLevel, TextWriter tw, bool isLastEntry)
        {
            tw.Write(" ".PadLeft(indentLevel) + "]");
            if (!isLastEntry)
            {
                tw.Write(",");
            }
            tw.WriteLine();
        }

        private void StartPathIfNotStarted()
        {
            if (!isPathStarted)
            {
                isPathStarted = true;
                WriteObjectStart("", indentLevel, pathWriter);
                indentLevel += 4;
                WriteArrayStart("pathData", indentLevel, pathWriter);
                indentLevel += 4;
            }
        }

        private void FinishPath(string op)
        {
            if (isPathStarted)
            {
                // Remove the last ','
                pathBuilder.Remove(pathBuilder.Length - 3, 1); // 3 = , \r \n
                isPathStarted = false;
                indentLevel -= 4;
                WriteArrayEnd(indentLevel, pathWriter, false);
                WriteString("op", op, indentLevel, pathWriter, true);
                indentLevel -= 4;
                WriteObjectEnd(indentLevel, pathWriter, false);

                sw.Write(pathBuilder.ToString());
            }

            if ((op != "W") && (op != "W*"))
            {
                pathBuilder.Clear();
            }
        }

        public override void Setup()
        {
            PDFPage page = context as PDFPage;
            if (page != null)
            {
                sw = new StreamWriter(jsonFileName);
                sw.WriteLine("{");

                PDFStandardRectangle mediaBox = page.MediaBox;
                WriteArray("MediaBox", new double[] { mediaBox.LLX, mediaBox.LLY, mediaBox.URX, mediaBox.URY }, indentLevel, sw, false);
                PDFStandardRectangle cropBox = page.CropBox;
                if (cropBox != null)
                {
                    WriteArray("CropBox", new double[] { cropBox.LLX, cropBox.LLY, cropBox.URX, cropBox.URY }, indentLevel, sw, false);
                }
                WriteNumber("Rotate", page.Rotation, indentLevel, sw, false);
                WriteArrayStart("Contents", indentLevel, sw);
                indentLevel += 4;
            }
        }

        public override void CleanUp()
        {
            PDFPage page = context as PDFPage;
            if (page != null)
            {
                // Dummy object to compensate the last ','
                sw.WriteLine(" ".PadLeft(indentLevel) + "{}");
                indentLevel -= 4;
                WriteArrayEnd(indentLevel, sw, true);
                sw.WriteLine("}");
                sw.Flush();
                sw.Close();
            }
        }

        public override void AnalyzeConcatenateMatrixOperator(double m11, double m12, double m21, double m22, double tx, double ty)
        {
            WriteObjectStart("", indentLevel, pathWriter);
            indentLevel += 4;
            WriteString("op", "cm", indentLevel, pathWriter, false);
            WriteArray("matrix", new double[] { m11, m12, m21, m22, tx, ty }, indentLevel, pathWriter, true);
            indentLevel -= 4;
            WriteObjectEnd(indentLevel, pathWriter, false);
        }

        public override void AnalyzeMoveToOperator(double x, double y)
        {
            StartPathIfNotStarted();

            WriteObjectStart("", indentLevel, pathWriter);
            indentLevel += 4;
            WriteString("op", "m", indentLevel, pathWriter, false);
            WriteArray("pts", new double[] { x, y }, indentLevel, pathWriter, true);
            indentLevel -= 4;
            WriteObjectEnd(indentLevel, pathWriter, false);
        }

        public override void AnalyzeLineToOperator(double x, double y)
        {
            StartPathIfNotStarted();

            WriteObjectStart("", indentLevel, pathWriter);
            indentLevel += 4;
            WriteString("op", "l", indentLevel, pathWriter, false);
            WriteArray("pts", new double[] { x, y }, indentLevel, pathWriter, true);
            indentLevel -= 4;
            WriteObjectEnd(indentLevel, pathWriter, false);
        }

        public override void AnalyzeRectangleOperator(double x, double y, double width, double height)
        {
            StartPathIfNotStarted();

            WriteObjectStart("", indentLevel, pathWriter);
            indentLevel += 4;
            WriteString("op", "re", indentLevel, pathWriter, false);
            WriteArray("pts", new double[] { x, y, width, height }, indentLevel, pathWriter, true);
            indentLevel -= 4;
            WriteObjectEnd(indentLevel, pathWriter, false);
        }

        public override void AnalyzeCCurveToOperator(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            StartPathIfNotStarted();

            WriteObjectStart("", indentLevel, pathWriter);
            indentLevel += 4;
            WriteString("op", "c", indentLevel, pathWriter, false);
            WriteArray("pts", new double[] { x1, y1, x2, y2, x3, y3 }, indentLevel, pathWriter, true);
            indentLevel -= 4;
            WriteObjectEnd(indentLevel, pathWriter, false);
        }

        public override void AnalyzeYCurveToOperator(double x1, double y1, double x2, double y2)
        {
            StartPathIfNotStarted();

            WriteObjectStart("", indentLevel, pathWriter);
            indentLevel += 4;
            WriteString("op", "y", indentLevel, pathWriter, false);
            WriteArray("pts", new double[] { x1, y1, x2, y2 }, indentLevel, pathWriter, true);
            indentLevel -= 4;
            WriteObjectEnd(indentLevel, pathWriter, false);
        }

        public override void AnalyzeVCurveToOperator(double x1, double y1, double x2, double y2)
        {
            StartPathIfNotStarted();

            WriteObjectStart("", indentLevel, pathWriter);
            indentLevel += 4;
            WriteString("op", "v", indentLevel, pathWriter, false);
            WriteArray("pts", new double[] { x1, y1, x2, y2 }, indentLevel, pathWriter, true);
            indentLevel -= 4;
            WriteObjectEnd(indentLevel, pathWriter, false);
        }

        /// <summary>
        /// Called when b operator is found.
        /// </summary>
        /// <param name="pathVisualObject">The path painted by this operator.</param>
        /// <remarks>The pathVisualObject parameter is set only when the <see cref="EnableExtendedOperatorInformation"/> property is set to true 
        /// on the analyzer that processes this operator.</remarks>
        public override void AnalyzeCloseFillNonZeroStrokeOperator(PDFPathVisualObject pathVisualObject)
        {
            FinishPath("b");
        }

        /// <summary>
        /// Called when b* operator is found.
        /// </summary>
        /// <param name="pathVisualObject">The path painted by this operator.</param>
        /// <remarks>The pathVisualObject parameter is set only when the <see cref="EnableExtendedOperatorInformation"/> property is set to true 
        /// on the analyzer that processes this operator.</remarks>
        public override void AnalyzeCloseFillEvenOddStrokeOperator(PDFPathVisualObject pathVisualObject)
        {
            FinishPath("b*");
        }

        /// <summary>
        /// Called when B operator is found.
        /// </summary>
        /// <param name="pathVisualObject">The path painted by this operator.</param>
        /// <remarks>The pathVisualObject parameter is set only when the <see cref="EnableExtendedOperatorInformation"/> property is set to true 
        /// on the analyzer that processes this operator.</remarks>
        public override void AnalyzeFillNonZeroStrokeOperator(PDFPathVisualObject pathVisualObject)
        {
            FinishPath("B");
        }

        /// <summary>
        /// Called when B* operator is found.
        /// </summary>
        /// <param name="pathVisualObject">The path painted by this operator.</param>
        /// <remarks>The pathVisualObject parameter is set only when the <see cref="EnableExtendedOperatorInformation"/> property is set to true 
        /// on the analyzer that processes this operator.</remarks>
        public override void AnalyzeFillEvenOddStrokeOperator(PDFPathVisualObject pathVisualObject)
        {
            FinishPath("B*");
        }

        /// <summary>
        /// Called when f operator is found.
        /// </summary>
        /// <param name="pathVisualObject">The path painted by this operator.</param>
        /// <remarks>The pathVisualObject parameter is set only when the <see cref="EnableExtendedOperatorInformation"/> property is set to true 
        /// on the analyzer that processes this operator.</remarks>
        public override void AnalyzeFillNonZeroOperator(PDFPathVisualObject pathVisualObject)
        {
            FinishPath("f");
        }

        /// <summary>
        /// Called when F operator is found.
        /// </summary>
        /// <param name="pathVisualObject">The path painted by this operator.</param>
        /// <remarks>The pathVisualObject parameter is set only when the <see cref="EnableExtendedOperatorInformation"/> property is set to true 
        /// on the analyzer that processes this operator.</remarks>
        public override void AnalyzeFillNonZero2Operator(PDFPathVisualObject pathVisualObject)
        {
            FinishPath("F");
        }

        /// <summary>
        /// Called when f* operator is found.
        /// </summary>
        /// <param name="pathVisualObject">The path painted by this operator.</param>
        /// <remarks>The pathVisualObject parameter is set only when the <see cref="EnableExtendedOperatorInformation"/> property is set to true 
        /// on the analyzer that processes this operator.</remarks>
        public override void AnalyzeFillOddEvenOperator(PDFPathVisualObject pathVisualObject)
        {
            FinishPath("f*");
        }

        /// <summary>
        /// Called when n operator is found.
        /// </summary>
        /// <param name="pathVisualObject">The path painted by this operator.</param>
        /// <remarks>The pathVisualObject parameter is set only when the <see cref="EnableExtendedOperatorInformation"/> property is set to true 
        /// on the analyzer that processes this operator.</remarks>
        public override void AnalyzeEndPathOperator(PDFPathVisualObject pathVisualObject)
        {
            isPathStarted = false;
            pathBuilder.Clear();
        }

        /// <summary>
        /// Called when S operator is found.
        /// </summary>
        /// <param name="pathVisualObject">The path painted by this operator.</param>
        /// <remarks>The pathVisualObject parameter is set only when the <see cref="EnableExtendedOperatorInformation"/> property is set to true 
        /// on the analyzer that processes this operator.</remarks>
        public override void AnalyzeStrokeOperator(PDFPathVisualObject pathVisualObject)
        {
            FinishPath("S");
        }

        /// <summary>
        /// Called when s operator is found.
        /// </summary>
        /// <param name="pathVisualObject">The path painted by this operator.</param>
        /// <remarks>The pathVisualObject parameter is set only when the <see cref="EnableExtendedOperatorInformation"/> property is set to true 
        /// on the analyzer that processes this operator.</remarks>
        public override void AnalyzeCloseStrokeOperator(PDFPathVisualObject pathVisualObject)
        {
            FinishPath("s");
        }

        /// <summary>
        /// Called when W operator is found.
        /// </summary>
        /// <param name="pathVisualObject">The path clipped by this operator.</param>
        /// <remarks>The pathVisualObject parameter is set only when the <see cref="EnableExtendedOperatorInformation"/> property is set to true 
        /// on the analyzer that processes this operator.</remarks>
        public override void AnalyzeSetClipNonZeroOperator(PDFPathVisualObject pathVisualObject)
        {
            FinishPath("W");
        }

        /// <summary>
        /// Called when W* operator is found.
        /// </summary>
        /// <param name="pathVisualObject">The path clipped by this operator.</param>
        /// <remarks>The pathVisualObject parameter is set only when the <see cref="EnableExtendedOperatorInformation"/> property is set to true 
        /// on the analyzer that processes this operator.</remarks>
        public override void AnalyzeSetClipEvenOddOperator(PDFPathVisualObject pathVisualObject)
        {
            FinishPath("W*");
        }

    }

    public class PageAnalyzer
    {
        static void Main(string[] args)
        {
            string fileName = "..\\..\\..\\..\\..\\SupportFiles\\content.pdf";

            PDFFixedDocument document = new PDFFixedDocument(fileName);

            JsonExporter jsonExporter = new JsonExporter("page.json");
            PDFPageContentAnalyzer pageContentAnalyzer = new PDFPageContentAnalyzer(document.Pages[3]);
            pageContentAnalyzer.RunAnalysis(jsonExporter);
        }
    }
}
