using APF_Alien_Plant_Finder_.BusinessLogicLayer;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Reflection;
using System.Security.Policy;
using System.Windows.Forms;

namespace TelloSharp
{
    public class TelloControls
    {
        WifiConnectivity wcty = new WifiConnectivity();
        public enum FlipDirection
        {
            Forward,
            Back,
            Left,
            Right
        }
        internal static void Main(string[] args)
        {
            typeof(WifiConnectivity).GetMethod("SendToDrone", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(new WifiConnectivity(), null);
            typeof(WifiConnectivity).GetMethod("Connect", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(new WifiConnectivity(), null);
        }

        public void Alerts()
        {
            
           
        }
        public string Takeoff()
        {
            if (wcty.isFlying) return "Already Flying";
            wcty.isFlying = true;
            return wcty.SendToDrone("takeoff", true);
        }
        public string Land()
        {
            if (!wcty.isFlying) return "Already Landed";
            wcty.isFlying = false;
            return wcty.SendToDrone("land", false);
        }
        public void Emergency()
        {
            wcty.SendToDrone("emergency", false);
        }
        public string Up(int distance)
        {
            return wcty.SendToDrone("up " + distance.ToString(), true);
        }
        public string Down(int distance)
        {
            return wcty.SendToDrone("down " + distance.ToString(), true);
        }
        public string Left(int distance)
        {
            return wcty.SendToDrone("left " + distance.ToString(), true);
        }
        public string Right(int distance)
        {
            return wcty.SendToDrone("right " + distance.ToString(), true);
        }
        public string Forward(int distance)
        {
            return wcty.SendToDrone("forward " + distance.ToString(), true);
        }
        public string Back(int distance)
        {
            return wcty.SendToDrone("back " + distance.ToString(), true);
        }
        public string Clockwise(int degrees)
        {
            return wcty.SendToDrone("cw " + degrees.ToString(), true);
        }
        public string CounterClockwise(int degrees)
        {
            return wcty.SendToDrone("ccw " + degrees.ToString(), true);
        }
        public string Flip(FlipDirection direction)
        {
            string flipDir = "";
            if (direction == FlipDirection.Forward)
            {
                flipDir = "f";
            }
            else if (direction == FlipDirection.Back)
            {
                flipDir = "b";
            }
            else if (direction == FlipDirection.Left)
            {
                flipDir = "l";
            }
            else if (direction == FlipDirection.Right)
            {
                flipDir = "r";
            }
            else
            {
                flipDir = "f";
            }
            return wcty.SendToDrone("flip " + flipDir, true);
        }
        /// <summary>
        /// | x is -500 to 500 |
        /// y is -500 to 500 |
        /// z is -500 to 500 |
        /// speed is 10 to 100 |
        /// </summary>
        public string Go(int x, int y, int z, int speed)
        {
            x = Math.Clamp(x, -500, 500);
            y = Math.Clamp(y, -500, 500);
            z = Math.Clamp(z, -500, 500);
            speed = Math.Clamp(speed, 10, 100);
            return wcty.SendToDrone("go " + x.ToString() + " " + y.ToString() + " " + z.ToString() + " " + speed.ToString(), true);
        }
        public string Stop()
        {
            return wcty.SendToDrone("stop", true);
        }

        /// <summary>
        /// | x1 is -500 to 500 |
        /// y1 is -500 to 500 |
        /// z1 is -500 to 500 |
        /// x2 is -500 to 500 |
        /// y2 is -500 to 500 |
        /// z2 is -500 to 500 |
        /// speed is 10 to 100 |
        /// </summary>
        public string Curve(int x1, int y1, int z1, int x2, int y2, int z2, int speed)
        {
            x1 = Math.Clamp(x1, -500, 500);
            y1 = Math.Clamp(y1, -500, 500);
            z1 = Math.Clamp(z1, -500, 500);
            x2 = Math.Clamp(x2, -500, 500);
            y2 = Math.Clamp(y2, -500, 500);
            z2 = Math.Clamp(z2, -500, 500);
            speed = Math.Clamp(speed, 10, 60);
            return wcty.SendToDrone("curve " + x1.ToString() + " " + y1.ToString() + " " + z1.ToString() + " " + x2.ToString() + " " + y2.ToString() + " " + z2.ToString() + " " + speed.ToString(), true);
        }
        public string SetSpeed(int speed)
        {
            return wcty.SendToDrone("speed " + speed.ToString(), true);
        }

        /// <summary>
        /// | leftright is -100 to 100 |
        /// forawrdback is -100 to 100 |
        /// updown is -100 to 100 |
        /// yaw is -100 to 100 |
        /// </summary>
        public void SendRcControl(int leftright, int forwardback, int updown, int yaw)
        {
            int a = Math.Clamp(leftright, -100, 100);
            int b = Math.Clamp(forwardback, -100, 100);
            int c = Math.Clamp(updown, -100, 100);
            int d = Math.Clamp(yaw, -100, 100);
            byte[] message = Encoding.UTF8.GetBytes("rc " + a.ToString() + " " + b.ToString() + " " + c.ToString() + " " + d.ToString());
            wcty.client.Send(message);
        }
        public int GetSpeed()
        {
            string response = wcty.STDGR("speed?");
            return Int32.Parse(response);
        }
        public int GetBattery()
        {
               
            string response = wcty.STDGR("battery?");
            return Int32.Parse(response);
        }
        public string GetTime()
        {
            return wcty.STDGR("time?");
        }
        public string GetWifi()
        {
            return wcty.STDGR("wifi?");
        }
        public string GetSDK()
        {
            return wcty.STDGR("sdk?");
        }
        public string GetSerialNumber()
        {
            return wcty.STDGR("sn?");
        }
        /// <summary>
        /// | x1 is -500 to 500 |
        /// y1 is -500 to 500 |
        /// z1 is -500 to 500 |
        /// x2 is -500 to 500 |
        /// y2 is -500 to 500 |
        /// z2 is -500 to 500 |
        /// speed is 10 to 100 |
        /// missionPadId is 1 - 8 |
        /// </summary>
        public string Curve(int x1, int y1, int z1, int x2, int y2, int z2, int speed, int missionPadId)
        {
            x1 = Math.Clamp(x1, -500, 500);
            y1 = Math.Clamp(y1, -500, 500);
            z1 = Math.Clamp(z1, -500, 500);
            x2 = Math.Clamp(x2, -500, 500);
            y2 = Math.Clamp(y2, -500, 500);
            z2 = Math.Clamp(z2, -500, 500);
            speed = Math.Clamp(speed, 10, 60);
            return wcty.SendToDrone("curve " + x1.ToString() + " " + y1.ToString() + " " + z1.ToString() + " " + x2.ToString() + " " + y2.ToString() + " " + z2.ToString() + " " + speed.ToString() + " " + missionPadId.ToString(), true);
        }

        /// <summary>
        /// | x is -500 to 500 |
        /// y is -500 to 500 |
        /// z is -500 to 500 |
        /// speed is 10 to 100 |
        /// missionPadId is 1 - 8 |
        /// </summary>
        public string Go(int x, int y, int z, int speed, int missionPadId)
        {
            x = Math.Clamp(x, -500, 500);
            y = Math.Clamp(y, -500, 500);
            z = Math.Clamp(z, -500, 500);
            speed = Math.Clamp(speed, 10, 100);
            return wcty.SendToDrone("go " + x.ToString() + " " + y.ToString() + " " + z.ToString() + " " + speed.ToString() + " " + missionPadId.ToString(), true);
        }

        /// <summary>
        /// | x is -500 to 500 |
        /// y is -500 to 500 |
        /// z is -500 to 500 |
        /// speed is 10 to 100 |
        /// yaw is rotation degrees |
        /// missionPadId is 1 - 8 |
        /// </summary>
        public string Jump(int x, int y, int z, int speed, int yaw, int missionPadId1, int missionPadId2)
        {
            x = Math.Clamp(x, -500, 500);
            y = Math.Clamp(y, -500, 500);
            z = Math.Clamp(z, -500, 500);
            speed = Math.Clamp(speed, 10, 100);
            missionPadId1 = Math.Clamp(missionPadId1, 1, 8);
            missionPadId2 = Math.Clamp(missionPadId2, 1, 8);
            return wcty.SendToDrone("jump " + " " + x.ToString() + " " + y.ToString() + " " + z.ToString() + " " + speed.ToString() + " " + yaw.ToString() + " " + missionPadId1.ToString() + " " + missionPadId2.ToString(), true);
        }
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

        public TelloControls() { }
    }



}
