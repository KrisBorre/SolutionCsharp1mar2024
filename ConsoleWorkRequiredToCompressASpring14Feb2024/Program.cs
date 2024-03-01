using LibraryIntegrationWork14Feb2024;
using LibraryPhysicalUnits13feb2024;

namespace ConsoleWorkRequiredToCompressASpring14Feb2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://math.libretexts.org/Bookshelves/Calculus/Calculus_(OpenStax)/06%3A_Applications_of_Integration/6.05%3A_Physical_Applications_of_Integration
            Console.WriteLine("The Work Required to Stretch or Compress a Spring.");

            Console.WriteLine("Suppose it takes a force of 10 N (in the negative direction) to compress a spring 0.2 m from the equilibrium position. ");
            Console.WriteLine("How much work is done to stretch the spring 0.5 m from the equilibrium position?");

            const int MAX = 8;

            #region linear
            {
                NumericalIntegrator14Feb2024 integrator1 = new NumericalIntegrator14Feb2024(new ForceLinearOscillator(), new LengthInMeter14feb2024(0.0, 0), new LengthInMeter14feb2024(0.5, 0));

                WorkInJoule work1 = new WorkInJoule(0);
                for (int j = 1; j <= MAX; j++)
                {
                    work1 = integrator1.Next();
                }
                Console.WriteLine(integrator1);
                Console.WriteLine($"Work = {work1}");

                Console.WriteLine("Solution: The work done to stretch the spring is 6.25 J.");
            }
            #endregion
            /*
The Work Required to Stretch or Compress a Spring.
Suppose it takes a force of 10 N (in the negative direction) to compress a spring 0.2 m from the equilibrium position.
How much work is done to stretch the spring 0.5 m from the equilibrium position?
The integral solution using integrand 50 x and using boundaries from 0 m to 0,5 m using the extended trapezoidal rule is 6,25 J
Work = 6,25 J
Solution: The work done to stretch the spring is 6.25 J.
            */

            Console.WriteLine();
            #region non-linear
            {
                Console.WriteLine("Non-linear oscillator:");

                NumericalIntegrator14Feb2024 integrator2 = new NumericalIntegrator14Feb2024(new ForceNonLinearOscillator(), new LengthInMeter14feb2024(0.0, 0), new LengthInMeter14feb2024(0.5, 0));

                WorkInJoule work2 = new WorkInJoule(0);
                for (int j = 1; j <= MAX; j++)
                {
                    work2 = integrator2.Next();
                }
                Console.WriteLine(integrator2);
                Console.WriteLine($"Work = {work2}");
            }
            #endregion
            /*
Non-linear oscillator:
The integral solution using integrand 50 x + 1 x^2 and using boundaries from 0 m to 0,5 m using the extended trapezoidal rule is 6,291667938232422 J
Work = 6,291667938232422 J
            */

            Console.WriteLine();
            #region linear
            {
                NumericalIntegrator14Feb2024 integrator3 = new NumericalIntegrator14Feb2024(new ForceLinearOscillator(), new LengthInMeter14feb2024(0.0, 0), new LengthInMeter14feb2024(-0.5, 0));

                WorkInJoule work3 = new WorkInJoule(0);
                for (int j = 1; j <= MAX; j++)
                {
                    work3 = integrator3.Next();
                }
                Console.WriteLine(integrator3);
                Console.WriteLine($"Work = {work3}");

                Console.WriteLine("The work done to compress the spring is 6.25 J.");
                /*
The integral solution using integrand 50 x and using boundaries from 0 m to -0,5 m using the extended trapezoidal rule is 6,25 J
Work = 6,25 J
The work done to compress the spring is 6.25 J.
                 */

                Console.WriteLine("Notice that both compression and stretching of the spring requires an amount of work that has a positive sign.");
            }
            #endregion

            Console.ReadLine();
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
