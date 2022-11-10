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
using APF_Alien_Plant_Finder_.PresentationLayer;
using System.Windows;
using System.Windows.Input;


using APF_Alien_Plant_Finder_.BusinessLogicLayer.Models;

namespace APF_Alien_Plant_Finder_.PresentationLayer
{
    public partial class DroneControlScreen : Form
    {
        WifiConnectivity wcty = new WifiConnectivity();
        TelloControls tcl = new TelloControls();
        TelloHandler thdr = new TelloHandler();
        Tello tlo = new Tello();

        public DroneControlScreen()
        {
            
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
        
        private int _speed;
        private int[] _rcChannels = { 0, 0, 0, 0 };     // 4 channels
        private bool _updateStatus;
        private bool _videoRecordingWhenConnected;
        private bool _videoStreamingWhenConnected;

        private void btn_connecttoDrone_Click(object sender, EventArgs e)
        {
            wcty.Connect();
            if (_videoStreamingWhenConnected) tlo.StartOrStopVideoStreaming();
            
        }
        
        private void DisplayStatus()
        {
            if (tlo.Connected)
            {
                btn_connecttoDrone.BackColor = Color.Green;
                
                lbl_Connected.Tag = "Connected";
                lbl_Height.Tag = thdr.DroneState<string>("h");
                lb_BateryLevel.Tag = thdr.DroneState<string>("bat");
                
                if (tlo.VideoStreaming ) btn_streamCamera.BackColor = Color.Green;
                else btn_streamCamera.BackColor = Color.LightGray;
                
            }
            else
            {
                btn_connecttoDrone.BackColor = Color.LightGray;
                btn_streamCamera.BackColor = Color.LightGray;
                btn_streamCamera.BackColor = Color.LightGray;
                lbl_Connected.Tag = "Not Connected";
                lbl_Height.Tag = "??";
                lb_BateryLevel.Tag = "??";
                
            }
        }

        
    }
}
