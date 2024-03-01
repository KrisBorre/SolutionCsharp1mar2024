﻿using LibraryDifferentialEquations25Feb2024;
using System.Globalization;

namespace ConsoleDifferentialEquationWorkToCompressASpring28feb2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using single precision floating point numbers");
            Console.WriteLine("Calculating the work (energy) required to compress a spring using a Runge-Kutta solver.");

            DifferentialEquationsSolverBaseClass26feb2024<float> solver = new DifferentialEquationsSolverEuler26feb2024<float>(new DifferentialEquationsWorkToCompressASpring());

            float a = 0.0f;
            float stretchInMeter = 0.5f;
            float b = stretchInMeter;
            float interval = b - a;
            float x_end = interval;

            ConditionInitial26feb2024<float> ic = new ConditionInitial26feb2024<float>(a, 0); // W(a) = 0

            ulong number_of_steps = 1000;

            solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, out float delta_x, out NumericalSolution26feb2024<float> solution, interval: interval, sophisticated: true, x_end: x_end);

            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            Console.WriteLine(solution.Y[0]); // 6.2437506

            Console.WriteLine("The work required to compress a spring.");
            Console.WriteLine("According to Hooke's Law, the force exerted by a spring is directly proportional to the displacement of the spring from its equilibrium position.");
            Console.WriteLine("So, suppose the force to compress the spring follows Hooke's law: 50 x");
            Console.WriteLine("How much work is done to stretch the spring 0.5 m from the equilibrium position?");
            Console.WriteLine("The integral solution using integrand 50 x and using boundaries from 0 m to 0.5 m using the extended trapezoidal rule is 6.25 Joule");
            Console.WriteLine("We can transform this integral problem into a differential equation problem.");
            Console.WriteLine("Solving this problem using a Runge-Kutta solver we find the same result for the work: 6.25 Joule.");
            // https://math.libretexts.org/Bookshelves/Calculus/Calculus_(OpenStax)/06%3A_Applications_of_Integration/6.05%3A_Physical_Applications_of_Integration

            Console.ReadLine();
        }
    }
}
