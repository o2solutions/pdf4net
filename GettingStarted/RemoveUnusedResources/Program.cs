using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Core;
using O2S.Components.PDF4NET.Core.Cos;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.Operators;
using O2S.Components.PDF4NET.Transforms;
using System;
using System.Collections.Generic;
using System.IO;

namespace RemoveUnusedResources
{
    public class RemoveUnusedResourcesTransform : PDFPageTransform
    {
        public RemoveUnusedResourcesTransform()
        {
            colorspaces = new HashSet<string>();
            xObjects = new HashSet<string>();
            fonts = new HashSet<string>();
            patterns = new HashSet<string>();
        }

        private HashSet<string> colorspaces;

        private HashSet<string> xObjects;

        private HashSet<string> fonts;

        private HashSet<string> patterns;

        protected override void TransformOperator(PDFContentStreamOperator input, List<PDFContentStreamOperator> output)
        {
            // Scan the operators in the page content and keep track of used resources (fonts, images, colorspaces, patterns)
            switch (input.Type)
            {
                case PDFContentStreamOperatorType.SetStrokeColorSpace:
                    PDFSetStrokeColorSpaceOperator sscs = input as PDFSetStrokeColorSpaceOperator;
                    colorspaces.Add(sscs.ColorSpaceID.Value);
                    break;
                case PDFContentStreamOperatorType.SetStrokeColorN:
                    PDFSetStrokeColorNOperator sscn = input as PDFSetStrokeColorNOperator;
                    if (sscn.PatternID != null)
                    {
                        patterns.Add(sscn.PatternID.Value);
                    }
                    break;
                case PDFContentStreamOperatorType.SetFillColorSpace:
                    PDFSetFillColorSpaceOperator sfcs = input as PDFSetFillColorSpaceOperator;
                    colorspaces.Add(sfcs.ColorSpaceID.Value);
                    break;
                case PDFContentStreamOperatorType.SetFillColorN:
                    PDFSetFillColorNOperator sfcn = input as PDFSetFillColorNOperator;
                    if (sfcn.PatternID != null)
                    {
                        patterns.Add(sfcn.PatternID.Value);
                    }
                    break;
                case PDFContentStreamOperatorType.DisplayXObject:
                    PDFDisplayImageXObjectOperator ixoo = input as PDFDisplayImageXObjectOperator;
                    if (ixoo != null)
                    {
                        xObjects.Add(ixoo.ImageID.Value);
                    }
                    else
                    {
                        PDFDisplayFormXObjectOperator fxoo = input as PDFDisplayFormXObjectOperator;
                        if (fxoo != null)
                        {
                            xObjects.Add(fxoo.FormXObjectID.Value);
                        }
                    }
                    break;
                case PDFContentStreamOperatorType.SetTextFontAndSize:
                    PDFSetTextFontAndSizeOperator stfs = input as PDFSetTextFontAndSizeOperator;
                    fonts.Add(stfs.FontID.Value);
                    break;
            }

            output.Add(input);
        }

        protected override void CleanUp()
        {
            base.CleanUp();

            PDFCosDictionary resourcesDict = this.Context.ContentStreamContainer[PDFNames.Resources] as PDFCosDictionary;
            if (resourcesDict != null)
            {
                resourcesDict = CopyResources(resourcesDict);
                CleanUpResources(resourcesDict[PDFNames.ColorSpace] as PDFCosDictionary, colorspaces);
                CleanUpResources(resourcesDict[PDFNames.XObject] as PDFCosDictionary, xObjects);
                CleanUpResources(resourcesDict[PDFNames.Font] as PDFCosDictionary, fonts);
                CleanUpResources(resourcesDict[PDFNames.Pattern] as PDFCosDictionary, patterns);

                this.Context.ContentStreamContainer[PDFNames.Resources] = resourcesDict;
            }
        }

        private void CleanUpResources(PDFCosDictionary resourcesDict, HashSet<string> usedResources)
        {
            if (resourcesDict == null)
            {
                return;
            }

            string[] keys = resourcesDict.Keys;
            foreach (string key in keys)
            {
                // The resources dictionary contains a key that is not used, remove it.
                if (!usedResources.Contains(key))
                {
                    resourcesDict[key] = null;
                }
            }
        }

        private PDFCosDictionary CopyResources(PDFCosDictionary resourcesDict)
        {
            PDFCosDictionary copy = new PDFCosDictionary();
            copy[PDFNames.XObject] = Copy(resourcesDict[PDFNames.XObject] as PDFCosDictionary);
            copy[PDFNames.Font] = Copy(resourcesDict[PDFNames.Font] as PDFCosDictionary);
            copy[PDFNames.ColorSpace] = Copy(resourcesDict[PDFNames.ColorSpace] as PDFCosDictionary);
            copy[PDFNames.Pattern] = Copy(resourcesDict[PDFNames.Pattern] as PDFCosDictionary);
            copy[PDFNames.Shading] = resourcesDict[PDFNames.Shading] as PDFCosDictionary;
            copy[PDFNames.Properties] = resourcesDict[PDFNames.Properties] as PDFCosDictionary;
            copy[PDFNames.ProcSet] = resourcesDict[PDFNames.ProcSet] as PDFCosArray;

            return copy;
        }

        private PDFCosDictionary Copy(PDFCosDictionary dict)
        {
            if (dict == null)
            {
                return null;
            }

            PDFCosDictionary copy = new PDFCosDictionary();
            string[] keys = dict.Keys;
            foreach(string key in keys)
            {
                copy[key] = dict[key];
            }

            return copy;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SplitPagesWithUnusedResourcesRemoval();

            SplitPagesNoUnusedResourcesRemoval();
        }

        private static void SplitPagesWithUnusedResourcesRemoval()
        {
            using (FileStream fs = File.OpenRead("PDF4NET.Features.pdf"))
            {
                PDFFile sourceFile = new PDFFile(fs);

                for (int i = 0; i < sourceFile.PageCount; i++)
                {
                    PDFFixedDocument document = new PDFFixedDocument();
                    PDFPage page = sourceFile.ExtractPage(i);

                    RemoveUnusedResourcesTransform transform = new RemoveUnusedResourcesTransform();
                    PDFPageTransformer pageTransformer = new PDFPageTransformer(page);
                    pageTransformer.ApplyTransform(transform);

                    document.Pages.Add(page);

                    document.Save($"UnusedResourcesRemoved.Page.{i}.pdf");
                }
            }
        }

        private static void SplitPagesNoUnusedResourcesRemoval()
        {
            using (FileStream fs = File.OpenRead("PDF4NET.Features.pdf"))
            {
                PDFFile sourceFile = new PDFFile(fs);

                for (int i = 0; i < sourceFile.PageCount; i++)
                {
                    PDFFixedDocument document = new PDFFixedDocument();
                    PDFPage page = sourceFile.ExtractPage(i);
                    document.Pages.Add(page);

                    document.Save($"UnusedResourcesKept.Page.{i}.pdf");
                }
            }
        }
    }
}
