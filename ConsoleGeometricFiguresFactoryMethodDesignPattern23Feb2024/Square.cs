namespace ConsoleGeometricFiguresFactoryMethodDesignPattern23Feb2024
{
    internal class Square : Rectangle
    {
        public Square(int length, int width)
        {
            if (length != width)
            {
                width = length;
            }
            Height = length;
            Width = width;
        }

        public Square(int length) : this(length, length)
        {
        }
    }
}
