using System;

namespace _3DTransform
{
    public class Vector4
    {
        public double x, y, z, w;

        public Vector4()
        {
        }

        public Vector4(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public Vector4(Vector4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }

        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }

        public Vector4 Cross(Vector4 v)
        {
            return new Vector4(this.y * v.z - this.z * v.y, this.z * v.x - this.x * v.z, this.x * v.y - this.y * v.x, 0);
        }

        public double Dot(Vector4 v)
        {
            return (this.x * v.x + this.y * v.y + this.z * v.z);
        }

        public Vector4 Normailized
        {
            get
            {
                double Mod = Math.Sqrt(x * x + y * y + z * z + w * w);
                return new Vector4(x / Mod, y / Mod, z / Mod, w / Mod);
            }
        }
    }
}