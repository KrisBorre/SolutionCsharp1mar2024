using LibraryPhysicalUnits13feb2024;

namespace ConsoleGeometricFiguresFactoryMethodDesignPattern23Feb2024
{
    internal class CircleFactory : GeometricFigureFactory
    {
        public override GeometricFigure Create()
        {
            return new Circle(new LengthInMeter14feb2024(2, 0));
        }
    }
}
