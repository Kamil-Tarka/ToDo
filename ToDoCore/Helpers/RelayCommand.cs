using System.Windows.Input;

namespace ToDoCore
{
    internal class RelayCommand : ICommand
    {
        private Action mAction;

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action mAction)
        {
            this.mAction = mAction;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            mAction();
        }
    }
}