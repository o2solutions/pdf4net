using System;
using System.Collections.Generic;
using O2S.Components.PDF4NET.Core;
using O2S.Components.PDF4NET.Core.Cos;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.Operators;
using O2S.Components.PDF4NET.Transforms;

namespace ChangeTransparencyAndBlendMode
{
    public class ChangeTransparencyAndBlendModeTransform : PDFPageTransform
    {
        public ChangeTransparencyAndBlendModeTransform() 
        {
            cachedOperators = new List<PDFContentStreamOperator>();
            cosTransparencyGs = new PDFCosName("/TransparencyGS");
            transparencyGs = new PDFExtendedGraphicState();
            transparencyGs.FillAlpha = 0.5;
            cosBlendModeGs = new PDFCosName("/BlendModeGS");
            blendModeGs = new PDFExtendedGraphicState();
            blendModeGs.BlendMode = PDFBlendMode.Multiply;
        }

        private List<PDFContentStreamOperator> cachedOperators;

        private PDFCosName cosTransparencyGs;

        private PDFExtendedGraphicState transparencyGs;

        private PDFCosName cosBlendModeGs;

        private PDFExtendedGraphicState blendModeGs;

        protected override void TransformOperator(PDFContentStreamOperator input, List<PDFContentStreamOperator> output)
        {
            switch (input.Type)
            {
                case PDFContentStreamOperatorType.MoveTo:
                case PDFContentStreamOperatorType.LineTo:
                case PDFContentStreamOperatorType.CCurveTo:
                case PDFContentStreamOperatorType.YCurveTo:
                case PDFContentStreamOperatorType.VCurveTo:
                case PDFContentStreamOperatorType.Rectangle:
                case PDFContentStreamOperatorType.CloseSubpath:
                    cachedOperators.Add(input);
                    break;
                case PDFContentStreamOperatorType.CloseFillNonZeroStroke:
                case PDFContentStreamOperatorType.CloseFillEvenOddStroke:
                case PDFContentStreamOperatorType.FillNonZeroStroke:
                case PDFContentStreamOperatorType.FillEvenOddStroke:
                case PDFContentStreamOperatorType.FillNonZero:
                case PDFContentStreamOperatorType.FillNonZero2:
                case PDFContentStreamOperatorType.FillOddEven:
                case PDFContentStreamOperatorType.EndPath:
                case PDFContentStreamOperatorType.Stroke:
                case PDFContentStreamOperatorType.CloseStroke:
                    PDFPathPaintingOperator ppo = input as PDFPathPaintingOperator;
                    PDFRgbColor fillColor = ppo.PathVisualObject.Brush.Color.ToRgbColor();
                    // Red filled paths are made transparent
                    if ((fillColor.R == 255) && (fillColor.G == 0) && (fillColor.B == 0))
                    {
                        output.Add(new PDFContentStreamOperator(PDFContentStreamOperatorType.SaveGraphicsState));
                        output.Add(new PDFSetGraphicsStateOperator(cosTransparencyGs));
                        for (int i = 0; i < cachedOperators.Count; i++)
                        {
                            output.Add(cachedOperators[i]);
                        }
                        output.Add(input);
                        output.Add(new PDFContentStreamOperator(PDFContentStreamOperatorType.RestoreGraphicsState));

                        cachedOperators.Clear();
                        AddResource(PDFNames.ExtGState, cosTransparencyGs, transparencyGs.CosDictionary);
                    }
                    // Blend mode is changed for blue filled paths
                    else if ((fillColor.R == 0) && (fillColor.G == 0) && (fillColor.B == 255))
                    {
                        output.Add(new PDFContentStreamOperator(PDFContentStreamOperatorType.SaveGraphicsState));
                        output.Add(new PDFSetGraphicsStateOperator(cosBlendModeGs));
                        for (int i = 0; i < cachedOperators.Count; i++)
                        {
                            output.Add(cachedOperators[i]);
                        }
                        output.Add(input);
                        output.Add(new PDFContentStreamOperator(PDFContentStreamOperatorType.RestoreGraphicsState));

                        cachedOperators.Clear();
                        AddResource(PDFNames.ExtGState, cosBlendModeGs, blendModeGs.CosDictionary);
                    }
                    else
                    {
                        for (int i = 0; i < cachedOperators.Count; i++)
                        {
                            output.Add(cachedOperators[i]);
                        }
                        output.Add(input);

                        cachedOperators.Clear();
                    }
                    break;
                default:
                    output.Add(input);
                    break;
            }
        }

        private void AddResource(PDFCosName cosResourceType, PDFCosName cosResourceID, PDFCosObject cosResource)
        {
            PDFCosDictionary cosResources = context.ContentStreamContainer[PDFNames.Resources] as PDFCosDictionary;
            if (cosResources == null)
            {
                cosResources = new PDFCosDictionary();
                context.ContentStreamContainer[PDFNames.Resources] = cosResources;
            }
            PDFCosDictionary cosTypeResource = cosResources[cosResourceType] as PDFCosDictionary;
            if (cosTypeResource == null)
            {
                cosTypeResource = new PDFCosDictionary();
                cosResources[cosResourceType] = cosTypeResource;
            }
            cosTypeResource[cosResourceID] = cosResource;
        }
    }
}
