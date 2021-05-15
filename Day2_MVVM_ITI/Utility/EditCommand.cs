using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Day2_MVVM_ITI.Utility
{
    public class EditCommand : ICommand
    {

        Action<object> execute;
        Predicate<object> canexecute;

        public EditCommand(Action<object> _exceute, Predicate<object> _canExecute)
        {
            execute = _exceute;
            canexecute = _canExecute;

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canexecute == null ? true : canexecute(parameter);

        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
