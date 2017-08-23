using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceOutputView.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Property and field.
        public MainWindowViewModel()
        {
            this.DevViewModel.IsConnected = true;

            this.Value1 = "0";
            this.Value2 = "0";
            this.Unit1 = "-";
            this.Unit2 = "-";
        }
        protected string _Value1;
        public string Value1
        {
            get { return this._Value1; }
            set
            {
                this._Value1 = value;
                this.DevViewModel.Value1 = value;
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
                this.DevViewModel.Value2 = value;
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
        #endregion
    }
}
