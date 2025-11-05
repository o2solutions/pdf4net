using System;
using System.Windows.Input;

namespace PDFViewer
{
    public class CommandHandler : ICommand
    {
        private Action commandAction;

        private Func<bool> canExecute;

        /// <summary>
        /// Creates instance of the command handler
        /// </summary>
        /// <param name="commandAction">Action to be executed by the command</param>
        /// <param name="canExecute">A bolean property to containing current permissions to execute the command</param>
        public CommandHandler(Action commandAction, Func<bool> canExecute)
        {
            this.commandAction = commandAction;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Wires CanExecuteChanged event 
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Forcess checking if execute is allowed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            commandAction();
        }
    }
}
