using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using APF_Alien_Plant_Finder_.BusinessLogicLayer;
using APF_Alien_Plant_Finder_.PresentationLayer;

using System.Net;


namespace APF_Alien_Plant_Finder_.BusinessLogicLayer
{
    internal class WifiConnectivity
    {
        public int vsPort = 11111;
        public bool streaming = false;
        
        public UdpClient client = new UdpClient();
        public UdpClient videoServer = new UdpClient();
        public bool isFlying = false;
        public int defTimeout = 5000;
        public bool printResults = true;
        public string SendToDrone(string message, bool printresults)
        {
           // client.Send(Encoding.UTF8.GetBytes(message));
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 8889);
            byte[] receivedResults = client.Receive(ref remoteEndPoint);
            string data = Encoding.UTF8.GetString(receivedResults);
            if (printResults && printresults) { Console.WriteLine(data); }
            return data;
        }
        public string STDGR(string message)
        {
           // client.Send(Encoding.UTF8.GetBytes(message));
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 8889);
            byte[] receivedResults = client.Receive(ref remoteEndPoint);
            string data = Encoding.UTF8.GetString(receivedResults);
            return data;
        }
        public string SendCommand(string message, bool printResults)
        {
            return SendToDrone(message, printResults);
        }
        public string Connect()
        {
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, defTimeout);
            client.Connect("192.168.10.1", 8889);
            return SendToDrone("command", false);
        }
        public void End()
        {
            client.Close();
            videoServer.Close();
            streaming = false;
            isFlying = false;
        }


    }
}
