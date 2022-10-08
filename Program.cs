// See https://aka.ms/new-console-template for more information
using ShapeInterview.Parsers;
using ShapeInterview.Shapes;
using System.Text;

string inputfile = @"C:\Users\Robert\Documents\ShapeInterview\Shapes-49464.txt";
string outputfile = @"C:\Users\Robert\Documents\ShapeInterview\calculations.csv";
string[] input = File.ReadAllLines(inputfile);

if (!File.Exists(inputfile))
{
    Console.WriteLine("No file exists with that name.");
    return;
}

if (input == null || !input.Any())
{
    Console.WriteLine("No data in given file.");
    return;
}


ShapeParser parser = new ShapeParser();
List<Shape> shapes = input.Select(x => parser.ParseString(x) ?? new Polygon(-1, new List<Point>())).ToList();

if (shapes == null || !shapes.Any())
{
    Console.WriteLine("No shapes generated.");
    return;
}

List<string> outputs = new();

outputs.Add("Id,Area,Perimeter,CentroidX,CentroidY");
outputs.AddRange(shapes.Select(shape => $"{shape.ID},{shape.Area()},{shape.Perimeter()},{shape.Center?.X ?? 0},{shape.Center?.Y ?? 0}"));

if (File.Exists(outputfile))
    File.Delete(outputfile);

File.WriteAllLines(outputfile, outputs);

Console.WriteLine("Calculations done.");
