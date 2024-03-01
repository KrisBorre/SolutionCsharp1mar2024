using LibraryIntegrationPrototypeDesignPattern12Feb2024;

namespace LibraryFunctionExamplesPrototypeDesignPattern12Feb2024.Test
{
    public class UnitTestNumericalIntegration
    {
        [Fact]
        public void Test1()
        {
            const int MAX = 5;
            NumericalIntegrator12Feb2024 integrationTrapezoidal1a = new NumericalIntegrator12Feb2024(new Square12Feb2024(), 0.0, 1.0);
            Console.WriteLine("Voorbeeld 1a: Integraal van x^2 van 0 tot 1 is 0.33333 dmv trapezoidal regel.");
            // De integraal van x^2 is (1/3) *x^3 + C 
            // Integreren van 0 tot 1 is
            // (1/3) *1^3 
            // dit is 1/3 = 0.33333
            double value = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value = integrationTrapezoidal1a.Next();
            }
            Assert.Equal(expected: 0.33333, actual: value, tolerance: 0.001);
        }

        [Fact]
        public void Test2()
        {
            const int MAX = 15;
            NumericalIntegrator12Feb2024 integrationTrapezoidal1a = new NumericalIntegrator12Feb2024(new Square12Feb2024(), 0.0, 1.0);
            NumericalIntegrator12Feb2024 integration1b = integrationTrapezoidal1a.Clone();
            integration1b.b = 2.0;
            Console.WriteLine("Voorbeeld 1b: Integraal van x^2 van 0 tot 2 is 2.666666 dmv trapezoidal regel.");
            // De integraal van x^2 is (1/3) *x^3 + C 
            // Integreren van 0 tot 2 is
            // (1/3) *2^3 
            // dit is 8/3 = 2.666666
            double value = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value = integration1b.Next();
            }
            Assert.Equal(expected: 2.666666, actual: value, tolerance: 0.01);
        }

        [Fact]
        public void Test3()
        {
            const int MAX = 5;
            NumericalIntegrator12Feb2024 integrationTrapezoidal1a = new NumericalIntegrator12Feb2024(new Square12Feb2024(), 0.0, 1.0);
            NumericalIntegrator12Feb2024 integration1b = integrationTrapezoidal1a.Clone();
            integration1b.b = 2.0;
            integration1b.a = 1.0;
            Console.WriteLine("Voorbeeld 1c: Integraal van x^2 van 1 tot 2 is 2.33333 dmv trapezoidal regel.");
            double value = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value = integration1b.Next();
            }
            Assert.Equal(expected: 2.33333, actual: value, tolerance: 0.001);
        }

        [Fact]
        public void Test4()
        {
            const int MAX = 15;
            NumericalIntegrator12Feb2024 integrationTrapezoidal2a = new NumericalIntegrator12Feb2024(new ConstantTimesPower12Feb2024(4.0, 0.5), 0.0, 1.0, Method12Feb2024.Trapezoidal);
            Console.WriteLine("Voorbeeld 2a: Integraal van 4*sqrt(x) van 0 tot 1 is 2.6666666 dmv trapezoidal regel.");
            // intergraal van 4*sqrt(x) is 4 * (2/3) * x^{3/2} + C
            // 4 * (2/3) * 1^{3/2} = 8 / 3 = 2.6666666
            double value = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value = integrationTrapezoidal2a.Next();
            }
            Assert.Equal(expected: 2.6666666, actual: value, tolerance: 0.01);
        }

        [Fact]
        public void Test5()
        {
            const int MAX = 5;
            NumericalIntegrator12Feb2024 integrationTrapezoidal2a = new NumericalIntegrator12Feb2024(new ConstantTimesPower12Feb2024(4.0, 0.5), 0.0, 1.0, Method12Feb2024.Trapezoidal);
            double value = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value = integrationTrapezoidal2a.Next();
            }
            NumericalIntegrator12Feb2024 integrationTrapezoidal2b = integrationTrapezoidal2a.Clone();
            integrationTrapezoidal2b.a = -1.0;
            integrationTrapezoidal2b.b = 0.0;
            Console.WriteLine("Voorbeeld 2b: Integraal van 4*sqrt(x) van -1 tot 0 is NaN dmv trapezoidal regel.");
            // intergraal van 4*sqrt(x) is 4 * (2/3) * x^{3/2} + C            
            value = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value = integrationTrapezoidal2b.Next();
            }
            Assert.Equal(expected: double.NaN, actual: value, tolerance: 0.001);
        }

        [Fact]
        public void Test6()
        {
            const int MAX = 5;
            NumericalIntegrator12Feb2024 integration3a = new NumericalIntegrator12Feb2024(new Square12Feb2024(), 0.0, 1.0, Method12Feb2024.Midpoint);
            Console.WriteLine("Voorbeeld 3a: Integraal van x^2 van 0 tot 1 is 0.33333 dmv midpoint regel.");
            // De integraal van x^2 is (1/3) *x^3 + C 
            // Integreren van 0 tot 1 is
            // (1/3) *1^3 
            // dit is 1/3 = 0.33333
            double value = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value = integration3a.Next();
            }
            Assert.Equal(expected: 0.33333, actual: value, tolerance: 0.001);
        }

        [Fact]
        public void Test7()
        {
            const int MAX = 5;
            var function1 = new ConstantTimesPower12Feb2024(4.0, 0.5);
            NumericalIntegrator12Feb2024 integration4a = new NumericalIntegrator12Feb2024(function1, 0.0, 1.0, Method12Feb2024.Midpoint);
            Console.WriteLine("Voorbeeld 4a: Integraal van 4*sqrt(x) van 0 tot 1 is 2.6666666 dmv midpoint regel");
            // intergraal van 4*sqrt(x) is 4 * (2/3) * x^{3/2} + C
            // 4 * (2/3) * 1^{3/2} = 8 / 3 = 2.6666666
            double value = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value = integration4a.Next();
            }
            Assert.Equal(expected: 2.6666666, actual: value, tolerance: 0.001);
        }

        [Fact]
        public void Test8()
        {
            const int MAX = 5;
            var function1 = new ConstantTimesPower12Feb2024(4.0, 0.5);
            NumericalIntegrator12Feb2024 integration4a = new NumericalIntegrator12Feb2024(function1, 0.0, 1.0, Method12Feb2024.Midpoint);
            NumericalIntegrator12Feb2024 integration4b = integration4a; // new NumericalIntegrator12Feb2024(function1, -1.0, 1.0, Method12Feb2024.Midpoint);
            integration4b.a = -1.0;
            Console.WriteLine("Voorbeeld 4b: Integraal van 4*sqrt(x) van -1 tot 1 is NaN dmv midpoint regel");
            // intergraal van 4*sqrt(x) is 4 * (2/3) * x^{3/2} + C
            double value = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value = integration4b.Next();
            }
            Assert.Equal(expected: double.NaN, actual: value, tolerance: 0.001);
        }

        [Fact]
        public void Test9()
        {
            const int MAX = 5;
            NumericalIntegrator12Feb2024 integration5a = new NumericalIntegrator12Feb2024(new Sinus12Feb2024(), 0.0, Math.PI, Method12Feb2024.Midpoint);
            Console.WriteLine("Voorbeeld 5a: Integraal van 0 tot pi van sin(x) dmv midpoint regel (is gelijk aan 2).");
            // https://nl.wikipedia.org/wiki/Integraalrekening
            // integraal van 0 tot pi van sin(x) is gelijk aan 2
            double value = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value = integration5a.Next();
            }
            Assert.Equal(expected: 2.0, actual: value, tolerance: 0.001);
        }

        [Fact]
        public void Test10()
        {
            const int MAX = 15;
            NumericalIntegrator12Feb2024 integration6a = new NumericalIntegrator12Feb2024(new Sinus12Feb2024(), 0.0, Math.PI, Method12Feb2024.Trapezoidal);
            Console.WriteLine("Voorbeeld 6a: Integraal van 0 tot pi van sin(x) dmv trapezoidal regel (is gelijk aan 2).");
            // https://nl.wikipedia.org/wiki/Integraalrekening
            // integraal van 0 tot pi van sin(x) is gelijk aan 2
            double value = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value = integration6a.Next();
            }
            Assert.Equal(expected: 2.0, actual: value, tolerance: 0.001);
        }

        [Fact]
        public void Test11()
        {
            const int MAX = 5;
            IntegrandAbstractClass12Feb2024 function2 = new Integrand1_12Feb2024(0.5);
            NumericalIntegrator12Feb2024 problem1 = new NumericalIntegrator12Feb2024(function2, 0.0, 1, Method12Feb2024.Midpoint);
            Console.WriteLine("Voorbeeld 7: Integral solution of x *Math.Pow(1 + x, 0, 5) from 0 to 1 using the extended midpoint rule is 0,64379");
            double value = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value = problem1.Next();
            }
            Assert.Equal(expected: 0.64379, actual: value, tolerance: 0.001);
        }

        [Fact]
        public void Test12()
        {
            const int MAX = 5;
            IntegrandAbstractClass12Feb2024 function2 = new Integrand1_12Feb2024(0.5);
            NumericalIntegrator12Feb2024 problem1b = new NumericalIntegrator12Feb2024(function2, 1, 0, Method12Feb2024.Midpoint);
            Console.WriteLine("Voorbeeld 8: Integral solution of x *Math.Pow(1 + x, 0, 5) from 1 to 0 using the extended midpoint rule");
            double value = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value = problem1b.Next();
            }
            Assert.Equal(expected: -0.64379, actual: value, tolerance: 0.001);
        }

        [Fact]
        public void Test13()
        {
            const int MAX = 5;
            IntegrandAbstractClass12Feb2024 function2 = new Integrand1_12Feb2024(0.5);
            NumericalIntegrator12Feb2024 problem1 = new NumericalIntegrator12Feb2024(function2, 0.0, 1, Method12Feb2024.Midpoint);
            double value1 = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value1 = problem1.Next();
            }
            NumericalIntegrator12Feb2024 problem1c = problem1.Clone();
            problem1c.b = 2;
            Console.WriteLine("Voorbeeld 9: Integral solution of x *Math.Pow(1 + x, 0.5) from 0 to 2 using the extended midpoint rule");
            double value2 = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value2 = problem1c.Next();
            }
            Assert.Equal(expected: 3.03, actual: value2, tolerance: 0.1);
        }

        [Fact]
        public void Test14()
        {
            const int MAX = 5;
            IntegrandAbstractClass12Feb2024 function3 = new Integrand2_12Feb2024(power1: 0.5, power2: 4);
            NumericalIntegrator12Feb2024 problem2 = new NumericalIntegrator12Feb2024(function3, 0.0, 1.0, Method12Feb2024.Trapezoidal);
            Console.WriteLine("Voorbeeld 10: Integral solution of Math.Pow(Math.Pow(x, 4) + 1, 0.5) from 0 to 1 using the extended trapezoidal rule is 1.089429");
            double value = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value = problem2.Next();
            }
            Assert.Equal(expected: 1.089429, actual: value, tolerance: 0.001);
        }

        [Fact]
        public void Test15()
        {
            const int MAX = 15;
            var function1 = new ConstantTimesPower12Feb2024(4.0, 0.5);
            IntegrandAbstractClass12Feb2024 function4 = function1.Clone();
            NumericalIntegrator12Feb2024 example11 = new NumericalIntegrator12Feb2024(function4, 0.0, 3.0, Method12Feb2024.Midpoint);
            Console.WriteLine("Voorbeeld 11: Integraal van 4*sqrt(x) van 0 tot 3 is 13,8564065 dmv midpoint regel");
            // intergraal van 4*sqrt(x) is 4 * (2/3) * x^{3/2} + C
            // 4 * (2/3) * 3^{3/2} = 8 * sqrt(3) = 13,8564065
            double value = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value = example11.Next();
            }
            Assert.Equal(expected: 13.8564065, actual: value, tolerance: 0.001);
        }

        [Fact]
        public void Test16()
        {
            const int MAX = 5;
            var function1 = new ConstantTimesPower12Feb2024(4.0, 0.5);
            ConstantTimesPower12Feb2024 function5 = (ConstantTimesPower12Feb2024)function1.Clone();
            function5.Constant = 2;
            NumericalIntegrator12Feb2024 example12 = new NumericalIntegrator12Feb2024(function5, 0.0, 3.0, Method12Feb2024.Midpoint);
            Console.WriteLine("Voorbeeld 12: Integraal van 2*sqrt(x) van 0 tot 3 is 6,92820325 dmv midpoint regel");
            // intergraal van 2*sqrt(x) is 2 * (2/3) * x^{3/2} + C
            double value = 0.0;
            for (int j = 1; j <= MAX; j++)
            {
                value = example12.Next();
            }
            Assert.Equal(expected: 6.92820325, actual: value, tolerance: 0.001);
        }
    }
}