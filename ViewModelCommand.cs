using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProject
{
    public class ViewModelCommand : ModelCommand
    {
        private readonly Func<bool> _canExecute;
        private readonly Action _execute;

        public ViewModelCommand(Func<bool> canExecute, Action execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        protected override bool CanExecute()
        {
            return _canExecute.Invoke();
        }

        protected override void Execute()
        {
            if (_execute != null)
                _execute.Invoke();
        }
    }
}
