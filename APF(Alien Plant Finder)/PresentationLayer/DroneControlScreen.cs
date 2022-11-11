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

using System.IO;




using APF_Alien_Plant_Finder_.BusinessLogicLayer.Models;
using static APF_Alien_Plant_Finder_.BusinessLogicLayer.Models.TelloHandler;
using System.Runtime.CompilerServices;

namespace APF_Alien_Plant_Finder_.PresentationLayer
{
    
    public partial class DroneControlScreen : Form
    {
        WifiConnectivity wcty = new WifiConnectivity();
        
        TelloHandler thdr = new TelloHandler();
        Telloc tlo = new Telloc();

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
                lbl_Height.Tag = tlo.DroneState<string>("h");
                lb_BateryLevel.Tag = tlo.DroneState<string>("bat");
                
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
        private void btnLand_Click(object sender, EventArgs e)
        {
            tlo.Land();
        }
        
        //take off method activated when pressing the enter key
        
        public void MyKeyDownEventHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tlo.Connected)

                {
                    tlo.Takeoff();
                }
            }
            
            else if (e.KeyCode == Keys.W)
            {
                if (tlo.Flying)
                {
                    tlo.Forward(_speed);
                }
            }
            else if (e.KeyCode == Keys.D)
            {
                if (tlo.Flying)
                {
                    tlo.Right(_speed);
                }
            }
            else if (e.KeyCode == Keys.A)
            {
                if (tlo.Flying)
                {
                    tlo.Left(_speed);
                }
            }
            else if (e.KeyCode == Keys.S)
            {
                if (tlo.Flying)
                {
                    tlo.Back(_speed);
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (tlo.Flying)
                {
                    tlo.Clockwise(_speed);
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (tlo.Flying)
                {
                    tlo.CounterClockwise(_speed);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (tlo.Flying)
                {
                    tlo.Up(_speed);
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (tlo.Flying)
                {
                    tlo.Down(_speed);
                }
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (tlo.Flying)
                {
                    tlo.Land();
                }
            }
        }

        private void btn_Scan_Click(object sender, EventArgs e)
        {
            tlo.SavePhoto("Plantimage");
        }

        private void btn_streamCamera_Click(object sender, EventArgs e)
        {
            tlo.StreamOn();
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            tlo.StreamOff();
            tlo.Disconnect();
        }
    }
}
