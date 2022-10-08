namespace ShapeInterview.Shapes
{
    public class Circle : Shape, IShape
    {
        private readonly double radius;

        public Circle(int id, double centerX, double centerY, double radius)
            : base(id, centerX, centerY)
        {
            this.radius = radius;
        }

        // Calculates Area of Circle: A = pi * r^2
        public override double Area() => Math.PI * Math.Pow(radius, 2);

        // Calculates Perimeter of circle: P = 2 * pi * r  
        public override double Perimeter() => 2 * Math.PI * radius;
    }
}
