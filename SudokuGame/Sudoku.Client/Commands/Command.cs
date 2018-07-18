/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: Command.cs
*     Creation Date: 7/11/2018
*            Author: M. Moody
*  
*       Description: This class defines Commands used for button click on the UI.
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Windows.Input;

namespace Sudoku.Client.Commands
{
    public class Command<T> : ICommand
    {
        private readonly Func<T, bool> _canExecute;
        private readonly Action<T> _execute;


        public Command(Action<T> execute)
            : this(_ => true, execute)
        {
        }


        public Command(Func<T, bool> canExecute, Action<T> execute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }


        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }


        public bool CanExecute(object parameter)
        {
            if (parameter == null && typeof(T).IsValueType)
                return false;

            return _canExecute((T)parameter);
        }


        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }


    public class Command : Command<object>
    {
        public Command(Func<bool> canExecute, Action execute)
            : base(_ => canExecute(), _ => execute())
        {
        }


        public Command(Action execute)
            : this(() => true, execute)
        {
        }
    }
}
