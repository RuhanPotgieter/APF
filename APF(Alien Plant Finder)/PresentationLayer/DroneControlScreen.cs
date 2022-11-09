using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using APF_Alien_Plant_Finder_.BusinessLogicLayer;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace APF_Alien_Plant_Finder_.PresentationLayer
{
    public partial class DroneControlScreen : Form
    {

        public DroneControlScreen()
        {
            wcty = new WifiConnectivity();
            tcl = new TelloControls();
            Thread t = new Thread(new ThreadStart(StartForrm));

            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();



        }

        public void StartForrm()
        {
            Application.Run(new SplashScreen());
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private WifiConnectivity wcty;
        private int _speed;
        private int[] _rcChannels = { 0, 0, 0, 0 };     // 4 channels
        private bool _updateStatus;
        private bool _videoRecordingWhenConnected;
        private bool _videoStreamingWhenConnected;

        private void btn_connecttoDrone_Click(object sender, EventArgs e)
        {
            wcty.Connect();
            if (_videoRecordingWhenConnected) wcty.StartOrStopVideoRecording();
            else if (_videoStreamingWhenConnected) wcty.StartOrStopVideoStreaming();
        }

        private void DisplayStatus()
        {
            if (tcl.Connected)
            {
                btnConnect.Background = Brushes.Green;
                if (_tello.Flying) statusLabel.Content = "Flying";
                else statusLabel.Content = "Connected";
                heightLabel.Content = _tello.DroneState<string>("h");
                batteryLabel.Content = _tello.DroneState<string>("bat");
                flightTimeLabel.Content = _tello.DroneState<string>("time");
                tofLabel.Content = _tello.DroneState<string>("tof");
                temperatureLabel.Content = (_tello.DroneState<int>("templ") + _tello.DroneState<int>("temph")) / 2;
                if (_tello.VideoStreaming || _tello.VideoRecording) btnStreaming.Background = Brushes.Green;
                else btnStreaming.Background = Brushes.LightGray;
                if (!_tello.VideoRecording) btnVideo.Background = Brushes.LightGray;
                else btnVideo.Background = Brushes.Green;
            }

        }

    }
}
