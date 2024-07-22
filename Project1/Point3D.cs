using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Point3D : IComparable, ICloneable
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D() : this(0, 0, 0)
        { 
        }

        public override string ToString()
        {
            return $"Point Coordinates: ({X}, {Y}, {Z})";
        }

        public int CompareTo(object? obj)
        {
            Point3D passedPoint = (Point3D) obj;
            return this.X - passedPoint.X == 0 ? (this.Y - passedPoint.Y) : this.X - passedPoint.X;
        }

        public object Clone()
        {
            return new Point3D(X, Y, Z);
        }
    }
}
