using LibraryIntegrationWork14Feb2024;
using LibraryPhysicalUnits13feb2024;

namespace ConsoleWorkRequiredToCompressASpring16Feb2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The work required to stretch or compress a spring. ");
            Console.WriteLine("The displacement from compression has a negative sign with units of meters.");
            Console.WriteLine("The displacement from stretching has a positive sign with units of meters.");
            Console.WriteLine("This is an exercise on the propagation of measurement errors in calculations.");

            Console.WriteLine("Suppose it takes a force of ( 10 \u00B1 1 ) Newton (in the negative direction) to compress a spring (0.2 ± 0.1) meter from the equilibrium position.");
            Console.WriteLine("How much work is done to stretch the spring (0.5 ± 0.1) m from the equilibrium position?");

            ForceInNewton F = new ForceInNewton(-10, 1); // F = -10 N plusminus 1 N
            LengthInMeter14feb2024 x = new LengthInMeter14feb2024(-0.2, 0.1); // x = -0.2 m plusminus 0.1 m

            var k = F / x; // k = 50 N/m
            Console.WriteLine($"spring constant is {k}");

            const int MAX = 7;
            NumericalIntegrator14Feb2024 integrator = new NumericalIntegrator14Feb2024(new ForceLinearOscillator(k), new LengthInMeter14feb2024(0.0, 0), new LengthInMeter14feb2024(0.5, 0.1));

            WorkInJoule work = new WorkInJoule(0);
            for (int j = 1; j <= MAX; j++)
            {
                work = integrator.Next();
            }
            Console.WriteLine(integrator);
            Console.WriteLine($"Work = {work}");

            Console.WriteLine("Solution: The work done to stretch the spring is 6.25 J.");
            // https://math.libretexts.org/Bookshelves/Calculus/Calculus_(OpenStax)/06%3A_Applications_of_Integration/6.05%3A_Physical_Applications_of_Integration

            /*
The work required to stretch or compress a spring.
The displacement from compression has a negative sign with units of meters.
The displacement from stretching has a positive sign with units of meters.
This is an exercise on the propagation of measurement errors in calculations.
Suppose it takes a force of ( 10 ± 1 ) Newton (in the negative direction) to compress a spring (0.2 ± 0.1) meter from the equilibrium position.
How much work is done to stretch the spring (0.5 ± 0.1) m from the equilibrium position?
spring constant is 50 N/m
The integral solution using integrand 50 N/m x and using boundaries from 0 m to 0,5 m using the extended trapezoidal rule is ( 6,25 ± 0,7250036897236558 ) Joule
Work = ( 6,25 ± 0,7250036897236558 ) Joule
Solution: The work done to stretch the spring is 6.25 J.*/

            Console.WriteLine("\nMaking errors is part of every growth and measurement process.\n");

            Console.WriteLine("Non-linear oscillator:");
            NumericalIntegrator14Feb2024 integrator2 = new NumericalIntegrator14Feb2024(new ForceNonLinearOscillator(), new LengthInMeter14feb2024(0.0, 0), new LengthInMeter14feb2024(0.5, 0));
            WorkInJoule work2 = new WorkInJoule(0);
            for (int j = 1; j <= MAX; j++)
            {
                work2 = integrator2.Next();
            }
            Console.WriteLine(integrator2);
            Console.WriteLine($"Work = {work2}");

            /*
Non-linear oscillator:
The integral solution using integrand 50 N/m x + 1 N/m^2 x^2 and using boundaries from 0 m to 0,5 m using the extended trapezoidal rule is ( 6,2916717529296875 ± 0 ) Joule
Work = ( 6,2916717529296875 ± 0 ) Joule*/

            Console.ReadLine();
        }
    }

    internal class ForceLinearOscillator : IntegrandAbstractClass14Feb2024
    {
        private SpringInNewtonPerMeter k;

        public ForceLinearOscillator()
        {
            this.k = new SpringInNewtonPerMeter(50.0, 0);
        }

        public ForceLinearOscillator(SpringInNewtonPerMeter k)
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
            return k * x;
        }

        public override string ToString()
        {
            return $"{k} x";
        }
    }

    internal class ForceNonLinearOscillator : IntegrandAbstractClass14Feb2024
    {
        private SpringInNewtonPerMeter k1;
        private SpringInNewtonPerSquareMeter k2;

        public ForceNonLinearOscillator()
        {
            this.k1 = new SpringInNewtonPerMeter(50.0, 0);
            this.k2 = new SpringInNewtonPerSquareMeter(1.0, 0);
        }

        public ForceNonLinearOscillator(SpringInNewtonPerMeter k1, SpringInNewtonPerSquareMeter k2)
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
            return k1 * x + k2 * x * x;
        }

        public override string ToString()
        {
            return $"{k1} x + {k2} x^2";
        }
    }
}
