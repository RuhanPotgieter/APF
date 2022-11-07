using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video;
using APF_Alien_Plant_Finder_.PresentationLayer;

namespace APF_Alien_Plant_Finder_.BusinessLogicLayer
{
    internal class TelloDroneCamera
    {
        MJPEGStream streamvideo;
        
        
        public void Cameradisplay()
        {
            //ip camera linking    
            streamvideo = new MJPEGStream("http://77.89.48.19:8000/cgi-bin/viewer/video.jpg?r=1667648901");
            streamvideo.NewFrame += GetNewFram;
        }


        private void GetNewFram(object sender, NewFrameEventArgs eventArgs)
        {
            DroneControlScreen dcs = new DroneControlScreen();
            Bitmap bm = (Bitmap)eventArgs.Frame.Clone();
            dcs.DroneView.Image = bm;
            
        }

        public void StartCamera()
        {
            streamvideo.Start();
        }

        public void StopCamera()
        {
            streamvideo.Stop();
        }

    }
}
