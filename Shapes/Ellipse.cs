namespace ShapeInterview.Shapes
{
    public class Ellipse: Shape, IShape 
    {
        private readonly double r1;
        private readonly double r2;
        private readonly double orientation;

        public Ellipse(int id, double centerX, double centerY, double r1, double r2, double orientation)
            : base(id, centerX, centerY)
        {
            this.r1 = r1;
            this.r2 = r2;
            this.orientation = orientation;
        }
        public override double Area() => Math.PI * r1 * r2;

        // Warning: Approximation, exact requires an infinite series
        public override double Perimeter() => PerimeterHelper();

        // Based off of one of Ramunajan's approximation formulas
        private double PerimeterHelper()
        {
            double a = Math.Max(r1, r2);
            double b = Math.Min(r1, r2);
            double h = Math.Pow((a - b) / (a + b), 2);

            double p = Math.PI * (a + b);
            p *= 1 + (3 * h / (10 + Math.Sqrt(4 - 3 * h)));

            return p;
        }
    }
}
