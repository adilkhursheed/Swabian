using System;

namespace GraphSystem.Models
{
    public class Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Coordinate(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
