using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DKNET.DKNumerics;

namespace DKNET.Core
{
    [Serializable]
    public struct ClientData
    {
        public uint ID;
        public string UserName;
        public Vec3 position;
        
        public static byte[] ObjectToByteArray(ClientData obj)
        {
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