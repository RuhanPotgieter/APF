using APF_Alien_Plant_Finder_.BusinessLogicLayer;
using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;


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
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }
        
        public string Go(int x, int y, int z, int speed)
        {
            
            x = Clamp(x,-500, 500);
            y = Clamp(y, -500, 500);
            z = Clamp(z, -500, 500);
            speed = Clamp(speed, 10, 100);
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
            x1 = Clamp(x1, -500, 500);
            y1 = Clamp(y1, -500, 500);
            z1 = Clamp(z1, -500, 500);
            x2 = Clamp(x2, -500, 500);
            y2 = Clamp(y2, -500, 500);
            z2 = Clamp(z2, -500, 500);
            speed = Clamp(speed, 10, 60);
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
            int a = Clamp(leftright, -100, 100);
            int b = Clamp(forwardback, -100, 100);
            int c = Clamp(updown, -100, 100);
            int d = Clamp(yaw, -100, 100);
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
            x1 = Clamp(x1, -500, 500);
            y1 = Clamp(y1, -500, 500);
            z1 = Clamp(z1, -500, 500);
            x2 = Clamp(x2, -500, 500);
            y2 = Clamp(y2, -500, 500);
            z2 = Clamp(z2, -500, 500);
            speed = Clamp(speed, 10, 60);
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
            x = Clamp(x, -500, 500);
            y = Clamp(y, -500, 500);
            z = Clamp(z, -500, 500);
            speed = Clamp(speed, 10, 100);
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
            x = Clamp(x, -500, 500);
            y = Clamp(y, -500, 500);
            z = Clamp(z, -500, 500);
            speed = Clamp(speed, 10, 100);
            missionPadId1 = Clamp(missionPadId1, 1, 8);
            missionPadId2 = Clamp(missionPadId2, 1, 8);
            return wcty.SendToDrone("jump " + " " + x.ToString() + " " + y.ToString() + " " + z.ToString() + " " + speed.ToString() + " " + yaw.ToString() + " " + missionPadId1.ToString() + " " + missionPadId2.ToString(), true);
        }
        
        public TelloControls() { }
    }



}
