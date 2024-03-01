using LibraryIntegrationPrototypeDesignPattern12Feb2024;

namespace LibraryFunctionExamplesPrototypeDesignPattern12Feb2024
{
    public class Sinus12Feb2024 : IntegrandAbstractClass12Feb2024
    {
        public override IntegrandAbstractClass12Feb2024 Clone()
        {
            return new Sinus12Feb2024();
        }

        public override double Function(double x)
        {
            return Math.Sin(x);
        }

        public override string ToString()
        {
            return "sin(x)";
        }
    }
}
