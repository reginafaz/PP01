using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pp_01
{
    public class MyCommand : ICommand
    {
        private readonly Action action;
        Func<bool> func;
        private readonly Action<object> actionObject;
        private ICommand saveGruppa;

        public MyCommand(Action action)
        {
            this.action = action;
        }
        public MyCommand(Func<bool> func)
        {
            this.func = func;
        }
        public MyCommand(Action<object> actionObject)
        {
            this.actionObject = actionObject;
        }

        public MyCommand(ICommand saveGruppa)
        {
            this.saveGruppa = saveGruppa;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return actionObject == null || parameter != null;
        }

        public void Execute(object parameter)
        {
            func?.Invoke();
            action?.Invoke();
            actionObject?.Invoke(parameter);
        }
    }
}
