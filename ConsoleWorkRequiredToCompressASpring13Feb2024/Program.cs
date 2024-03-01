using LibraryIntegrationPrototypeDesignPattern12Feb2024;

namespace ConsoleWorkRequiredToCompressASpring13Feb2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://math.libretexts.org/Bookshelves/Calculus/Calculus_(OpenStax)/06%3A_Applications_of_Integration/6.05%3A_Physical_Applications_of_Integration
            Console.WriteLine("The Work Required to Stretch or Compress a Spring");

            Console.WriteLine("Suppose it takes a force of 10 N (in the negative direction) to compress a spring 0.2 m from the equilibrium position.");
            Console.WriteLine("How much work is done to stretch the spring 0.5 m from the equilibrium position?");

            const int MAX = 8;
            NumericalIntegrator12Feb2024 integrator1 = new NumericalIntegrator12Feb2024(new ForceLinearOscillator(), 0.0, 0.5);

            double work1 = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                work1 = integrator1.Next();
            }
            Console.WriteLine(integrator1);
            Console.WriteLine($"Work = {work1}");

            Console.WriteLine("Solution: The work done to stretch the spring is 6.25 J.");

            /*
The Work Required to Stretch or Compress a Spring
Suppose it takes a force of 10 N (in the negative direction) to compress a spring 0.2 m from the equilibrium position.
How much work is done to stretch the spring 0.5 m from the equilibrium position?
Integral solution of 50 x using the extended trapezoidal rule is 6,25
Work = 6,25
Solution: The work done to stretch the spring is 6.25 J.
            */

            Console.WriteLine();
            Console.WriteLine("Non-linear oscillator:");
            NumericalIntegrator12Feb2024 integrator2 = new NumericalIntegrator12Feb2024(new ForceNonLinearOscillator(), 0.0, 0.5);

            double work2 = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                work2 = integrator2.Next();
            }
            Console.WriteLine(integrator2);
            Console.WriteLine($"Work = {work2}");
            /*
Non-linear oscillator:
Integral solution of 50 x + 1 x^2 using the extended trapezoidal rule is 6,291667938232422
Work = 6,291667938232422
            */

            Console.WriteLine();
            Console.WriteLine("How much work is done to compress the spring 0.5 m from the equilibrium position?");
            NumericalIntegrator12Feb2024 integrator3 = new NumericalIntegrator12Feb2024(new ForceLinearOscillator(), 0.0, -0.5);

            double work3 = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                work3 = integrator3.Next();
            }
            Console.WriteLine(integrator3);
            Console.WriteLine($"Work = {work3}");

            /*
            How much work is done to compress the spring 0.5 m from the equilibrium position?
            Integral solution of 50 x using the extended trapezoidal rule is 6,25
            Work = 6,25
            */

            Console.WriteLine("Notice that both compression and stretching of the spring requires an amount of work that has a positive sign.");

            Console.ReadLine();
        }
    }

    internal class ForceLinearOscillator : IntegrandAbstractClass12Feb2024
    {
        private double k;

        public ForceLinearOscillator(double k = 50.0)
        {
            this.k = k;
        }

        public override IntegrandAbstractClass12Feb2024 Clone()
        {
            ForceLinearOscillator clone = new ForceLinearOscillator(this.k);
            return clone;
        }

        public override double Function(double x)
        {
            return k * x;
        }

        public override string ToString()
        {
            return $"{k} x";
        }
    }

    internal class ForceNonLinearOscillator : IntegrandAbstractClass12Feb2024
    {
        private double k1;
        private double k2;

        public ForceNonLinearOscillator(double k1 = 50.0, double k2 = 1.0)
        {
            this.k1 = k1;
            this.k2 = k2;
        }

        public override IntegrandAbstractClass12Feb2024 Clone()
        {
            ForceNonLinearOscillator clone = new ForceNonLinearOscillator(this.k1, this.k2);
            return clone;
        }

        public override double Function(double x)
        {
            return k1 * x + k2 * x * x;
        }

        public override string ToString()
        {
            return $"{k1} x + {k2} x^2";
        }
    }
}
