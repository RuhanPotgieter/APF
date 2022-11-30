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
using APF_Alien_Plant_Finder_.DataAccessLayer;
using System.Windows;
using System.Windows.Input;

using System.IO;




using APF_Alien_Plant_Finder_.BusinessLogicLayer.Models;
using static APF_Alien_Plant_Finder_.BusinessLogicLayer.Models.TelloHandler;
using System.Runtime.CompilerServices;
using AForge.Video.DirectShow;
using AForge.Video;

namespace APF_Alien_Plant_Finder_.PresentationLayer
{
    
    public partial class DroneControlScreen : Form
    {
        WifiConnectivity wcty = new WifiConnectivity();
        TelloDroneCamera tdc = new TelloDroneCamera();
        MLConnection mcs = new MLConnection();

        TelloHandler thdr = new TelloHandler();
        //Telloc tlo = new Telloc();

        private bool mouseDown;
        private Point lastLocation;
        public DroneControlScreen()
        {
            
            Thread t = new Thread(new ThreadStart(StartForrm));

            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();



        }
        
        
        private void Panel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            {
                if (e.Button == MouseButtons.Left)
                {
                    mouseDown = true;
                    lastLocation = e.Location;
                }
            }
        }
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        public void StartForrm()
        {
            Application.Run(new SplashScreen());
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.Stop();
            Environment.Exit(0);
            
        }
        
        private int _speed;
        private int[] _rcChannels = { 0, 0, 0, 0 };     // 4 channels
        private bool _updateStatus;
        private bool _videoRecordingWhenConnected;
        private bool _videoStreamingWhenConnected;

        //private void btn_connecttoDrone_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        wcty.Connect();
        //        if (_videoStreamingWhenConnected) tlo.StartOrStopVideoStreaming();
        //    }
        //    catch (System.Net.Sockets.SocketException)
        //    {
        //        MessageBox.Show("Drone not found. Please check your connection and try again.");
        //        throw;
        //    }
           
            
        //}

        
        
        private void DisplayStatus()
        {
            //if (tlo.Connected)
            //{
            //    btn_connecttoDrone.BackColor = Color.Green;
                
            //    lbl_Connected.Tag = "Connected";
            //    lbl_Height.Tag = tlo.DroneState<string>("h");
            //    lb_BateryLevel.Tag = tlo.DroneState<string>("bat");
                
            //    if (tlo.VideoStreaming ) btn_streamCamera.BackColor = Color.Green;
            //    else btn_streamCamera.BackColor = Color.LightGray;
                
            //}
            //else
            //{
            //    btn_connecttoDrone.BackColor = Color.LightGray;
            //    btn_streamCamera.BackColor = Color.LightGray;
            //    btn_streamCamera.BackColor = Color.LightGray;
            //    lbl_Connected.Tag = "Not Connected";
            //    lbl_Height.Tag = "??";
            //    lb_BateryLevel.Tag = "??";
                
            //}
        }
        private void btnLand_Click(object sender, EventArgs e)
        {
            //tlo.Land();
        }
        
        //take off method activated when pressing the enter key
        
        //public void MyKeyDownEventHandler(object sender, KeyEventArgs e)
        ////{
        ////    if (e.Control && e.KeyCode == Keys.Enter)
        ////    {
        ////        if (tlo.Connected)

        ////        {
        ////            tlo.Takeoff();
        ////        }
        ////    }
            
        ////    else if (e.Control && e.KeyCode == Keys.W)
        ////    {
        ////        if (tlo.Flying)
        ////        {
        ////            tlo.Forward(_speed);
        ////        }
        ////    }
        ////    else if (e.Control && e.KeyCode == Keys.D)
        ////    {
        ////        if (tlo.Flying)
        ////        {
        ////            tlo.Right(_speed);
        ////        }
        ////    }
        ////    else if (e.Control && e.KeyCode == Keys.A)
        ////    {
        ////        if (tlo.Flying)
        ////        {
        ////            tlo.Left(_speed);
        ////        }
        ////    }
        ////    else if (e.Control && e.KeyCode == Keys.S)
        ////    {
        ////        if (tlo.Flying)
        ////        {
        ////            tlo.Back(_speed);
        ////        }
        ////    }
        ////    else if (e.Control && e.KeyCode == Keys.Right)
        ////    {
        ////        if (tlo.Flying)
        ////        {
        ////            tlo.Clockwise(_speed);
        ////        }
        ////    }
        ////    else if (e.Control && e.KeyCode == Keys.Left)
        ////    {
        ////        if (tlo.Flying)
        ////        {
        ////            tlo.CounterClockwise(_speed);
        ////        }
        ////    }
        ////    else if (e.Control && e.KeyCode == Keys.Up)
        ////    {
                
        ////        if (tlo.Flying)
        ////        {
        ////            tlo.Up(_speed);
        ////        }
        ////    }
        ////    else if (e.Control && e.KeyCode == Keys.Down)
        ////    {
        ////        if (tlo.Flying)
        ////        {
        ////            tlo.Down(_speed);
        ////        }
        ////    }
        ////    else if (e.Control && e.KeyCode == Keys.Space)
        ////    {
        ////        if (tlo.Flying)
        ////        {
        ////            tlo.Land();
        ////        }
        ////    }
        //}

        //private void btn_Scan_Click(object sender, EventArgs e)
        //{
        //    tlo.SavePhoto("Plantimage");
        //    //mcs.MLConnections();
        //}

        private void btn_streamCamera_Click(object sender, EventArgs e)
        {
            //tlo.StreamOn();
            // tdc.CameraOn();
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        private void DroneControlScreen_Load_1(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                comboBox1.Items.Add(filterInfo.Name);
            comboBox1.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
        }
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            DroneView.Image = (Bitmap)eventArgs.Frame.Clone();

        }

        private void btn_Scan_Click(object sender, EventArgs e)
        {
            CapturedFrame.Image = DroneView.Image;
            string fileN = @"S:\plantimages\Plantimage.jpg";
            var bitmap = new Bitmap(CapturedFrame.Width, CapturedFrame.Height);
            CapturedFrame.DrawToBitmap(bitmap, CapturedFrame.ClientRectangle);
            System.Drawing.Imaging.ImageFormat imageformat = null;
            imageformat = System.Drawing.Imaging.ImageFormat.Jpeg;

            bitmap.Save(fileN);
        }


        //private void btn_disconnect_Click(object sender, EventArgs e)
        //{
        //    tlo.StreamOff();
        //    tlo.Disconnect();
        //}
    }
}
