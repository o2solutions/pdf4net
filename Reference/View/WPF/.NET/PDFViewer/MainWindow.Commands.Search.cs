using System;
using System.Windows.Controls;
using System.Windows.Input;
using O2S.Components.PDF4NET.View;
using O2S.Components.PDF4NET.View.Content;

namespace PDFViewer
{
    public partial class MainWindow
    {
        private PDFVisualContentLocator contentLocator;

		private bool isSearchInitialized;

        private ICommand findPreviousCommand;
		public ICommand FindPreviousCommand
		{
			get
			{
				return findPreviousCommand ?? (findPreviousCommand = new CommandHandler(() => FindPreviousCommandExecute(), () => FindPreviousCommandCanExecute));
			}
		}

		public bool FindPreviousCommandCanExecute
		{
			get { return currentActivity == Activity.Search; }
		}

		public void FindPreviousCommandExecute()
		{
            if (!isSearchInitialized)
            {
                InitSearch();
            }
            else
            {
                contentLocator.HighlightPreviousTextSearchResult();
            }
        }

        private ICommand findNextCommand;
		public ICommand FindNextCommand
		{
			get
			{
				return findNextCommand ?? (findNextCommand = new CommandHandler(() => FindNextCommandExecute(), () => FindNextCommandCanExecute));
			}
		}

		public bool FindNextCommandCanExecute
		{
			get { return currentActivity == Activity.Search; }
		}

		public void FindNextCommandExecute()
		{
            if (!isSearchInitialized)
            {
                InitSearch();
            }
            else
            {
                contentLocator.HighlightNextTextSearchResult();
            }
        }

        private ICommand findMatchCaseCommand;
		public ICommand FindMatchCaseCommand
		{
			get
			{
				return findMatchCaseCommand ?? (findMatchCaseCommand = new CommandHandler(() => FindMatchCaseCommandExecute(), () => FindMatchCaseCommandCanExecute));
			}
		}

		public bool FindMatchCaseCommandCanExecute
		{
			get { return currentActivity == Activity.Search; }
		}

		public void FindMatchCaseCommandExecute()
		{
            if (btnMatchCase.IsChecked.Value)
            {
                btnMatchRegEx.IsChecked = false;
            }
        }

        private ICommand findMatchAccentCommand;
		public ICommand FindMatchAccentCommand
		{
			get
			{
				return findMatchAccentCommand ?? (findMatchAccentCommand = new CommandHandler(() => FindMatchAccentCommandExecute(), () => FindMatchAccentCommandCanExecute));
			}
		}

		public bool FindMatchAccentCommandCanExecute
		{
			get { return currentActivity == Activity.Search; }
		}

		public void FindMatchAccentCommandExecute()
		{
            if (btnMatchAccent.IsChecked.Value)
            {
                btnMatchRegEx.IsChecked = false;
            }
        }

        private ICommand findMatchWholeWordCommand;
		public ICommand FindMatchWholeWordCommand
		{
			get
			{
				return findMatchWholeWordCommand ?? (findMatchWholeWordCommand = new CommandHandler(() => FindMatchWholeWordCommandExecute(), () => FindMatchWholeWordCommandCanExecute));
			}
		}

		public bool FindMatchWholeWordCommandCanExecute
		{
			get { return currentActivity == Activity.Search; }
		}

		public void FindMatchWholeWordCommandExecute()
		{
            if (btnMatchWholeWord.IsChecked.Value)
            {
                btnMatchRegEx.IsChecked = false;
            }
        }

        private ICommand findMatchRegExCommand;
		public ICommand FindMatchRegExCommand
		{
			get
			{
				return findMatchRegExCommand ?? (findMatchRegExCommand = new CommandHandler(() => FindMatchRegExCommandExecute(), () => FindMatchRegExCommandCanExecute));
			}
		}

		public bool FindMatchRegExCommandCanExecute
		{
			get { return currentActivity == Activity.Search; }
		}

		public void FindMatchRegExCommandExecute()
		{
			if (btnMatchRegEx.IsChecked.Value)
			{
				btnMatchCase.IsChecked = false;
				btnMatchAccent.IsChecked = false;
				btnMatchWholeWord.IsChecked = false;
			}
		}

        private void InitSearch()
        {
            PDFVisualTextSearchOptions searchOptions = btnMatchCase.IsChecked.Value ? PDFVisualTextSearchOptions.CaseSensitiveSearch : PDFVisualTextSearchOptions.CaseInsensitiveSearch;
            searchOptions |= btnMatchAccent.IsChecked.Value ? PDFVisualTextSearchOptions.AccentSensitiveSearch : PDFVisualTextSearchOptions.AccentInsensitiveSearch;
            if (btnMatchWholeWord.IsChecked.Value)
            {
                searchOptions |= PDFVisualTextSearchOptions.WholeWordSearch;
            }
            if (btnMatchRegEx.IsChecked.Value)
            {
                searchOptions = PDFVisualTextSearchOptions.RegExSearch;
            }

            PDFVisualSearchRange searchRange = PDFVisualSearchRange.CurrentPage;
            switch (cbxRange.SelectedIndex)
            {
                case 1:
                    searchRange = PDFVisualSearchRange.VisiblePages;
                    break;
                case 2:
                    searchRange = PDFVisualSearchRange.AllPages;
                    break;
            }

            contentLocator.SearchText(txtFind.Text, searchRange, searchOptions, true);

            isSearchInitialized = true;
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
			isSearchInitialized = false;
        }

        private void cbxRange_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			isSearchInitialized = false;
        }
    }
}
