using System;
using System.IO;
using System.Drawing;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Annotations;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Graphics.Fonts;
//using O2S.Components.PDF4NET.Graphics.Shapes;

namespace O2S.Samples.PDF4NET
{
	/// <summary>
	/// This sample shows how to embed 3D artwork in PDF files.
	/// </summary>
	class _3DArtwork
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			// Create the pdf document
			//PDF4NET v5: PDFDocument doc = new PDFDocument();
			PDFFixedDocument doc = new PDFFixedDocument();

			// Create a blank page
			//PDF4NET v5: PDFPage page = doc.AddPage();
			PDFPage page = doc.Pages.Add();

			// Create the annotation that will display the 3D artwork.
			PDF3DAnnotation annot3d = new PDF3DAnnotation();
			// Add the annotation to the page.
			page.Annotations.Add(annot3d);

			//PDF4NET v5: annot3d.Rectangle = new RectangleF(50, 50, 400, 400);
			annot3d.DisplayRectangle = new PDFDisplayRectangle(50, 50, 400, 400);

			annot3d.Stream = Create3DStream();

			//PDF4NET v5: annot3d.Appearance = new PDFAnnotationAppearance();
			annot3d.NormalAppearance = new PDFAnnotationAppearance(annot3d.DisplayRectangle.Width, annot3d.DisplayRectangle.Height);

			//PDF4NET v5: annot3d.Appearance.Canvas.DrawText("Click to activate", new PDFFont(),
			//                null, new PDFBrush(new PDFRgbColor()), 200, 200, 0, PDFTextAlign.MiddleCenter);
			PDFStringLayoutOptions slo = new PDFStringLayoutOptions();
			slo.X = 200;
			slo.Y = 200;
			slo.HorizontalAlign = PDFStringHorizontalAlign.Center;
			slo.VerticalAlign = PDFStringVerticalAlign.Middle;
			PDFStringAppearanceOptions sao = new PDFStringAppearanceOptions();
			sao.Font = new PDFStandardFont(PDFStandardFontFace.Helvetica, 10);
			sao.Brush = new PDFBrush(PDFRgbColor.Black);
			annot3d.NormalAppearance.Canvas.DrawString("Click to activate", sao, slo);

			// Create the default view.
			//PDF4NET v5: PDF3DProjection projection1 = new PDF3DProjection(PDF3DProjectionType.Perspective);
			PDF3DProjection projection1 = new PDF3DProjection() { Type = PDF3DProjectionType.Perspective };

			projection1.FieldOfView = 30;
            PDF3DLightingScheme lightScheme1 = null;
			//PDF4NET v5: PDF3DRenderMode renderMode1 = new PDF3DRenderMode(PDF3DRenderStyle.Solid);
			PDF3DRenderMode renderMode1 = new PDF3DRenderMode() { Mode = PDF3DRenderModeType.Solid };

			//PDF4NET v5: PDF3DBackground background1 = new PDF3DBackground(new PDFRgbColor(255, 255, 255));
			PDF3DBackground background1 = new PDF3DBackground() { Color = PDFRgbColor.White };

			PDF3DView defaultView = CreateView("Default view",
                new double[] { -0.382684f, 0.92388f, -0.0000000766026f, 0.18024f, 0.0746579f, 0.980785f, 0.906127f, 0.37533f, -0.19509f, -122.669f, -112.432f, 45.6829f },
                131.695f, background1, projection1, renderMode1, lightScheme1);

			// Create a wireframe view.
			//PDF4NET v5: PDF3DRenderMode renderMode2 = new PDF3DRenderMode(PDF3DRenderStyle.Wireframe);
			PDF3DRenderMode renderMode2 = new PDF3DRenderMode() { Mode = PDF3DRenderModeType.Wireframe };

			PDF3DView wireframeView = CreateView("Wireframe view",
                new double[] { -0.382684f, 0.92388f, -0.0000000766026f, 0.18024f, 0.0746579f, 0.980785f, 0.906127f, 0.37533f, -0.19509f, -122.669f, -112.432f, 45.6829f },
                131.695f, background1, projection1, renderMode2, lightScheme1);

			// Create a transparent wireframe view.
			//PDF4NET v5: PDF3DRenderMode renderMode3 = new PDF3DRenderMode(PDF3DRenderStyle.TransparentWireframe);
			PDF3DRenderMode renderMode3 = new PDF3DRenderMode() { Mode = PDF3DRenderModeType.TransparentWireframe };

			renderMode3.AuxiliaryColor = new PDFRgbColor(0, 192, 0);
            PDF3DView transparentWireframeView = CreateView("Transparent wireframe view",
                new double[] { -0.382684f, 0.92388f, -0.0000000766026f, 0.18024f, 0.0746579f, 0.980785f, 0.906127f, 0.37533f, -0.19509f, -122.669f, -112.432f, 45.6829f },
                131.695f, background1, projection1, renderMode3, lightScheme1);

            annot3d.Stream.Views.Add(defaultView);
            annot3d.Stream.Views.Add(wireframeView);
            annot3d.Stream.Views.Add(transparentWireframeView);
			//PDF4NET v5: annot3d.Stream.DefaultView = 0;
			annot3d.Stream.DefaultView = defaultView;

			doc.Save("Sample_3D.pdf");
		}

		/// <summary>
		/// Creates the 3D stream.
		/// </summary>
		private static PDF3DStream Create3DStream()
		{
			// Read the U3D file.
			FileStream fs = new FileStream("..\\..\\..\\..\\..\\SupportFiles\\box.u3d", FileMode.Open, FileAccess.Read);
			byte[] u3data = new byte[fs.Length];
			fs.Read(u3data, 0, u3data.Length);
			fs.Close();

			PDF3DStream stream = new PDF3DStream();
			stream.Content = u3data;

			return stream;
		}

		/// <summary>
		/// Creates a view for the 3D artwork.
		/// </summary>
		private static PDF3DView CreateView(string viewName, double[] camera2world, float centerOfOrbit, 
			PDF3DBackground background, PDF3DProjection projection, PDF3DRenderMode renderMode, PDF3DLightingScheme lightingScheme)
		{
			PDF3DView view = new PDF3DView();
			view.ExternalName = viewName;
			view.InternalName = Guid.NewGuid().ToString("N");
			view.CameraToWorldMatrix = camera2world;
			view.CenterOfOrbit = centerOfOrbit;
			view.Background = background;
			view.Projection = projection;
			view.RenderMode = renderMode;
			view.LightingScheme = lightingScheme;
			//PDF4NET v5: view.ResetNodesState = true;
			view.ResetNodes = true;

			return view;
		}
	}
}
