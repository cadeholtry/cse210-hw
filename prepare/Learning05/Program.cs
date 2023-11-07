using System;
using System.Collections.ObjectModel;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("teal", 3));
        shapes.Add(new Rectangle("turqoise", 4, 5));
        shapes.Add(new Circle("voilet", 3));
        foreach (Shape shape in shapes) {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"The {color} shape has an area of {area}");
        }
    }
}