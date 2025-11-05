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

		private ICommand panAndScanCommand;
		public ICommand PanAndScanCommand
		{
			get
			{
				return panAndScanCommand ?? (panAndScanCommand = new CommandHandler(() => PanAndScanCommandExecute(), () => PanAndScanCommandCanExecute));
			}
		}

		public bool PanAndScanCommandCanExecute
		{
			get { return IsDocumentAvailable; }
		}

		public void PanAndScanCommandExecute()
		{
			UpdateCurrentActivity(Activity.PanAndScan);
			documentView.UserInteractionMode = PDFUserInteractionMode.PanAndScan;
		}

		private ICommand selectContentCommand;
		public ICommand SelectContentCommand
		{
			get
			{
				return selectContentCommand ?? (selectContentCommand = new CommandHandler(() => SelectContentCommandExecute(), () => SelectContentCommandCanExecute));
			}
		}

		public bool SelectContentCommandCanExecute
		{
			get { return IsDocumentAvailable; }
		}

		public void SelectContentCommandExecute()
		{
			UpdateCurrentActivity(Activity.SelectContent);
			documentView.UserInteractionMode = PDFUserInteractionMode.SelectContent;
		}

		private ICommand commentCommand;
		public ICommand CommentCommand
		{
			get
			{
				return commentCommand ?? (commentCommand = new CommandHandler(() => CommentCommandExecute(), () => CommentCommandCanExecute));
			}
		}

		public bool CommentCommandCanExecute
		{
			get { return IsDocumentAvailable; }
		}

		public void CommentCommandExecute()
		{
			UpdateCurrentActivity(Activity.Comment);
			documentView.UserInteractionMode = PDFUserInteractionMode.EditAnnotations;
		}

		private ICommand editFormCommand;
		public ICommand EditFormCommand
		{
			get
			{
				return editFormCommand ?? (editFormCommand = new CommandHandler(() => EditFormCommandExecute(), () => EditFormCommandCanExecute));
			}
		}

		public bool EditFormCommandCanExecute
		{
			get { return IsDocumentAvailable; }
		}

		public void EditFormCommandExecute()
		{
			UpdateCurrentActivity(Activity.EditForm);
			documentView.UserInteractionMode = PDFUserInteractionMode.EditFormFields;
		}

		private ICommand highlightContentCommand;
		public ICommand HighlightContentCommand
		{
			get
			{
				return highlightContentCommand ?? (highlightContentCommand = new CommandHandler(() => HighlightContentCommandExecute(), () => HighlightContentCommandCanExecute));
			}
		}

		public bool HighlightContentCommandCanExecute
		{
			get { return IsDocumentAvailable; }
		}

		public void HighlightContentCommandExecute()
		{
			UpdateCurrentActivity(Activity.HighlightContent);
			documentView.UserInteractionMode = PDFUserInteractionMode.HighlightText;
		}

		private ICommand searchCommand;
		public ICommand SearchCommand
		{
			get
			{
				return searchCommand ?? (searchCommand = new CommandHandler(() => SearchCommandExecute(), () => SearchCommandCanExecute));
			}
		}

		public bool SearchCommandCanExecute
		{
			get { return IsDocumentAvailable; }
		}

		public void SearchCommandExecute()
		{
			UpdateCurrentActivity(Activity.Search);
		}

		private void UpdateCurrentActivity(Activity activity)
		{
			if (currentActivity == Activity.Search)
			{
				contentLocator.ClearTextSearchResults();
				isSearchInitialized = false;
			}

			currentActivity = activity;
			btnPanAndScan.IsChecked = currentActivity == Activity.PanAndScan;
			btnSelectContent.IsChecked = currentActivity == Activity.SelectContent;
			btnComment.IsChecked = currentActivity == Activity.Comment;
			btnEditForm.IsChecked = currentActivity == Activity.EditForm;
			btnHighlightContent.IsChecked = currentActivity == Activity.HighlightContent;
			btnSearch.IsChecked = currentActivity == Activity.Search;
		}
	}
}
