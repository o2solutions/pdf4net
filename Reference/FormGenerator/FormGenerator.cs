using System;
using System.IO;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Graphics;
using O2S.Components.PDF4NET.Forms;
using O2S.Components.PDF4NET.Actions;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// FormGenerator sample.
    /// </summary>
    public class FormGenerator
    {
        /// <summary>
        /// Main method for running the sample.
        /// </summary>
        public static SampleOutputInfo[] Run()
        {
            PDFFixedDocument document = new PDFFixedDocument();
            PDFStandardFont helvetica = new PDFStandardFont(PDFStandardFontFace.Helvetica, 12);
            PDFBrush brush = new PDFBrush();

            PDFPage page = document.Pages.Add();

            // First name
            page.Canvas.DrawString("First name:", helvetica, brush, 50, 50);
            PDFTextBoxField firstNameTextBox = new PDFTextBoxField("firstname");
            page.Fields.Add(firstNameTextBox);
            firstNameTextBox.Widgets[0].Font = helvetica;
            firstNameTextBox.Widgets[0].VisualRectangle = new PDFDisplayRectangle(150, 45, 200, 20);
            firstNameTextBox.Widgets[0].BorderColor = PDFRgbColor.Black;
            firstNameTextBox.Widgets[0].BorderWidth = 1;

            // Last name
            page.Canvas.DrawString("Last name:", helvetica, brush, 50, 80);
            PDFTextBoxField lastNameTextBox = new PDFTextBoxField("lastname");
            page.Fields.Add(lastNameTextBox);
            lastNameTextBox.Widgets[0].Font = helvetica;
            lastNameTextBox.Widgets[0].VisualRectangle = new PDFDisplayRectangle(150, 75, 200, 20);
            lastNameTextBox.Widgets[0].BorderColor = PDFRgbColor.Black;
            lastNameTextBox.Widgets[0].BorderWidth = 1;

            // Sex
            page.Canvas.DrawString("Sex:", helvetica, brush, 50, 110);
            PDFRadioButtonField sexRadioButton = new PDFRadioButtonField("sex");
            PDFRadioButtonWidget maleRadioItem = new PDFRadioButtonWidget();
            sexRadioButton.Widgets.Add(maleRadioItem);
            PDFRadioButtonWidget femaleRadioItem = new PDFRadioButtonWidget();
            sexRadioButton.Widgets.Add(femaleRadioItem);
            page.Fields.Add(sexRadioButton);

            page.Canvas.DrawString("Male", helvetica, brush, 180, 110);
            maleRadioItem.ExportValue = "M";
            maleRadioItem.CheckStyle = PDFCheckStyle.Circle;
            maleRadioItem.VisualRectangle = new PDFDisplayRectangle(150, 105, 20, 20);
            maleRadioItem.BorderColor = PDFRgbColor.Black;
            maleRadioItem.BorderWidth = 1;

            page.Canvas.DrawString("Female", helvetica, brush, 280, 110);
            femaleRadioItem.ExportValue = "F";
            femaleRadioItem.CheckStyle = PDFCheckStyle.Circle;
            femaleRadioItem.VisualRectangle = new PDFDisplayRectangle(250, 105, 20, 20);
            femaleRadioItem.BorderColor = PDFRgbColor.Black;
            femaleRadioItem.BorderWidth = 1;

            // First car
            page.Canvas.DrawString("First car:", helvetica, brush, 50, 140);
            PDFComboBoxField firstCarList = new PDFComboBoxField("firstcar");
            firstCarList.Items.Add(new PDFListItem("Mercedes", "Mercedes"));
            firstCarList.Items.Add(new PDFListItem("BMW", "BMW"));
            firstCarList.Items.Add(new PDFListItem("Audi", "Audi"));
            firstCarList.Items.Add(new PDFListItem("Volkswagen", "Volkswagen"));
            firstCarList.Items.Add(new PDFListItem("Porsche", "Porsche"));
            firstCarList.Items.Add(new PDFListItem("Honda", "Honda"));
            firstCarList.Items.Add(new PDFListItem("Toyota", "Toyota"));
            firstCarList.Items.Add(new PDFListItem("Lexus", "Lexus"));
            firstCarList.Items.Add(new PDFListItem("Infiniti", "Infiniti"));
            firstCarList.Items.Add(new PDFListItem("Acura", "Acura"));
            page.Fields.Add(firstCarList);
            firstCarList.Widgets[0].Font = helvetica;
            firstCarList.Widgets[0].VisualRectangle = new PDFDisplayRectangle(150, 135, 200, 20);
            firstCarList.Widgets[0].BorderColor = PDFRgbColor.Black;
            firstCarList.Widgets[0].BorderWidth = 1;

            // Second car
            page.Canvas.DrawString("Second car:", helvetica, brush, 50, 170);
            PDFListBoxField secondCarList = new PDFListBoxField("secondcar");
            secondCarList.Items.Add(new PDFListItem("Mercedes", "Mercedes"));
            secondCarList.Items.Add(new PDFListItem("BMW", "BMW"));
            secondCarList.Items.Add(new PDFListItem("Audi", "Audi"));
            secondCarList.Items.Add(new PDFListItem("Volkswagen", "Volkswagen"));
            secondCarList.Items.Add(new PDFListItem("Porsche", "Porsche"));
            secondCarList.Items.Add(new PDFListItem("Honda", "Honda"));
            secondCarList.Items.Add(new PDFListItem("Toyota", "Toyota"));
            secondCarList.Items.Add(new PDFListItem("Lexus", "Lexus"));
            secondCarList.Items.Add(new PDFListItem("Infiniti", "Infiniti"));
            secondCarList.Items.Add(new PDFListItem("Acura", "Acura"));
            page.Fields.Add(secondCarList);
            secondCarList.Widgets[0].Font = helvetica;
            secondCarList.Widgets[0].VisualRectangle = new PDFDisplayRectangle(150, 165, 200, 60);
            secondCarList.Widgets[0].BorderColor = PDFRgbColor.Black;
            secondCarList.Widgets[0].BorderWidth = 1;

            // I agree
            page.Canvas.DrawString("I agree:", helvetica, brush, 50, 240);
            PDFCheckBoxField agreeCheckBox = new PDFCheckBoxField("agree");
            page.Fields.Add(agreeCheckBox);
            agreeCheckBox.Widgets[0].Font = helvetica;
            (agreeCheckBox.Widgets[0] as PDFCheckWidget).ExportValue = "YES";
            (agreeCheckBox.Widgets[0] as PDFCheckWidget).CheckStyle = PDFCheckStyle.Check;
            agreeCheckBox.Widgets[0].VisualRectangle = new PDFDisplayRectangle(150, 235, 20, 20);
            agreeCheckBox.Widgets[0].BorderColor = PDFRgbColor.Black;
            agreeCheckBox.Widgets[0].BorderWidth = 1;

            // Sign here
            page.Canvas.DrawString("Sign here:", helvetica, brush, 50, 270);
            PDFSignatureField signHereField = new PDFSignatureField("signhere");
            page.Fields.Add(signHereField);
            signHereField.Widgets[0].Font = helvetica;
            signHereField.Widgets[0].VisualRectangle = new PDFDisplayRectangle(150, 265, 200, 60);

            // Submit form
            PDFPushButtonField submitBtn = new PDFPushButtonField("submit");
            page.Fields.Add(submitBtn);
            submitBtn.Widgets[0].VisualRectangle = new PDFDisplayRectangle(450, 45, 150, 30);
            (submitBtn.Widgets[0] as PDFPushButtonWidget).Caption = "Submit form";
            submitBtn.Widgets[0].BackgroundColor = PDFRgbColor.LightGray;
            PDFSubmitFormAction submitFormAction = new PDFSubmitFormAction();
            submitFormAction.DataFormat = PDFSubmitDataFormat.FDF;
            submitFormAction.Fields.Add("firstname");
            submitFormAction.Fields.Add("lastname");
            submitFormAction.Fields.Add("sex");
            submitFormAction.Fields.Add("firstcar");
            submitFormAction.Fields.Add("secondcar");
            submitFormAction.Fields.Add("agree");
            submitFormAction.Fields.Add("signhere");
            submitFormAction.SubmitFields = true;
            submitFormAction.Url = "http://www.o2sol.com/";
            submitBtn.Widgets[0].MouseUp = submitFormAction;

            // Reset form
            PDFPushButtonField resetBtn = new PDFPushButtonField("reset");
            page.Fields.Add(resetBtn);
            resetBtn.Widgets[0].VisualRectangle = new PDFDisplayRectangle(450, 85, 150, 30);
            (resetBtn.Widgets[0] as PDFPushButtonWidget).Caption = "Reset form";
            resetBtn.Widgets[0].BackgroundColor = PDFRgbColor.LightGray;
            PDFResetFormAction resetFormAction = new PDFResetFormAction();
            resetBtn.Widgets[0].MouseUp = resetFormAction;

            // Print form
            PDFPushButtonField printBtn = new PDFPushButtonField("print");
            page.Fields.Add(printBtn);
            printBtn.Widgets[0].VisualRectangle = new PDFDisplayRectangle(450, 125, 150, 30);
            (printBtn.Widgets[0] as PDFPushButtonWidget).Caption = "Print form";
            printBtn.Widgets[0].BackgroundColor = PDFRgbColor.LightGray;
            PDFJavaScriptAction printAction = new PDFJavaScriptAction();
            printAction.Script = "this.print(true);\n";
            printBtn.Widgets[0].MouseUp = printAction;

            SampleOutputInfo[] output = new SampleOutputInfo[] { new SampleOutputInfo(document, "formgenerator.pdf") };
            return output;
        }
    }
}