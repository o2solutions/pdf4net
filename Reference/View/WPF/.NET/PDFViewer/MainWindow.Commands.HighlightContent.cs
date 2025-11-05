using System;
using System.Windows.Input;
using O2S.Components.PDF4NET.View;

namespace PDFViewer
{
    public partial class MainWindow
    {

        private ICommand highlightTextCommand;
        public ICommand HighlightTextCommand
        {
            get
            {
                return highlightTextCommand ?? (highlightTextCommand = new CommandHandler(() => HighlightTextCommandExecute(), () => HighlightTextCommandCanExecute));
            }
        }

        public bool HighlightTextCommandCanExecute
        {
            get { return currentActivity == Activity.HighlightContent; }
        }

        public void HighlightTextCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.HighlightText;
        }

        private ICommand flatUnderlineTextCommand;
        public ICommand FlatUnderlineTextCommand
        {
            get
            {
                return flatUnderlineTextCommand ?? (flatUnderlineTextCommand = new CommandHandler(() => FlatUnderlineTextCommandExecute(), () => FlatUnderlineTextCommandCanExecute));
            }
        }

        public bool FlatUnderlineTextCommandCanExecute
        {
            get { return currentActivity == Activity.HighlightContent; }
        }

        public void FlatUnderlineTextCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.FlatUnderlineText;
        }

        private ICommand squigglyUnderlineTextCommand;
        public ICommand SquigglyUnderlineTextCommand
        {
            get
            {
                return squigglyUnderlineTextCommand ?? (squigglyUnderlineTextCommand = new CommandHandler(() => SquigglyUnderlineTextCommandExecute(), () => SquigglyUnderlineTextCommandCanExecute));
            }
        }

        public bool SquigglyUnderlineTextCommandCanExecute
        {
            get { return currentActivity == Activity.HighlightContent; }
        }

        public void SquigglyUnderlineTextCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.SquigglyUnderlineText;
        }

        private ICommand strikeoutTextCommand;
        public ICommand StrikeoutTextCommand
        {
            get
            {
                return strikeoutTextCommand ?? (strikeoutTextCommand = new CommandHandler(() => StrikeoutTextCommandExecute(), () => StrikeoutTextCommandCanExecute));
            }
        }

        public bool StrikeoutTextCommandCanExecute
        {
            get { return currentActivity == Activity.HighlightContent; }
        }

        public void StrikeoutTextCommandExecute()
        {
            documentView.UserInteractionMode = PDFUserInteractionMode.StrikeoutText;
        }
    }
}
