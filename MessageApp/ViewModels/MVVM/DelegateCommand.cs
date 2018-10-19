using System;
using System.Windows.Input;

namespace MessageApp.ViewModels.MVVM
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _command;
        private readonly Func<bool> _canExecute;
        private readonly bool _newThread;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DelegateCommand(Action command, bool newThread = false, Func<bool> canExecute = null)
        {
            if (command == null)
                throw new ArgumentNullException();
            _newThread = newThread;
            _canExecute = canExecute;
            _command = command;
        }

        public void Execute(object parameter)
        {
            if (_newThread == true)
                new System.Threading.Thread(() => _command()).Start();
            else
                _command();
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

    }
}
