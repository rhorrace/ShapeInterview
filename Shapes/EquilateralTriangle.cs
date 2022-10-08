namespace ShapeInterview.Shapes
{
    public class EquilateralTriangle : Shape, IShape
    {
        private readonly double sideLength;
        private readonly double orientation;
        
        public EquilateralTriangle(int id, double centerX, double centerY, double sideLength, double orientation)
            : base(id, centerX, centerY)
        {
            this.sideLength = sideLength;
            this.orientation = orientation;
        }

        // Area of Equilateral Triangle: A = sqrt(3) * s^2 / 4
        public override double Area() => Math.Sqrt(3) * Math.Pow(sideLength, 2) / 4; 

        // Perimeter of Equilateral triangle: P = 3 * s
        public override double Perimeter() => 3 * sideLength;
    }
}
