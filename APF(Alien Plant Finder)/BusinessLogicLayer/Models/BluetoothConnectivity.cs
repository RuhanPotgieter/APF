using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APF_Alien_Plant_Finder_.BusinessLogicLayer
{
    internal class BluetoothConnectivity
    {
        private string _bluetoothName;
        private string _bluetoothAddress;
        private string _bluetoothPin;

        public string BluetoothName
        {
            get { return _bluetoothName; }
            set { _bluetoothName = value; }
        }

        public string BluetoothAddress
        {
            get { return _bluetoothAddress; }
            set { _bluetoothAddress = value; }
        }

        public string BluetoothPin
        {
            get { return _bluetoothPin; }
            set { _bluetoothPin = value; }
        }

        public BluetoothConnectivity(string bluetoothName, string bluetoothAddress, string bluetoothPin)
        {
            _bluetoothName = bluetoothName;
            _bluetoothAddress = bluetoothAddress;
            _bluetoothPin = bluetoothPin;
        }





    }
}
