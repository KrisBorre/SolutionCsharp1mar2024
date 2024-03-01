namespace ConsoleGeometricFiguresFactoryMethodDesignPattern23Feb2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Factory Method Design Pattern!");

            GeometricFigureFactory triangleFactory = new TriangleFactory();
            GeometricFigure triangle = triangleFactory.Create();

            triangle.Width = 2; triangle.Height = 2;
            Console.WriteLine(triangle.Surface);

            GeometricFigureFactory rectangleFactory = new RectangleFactory();
            GeometricFigure rectangle = rectangleFactory.Create();
            rectangle.Width = 2; rectangle.Height = 3;
            Console.WriteLine(rectangle.Surface);

            GeometricFigureFactory squareFactory = new SquareFactory();
            GeometricFigure square = squareFactory.Create();
            Console.WriteLine(square.Surface);

            GeometricFigureFactory circleFactory = new CircleFactory();
            GeometricFigure circle = circleFactory.Create();
            Console.WriteLine(circle.Surface);

            Console.ReadLine();
        }


    }
}

