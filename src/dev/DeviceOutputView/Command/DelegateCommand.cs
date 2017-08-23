using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeviceStateView.Command
{
    public class DelegateCommand : ICommand
    {
        private Action execute;
        private Func<bool> canExecute;

        /// <summary>
        /// コマンドのExecuteメソッドで実行する処理を指定してDelegateCommandインスタンスを
        /// 作成する。
        /// </summary>
        /// <param name="execute"></param>
        public DelegateCommand(Action execute) : this(execute, () => true) { }

        /// <summary>
        /// コマンドのExecuteメソッドで実行する処理とCanExecuteメソッドで実行する処理を
        /// 指定して、DelegateCommandのインスタンスを作成する。
        /// </summary>
        /// <param name="execute">Executeメソッドで実行する処理</param>
        /// <param name="p">canExecuteで実行するメソッド</param>
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            if (null == execute)
            {
                throw new ArgumentNullException("execute");
            }
            if (null == canExecute)
            {
                throw new ArgumentNullException("canExecute");
            }
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// CanExecuteの結果に変更あったことを通知するイベント。
        /// </summary>
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// コマンドを実行する。
        /// </summary>
        public void Execute()
        {
            this.execute();
        }

        /// <summary>
        /// コマンドが実行可能な状態かどうか、問い合わせをする。
        /// </summary>
        /// <returns></returns>
        public bool CanExecute()
        {
            return this.canExecute();
        }

        /// <summary>
        /// ICommand.CanExecuteの明示的な実装です。
        /// CanExecuteメソッドに、処理を委譲します。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute();
        }

        /// <summary>
        /// ICommand.Executeの明示的な実装。Executeメソッドに処理を委譲する。
        /// </summary>
        /// <param name="parameter"></param>
        void ICommand.Execute(object parameter)
        {
            this.Execute();
        }
    }

    public class DelegateCommand<T> : ICommand
    {
        #region
        private readonly Action<T> execute;
        private readonly Func<bool> canExecute;
        #endregion

        #region Event
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

        #region Constructors and the Finalizer
        public DelegateCommand(Action<T> execute) : this(execute, null) { }
        public DelegateCommand(Action<T> execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            this.execute = execute;
            this.canExecute = canExecute;
        }
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Defines the method that determines whether the command can execute
        /// in its current state.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data
        /// to be passed, this object can be set to null.
        /// </param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null ? true : this.canExecute();
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            this.execute((T)parameter);
        }
        #endregion
    }
}
