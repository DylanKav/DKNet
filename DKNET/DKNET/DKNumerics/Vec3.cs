using System;

namespace DKNET.DKNumerics
{
    [Serializable]
    public class Vec3
    {
        public float X, Y, Z;

        public Vec3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float Distance(Vec3 a, Vec3 b)
        {
            var difX = a.X - b.X;
            var difY = a.Y - b.Y;
            var difZ = a.Z - b.Z;
            return (float)Math.Sqrt(Math.Pow(difX, 2) + Math.Pow(difY, 2) + Math.Pow(difZ, 2));
        }

        public byte[] ToBytes()
        {
            var floatArray1 = new float[] {X, Y, Z};
            //4 bytes to a float.
            var byteArray = new byte[floatArray1.Length * 4];
            Buffer.BlockCopy(floatArray1, 0, byteArray, 0, byteArray.Length);
            return byteArray;
        }

        public void SetValuesFromBytes(byte[] byteArray)
        {
            var floatArray = new float[byteArray.Length / 4];
            Buffer.BlockCopy(byteArray, 0, floatArray, 0, byteArray.Length);
            X = floatArray[0];
            Y = floatArray[1];
            Z = floatArray[2];
        }
    }
}