using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using O2S.Components.PDF4NET.View;

namespace PDFViewer
{
    public partial class MainWindow
    {

        private ICommand editAnnotationsCommand;
        public ICommand EditAnnotationsCommand
        {
            get
            {
                return editAnnotationsCommand ?? (editAnnotationsCommand = new CommandHandler(() => EditAnnotationsCommandExecute(), () => EditAnnotationsCommandCanExecute));
            }
        }

        public bool EditAnnotationsCommandCanExecute
        {
            get { return currentActivity == Activity.Comment; }
        }

        public void EditAnnotationsCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.EditAnnotations;
        }

        private ICommand addTextAnnotationCommand;
        public ICommand AddTextAnnotationCommand
        {
            get
            {
                return addTextAnnotationCommand ?? (addTextAnnotationCommand = new CommandHandler(() => AddTextAnnotationCommandExecute(), () => AddTextAnnotationCommandCanExecute));
            }
        }

        public bool AddTextAnnotationCommandCanExecute
        {
            get { return currentActivity == Activity.Comment; }
        }

        public void AddTextAnnotationCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddTextAnnotation;
        }

        private ICommand addRubberStampAnnotationCommand;
        public ICommand AddRubberStampAnnotationCommand
        {
            get
            {
                return addRubberStampAnnotationCommand ?? (addRubberStampAnnotationCommand = new CommandHandler(() => AddRubberStampAnnotationCommandExecute(), () => AddRubberStampAnnotationCommandCanExecute));
            }
        }

        public bool AddRubberStampAnnotationCommandCanExecute
        {
            get { return currentActivity == Activity.Comment; }
        }

        public void AddRubberStampAnnotationCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddRubberStampAnnotation;
        }

        private ICommand addCircleAnnotationCommand;
        public ICommand AddCircleAnnotationCommand
        {
            get
            {
                return addCircleAnnotationCommand ?? (addCircleAnnotationCommand = new CommandHandler(() => AddCircleAnnotationCommandExecute(), () => AddCircleAnnotationCommandCanExecute));
            }
        }

        public bool AddCircleAnnotationCommandCanExecute
        {
            get { return currentActivity == Activity.Comment; }
        }

        public void AddCircleAnnotationCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddCircleAnnotation;
        }

        private ICommand addSquareAnnotationCommand;
        public ICommand AddSquareAnnotationCommand
        {
            get
            {
                return addSquareAnnotationCommand ?? (addSquareAnnotationCommand = new CommandHandler(() => AddSquareAnnotationCommandExecute(), () => AddSquareAnnotationCommandCanExecute));
            }
        }

        public bool AddSquareAnnotationCommandCanExecute
        {
            get { return currentActivity == Activity.Comment; }
        }

        public void AddSquareAnnotationCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddSquareAnnotation;
        }

        private ICommand addCloudSquareAnnotationCommand;
        public ICommand AddCloudSquareAnnotationCommand
        {
            get
            {
                return addCloudSquareAnnotationCommand ?? (addCloudSquareAnnotationCommand = new CommandHandler(() => AddCloudSquareAnnotationCommandExecute(), () => AddCloudSquareAnnotationCommandCanExecute));
            }
        }

        public bool AddCloudSquareAnnotationCommandCanExecute
        {
            get { return currentActivity == Activity.Comment; }
        }

        public void AddCloudSquareAnnotationCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddCloudSquareAnnotation;
        }

        private ICommand addLineAnnotationCommand;
        public ICommand AddLineAnnotationCommand
        {
            get
            {
                return addLineAnnotationCommand ?? (addLineAnnotationCommand = new CommandHandler(() => AddLineAnnotationCommandExecute(), () => AddLineAnnotationCommandCanExecute));
            }
        }

        public bool AddLineAnnotationCommandCanExecute
        {
            get { return currentActivity == Activity.Comment; }
        }

        public void AddLineAnnotationCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddLineAnnotation;
        }

        private ICommand addPolylineAnnotationCommand;
        public ICommand AddPolylineAnnotationCommand
        {
            get
            {
                return addPolylineAnnotationCommand ?? (addPolylineAnnotationCommand = new CommandHandler(() => AddPolylineAnnotationCommandExecute(), () => AddPolylineAnnotationCommandCanExecute));
            }
        }

        public bool AddPolylineAnnotationCommandCanExecute
        {
            get { return currentActivity == Activity.Comment; }
        }

        public void AddPolylineAnnotationCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddPolylineAnnotation;
        }

        private ICommand addPolygonAnnotationCommand;
        public ICommand AddPolygonAnnotationCommand
        {
            get
            {
                return addPolygonAnnotationCommand ?? (addPolygonAnnotationCommand = new CommandHandler(() => AddPolygonAnnotationCommandExecute(), () => AddPolygonAnnotationCommandCanExecute));
            }
        }

        public bool AddPolygonAnnotationCommandCanExecute
        {
            get { return currentActivity == Activity.Comment; }
        }

        public void AddPolygonAnnotationCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddPolygonAnnotation;
        }

        private ICommand addCloudPolygonAnnotationCommand;
        public ICommand AddCloudPolygonAnnotationCommand
        {
            get
            {
                return addCloudPolygonAnnotationCommand ?? (addCloudPolygonAnnotationCommand = new CommandHandler(() => AddCloudPolygonAnnotationCommandExecute(), () => AddCloudPolygonAnnotationCommandCanExecute));
            }
        }

        public bool AddCloudPolygonAnnotationCommandCanExecute
        {
            get { return currentActivity == Activity.Comment; }
        }

        public void AddCloudPolygonAnnotationCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddCloudPolygonAnnotation;
        }

        private ICommand addInkAnnotationCommand;
        public ICommand AddInkAnnotationCommand
        {
            get
            {
                return addInkAnnotationCommand ?? (addInkAnnotationCommand = new CommandHandler(() => AddInkAnnotationCommandExecute(), () => AddInkAnnotationCommandCanExecute));
            }
        }

        public bool AddInkAnnotationCommandCanExecute
        {
            get { return currentActivity == Activity.Comment; }
        }

        public void AddInkAnnotationCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddInkAnnotation;
        }

        private ICommand addLinkAnnotationCommand;
        public ICommand AddLinkAnnotationCommand
        {
            get
            {
                return addLinkAnnotationCommand ?? (addLinkAnnotationCommand = new CommandHandler(() => AddLinkAnnotationCommandExecute(), () => AddLinkAnnotationCommandCanExecute));
            }
        }

        public bool AddLinkAnnotationCommandCanExecute
        {
            get { return currentActivity == Activity.Comment; }
        }

        public void AddLinkAnnotationCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddLinkAnnotation;
        }

        private ICommand addFileAttachmentAnnotationCommand;
        public ICommand AddFileAttachmentAnnotationCommand
        {
            get
            {
                return addFileAttachmentAnnotationCommand ?? (addFileAttachmentAnnotationCommand = new CommandHandler(() => AddFileAttachmentAnnotationCommandExecute(), () => AddFileAttachmentAnnotationCommandCanExecute));
            }
        }

        public bool AddFileAttachmentAnnotationCommandCanExecute
        {
            get { return currentActivity == Activity.Comment; }
        }

        public void AddFileAttachmentAnnotationCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddFileAttachmentAnnotation;
        }

        private ICommand addFreeTextAnnotationCommand;
        public ICommand AddFreeTextAnnotationCommand
        {
            get
            {
                return addFreeTextAnnotationCommand ?? (addFreeTextAnnotationCommand = new CommandHandler(() => AddFreeTextAnnotationCommandExecute(), () => AddFreeTextAnnotationCommandCanExecute));
            }
        }

        public bool AddFreeTextAnnotationCommandCanExecute
        {
            get { return currentActivity == Activity.Comment; }
        }

        public void AddFreeTextAnnotationCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.AddFreeTextAnnotation;
        }

    }
}
