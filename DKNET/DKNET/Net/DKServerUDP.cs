using System;
using System.Net;
using System.Net.Sockets;
using DKNET.Core;
using DKNET.DKNumerics;

namespace DKNET.Net
{
    /// <summary>
    /// A server used for player positioning.
    /// </summary>
    public class DKServerUDP
    {
        private DKServerCore _core = new DKServerCore();
        private UdpClient UDPServerListener;
        private IPAddress _address = IPAddress.Loopback;
        private IPEndPoint _endPoint;
        
        private string _ipAddressString = "127.0.0.1";


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

        public DKServerUDP(string ipAddress, uint port)
        {
            Address = ipAddress;
            Port = port;
            _endPoint = new IPEndPoint(_address, (int)Port);
            Console.WriteLine("UDP Server is setting up to " + ipAddress + ":" + (int)port);
        }

        public void StartServerListen()
        {
            Console.WriteLine("Starting UDP Server");
            UDPServerListener = new UdpClient((int)Port);
            try
            {
                Console.WriteLine("Listening for broadcast...");
                byte[] bytes = UDPServerListener.Receive(ref _endPoint);
                Console.WriteLine("Broadcast Received...");
                var clientData = ClientData.ByteArrayToObject(bytes);
                Console.WriteLine("ID: " + clientData.ID + "username: " + clientData.UserName + 
                                  "Position: (" + clientData.position.X  + ", " + clientData.position.Y + ", " + clientData.position.Z + ")");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                UDPServerListener.Close();
            }
        }
    }
}