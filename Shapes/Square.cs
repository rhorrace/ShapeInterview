using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterview.Shapes
{
    public class Square: Shape, IShape
    {
        private readonly double sideLength;
        private readonly double orientation;

        public Square(int id, double centerX, double centerY, double sideLength, double orientation)
            : base(id, centerX, centerY)
        {
            this.sideLength = sideLength;
            this.orientation = orientation;
        }

        // Area of a Square: A = s^2
        public override double Area() => Math.Pow(sideLength, 2);

        // Perimeter of a Square: P = 4 * s
        public override double Perimeter() => 4 * sideLength;

    }
}
