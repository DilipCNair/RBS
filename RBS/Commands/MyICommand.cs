using System;
using System.Windows.Input;

namespace RBS.Commands
{
    public class MyICommand : ICommand
    {
        readonly Func<bool> TargetCanExecuteMethod;
        readonly Action TargetExecuteMethod;


        public MyICommand(Action ExecuteMethod)
        {
           TargetExecuteMethod = ExecuteMethod;
        }

        public MyICommand(Func<bool> CanExecuteMethod,  Action ExecuteMthod)
        {
            TargetCanExecuteMethod = CanExecuteMethod;
            TargetExecuteMethod = ExecuteMthod;
        }


        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        //When User Clicks a Button this function get invoked
        bool ICommand.CanExecute(object parameter)
        {
            if (TargetCanExecuteMethod != null)
                return TargetCanExecuteMethod();
            else if (TargetExecuteMethod != null)
                return true;
            else
                return false;
        }

        //When User Clicks a Button this function get invoked
        void ICommand.Execute(object parameter)
        {
            TargetExecuteMethod();
        }
    }
}
