using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeviceOutputView.View
{
    /// <summary>
    /// DeviceOutputView.xaml の相互作用ロジック
    /// </summary>
    public partial class DeviceOutputView : UserControl
    {
        protected static BitmapImage ConnImage = new BitmapImage(
            new Uri(@"../Resource/conn.png", UriKind.Relative));
        protected static BitmapImage DisConnImage = new BitmapImage(
            new Uri(@"../Resource/disconn.png", UriKind.Relative));
        protected static Brush FontColor_DisConn = new SolidColorBrush(Colors.Gray);
        protected static Brush FontColor_Conn = new SolidColorBrush(Colors.Black);

        public DeviceOutputView()
        {
            InitializeComponent();

            this.ConnectImage.Source = DeviceOutputView.DisConnImage;
            this.DeviceNameText.Foreground = DeviceOutputView.FontColor_DisConn;
            this.DevicePortText.Foreground = DeviceOutputView.FontColor_DisConn;
        }

        #region Properties and fields
        /// <summary>Property coresponding to Value1 field.</summary>
        public static readonly DependencyProperty Value1Property =
            DependencyProperty.Register(
                "Value1",
                typeof(string),
                typeof(DeviceOutputView),
                new PropertyMetadata(""));
        public string Value1
        {
            get { return (string)GetValue(Value1Property); }
            set { SetValue(Value1Property, value); }
        }
        /// <summary>Property coresponding to Unit1 field.</summary>
        public static readonly DependencyProperty Unit1Property =
            DependencyProperty.Register(
                "Unit1",
                typeof(string),
                typeof(DeviceOutputView),
                new PropertyMetadata(""));
        public string Unit1
        {
            get { return (string)GetValue(Unit1Property); }
            set { SetValue(Unit1Property, value); }
        }
        /// <summary>Property coresponding to Value2 field.</summary>
        public static readonly DependencyProperty Value2Property =
            DependencyProperty.Register(
                "Value2",
                typeof(string),
                typeof(DeviceOutputView),
                new PropertyMetadata(""));
        public string Value2
        {
            get { return (string)GetValue(Value2Property); }
            set { SetValue(Value2Property, value); }
        }
        /// <summary>Property coresponding to InSide field.</summary>
        public static DependencyProperty InSideProperty = 
            DependencyProperty.Register(
                "InSide",
                typeof(double),
                typeof(DeviceOutputView),
                new PropertyMetadata(0d, InSideValueChanged));
        public double InSide
        {
            get { return (double)GetValue(InSideProperty); }
            set { SetValue(InSideProperty, value); }
        }
        /// <summary>Property coresponding to OutSide field.</summary>
        public static DependencyProperty OutSideProperty =
            DependencyProperty.Register(
                "OutSide",
                typeof(double),
                typeof(DeviceOutputView),
                new PropertyMetadata(0d, OutSideValueChanged));
        public double OutSide
        {
            get { return (double)GetValue(OutSideProperty); }
            set { SetValue(OutSideProperty, value); }
        }
        /// <summary>Property coresponding to Unit2 field.</summary>
        public static readonly DependencyProperty Unit2Property =
            DependencyProperty.Register(
                "Unit2",
                typeof(string),
                typeof(DeviceOutputView),
                new PropertyMetadata(""));
        public string Unit2
        {
            get { return (string)GetValue(Unit2Property); }
            set { SetValue(Unit2Property, value); }
        }
        /// <summary>Property coresponding to DeviceName field.</summary>
        public static readonly DependencyProperty DeviceNameProperty =
            DependencyProperty.Register(
                "DeviceName",
                typeof(string),
                typeof(DeviceOutputView),
                new PropertyMetadata(""));
        public string DeviceName
        {
            get { return (string)GetValue(DeviceNameProperty); }
            set { SetValue(DeviceNameProperty, value); }
        }
        /// <summary>Property coresponding to DeviceName field.</summary>
        public static readonly DependencyProperty DevicePortProperty =
            DependencyProperty.Register(
                "DevicePort",
                typeof(string),
                typeof(DeviceOutputView),
                new PropertyMetadata(""));
        public string DevicePort
        {
            get { return (string)GetValue(DevicePortProperty); }
            set { SetValue(DevicePortProperty, value); }
        }
        /// <summary>Property coresponding to DeviceName field.</summary>
        public static readonly DependencyProperty IsConnectedProperty =
            DependencyProperty.Register(
                "IsConnected",
                typeof(bool),
                typeof(DeviceOutputView),
                new PropertyMetadata(false, IsConnectedChanged));
        public bool IsConnected
        {
            get { return (bool)GetValue(IsConnectedProperty); }
            set { SetValue(IsConnectedProperty, value); }
        }
        #endregion
        #region Event handler
        /// <summary>
        /// Event handler called when the property "IsConnected" is changed.
        /// </summary>
        /// <param name="sender">The DependencyObject on which the property has changed value.</param>
        /// <param name="e">Event data that is issued by any event that tracks changes to the effective value of this property.</param>
        [Browsable(true)]
        [Description("Event handler called when the property \"IsConnected\" is changed.")]
        public static void IsConnectedChanged(
            DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            DeviceOutputView DstView = sender as DeviceOutputView;
            bool NewValue = (bool)e.NewValue;
            if (NewValue)
            {
                DstView.ConnectImage.Source = DeviceOutputView.ConnImage;
                DstView.DeviceNameText.Foreground = DeviceOutputView.FontColor_Conn;
                DstView.DevicePortText.Foreground = DeviceOutputView.FontColor_Conn;
            }
            else
            {
                DstView.ConnectImage.Source = DeviceOutputView.DisConnImage;
                DstView.DeviceNameText.Foreground = DeviceOutputView.FontColor_DisConn;
                DstView.DevicePortText.Foreground = DeviceOutputView.FontColor_DisConn;
            }
        }
        [Browsable(true)]
        [Description("Event handler called when the property \"InSide\" is changed.")]
        public static void InSideValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DeviceOutputView DstView = sender as DeviceOutputView;
            double NewValue = (double)e.NewValue;
            ProgressBar.CircleProgressBar.SetValue(ref DstView.ForegroundBar_InSide, NewValue, true);
            ProgressBar.CircleProgressBar.SetValue(ref DstView.BackgroundBar_InSide, NewValue, false);
        }
        [Browsable(true)]
        [Description("Event handler called when the property \"OutSide\" is changed.")]
        public static void OutSideValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DeviceOutputView DstView = sender as DeviceOutputView;
            double NewValue = (double)e.NewValue;
            ProgressBar.CircleProgressBar.SetValue(ref DstView.ForegroundBar_OutSide, NewValue, true);
            ProgressBar.CircleProgressBar.SetValue(ref DstView.BackgroundBar_OutSide, NewValue, false);
        }
        #endregion
    }
}
