namespace ShapeInterview.Shapes
{
    public class Polygon : Shape, IShape
    {
        private readonly List<Point> points;

        public Polygon(int id, List<Point> points) : base(id)
        {
            this.points = points;
        }

        public override Point? Center {
            get => CalculateCentroid();
        }

        // Area of a Polygon: Based off the shoelace formula
        public override double Area()
        {
            double area = 0;
            int count = points.Count;

            if (count < 3)
                return 0;

            for (int i = 0; i < count; ++i)
            {
                Point p1 = points[i % count];
                Point p2 = points[(i + 1) % count];
                area += (p1.X * p2.Y) - (p1.Y * p2.X); 
            }

            return Math.Abs(area / 2);
        }

        // Perimeter of a Polygon: sum of Euclidean distances between piars of ordered points
        public override double Perimeter()
        {
            double perimeter = 0;
            int count = points.Count;

            if (count < 3)
                return 0;

            for (int i = 0; i < count; ++i)
            {
                Point p1 = points[i % count];
                Point p2 = points[(i + 1) % count];
                double distance = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
                perimeter += distance;
            }

            return perimeter;
        }

        private Point? CalculateCentroid()
        {
            if (!points.Any())
                return null;

            double centroidX = points.Select(p => p.X).Average();
            double centroidY = points.Select(p => p.Y).Average();

            return new Point(centroidX, centroidY);
        }
    }
}
