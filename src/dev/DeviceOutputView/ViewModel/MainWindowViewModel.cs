using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceStateView.Command;

namespace DeviceOutputView.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Property and field.
        public MainWindowViewModel()
        {
            this.Value1 = "0";
            this.Value2 = "0";
            this.Unit1 = "-";
            this.Unit2 = "-";
            this.DValue1 = 0d;
            this.DValue2 = 0d;
        }
        protected string _Value1;
        public string Value1
        {
            get { return this._Value1; }
            set
            {
                this._Value1 = value;
                this.DValue1 = Convert.ToDouble(value);
                this.RaisePropertyChanged("Value1");
            }
        }
        protected string _Value2;
        public string Value2
        {
            get { return this._Value2; }
            set
            {
                this._Value2 = value;
                this.DValue2 = Convert.ToDouble(value);
                this.RaisePropertyChanged("Value2");
            }
        }
        protected double _DValue1;
        public double DValue1
        {
            get { return this._DValue1; }
            set
            {
                this._DValue1 = value;
                this.DevViewModel.InSide = value;
                this.RaisePropertyChanged("DValue1");
            }
        }
        protected double _DValue2;
        public double DValue2
        {
            get { return this._DValue2; }
            set
            {
                this._DValue2 = value;
                this.DevViewModel.OutSide = value;
                this.RaisePropertyChanged("DValue2");
            }
        }
        protected string _Unit1;
        public string Unit1
        {
            get { return this._Unit1; }
            set
            {
                this._Unit1 = value;
                this.DevViewModel.Unit1 = value;
                this.RaisePropertyChanged("Unit1");
            }
        }
        protected string _Unit2;
        public string Unit2
        {
            get { return this._Unit2; }
            set
            {
                this._Unit2 = value;
                this.DevViewModel.Unit2 = value;
                this.RaisePropertyChanged("Unit2");
            }
        }
        protected DelegateCommand _ConnectStateChangeCommand;
        public DelegateCommand ConnectStateChangeCommand
        {
            get
            {
                if (null == this._ConnectStateChangeCommand)
                {
                    this._ConnectStateChangeCommand = new DelegateCommand(
                        this.ConnectStateChangeCommandExecute,
                        this.CanConnectStateChangeCommandExecute);
                }
                return this._ConnectStateChangeCommand;
            }
        }

        protected DeviceOutputViewModel _DevViewModel;
        public DeviceOutputViewModel DevViewModel
        {
            get
            {
                if (null == this._DevViewModel)
                {
                    this._DevViewModel = new DeviceOutputViewModel();
                }
                return this._DevViewModel;
            }
            set
            {
                this._DevViewModel = value;
                this.RaisePropertyChanged("DevViewModel");
            }
        }

        /// <summary>
        /// Command body to change connect state.
        /// </summary>
        public void ConnectStateChangeCommandExecute()
        {
            if (this.DevViewModel.IsConnected)
            {
                this.DevViewModel.IsConnected = false;

                this.DValue1 = 0d;
                this.DValue2 = 0d;
            }
            else
            {
                this.DevViewModel.IsConnected = true;
                this.DevViewModel.Unit1 = this.Unit1;
                this.DevViewModel.Unit2 = this.Unit2;
                this.DevViewModel.InSide = this.DValue1;
                this.DevViewModel.OutSide = this.DValue2;
            }
        }

        /// <summary>
        /// Returns whether ConnectStateChange command can execute or not.
        /// </summary>
        /// <returns>Whether the command can execute or not.</returns>
        public bool CanConnectStateChangeCommandExecute() { return true; }

        #endregion
    }
}
