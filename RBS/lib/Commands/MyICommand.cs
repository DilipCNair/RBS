using System;
using System.Windows.Input;

namespace RBS.Commands
{
    public class MyICommand : ICommand
    {
        //Delegates holding references to the target functions 
        private readonly Func<bool> TargetCanExecuteMethod;
        private readonly Action TargetExecuteMethod;


        public MyICommand(Action ExecuteMethod)
        {
            TargetExecuteMethod = ExecuteMethod;
        }

        public MyICommand(Func<bool> CanExecuteMethod, Action ExecuteMethod)
        {
            TargetCanExecuteMethod = CanExecuteMethod;
            TargetExecuteMethod = ExecuteMethod;
        }


        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }


        //When User Clicks a Button this function gets invoked
        bool ICommand.CanExecute(object parameter)
        {
            return TargetCanExecuteMethod != null ? TargetCanExecuteMethod() : TargetExecuteMethod != null;
        }

        //When User Clicks a Button this function gets invoked
        void ICommand.Execute(object parameter)
        {
            TargetExecuteMethod();
        }
    }
}
