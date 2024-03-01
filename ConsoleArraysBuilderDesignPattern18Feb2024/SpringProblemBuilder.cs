using LibraryIntegrationWork14Feb2024;
using LibraryPhysicalUnits13feb2024;
using System.Text;

namespace ConsoleArraysBuilderDesignPattern18Feb2024
{
    internal class SpringProblemBuilder : IBuilder
    {
        private Problem problem;

        private NumericalIntegrator14Feb2024 integrator;
        private IntegrandAbstractClass14Feb2024 integrand;
        private LengthInMeter14feb2024 a;
        private LengthInMeter14feb2024 b;
        private Method14Feb2024 method;

        public SpringProblemBuilder(double stretchInMeter = 0.5, double accuracyOfStretchInMeter = 0.1, double spring = 50.0)
        {
            this.b = new LengthInMeter14feb2024(stretchInMeter, accuracyOfStretchInMeter);
            this.integrand = new ForceLinearOscillator(spring);
            this.method = Method14Feb2024.Trapezoidal;
        }

        public SpringProblemBuilder(LengthInMeter14feb2024 length)
        {
            this.b = length;
            this.method = Method14Feb2024.Trapezoidal;
        }

        public SpringProblemBuilder(LengthInCentimeter14feb2024 length, Method14Feb2024 method = Method14Feb2024.Midpoint)
        {
            this.b = length.ConvertToMeter();
            this.method = method;
        }

        public SpringProblemBuilder(Method14Feb2024 method)
        {
            this.method = method;
        }

        public SpringProblemBuilder(bool isLinear)
        {
            if (!isLinear) this.integrand = new ForceNonLinearOscillator();
        }

        public void AddQuantities()
        {
            if (this.a == null) this.a = new LengthInMeter14feb2024(0.0, 0);
            if (this.b == null) this.b = new LengthInMeter14feb2024(0.5, 0);
        }

        public void AddAlgorithms()
        {
            if (this.integrand == null) this.integrand = new ForceLinearOscillator();
            this.integrator = new NumericalIntegrator14Feb2024(this.integrand, this.a, this.b, this.method);
        }

        public void AddProblem()
        {
            StringBuilder s = new StringBuilder();
            s.Append("The work required to compress a spring.\n");
            s.Append("According to Hooke’s Law, the force exerted by a spring is directly proportional to the displacement of the spring from its equilibrium position.\n");
            s.Append($"So, suppose the force to compress the spring follows Hooke's law: {this.integrand.ToString()}\n");
            s.Append($"How much work is done to stretch the spring {b} from the equilibrium position?\n");

            const int MAX = 8;

            WorkInJoule work = new WorkInJoule(0);
            for (int j = 1; j <= MAX; j++)
            {
                work = integrator.Next();
            }
            s.Append(integrator.ToString() + '\n');
            s.Append($"Work = {work}\n");

            this.problem = new Problem(s);
        }

        public Problem GetProblem()
        {
            return this.problem;
        }
    }

    internal class ForceLinearOscillator : IntegrandAbstractClass14Feb2024
    {
        private double k;

        public ForceLinearOscillator(double k = 50.0)
        {
            this.k = k;
        }

        public override IntegrandAbstractClass14Feb2024 Clone()
        {
            ForceLinearOscillator clone = new ForceLinearOscillator(this.k);
            return clone;
        }

        public override ForceInNewton Function(LengthInMeter14feb2024 x)
        {
            return new ForceInNewton(k * x.GetInMeter());
        }

        public override string ToString()
        {
            return $"{k} x";
        }
    }

    internal class ForceNonLinearOscillator : IntegrandAbstractClass14Feb2024
    {
        private double k1;
        private double k2;

        public ForceNonLinearOscillator(double k1 = 50.0, double k2 = 1.0)
        {
            this.k1 = k1;
            this.k2 = k2;
        }

        public override IntegrandAbstractClass14Feb2024 Clone()
        {
            ForceNonLinearOscillator clone = new ForceNonLinearOscillator(this.k1, this.k2);
            return clone;
        }

        public override ForceInNewton Function(LengthInMeter14feb2024 x)
        {
            return new ForceInNewton(k1 * x.GetInMeter() + k2 * x.GetInMeter() * x.GetInMeter());
        }

        public override string ToString()
        {
            return $"{k1} x + {k2} x^2";
        }
    }
}
