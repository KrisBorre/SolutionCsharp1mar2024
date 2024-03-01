using LibraryFunctionExamplesPrototypeDesignPattern12Feb2024;
using LibraryIntegrationPrototypeDesignPattern12Feb2024;

namespace ConsoleIntegrationPrototypeDesignPattern12Feb2024
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welkom bij integralen en het prototype design pattern.");
            const int MAX = 5; // 15;

            NumericalIntegrator12Feb2024 integrationTrapezoidal1a = new NumericalIntegrator12Feb2024(new Square12Feb2024(), 0.0, 1.0);
            Console.WriteLine("Voorbeeld 1a: Integraal van x^2 van 0 tot 1 is 0.33333 dmv trapezoidal rule.");
            // De integraal van x^2 is (1/3) *x^3 + C 
            // Integreren van 0 tot 1 is
            // (1/3) *1^3 
            // dit is 1/3 = 0.33333
            for (int j = 1; j <= MAX; j++)
            {
                double value = integrationTrapezoidal1a.Next();
                Console.WriteLine("waarde = " + value);
            }
            Console.WriteLine();

            NumericalIntegrator12Feb2024 integration1b = integrationTrapezoidal1a.Clone();
            integration1b.b = 2.0;
            Console.WriteLine("Voorbeeld 1b: Integraal van x^2 van 0 tot 2 is 2.666666 dmv trapezoidal rule.");
            // De integraal van x^2 is (1/3) *x^3 + C 
            // Integreren van 0 tot 2 is
            // (1/3) *2^3 
            // dit is 8/3 = 2.666666
            for (int j = 1; j <= MAX; j++)
            {
                double value = integration1b.Next();
                Console.WriteLine("waarde = " + value);
            }
            Console.WriteLine();

            integration1b.a = 1.0;
            Console.WriteLine("Voorbeeld 1c: Integraal van x^2 van 1 tot 2 is 2.33333 dmv trapezoidal rule.");
            for (int j = 1; j <= MAX; j++)
            {
                double value = integration1b.Next();
                Console.WriteLine("waarde = " + value);
            }
            Console.WriteLine();

            NumericalIntegrator12Feb2024 integrationTrapezoidal2a = new NumericalIntegrator12Feb2024(new ConstantTimesPower12Feb2024(4.0, 0.5), 0.0, 1.0, Method12Feb2024.Trapezoidal);
            Console.WriteLine("Voorbeeld 2a: Integraal van 4*sqrt(x) van 0 tot 1 is 2.6666666 dmv trapezoidal rule.");
            // intergraal van 4*sqrt(x) is 4 * (2/3) * x^{3/2} + C
            // 4 * (2/3) * 1^{3/2} = 8 / 3 = 2.6666666
            for (int j = 1; j <= MAX; j++)
            {
                double value = integrationTrapezoidal2a.Next();
                Console.WriteLine("waarde = " + value);
            }
            Console.WriteLine();

            NumericalIntegrator12Feb2024 integrationTrapezoidal2b = integrationTrapezoidal2a.Clone();
            integrationTrapezoidal2b.a = -1.0;
            integrationTrapezoidal2b.b = 0.0;
            Console.WriteLine("Voorbeeld 2b: Integraal van 4*sqrt(x) van -1 tot 0 is NaN dmv trapezoidal rule.");
            // intergraal van 4*sqrt(x) is 4 * (2/3) * x^{3/2} + C            
            for (int j = 1; j <= MAX; j++)
            {
                double value = integrationTrapezoidal2b.Next();
                Console.WriteLine("waarde = " + value);
            }
            Console.WriteLine();

            NumericalIntegrator12Feb2024 integration3a = new NumericalIntegrator12Feb2024(new Square12Feb2024(), 0.0, 1.0, Method12Feb2024.Midpoint);
            Console.WriteLine("Voorbeeld 3a: Integraal van x^2 van 0 tot 1 is 0.33333 dmv midpoint rule.");
            // De integraal van x^2 is (1/3) *x^3 + C 
            // Integreren van 0 tot 1 is
            // (1/3) *1^3 
            // dit is 1/3 = 0.33333
            for (int j = 1; j <= MAX; j++)
            {
                double value = integration3a.Next();
                Console.WriteLine("waarde = " + value);
            }
            Console.WriteLine();

            var function1 = new ConstantTimesPower12Feb2024(4.0, 0.5);
            NumericalIntegrator12Feb2024 integration4a = new NumericalIntegrator12Feb2024(function1, 0.0, 1.0, Method12Feb2024.Midpoint);
            Console.WriteLine("Voorbeeld 4a: Integraal van 4*sqrt(x) van 0 tot 1 is 2.6666666 dmv midpoint rule");
            // intergraal van 4*sqrt(x) is 4 * (2/3) * x^{3/2} + C
            // 4 * (2/3) * 1^{3/2} = 8 / 3 = 2.6666666
            for (int j = 1; j <= MAX; j++)
            {
                double value = integration4a.Next();
                Console.WriteLine("waarde = " + value);
            }
            Console.WriteLine();

            NumericalIntegrator12Feb2024 integration4b = integration4a; // new NumericalIntegrator12Feb2024(function1, -1.0, 1.0, Method12Feb2024.Midpoint);
            integration4b.a = -1.0;
            Console.WriteLine("Voorbeeld 4b: Integraal van 4*sqrt(x) van -1 tot 1 is NaN dmv midpoint rule");
            // intergraal van 4*sqrt(x) is 4 * (2/3) * x^{3/2} + C        
            for (int j = 1; j <= MAX; j++)
            {
                double value = integration4b.Next();
                Console.WriteLine("waarde = " + value);
            }
            Console.WriteLine();

            Console.WriteLine("Voorbeeld 4c: Integraal van 4*sqrt(x) van 0 tot 1 is 2.6666666 dmv midpoint rule");
            double value2 = integration4a.Next();
            Console.Write("waarde = " + value2);
            Console.WriteLine(" This shows incorrectly the value NaN, because I forgot to Clone.\n");

            NumericalIntegrator12Feb2024 integration5a = new NumericalIntegrator12Feb2024(new Sinus12Feb2024(), 0.0, Math.PI, Method12Feb2024.Midpoint);
            Console.WriteLine("Voorbeeld 5a: Integraal van 0 tot pi van sin(x) dmv midpoint regel (is gelijk aan 2).");
            // https://nl.wikipedia.org/wiki/Integraalrekening
            // integraal van 0 tot pi van sin(x) is gelijk aan 2                    
            for (int j = 1; j <= MAX; j++)
            {
                double value = integration5a.Next();
                Console.WriteLine("waarde = " + value);
            }
            Console.WriteLine();

            NumericalIntegrator12Feb2024 integration6a = new NumericalIntegrator12Feb2024(new Sinus12Feb2024(), 0.0, Math.PI, Method12Feb2024.Trapezoidal);
            Console.WriteLine("Voorbeeld 6a: Integraal van 0 tot pi van sin(x) dmv trapezoidal regel (is gelijk aan 2).");
            // https://nl.wikipedia.org/wiki/Integraalrekening
            // integraal van 0 tot pi van sin(x) is gelijk aan 2                    
            for (int j = 1; j <= MAX; j++)
            {
                double value = integration6a.Next();
                Console.WriteLine("waarde = " + value);
            }
            Console.WriteLine();

            IntegrandAbstractClass12Feb2024 function2 = new Integrand1_12Feb2024(0.5);
            NumericalIntegrator12Feb2024 problem1 = new NumericalIntegrator12Feb2024(function2, 0.0, 1, Method12Feb2024.Midpoint);
            Console.WriteLine("Voorbeeld 7: Integral solution of x *Math.Pow(1 + x, 0, 5) from 0 to 1 using the extended midpoint rule is 0,64379");
            for (int j = 1; j <= MAX; j++)
            {
                double value = problem1.Next();
                Console.WriteLine("waarde = " + value);
            }
            Console.WriteLine();

            NumericalIntegrator12Feb2024 problem1b = new NumericalIntegrator12Feb2024(function2, 1, 0, Method12Feb2024.Midpoint);
            Console.WriteLine("Voorbeeld 8: Integral solution of x *Math.Pow(1 + x, 0, 5) from 1 to 0 using the extended midpoint rule");
            for (int j = 1; j <= MAX; j++)
            {
                double value = problem1b.Next();
                Console.WriteLine("waarde = " + value);
            }
            Console.WriteLine();

            NumericalIntegrator12Feb2024 problem1c = problem1.Clone();
            problem1c.b = 2;
            Console.WriteLine("Voorbeeld 9: Integral solution of x *Math.Pow(1 + x, 0, 5) from 0 to 2 using the extended midpoint rule");
            for (int j = 1; j <= MAX; j++)
            {
                double value = problem1c.Next();
                Console.WriteLine("waarde = " + value);
            }
            Console.WriteLine();

            IntegrandAbstractClass12Feb2024 function3 = new Integrand2_12Feb2024(power1: 0.5, power2: 4);
            NumericalIntegrator12Feb2024 problem2 = new NumericalIntegrator12Feb2024(function3, 0.0, 1.0, Method12Feb2024.Trapezoidal);
            Console.WriteLine("Voorbeeld 10: Integral solution of Math.Pow(Math.Pow(x, 4) + 1, 0.5) from 0 to 1 using the extended trapezoidal rule is 1.089429");
            for (int j = 1; j <= MAX; j++)
            {
                double value = problem2.Next();
                Console.WriteLine("waarde = " + value);
            }
            Console.WriteLine();

            IntegrandAbstractClass12Feb2024 function4 = function1.Clone();
            NumericalIntegrator12Feb2024 example11 = new NumericalIntegrator12Feb2024(function4, 0.0, 3.0, Method12Feb2024.Midpoint);
            Console.WriteLine("Voorbeeld 11: Integraal van 4*sqrt(x) van 0 tot 3 is 13,8564065 dmv midpoint rule");
            // intergraal van 4*sqrt(x) is 4 * (2/3) * x^{3/2} + C
            // 4 * (2/3) * 3^{3/2} = 8 * sqrt(3) = 13,8564065
            for (int j = 1; j <= MAX; j++)
            {
                double value = example11.Next();
                Console.WriteLine("waarde = " + value);
            }
            Console.WriteLine();

            ConstantTimesPower12Feb2024 function5 = (ConstantTimesPower12Feb2024)function1.Clone();
            function5.Constant = 2;
            NumericalIntegrator12Feb2024 example12 = new NumericalIntegrator12Feb2024(function5, 0.0, 3.0, Method12Feb2024.Midpoint);
            Console.WriteLine("Voorbeeld 12: Integraal van 2*sqrt(x) van 0 tot 3 is 6,92820325 dmv midpoint rule");
            // intergraal van 2*sqrt(x) is 2 * (2/3) * x^{3/2} + C            
            for (int j = 1; j <= MAX; j++)
            {
                double value = example12.Next();
                Console.WriteLine("waarde = " + value);
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}