using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using DKNET.Core;

namespace DKNET.Net.NetMessages
{
    public class ClientNetMessage
    {
        
        public ClientData ClientData;

        
        public byte[] ObjectToByteArray()
        {
            ClientData obj = ClientData;
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        
        public static ClientData ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return (ClientData)obj;
            }
        }
        
    }
}