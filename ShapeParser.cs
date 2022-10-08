using ShapeInterview.Shapes;

namespace ShapeInterview.Parsers
{
    public class ShapeParser
    {
        public ShapeParser() { }

        public Shape? ParseString(string line)
        {
            Shape? shape = null;

            if (line == null)
                return null;

            string[] values = line.Split(',');

            if (values == null || !values.Any() || values.Length < 8)
                return null;

            switch (values[1])
            {
                case "Circle":
                    return ParseCircle(values);
                case "Ellipse":
                    return ParseEllipse(values);
                case "Equilateral Triangle":
                    return ParseEquilateralTriangle(values);
                case "Polygon":
                    return ParsePolygon(values);
                case "Square":
                    return ParseSquare(values);
                default:
                    return null;
            }
        }

        private static Circle? ParseCircle(string[] values)
        {
            if (values == null || !values.Any() || values.Length != 8)
                return null;

            if (!int.TryParse(values[0], out int id))
                return null;

            if (values[2] != "CenterX")
                return null;

            if (!double.TryParse(values[3], out double centerX))
                return null;

            if (values[4] != "CenterY")
                return null;

            if (!double.TryParse(values[5], out double centerY))
                return null;

            if (values[6] != "Radius")
                return null;

            if (!double.TryParse(values[7], out double radius))
                return null;

            return new Circle(id, centerX, centerY, radius);
        }

        private static Ellipse? ParseEllipse(string[] values)
        {
            if (values == null || !values.Any() || values.Length != 12)
                return null;

            if (!int.TryParse(values[0], out int id))
                return null;

            if (values[2] != "CenterX")
                return null;

            if (!double.TryParse(values[3], out double centerX))
                return null;

            if (values[4] != "CenterY")
                return null;

            if (!double.TryParse(values[5], out double centerY))
                return null;

            if (values[6] != "R1")
                return null;

            if (!double.TryParse(values[7], out double r1))
                return null;

            if (values[8] != "R2")
                return null;

            if (!double.TryParse(values[9], out double r2))
                return null;

            if (values[10] != "Orientation")
                return null;

            if (!double.TryParse(values[11], out double orient))
                return null;

            return new Ellipse(id, centerX, centerY, r1, r2, orient);
        }

        private static EquilateralTriangle? ParseEquilateralTriangle(string[] values)
        {
            if (values == null || !values.Any() || values.Length != 10)
                return null;

            if (!int.TryParse(values[0], out int id))
                return null;

            if (values[2] != "CenterX")
                return null;

            if (!double.TryParse(values[3], out double centerX))
                return null;

            if (values[4] != "CenterY")
                return null;

            if (!double.TryParse(values[5], out double centerY))
                return null;

            if (values[6] != "SideLength")
                return null;

            if (!double.TryParse(values[7], out double sideLength))
                return null;

            if (values[8] != "Orientation")
                return null;

            if (!double.TryParse(values[9], out double orient))
                return null;

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
            for(int i = 2;i < values.Length ;i += 4)
            {
                if (values[i] != $"X{pdx}")
                    return null;

                if (!double.TryParse(values[i + 1], out double pointX))
                    return null;

                if (values[i + 2] != $"Y{pdx}")
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
            if (values == null || !values.Any() || values.Length != 10)
                return null;

            if (!int.TryParse(values[0], out int id))
                return null;

            if (values[2] != "CenterX")
                return null;

            if (!double.TryParse(values[3], out double centerX))
                return null;

            if (values[4] != "CenterY")
                return null;

            if (!double.TryParse(values[5], out double centerY))
                return null;

            if (values[6] != "SideLength")
                return null;

            if (!double.TryParse(values[7], out double sideLength))
                return null;

            if (values[8] != "Orientation")
                return null;

            if (!double.TryParse(values[9], out double orient))
                return null;

            return new Square(id, centerX, centerY, sideLength, orient);
        }
    }
}
