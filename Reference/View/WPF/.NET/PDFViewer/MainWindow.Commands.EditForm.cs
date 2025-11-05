using System;
using System.Windows.Input;
using O2S.Components.PDF4NET.View;

namespace PDFViewer
{
    public partial class MainWindow
    {
        private int selectedFieldCount = 0;

        private bool IsFormDesignerAvailable
        {
            get { return (documentView != null) && (documentView.UserInteractionMode == PDFUserInteractionMode.EditFormFields); }
        }


        private ICommand editFormFieldsCommand;
        public ICommand EditFormFieldsCommand
        {
            get
            {
                return editFormFieldsCommand ?? (editFormFieldsCommand = new CommandHandler(() => EditFormFieldsCommandExecute(), () => EditFormFieldsCommandCanExecute));
            }
        }

        public bool EditFormFieldsCommandCanExecute
        {
            get { return currentActivity == Activity.EditForm; }
        }

        public void EditFormFieldsCommandExecute()
        {
            selectedFieldCount = 0;
            documentView.UserInteractionMode = PDFUserInteractionMode.EditFormFields;
        }

        private ICommand addTextBoxFieldCommand;
        public ICommand AddTextBoxFieldCommand
        {
            get
            {
                return addTextBoxFieldCommand ?? (addTextBoxFieldCommand = new CommandHandler(() => AddTextBoxFieldCommandExecute(), () => AddTextBoxFieldCommandCanExecute));
            }
        }

        public bool AddTextBoxFieldCommandCanExecute
        {
            get { return currentActivity == Activity.EditForm; }
        }

        public void AddTextBoxFieldCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddTextBoxField;
        }

        private ICommand addCheckBoxFieldCommand;
        public ICommand AddCheckBoxFieldCommand
        {
            get
            {
                return addCheckBoxFieldCommand ?? (addCheckBoxFieldCommand = new CommandHandler(() => AddCheckBoxFieldCommandExecute(), () => AddCheckBoxFieldCommandCanExecute));
            }
        }

        public bool AddCheckBoxFieldCommandCanExecute
        {
            get { return currentActivity == Activity.EditForm; }
        }

        public void AddCheckBoxFieldCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddCheckBoxField;
        }

        private ICommand addRadioButtonFieldCommand;
        public ICommand AddRadioButtonFieldCommand
        {
            get
            {
                return addRadioButtonFieldCommand ?? (addRadioButtonFieldCommand = new CommandHandler(() => AddRadioButtonFieldCommandExecute(), () => AddRadioButtonFieldCommandCanExecute));
            }
        }

        public bool AddRadioButtonFieldCommandCanExecute
        {
            get { return currentActivity == Activity.EditForm; }
        }

        public void AddRadioButtonFieldCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddRadioButtonField;
        }

        private ICommand addComboBoxFieldCommand;
        public ICommand AddComboBoxFieldCommand
        {
            get
            {
                return addComboBoxFieldCommand ?? (addComboBoxFieldCommand = new CommandHandler(() => AddComboBoxFieldCommandExecute(), () => AddComboBoxFieldCommandCanExecute));
            }
        }

        public bool AddComboBoxFieldCommandCanExecute
        {
            get { return currentActivity == Activity.EditForm; }
        }

        public void AddComboBoxFieldCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddComboBoxField;
        }

        private ICommand addListBoxFieldCommand;
        public ICommand AddListBoxFieldCommand
        {
            get
            {
                return addListBoxFieldCommand ?? (addListBoxFieldCommand = new CommandHandler(() => AddListBoxFieldCommandExecute(), () => AddListBoxFieldCommandCanExecute));
            }
        }

        public bool AddListBoxFieldCommandCanExecute
        {
            get { return currentActivity == Activity.EditForm; }
        }

        public void AddListBoxFieldCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddListBoxField;
        }

        private ICommand addPushButtonFieldCommand;
        public ICommand AddPushButtonFieldCommand
        {
            get
            {
                return addPushButtonFieldCommand ?? (addPushButtonFieldCommand = new CommandHandler(() => AddPushButtonFieldCommandExecute(), () => AddPushButtonFieldCommandCanExecute));
            }
        }

        public bool AddPushButtonFieldCommandCanExecute
        {
            get { return currentActivity == Activity.EditForm; }
        }

        public void AddPushButtonFieldCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddPushButtonField;
        }

        private ICommand addSignatureFieldCommand;
        public ICommand AddSignatureFieldCommand
        {
            get
            {
                return addSignatureFieldCommand ?? (addSignatureFieldCommand = new CommandHandler(() => AddSignatureFieldCommandExecute(), () => AddSignatureFieldCommandCanExecute));
            }
        }

        public bool AddSignatureFieldCommandCanExecute
        {
            get { return currentActivity == Activity.EditForm; }
        }

        public void AddSignatureFieldCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddSignatureField;
        }

        private ICommand formDesignerAlignLeftCommand;
        public ICommand FormDesignerAlignLeftCommand
        {
            get
            {
                return formDesignerAlignLeftCommand ?? (formDesignerAlignLeftCommand = new CommandHandler(() => FormDesignerAlignLeftCommandExecute(), () => FormDesignerAlignLeftCommandCanExecute));
            }
        }

        public bool FormDesignerAlignLeftCommandCanExecute
        {
            get { return IsFormDesignerAvailable && (selectedFieldCount >= 2); }
        }

        public void FormDesignerAlignLeftCommandExecute()
        {
            documentView.FormDesigner.AlignLeft();
        }

        private ICommand formDesignerAlignCenterCommand;
        public ICommand FormDesignerAlignCenterCommand
        {
            get
            {
                return formDesignerAlignCenterCommand ?? (formDesignerAlignCenterCommand = new CommandHandler(() => FormDesignerAlignCenterCommandExecute(), () => FormDesignerAlignCenterCommandCanExecute));
            }
        }

        public bool FormDesignerAlignCenterCommandCanExecute
        {
            get { return IsFormDesignerAvailable && (selectedFieldCount >= 2); }
        }

        public void FormDesignerAlignCenterCommandExecute()
        {
            documentView.FormDesigner.AlignCenter();
        }

        private ICommand formDesignerAlignRightCommand;
        public ICommand FormDesignerAlignRightCommand
        {
            get
            {
                return formDesignerAlignRightCommand ?? (formDesignerAlignRightCommand = new CommandHandler(() => FormDesignerAlignRightCommandExecute(), () => FormDesignerAlignRightCommandCanExecute));
            }
        }

        public bool FormDesignerAlignRightCommandCanExecute
        {
            get { return IsFormDesignerAvailable && (selectedFieldCount >= 2); }
        }

        public void FormDesignerAlignRightCommandExecute()
        {
            documentView.FormDesigner.AlignRight();
        }

        private ICommand formDesignerAlignTopCommand;
        public ICommand FormDesignerAlignTopCommand
        {
            get
            {
                return formDesignerAlignTopCommand ?? (formDesignerAlignTopCommand = new CommandHandler(() => FormDesignerAlignTopCommandExecute(), () => FormDesignerAlignTopCommandCanExecute));
            }
        }

        public bool FormDesignerAlignTopCommandCanExecute
        {
            get { return IsFormDesignerAvailable && (selectedFieldCount >= 2); }
        }

        public void FormDesignerAlignTopCommandExecute()
        {
            documentView.FormDesigner.AlignTop();
        }

        private ICommand formDesignerAlignMiddleCommand;
        public ICommand FormDesignerAlignMiddleCommand
        {
            get
            {
                return formDesignerAlignMiddleCommand ?? (formDesignerAlignMiddleCommand = new CommandHandler(() => FormDesignerAlignMiddleCommandExecute(), () => FormDesignerAlignMiddleCommandCanExecute));
            }
        }

        public bool FormDesignerAlignMiddleCommandCanExecute
        {
            get { return IsFormDesignerAvailable && (selectedFieldCount >= 2); }
        }

        public void FormDesignerAlignMiddleCommandExecute()
        {
            documentView.FormDesigner.AlignMiddle();
        }

        private ICommand formDesignerAlignBottomCommand;
        public ICommand FormDesignerAlignBottomCommand
        {
            get
            {
                return formDesignerAlignBottomCommand ?? (formDesignerAlignBottomCommand = new CommandHandler(() => FormDesignerAlignBottomCommandExecute(), () => FormDesignerAlignBottomCommandCanExecute));
            }
        }

        public bool FormDesignerAlignBottomCommandCanExecute
        {
            get { return IsFormDesignerAvailable && (selectedFieldCount >= 2); }
        }

        public void FormDesignerAlignBottomCommandExecute()
        {
            documentView.FormDesigner.AlignBottom();
        }

        private ICommand formDesignerCenterHorizontallyCommand;
        public ICommand FormDesignerCenterHorizontallyCommand
        {
            get
            {
                return formDesignerCenterHorizontallyCommand ?? (formDesignerCenterHorizontallyCommand = new CommandHandler(() => FormDesignerCenterHorizontallyCommandExecute(), () => FormDesignerCenterHorizontallyCommandCanExecute));
            }
        }

        public bool FormDesignerCenterHorizontallyCommandCanExecute
        {
            get { return IsFormDesignerAvailable && (selectedFieldCount >= 2); }
        }

        public void FormDesignerCenterHorizontallyCommandExecute()
        {
            documentView.FormDesigner.CenterHorizontally();
        }

        private ICommand formDesignerCenterVerticallyCommand;
        public ICommand FormDesignerCenterVerticallyCommand
        {
            get
            {
                return formDesignerCenterVerticallyCommand ?? (formDesignerCenterVerticallyCommand = new CommandHandler(() => FormDesignerCenterVerticallyCommandExecute(), () => FormDesignerCenterVerticallyCommandCanExecute));
            }
        }

        public bool FormDesignerCenterVerticallyCommandCanExecute
        {
            get { return IsFormDesignerAvailable && (selectedFieldCount >= 2); }
        }

        public void FormDesignerCenterVerticallyCommandExecute()
        {
            documentView.FormDesigner.CenterVertically();
        }

        private ICommand formDesignerCenterBothCommand;
        public ICommand FormDesignerCenterBothCommand
        {
            get
            {
                return formDesignerCenterBothCommand ?? (formDesignerCenterBothCommand = new CommandHandler(() => FormDesignerCenterBothCommandExecute(), () => FormDesignerCenterBothCommandCanExecute));
            }
        }

        public bool FormDesignerCenterBothCommandCanExecute
        {
            get { return IsFormDesignerAvailable && (selectedFieldCount >= 2); }
        }

        public void FormDesignerCenterBothCommandExecute()
        {
            documentView.FormDesigner.CenterHorizontallyAndVertically();
        }

        private ICommand formDesignerMakeSameWidthCommand;
        public ICommand FormDesignerMakeSameWidthCommand
        {
            get
            {
                return formDesignerMakeSameWidthCommand ?? (formDesignerMakeSameWidthCommand = new CommandHandler(() => FormDesignerMakeSameWidthCommandExecute(), () => FormDesignerMakeSameWidthCommandCanExecute));
            }
        }

        public bool FormDesignerMakeSameWidthCommandCanExecute
        {
            get { return IsFormDesignerAvailable && (selectedFieldCount >= 2); }
        }

        public void FormDesignerMakeSameWidthCommandExecute()
        {
            documentView.FormDesigner.MatchWidth();
        }

        private ICommand formDesignerMakeSameHeightCommand;
        public ICommand FormDesignerMakeSameHeightCommand
        {
            get
            {
                return formDesignerMakeSameHeightCommand ?? (formDesignerMakeSameHeightCommand = new CommandHandler(() => FormDesignerMakeSameHeightCommandExecute(), () => FormDesignerMakeSameHeightCommandCanExecute));
            }
        }

        public bool FormDesignerMakeSameHeightCommandCanExecute
        {
            get { return IsFormDesignerAvailable && (selectedFieldCount >= 2); }
        }

        public void FormDesignerMakeSameHeightCommandExecute()
        {
            documentView.FormDesigner.MatchHeight();
        }

        private ICommand formDesignerMakeSameWidthAndHeightCommand;
        public ICommand FormDesignerMakeSameWidthAndHeightCommand
        {
            get
            {
                return formDesignerMakeSameWidthAndHeightCommand ?? (formDesignerMakeSameWidthAndHeightCommand = new CommandHandler(() => FormDesignerMakeSameWidthAndHeightCommandExecute(), () => FormDesignerMakeSameWidthAndHeightCommandCanExecute));
            }
        }

        public bool FormDesignerMakeSameWidthAndHeightCommandCanExecute
        {
            get { return IsFormDesignerAvailable && (selectedFieldCount >= 2); }
        }

        public void FormDesignerMakeSameWidthAndHeightCommandExecute()
        {
            documentView.FormDesigner.MatchWidthAndHeight();
        }

        private ICommand formDesignerDistributeHorizontallyCommand;
        public ICommand FormDesignerDistributeHorizontallyCommand
        {
            get
            {
                return formDesignerDistributeHorizontallyCommand ?? (formDesignerDistributeHorizontallyCommand = new CommandHandler(() => FormDesignerDistributeHorizontallyCommandExecute(), () => FormDesignerDistributeHorizontallyCommandCanExecute));
            }
        }

        public bool FormDesignerDistributeHorizontallyCommandCanExecute
        {
            get { return IsFormDesignerAvailable && (selectedFieldCount >= 3); }
        }

        public void FormDesignerDistributeHorizontallyCommandExecute()
        {
            documentView.FormDesigner.SpaceEquallyOnHorizontal();
        }

        private ICommand formDesignerDistributeVerticallyCommand;
        public ICommand FormDesignerDistributeVerticallyCommand
        {
            get
            {
                return formDesignerDistributeVerticallyCommand ?? (formDesignerDistributeVerticallyCommand = new CommandHandler(() => FormDesignerDistributeVerticallyCommandExecute(), () => FormDesignerDistributeVerticallyCommandCanExecute));
            }
        }

        public bool FormDesignerDistributeVerticallyCommandCanExecute
        {
            get { return IsFormDesignerAvailable && (selectedFieldCount >= 3); }
        }

        public void FormDesignerDistributeVerticallyCommandExecute()
        {
            documentView.FormDesigner.SpaceEquallyOnVertical();
        }

        private void documentView_AnnotationSelected(object sender, PDFVisualAnnotationEventArgs e)
        {
            if (documentView.UserInteractionMode == PDFUserInteractionMode.EditFormFields)
            {
                selectedFieldCount++;
            }
        }

        private void documentView_AnnotationDeselected(object sender, PDFVisualAnnotationEventArgs e)
        {
            if (documentView.UserInteractionMode == PDFUserInteractionMode.EditFormFields)
            {
                selectedFieldCount--;
            }
        }
    }
}
