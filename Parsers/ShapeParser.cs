using ShapeInterview.Shapes;

namespace ShapeInterview.Parsers
{
    public class ShapeParser
    {
        public static Shape? ParseString(string line)
        {
            if (string.IsNullOrEmpty(line))
                return null;

            string[] values = line.Split(',');

            return values[1] switch
            {
                "Circle" => ParseCircle(values),
                "Ellipse" => ParseEllipse(values),
                "Equilateral Triangle" => ParseEquilateralTriangle(values),
                "Polygon" => ParsePolygon(values),
                "Square" => ParseSquare(values),
                _ => null,
            };
        }

        private static Circle? ParseCircle(string[] values)
        {
            if (values == null || !values.Any() || values.Length != 8)
                return null;

            var valueLabels = (values[2], values[4], values[6]);
            var correctValueLabels = ("CenterX", "CenterY", "Radius");

            if (valueLabels != correctValueLabels)
                return null;

            if (!int.TryParse(values[0], out int id))
                return null;

            if (!double.TryParse(values[3], out double centerX))
                return null;

            if (!double.TryParse(values[5], out double centerY))
                return null;

            if (!double.TryParse(values[7], out double radius))
                return null;

            return new Circle(id, centerX, centerY, radius);
        }

        private static Ellipse? ParseEllipse(string[] values)
        {
            if (values == null || !values.Any() || values.Length != 12)
                return null;

            var valueLabels = (values[2], values[4], values[6], values[8], values[10]);
            var correctValueLabels = ("CenterX", "CenterY", "R1", "R2", "Orientation");

            if (valueLabels != correctValueLabels)
                return null;

            if (!int.TryParse(values[0], out int id))
                return null;

            if (!double.TryParse(values[3], out double centerX))
                return null;

            if (!double.TryParse(values[5], out double centerY))
                return null;

            if (!double.TryParse(values[7], out double r1))
                return null;

            if (!double.TryParse(values[9], out double r2))
                return null;

            if (!double.TryParse(values[11], out double orient))
                return null;

            return new Ellipse(id, centerX, centerY, r1, r2, orient);
        }

        private static EquilateralTriangle? ParseEquilateralTriangle(string[] values)
        {
            var regVals = ParseRegularPolygonValues(values);

            if (regVals == null)
                return null;

            (int id, double centerX, double centerY, double sideLength, double orient) = regVals.Value;

            return new EquilateralTriangle(id, centerX, centerY, sideLength, orient);
        }

        private static Polygon? ParsePolygon(string[] values)
        {
            List<Point> points = new();

            if (values == null || !values.Any() || values.Length < 6)
                return null;

            if (!int.TryParse(values[0], out int id))
                return null;

            int pdx = 0;
            for (int i = 2; i < values.Length; i += 4)
            {
                var valueLabels = (values[i], values[i + 2]);
                var correctValueLabels = ($"X{pdx}", $"Y{pdx}");

                if (valueLabels != correctValueLabels)
                    return null;

                if (!double.TryParse(values[i + 1], out double pointX))
                    return null;

                if (!double.TryParse(values[i + 3], out double pointY))
                    return null;

                points.Add(new Point(pointX, pointY));
                ++pdx;
            }

            return new Polygon(id, points);
        }

        private static Square? ParseSquare(string[] values)
        {
            var regVals = ParseRegularPolygonValues(values);

            if (regVals == null)
                return null;

            (int id, double centerX, double centerY, double sideLength, double orient) = regVals.Value;

            return new Square(id, centerX, centerY, sideLength, orient);
        }

        private static (int, double, double, double, double)? ParseRegularPolygonValues(string[] values)
        {
            if (values == null || !values.Any() || values.Length != 10)
                return null;

            var valueLabels = (values[2], values[4], values[6], values[8]);
            var correctValueLabels = ("CenterX", "CenterY", "SideLength", "Orientation");

            if (valueLabels != correctValueLabels)
                return null;

            if (!int.TryParse(values[0], out int id))
                return null;

            if (!double.TryParse(values[3], out double centerX))
                return null;

            if (!double.TryParse(values[5], out double centerY))
                return null;

            if (!double.TryParse(values[7], out double sideLength))
                return null;

            if (!double.TryParse(values[9], out double orient))
                return null;

            return (id, centerX, centerY, sideLength, orient);
        }
    }
}
