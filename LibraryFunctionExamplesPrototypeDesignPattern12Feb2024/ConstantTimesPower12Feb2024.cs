using LibraryIntegrationPrototypeDesignPattern12Feb2024;

namespace LibraryFunctionExamplesPrototypeDesignPattern12Feb2024
{
    public class ConstantTimesPower12Feb2024 : IntegrandAbstractClass12Feb2024
    {
        private double c, p;

        public double Constant
        {
            get { return this.c; }
            set
            {
                this.c = value;
            }
        }

        public double Power
        {
            get { return this.p; }
            set
            {
                this.p = value;
            }
        }

        public ConstantTimesPower12Feb2024(double constant = 4.0, double power = 0.5)
        {
            this.c = constant;
            this.p = power;
        }

        public override IntegrandAbstractClass12Feb2024 Clone()
        {
            ConstantTimesPower12Feb2024 clone = new ConstantTimesPower12Feb2024(this.c, this.p);
            return clone;
        }

        public override double Function(double x)
        {
            return c * Math.Pow(x, p);
        }

        public override string ToString()
        {
            return $"{c} x^{p:F2}";
        }
    }
}
