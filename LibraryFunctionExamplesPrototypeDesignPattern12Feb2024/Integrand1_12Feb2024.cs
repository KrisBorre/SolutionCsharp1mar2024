using LibraryIntegrationPrototypeDesignPattern12Feb2024;

namespace LibraryFunctionExamplesPrototypeDesignPattern12Feb2024
{
    public class Integrand1_12Feb2024 : IntegrandAbstractClass12Feb2024
    {
        private double p;
        // https://www.whitman.edu/mathematics/calculus_late_online/section10.05.html
        // Integraal oplossing is 0.6438 ... als p = 0.5 en integraal is van 0 tot 1

        public Integrand1_12Feb2024(double power = 0.5)
        {
            p = power;
        }

        public override IntegrandAbstractClass12Feb2024 Clone()
        {
            Integrand1_12Feb2024 clone = new Integrand1_12Feb2024(this.p);
            return clone;
        }

        public override double Function(double x)
        {
            return x * Math.Pow(1 + x, p);
        }

        public override string ToString()
        {
            return $"x * Math.Pow(1+x,{p:F1})";
        }
    }
}
