The `PageAnalyzer` sample shows how to implement a custom page analysis. A page analysis is a read-only parser of a page content stream. 

The `JsonExporter` class (inherits from `PDFPageContentAnalysis`) shows how to export the path objects in a page content stream as json objects.

A custom page analysis is implemented by inheriting the `PDFPageContentAnalysis` and overriding any of the `Analyze*` methods.

The `PDFPageContentAnalysis` implements a parser for the page content stream. When the analysis is run, the page content stream is parsed and for each operator in the page content stream its corresponding `Analyze` method is called. The operands are passed as parameters to the method.

|Operator|Method|
|---|---|
| BX | AnalyzeBeginCompatibilitySectionOperator() |
| EX | AnalyzeEndCompatibilitySectionOperator() |
| q| AnalyzeSaveGraphicsStateOperator() |
| Q | AnalyzeRestoreGraphicsStateOperator() |
| sc | AnalyzeSetFillColorOperator(double[] colorComponents) |
| SC | AnalyzeSetStrokeColorOperator(double[] colorComponents) |
| scn | AnalyzeSetFillColorNOperator(double[] colorComponents, PdfCosName cosPatternID) |
| SCN | AnalyzeSetStrokeColorNOperator(double[] colorComponents, PdfCosName cosPatternID) |
| cs | AnalyzeSetFillColorSpaceOperator(PdfCosName cosColorSpaceID, PdfColorSpace colorSpace) |
| CS | AnalyzeSetStrokeColorSpaceOperator(PdfCosName cosColorSpaceID, PdfColorSpace colorSpace) |
| gs | AnalyzeSetGraphicsStateOperator(PdfCosName cosGraphicsStateID, PdfCosDictionary cosGraphicsState) |
| sh | AnalyzeSetShadingOperator(PdfCosName cosShadingID, PdfCosDictionary cosShading) |
| ri | AnalyzeSetRenderingIntentOperator(PdfCosName cosRenderingIntent) |
| g | AnalyzeSetGrayFillOperator(double g) |
| G | AnalyzeSetGrayStrokeOperator(double g) |
| rg | AnalyzeSetRgbFillOperator(double r, double g, double b) |
| RG | AnalyzeSetRgbStrokeOperator(double r, double g, double b) |
| k | AnalyzeSetCmykFillOperator(double c, double m, double y, double k) |
| K | AnalyzeSetCmykStrokeOperator(double c, double m, double y, double k) |
| b| AnalyzeCloseFillNonZeroStrokeOperator(PdfPathVisualObject pathVisualObject) |
| b\* | AnalyzeCloseFillEvenOddStrokeOperator(PdfPathVisualObject pathVisualObject) |
| B | AnalyzeFillNonZeroStrokeOperator(PdfPathVisualObject pathVisualObject) |
| B\* | AnalyzeFillEvenOddStrokeOperator(PdfPathVisualObject pathVisualObject) |
| f | AnalyzeFillNonZeroOperator(PdfPathVisualObject pathVisualObject) |
| F | AnalyzeFillNonZero2Operator(PdfPathVisualObject pathVisualObject) |
| f\* | AnalyzeFillOddEvenOperator(PdfPathVisualObject pathVisualObject) |
| S | AnalyzeStrokeOperator(PdfPathVisualObject pathVisualObject) |
| s | AnalyzeCloseStrokeOperator(PdfPathVisualObject pathVisualObject) |
| W | AnalyzeSetClipNonZeroOperator(PdfPathVisualObject pathVisualObject) |
| W\* | AnalyzeSetClipEvenOddOperator(PdfPathVisualObject pathVisualObject) |
| n | AnalyzeEndPathOperator(PdfPathVisualObject pathVisualObject) |
| i | AnalyzeSetFlatnessToleranceOperator(double value) |
| j | AnalyzeSetLineJoinOperator(int value) |
| J | AnalyzeSetLineCapOperator(int value) |
| M | AnalyzeSetMiterLimitOperator(double value) |
| w | AnalyzeSetLineWidthOperator(double value) |
| d | AnalyzeSetLineDashPatternOperator(double[] dashPattern, double dashOffset) |
| cm | AnalyzeConcatenateMatrixOperator(double m11, double m12, double m21, double m22, double tx, double ty) |
| m | AnalyzeMoveToOperator(double x, double y) |
| l | AnalyzeLineToOperator(double x, double y) |
| re | AnalyzeRectangleOperator(double x, double y, double width, double height) |
| c | AnalyzeCCurveToOperator(double x1, double y1, double x2, double y2, double x3, double y3) |
| v | AnalyzeVCurveToOperator(double x1, double y1, double x2, double y2) |
| y | AnalyzeYCurveToOperator(double x1, double y1, double x2, double y2) |
| h | AnalyzeCloseSubpathOperator() |
| BT | AnalyzeBeginTextOperator() |
| ET | AnalyzeEndTextOperator() |
| Tc | AnalyzeSetCharacterSpacingOperator(double value) |
| Tw | AnalyzeSetWordSpacingOperator(double value) |
| TL | AnalyzeSetTextLeadingOperator(double value) |
| Tz | AnalyzeSetTextHorizontalScalingOperator(double value) |
| Ts | AnalyzeSetTextRiseOperator(double value) |
| Tr | AnalyzeSetTextRenderingOperator(int value) |
| Td | AnalyzeMoveTextPositionOperator(double x, double y) |
| TD | AnalyzeMoveTextPositionSetLeadingOperator(double x, double y) |
| T\* | AnalyzeMoveStartNextTextLineOperator() |
| d0 | AnalyzeSetType3GlyphWidthOperator(double x, double y) |
| d1 | AnalyzeSetType3GlyphWidthAndBoundingBoxOperator(double x, double y, double x1, double y1, double x2, double y2) |
| Tm | AnalyzeSetTextMatrixOperator(double a, double b, double c, double d, double e, double f) |
| Tf | AnalyzeSetTextFontAndSizeOperator(PdfCosName cosFontID, PdfCosDictionary cosFontDictionary) |
| Tj | AnalyzeShowTextOperator(PdfCosString cosText, PdfTextVisualObject textVisualObject) |
| TJ | AnalyzeShowText2Operator(PdfCosArray cosText, PdfTextVisualObject textVisualObject) |
| ' | AnalyzeShowText3Operator(PdfCosString cosText, PdfTextVisualObject textVisualObject) |
| " | AnalyzeShowText4Operator(PdfCosString cosText, double x, double y, PdfTextVisualObject textVisualObject) |
| Do | AnalyzeDisplayImageXObjectOperator(PdfCosName cosImageID, PdfCosDictionary cosImage, PdfImageVisualObject imageVisualObject) |
| BI | AnalyzeBeginImageOperator(PdfCosDictionary cosImage, PdfImageVisualObject imageVisualObject) |
| Do | AnalyzeDisplayFormXObjectOperator(PdfCosName cosFormXObjectID, PdfCosDictionary cosFormXObject) |
| BDC |AnalyzeBeginMarkedContentPropertyListOperator(PdfCosName cosTag, PdfCosDictionary cosProperties) |
| BMC | AnalyzeBeginMarkedContentOperator(PdfCosName cosTag) |
| DP | AnalyzeDefineMarkedContentPropertyListOperator(PdfCosName cosTag, PdfCosDictionary cosProperties) |
| MP | AnalyzeDefineMarkedContentOperator(PdfCosName cosTag) |
| EMC | AnalyzeEndMarkedContentOperator() |

The analysis is run by creating a `PDFPageAnalyzer` object on the specified page and calling its `RunAnalysis` method with the custom analysis as parameter.

When the `PDFPageContentAnalysis.EnableExtendedOperatorInformation` property is set to true the corresponding visual object is provided to the path painting, path clipping, text showing and image showing operators.