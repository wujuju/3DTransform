using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DTransform
{
    class Triangle3D
    {
        bool cullBack;
        double dot;
        public Vector4 A, B, C;
        public Vector4 a, b, c;
        public Triangle3D() { }
        public Triangle3D(Vector4 a, Vector4 b, Vector4 c)
        {
            this.A = this.a = new Vector4(a);
            this.B = this.b = new Vector4(b);
            this.C = this.c = new Vector4(c);
        }

        public void Transform(Matrix4x4 m)
        {
            this.a = m.Mul(this.A);
            this.b = m.Mul(this.B);
            this.c = m.Mul(this.C);
        }

        public void Draw(Graphics g, bool showLine)
        {
            if (showLine)
                g.DrawLines(new Pen(Color.Red, 2), Get2DPointFArr());
            if (!cullBack)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddLines(this.Get2DPointFArr());
                int r = (int)(200 * dot) + 55;
                Color color = Color.FromArgb(r, r, r);
                Brush br = new SolidBrush(color);
                g.FillPath(br, path);
            }
        }

        PointF[] Get2DPointFArr()
        {
            PointF[] arr = new PointF[4];
            arr[0] = Get2DPointF(this.a);
            arr[1] = Get2DPointF(this.b);
            arr[2] = Get2DPointF(this.c);
            arr[3] = Get2DPointF(this.a);
            return arr;
        }

        PointF Get2DPointF(Vector4 v)
        {
            PointF p = new PointF();
            p.X = (float)(v.x / v.w);
            p.Y = -(float)(v.y / v.w);
            return p;
        }

        //public void CalculateNormal()
        //{
        //    Vector4 U = this.a - this.b;
        //    Vector4 V = this.c - this.a;
        //    normal = U.Cross(V);
        //}

        public void CalculateLighting(Matrix4x4 obj2World, Vector4 L)
        {
            this.Transform(obj2World);
            Vector4 U = this.b - this.a;
            Vector4 V = this.c - this.a;
            Vector4 normal = U.Cross(V);
            dot = normal.Normailized.Dot(L.Normailized);
            dot = Math.Max(0, dot);

            Vector4 E = new Vector4(0, 0, -1, 0);
            cullBack = normal.Normailized.Dot(E) < 0 ? true : false;
        }
    }
}
