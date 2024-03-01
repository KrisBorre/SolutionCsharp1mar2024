using LibraryPhysicalUnits13feb2024;

namespace ConsoleArraysBuilderDesignPattern18Feb2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Arrays and the Builder Design Pattern!");

            IWeight7feb2024 weight1 = new WeightInKilogram14feb2024(1);
            Console.WriteLine(weight1);

            IWeight7feb2024[,] weights1 = {
                        {new WeightInTon14feb2024(1.1), new WeightInTon14feb2024(1.2), new WeightInTon14feb2024(1.3)},
                        {new WeightInTon14feb2024(4.1), new WeightInTon14feb2024(1.5), new WeightInTon14feb2024(3.3)},
                        {new WeightInTon14feb2024(0.1), new WeightInTon14feb2024(1.2), new WeightInTon14feb2024(0.3)}
                    };
            Console.WriteLine(weights1[2, 1]);

            int matrixRows = weights1.GetLength(0);
            int matrixColumns = weights1.GetLength(1);

            ITemperature[,,] temperatures = {
                    {
                        {new TemperatureInCelsius(3, 1),new TemperatureInCelsius(4, 1)}, {new TemperatureInCelsius(5, 1),new TemperatureInCelsius(4, 1)}
                    },
                    {
                        {new TemperatureInCelsius(12, 1),new TemperatureInCelsius(34, 1)}, {new TemperatureInCelsius(35, 1),new TemperatureInCelsius(24, 1)}
                    },
                    {
                        {new TemperatureInCelsius(-12, 1),new TemperatureInCelsius(27, 1)}, {new TemperatureInCelsius(3, 1),new TemperatureInCelsius(24, 1)}
                    },
                };
            Console.WriteLine(temperatures[2, 0, 1]);
            int dimensions = temperatures.Rank;

            /*
            1 kg
            1,2 Ton
            27 °C
            */

            Directory directory = new Directory();

            IBuilder b1 = new WeightInKilogramArrayBuilder();
            IBuilder b2 = new TemperatureInCelsiusArrayBuilder();
            IBuilder b3 = new WeightInKilogramMatrixBuilder();
            IBuilder b4 = new TemperatureInCelsiusMatrixBuilder();

            directory.Construct(b1);

            Problem p1 = b1.GetProblem();
            p1.Solve();
            p1.Show();

            directory.Construct(b2);
            Problem p2 = b2.GetProblem();
            p2.Solve();
            p2.Show();

            directory.Construct(b3);
            Problem p3 = b3.GetProblem();
            p3.Solve();
            p3.Show();

            directory.Construct(b4);
            Problem p4 = b4.GetProblem();
            p4.Solve();
            p4.Show();

            /*
1,1 kg  1,2 kg  1,3 kg
0,6145786182516499 °C   0,377834109101293 °C    0,7909362000295477 °C
1,1 kg  1,2 kg  1,3 kg
4,1 kg  1,5 kg  3,3 kg
0,1 kg  1,2 kg  0,3 kg

0,79326847038489 °C     0,5575503604833982 °C   0,8312922224169302 °C
0,6487266020766573 °C   0,5136023021930805 °C   0,09641305879709827 °C
0,7030990549959097 °C   0,6002200964430434 °C   0,12984261358459237 °C
            */

            Console.WriteLine("Excercise 5");
            IBuilder b5 = new TemperatureInCelsiusMatrixBuilder(Temperature.Hot, Method.Measurements);

            directory.Construct(b5);

            Problem p5 = b5.GetProblem();
            p5.Solve();
            p5.Show();

            /*
399,83502878336117 °C   492,02709408619637 °C   903,0532003015935 °C
363,90783816782744 °C   939,6072416814322 °C    937,6073359086402 °C
473,73790168819664 °C   188,01802504376798 °C   790,4164616202395 °C
            */

            Console.WriteLine("Excercise 6");
            IBuilder b6 = new SpringProblemBuilder();
            directory.Construct(b6);

            Problem p6 = b6.GetProblem();
            p6.Solve();
            p6.Show();
            /*The work required to compress a spring.
According to Hooke's Law, the force exerted by a spring is directly proportional to the displacement of the spring from its equilibrium position.
So, suppose the force to compress the spring follows Hooke's law: 50 x
How much work is done to stretch the spring 0,5 m from the equilibrium position?
The integral solution using integrand 50 x and using boundaries from 0 m to 0,5 m using the extended trapezoidal rule is 6,25 J
Work = 6,25 J
            */

            Console.WriteLine("Excercise 7");
            IBuilder b7 = new SpringProblemBuilder(0.1);
            directory.Construct(b7);

            Problem p7 = b7.GetProblem();
            p7.Solve();
            p7.Show();
            /*The work required to compress a spring.
According to Hooke's Law, the force exerted by a spring is directly proportional to the displacement of the spring from its equilibrium position.
So, suppose the force to compress the spring follows Hooke's law: 50 x
How much work is done to stretch the spring 0,1 m from the equilibrium position?
The integral solution using integrand 50 x and using boundaries from 0 m to 0,1 m using the extended trapezoidal rule is 0,25 J
Work = 0,25 J
            */

            Console.WriteLine("Excercise 8");
            IBuilder b8 = new SpringProblemBuilder(0.5, 0.0);
            directory.Construct(b8);

            Problem p8 = b8.GetProblem();
            p8.Solve();
            p8.Show();
            /*
The work required to compress a spring.
According to Hooke's Law, the force exerted by a spring is directly proportional to the displacement of the spring from its equilibrium position.
So, suppose the force to compress the spring follows Hooke's law: 50 x
How much work is done to stretch the spring 0,5 m from the equilibrium position?
The integral solution using integrand 50 x and using boundaries from 0 m to 0,5 m using the extended trapezoidal rule is 6,25 J
Work = 6,25 J
            */

            Console.WriteLine("Excercise 9");
            IBuilder b9 = new SpringProblemBuilder(0.5, 0.0, 500);
            directory.Construct(b9);

            Problem p9 = b9.GetProblem();
            p9.Solve();
            p9.Show();
            /*The work required to compress a spring.
According to Hooke's Law, the force exerted by a spring is directly proportional to the displacement of the spring from its equilibrium position.
So, suppose the force to compress the spring follows Hooke's law: 500 x
How much work is done to stretch the spring 0,5 m from the equilibrium position?
The integral solution using integrand 500 x and using boundaries from 0 m to 0,5 m using the extended trapezoidal rule is 62,5 J
Work = 62,5 J
            */

            Console.WriteLine("Excercise 10");
            IBuilder b10 = new SpringProblemBuilder(new LengthInMeter14feb2024(0.5, 0));
            directory.Construct(b10);

            Problem p10 = b10.GetProblem();
            p10.Solve();
            p10.Show();
            /*
The work required to compress a spring.
According to Hooke's Law, the force exerted by a spring is directly proportional to the displacement of the spring from its equilibrium position.
So, suppose the force to compress the spring follows Hooke's law: 50 x
How much work is done to stretch the spring 0,5 m from the equilibrium position?
The integral solution using integrand 50 x and using boundaries from 0 m to 0,5 m using the extended trapezoidal rule is 6,25 J
Work = 6,25 J
            */

            Console.WriteLine("Excercise 11");

            IBuilder b11 = new SpringProblemBuilder(method: LibraryIntegrationWork14Feb2024.Method14Feb2024.Trapezoidal);
            directory.Construct(b11);

            Problem p11 = b11.GetProblem();
            p11.Solve();
            p11.Show();
            /*The work required to compress a spring.
According to Hooke's Law, the force exerted by a spring is directly proportional to the displacement of the spring from its equilibrium position.
So, suppose the force to compress the spring follows Hooke's law: 50 x
How much work is done to stretch the spring 0,5 m from the equilibrium position?
The integral solution using integrand 50 x and using boundaries from 0 m to 0,5 m using the extended trapezoidal rule is 6,25 J
Work = 6,25 J*/

            Console.WriteLine("Excercise 12");
            IBuilder b12 = new SpringProblemBuilder(LibraryIntegrationWork14Feb2024.Method14Feb2024.Midpoint);
            directory.Construct(b12);

            Problem p12 = b12.GetProblem();
            p12.Solve();
            p12.Show();
            /*
The work required to compress a spring.
According to Hooke's Law, the force exerted by a spring is directly proportional to the displacement of the spring from its equilibrium position.
So, suppose the force to compress the spring follows Hooke's law: 50 x
How much work is done to stretch the spring 0,5 m from the equilibrium position?
The integral solution using integrand 50 x and using boundaries from 0 m to 0,5 m using the extended midpoint rule is 6,250000000000054 J
Work = 6,250000000000054 J
            */

            Console.WriteLine("Excercise 13");
            IBuilder b13 = new SpringProblemBuilder(isLinear: false);
            directory.Construct(b13);

            Problem p13 = b13.GetProblem();
            p13.Solve();
            p13.Show();
            /*The work required to compress a spring.
According to Hooke's Law, the force exerted by a spring is directly proportional to the displacement of the spring from its equilibrium position.
So, suppose the force to compress the spring follows Hooke's law: 50 x + 1 x^2
How much work is done to stretch the spring 0,5 m from the equilibrium position?
The integral solution using integrand 50 x + 1 x^2 and using boundaries from 0 m to 0,5 m using the extended midpoint rule is 6,291666664488859 J
Work = 6,291666664488859 J*/

            Console.ReadLine();
        }
    }
}
