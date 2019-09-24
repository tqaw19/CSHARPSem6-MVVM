using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Semana05.ViewModel
{


    public class RelayCommand<T> : ICommand
    {
        #region Fields

        readonly Action<T> _execute = null;
        readonly Predicate<T> _canExceute = null;

        #endregion

        #region Constructors

        ///<sumary>
        ///Initializes a new instance of <see cref="DelegateCommand{T}"/>
        ///</sumary>
        ///<params name="execute">Delegate to execute when Execute is called on the command. This</params>
        ///<remarks><seealso cref="CanExecute"/> will always return true.</remarks>
        
        public RelayCommand(Action<T> execute)
            : this(execute, null)
        { 
        }

        ///<summary>
        ///Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <params name="canExecute">The execution status logic.</params>
        
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExceute = canExecute;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExceute == null ? true : _canExceute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        #endregion
    }
}
