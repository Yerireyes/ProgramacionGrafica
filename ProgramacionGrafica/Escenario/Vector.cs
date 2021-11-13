using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace ConsoleApp5
{
    class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector(float X, float Y, float Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public void Set(Vector nuevoVector)
        {
            X = nuevoVector.X;
            Y = nuevoVector.Y;
            Z = nuevoVector.Z;
        }

        public static Vector operator *(Vector a, Matrix3 b) => new Vector(
            a.X * b.M11 + a.Y * b.M12 + a.Z * b.M13,
            a.X * b.M21 + a.Y * b.M22 + a.Z * b.M23,
            a.X * b.M31 + a.Y * b.M32 + a.Z * b.M33);

        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }
}
