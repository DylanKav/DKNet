using System.Net;
using System.Net.Sockets;
using DKNET.Core;

namespace DKNET.Net
{
    public class DKClientUDP
    {
        private Socket socketToServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private IPAddress _address;
        private string _ipAddressString = "127.0.0.1";
        private IPEndPoint _endPoint;
        public uint Port { get; set; }
        public string Address
        {
            get => _ipAddressString;
            set
            {
                _ipAddressString = value;
                _address = System.Net.IPAddress.Parse(value);
            }
        }
        
        public DKClientUDP(string ipAddress, uint port)
        {
            Address = ipAddress;
            Port = port;
            _endPoint = new IPEndPoint(_address, (int)Port);
        }

        public void SendClientData(ClientData data)
        {
            var msg = ClientData.ObjectToByteArray(data);
            socketToServer.SendTo(msg, _endPoint);
        }
        
    }
}