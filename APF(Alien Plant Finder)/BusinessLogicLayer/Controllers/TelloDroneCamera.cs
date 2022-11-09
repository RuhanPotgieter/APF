using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AForge.Video;
using APF_Alien_Plant_Finder_.PresentationLayer;

namespace APF_Alien_Plant_Finder_.BusinessLogicLayer
{
    internal class TelloDroneCamera
    {
        WifiConnectivity wcty = new WifiConnectivity();
        public string StreamOn()
        {
            wcty.videoServer = new UdpClient(wcty.vsPort);
            wcty.streaming = true;
            return wcty.SendToDrone("streamon", true);
        }
        public string StreamOff()
        {
            wcty.streaming = false;
            wcty.videoServer.Close();
            return wcty.SendToDrone("streamoff", true);
        }
        public byte[] GetVideoImage()
        {
            if (!wcty.streaming) return null;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("0.0.0.0"), wcty.vsPort);
            return wcty.videoServer.Receive(ref ep);
        }

        //MJPEGStream streamvideo;


        //public void Cameradisplay()
        //{
        //    //ip camera linking    
        //    streamvideo = new MJPEGStream("http://77.89.48.19:8000/cgi-bin/viewer/video.jpg?r=1667648901");
        //    streamvideo.NewFrame += GetNewFram;
        //}


        //private void GetNewFram(object sender, NewFrameEventArgs eventArgs)
        //{
        //    DroneControlScreen dcs = new DroneControlScreen();
        //    Bitmap bm = (Bitmap)eventArgs.Frame.Clone();
        //    dcs.DroneView.Image = bm;

        //}

        //public void StartCamera()
        //{
        //    streamvideo.Start();
        //}

        //public void StopCamera()
        //{
        //    streamvideo.Stop();
        //}

    }
}
