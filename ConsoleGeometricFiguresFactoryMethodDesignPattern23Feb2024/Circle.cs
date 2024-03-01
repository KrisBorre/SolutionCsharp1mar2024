using LibraryPhysicalUnits13feb2024;

namespace ConsoleGeometricFiguresFactoryMethodDesignPattern23Feb2024
{
    internal class Circle : GeometricFigure
    {
        private LengthInMeter14feb2024 diameter;

        public LengthInMeter14feb2024 Diameter
        {
            get { return diameter; }
            set { diameter = value; }
        }

        public Circle(LengthInMeter14feb2024 diameter)
        {
            this.diameter = diameter;
        }

        protected override int CalculateSurface()
        {
            return (int)this.CalculateArea().GetInSquareMeter();
        }

        public LengthInMeter14feb2024 CalculateRadius()
        {
            return diameter / 2;
        }

        // https://en.wikipedia.org/wiki/Circumference
        public LengthInMeter14feb2024 CalculateCircumference()
        {
            return 2 * Math.PI * this.CalculateRadius();
        }

        // https://en.wikipedia.org/wiki/Circle
        public AreaInSquareMeter CalculateArea()
        {
            return Math.PI * this.Square(this.CalculateRadius());
        }

        private AreaInSquareMeter Square(LengthInMeter14feb2024 x)
        {
            return x * x;
        }
    }
}
