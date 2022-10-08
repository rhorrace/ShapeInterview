namespace ShapeInterview.Shapes
{
    public abstract class Shape: IShape
    {
        public Shape(int id)
        {
            ID = id;
        }

        public Shape(int id, double centerX, double centerY) : this(id)
        {
            Center = new Point(centerX, centerY);
        }

        public virtual int ID { get; } = 0;
        public virtual Point? Center { get; } = null;

        public virtual double Area() => 0;

        public virtual double Perimeter() => 0;
    }
}
