using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceOutputView.ViewModel
{
    public class DeviceOutputViewModel : ViewModelBase
    {
        #region Constructors and the Finalizer
        /// <summary>
        /// Constructor
        /// </summary>
        public DeviceOutputViewModel()
        {
            this.Init();
        }
        #endregion

        #region Property and field.
        protected string _DeviceName;
        public string DeviceName
        {
            get { return this._DeviceName; }
            set
            {
                this._DeviceName = value;
                this.RaisePropertyChanged("DeviceName");
            }
        }
        protected string _DevicePort;
        public string DevicePort
        {
            get { return this._DevicePort; }
            set
            {
                this._DevicePort = value;
                this.RaisePropertyChanged("DevicePort");
            }
        }
        protected string _Value1;
        public string Value1
        {
            get { return this._Value1; }
            set
            {
                if (this.IsConnected)
                {
                    this._Value1 = value;
                    this.RaisePropertyChanged("Value1");
                }
            }
        }
        protected string _Unit1;
        public string Unit1
        {
            get { return this._Unit1; }
            set
            {
                if (this.IsConnected)
                {
                    this._Unit1 = value;
                    this.RaisePropertyChanged("Unit1");
                }
            }
        }
        protected string _Value2;
        public string Value2
        {
            get { return this._Value2; }
            set
            {
                if (this.IsConnected)
                {
                    this._Value2 = value;
                    this.RaisePropertyChanged("Value2");
                }
            }
        }
        protected string _Unit2;
        public string Unit2
        {
            get { return this._Unit2; }
            set
            {
                if (this.IsConnected)
                {
                    this._Unit2 = value;
                    this.RaisePropertyChanged("Unit2");
                }
            }
        }
        protected bool _IsConnected;
        public bool IsConnected
        {
            get { return this._IsConnected; }
            set
            {
                if ((this._IsConnected == true) && (value == false))
                {
                    /*
                     *  When disconnected, the device information must be reset.
                     */
                    this.Clear();
                }
                this._IsConnected = value;
                if (!value)
                {
                    this.Clear();
                }
                this.RaisePropertyChanged("IsConnected");
            }
        }
        protected double _InSide;
        public double InSide
        {
            get { return this._InSide; }
            set
            {
                if (this.IsConnected)
                {
                    this._InSide = value;
                    this.RaisePropertyChanged("InSide");
                    this.Value1 = Convert.ToString(Convert.ToInt16(value));
                }
            }
        }
        protected double _OutSide;
        public double OutSide
        {
            get { return this._OutSide; }
            set
            {
                if (this.IsConnected)
                {
                    this._OutSide = value;
                    this.RaisePropertyChanged("OutSide");
                    this.Value2 = Convert.ToString(Convert.ToInt16(value));
                }
            }
        }
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Initialize device information.
        /// </summary>
        protected void Init()
        {
            this.Clear();

            this.IsConnected = false;
        }
        /// <summary>
        /// Clear parameters bound to views.
        /// </summary>
        protected void Clear()
        {
            this.Value1 = "";
            this.Value2 = "";
            this.Unit1 = "-";
            this.Unit2 = "-";
            this.InSide = 0d;
            this.OutSide = 0d;
        }
        #endregion
    }
}
