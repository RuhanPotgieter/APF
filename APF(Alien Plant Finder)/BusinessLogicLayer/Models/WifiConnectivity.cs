using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APF_Alien_Plant_Finder_.BusinessLogicLayer
{
    internal class WifiConnectivity
    {
        private string _wifiName;
        private string _wifiAddress;
        private string _wifiPin;

        public string WifiName
        {
            get { return _wifiName; }
            set { _wifiName = value; }
        }

        public string WifiAddress
        {
            get { return _wifiAddress; }
            set { _wifiAddress = value; }
        }

        public string WifiPin
        {
            get { return _wifiPin; }
            set { _wifiPin = value; }
        }

        public WifiConnectivity(string wifiName, string wifiAddress, string wifiPin)
        {
            _wifiName = wifiName;
            _wifiAddress = wifiAddress;
            _wifiPin = wifiPin;
        }
    }
}
