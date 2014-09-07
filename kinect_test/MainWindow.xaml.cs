using System;
using System.Collections.Generic;
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

using Microsoft.Kinect;
using Coding4Fun.Kinect.Wpf;

namespace kinect_test
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private KinectSensor kinect;

        public MainWindow()
        {
            InitializeComponent();

            // Kinectが接続されているかどうか
            if ( KinectSensor.KinectSensors.Count == 0 ) {
                // 例外を吐いてもいい
                MessageBox.Show("No Kinect Sensors connected");
                Close();
            }
            // 0個目のKinectのKinectSensorインスタンスを取得（つまり1台目）
            kinect = KinectSensor.KinectSensors[0];

            // RGBカメラを有効化
            kinect.ColorStream.Enable();

            // ColorStreamのイベントを追加
            kinect.ColorFrameReady += new EventHandler<ColorImageFrameReadyEventArgs>(kinect_ColorFrameReady);

            kinect.Start();
        }
        void kinect_ColorFrameReady( object sender, ColorImageFrameReadyEventArgs e )
        {
            rgbCamera.Source = e.OpenColorImageFrame().ToBitmapSource();
        }
    }
    
}
