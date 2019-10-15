using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Forms;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// FormFill sample.
    /// </summary>
    public class FormFill
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        /// <param name="stream"></param>
        public static SampleOutputInfo[] Run(Stream stream)
        {
            PDFFixedDocument document = new PDFFixedDocument(stream);
            (document.Form.Fields["firstname"] as PDFTextBoxField).Text = "John";
            (document.Form.Fields["lastname"] as PDFTextBoxField).Value = "Doe";

            (document.Form.Fields["sex"].Widgets[0] as PDFRadioButtonWidget).Checked = true;

            (document.Form.Fields["firstcar"] as PDFDropDownListField).SelectedIndex = 0;

            (document.Form.Fields["secondcar"] as PDFListBoxField).SelectedIndex = 1;

            (document.Form.Fields["agree"] as PDFCheckBoxField).Checked = true;
            document.Form.FlattenFields();

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "formfill.pdf") };
            return output;
        }
    }
}