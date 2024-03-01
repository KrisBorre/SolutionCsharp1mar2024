using LibraryDifferentialEquationDog29Feb2024;
using LibraryDifferentialEquations25Feb2024;
using System.Text;

namespace ConsoleDifferentialEquationDogRK31_29Feb2024
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Don’t wait for your feelings to change to take the action. Take the action and your feelings will change.");

            // https://mathcurve.com/courbes2d.gb/poursuite/poursuite.shtml
            // Solving ODEs I (2000) page 14 master-and-dog problem

            // v / w
            // Dog is twice as fast as the master.
            // That means that we stop when the dog reaches the master.

            // This is the distance at the outset of the problem between the dog and the master.
            Half a = Half.One; // This is the location where the dog starts running.
            Half x_end = Half.Zero;
            Half interval = Half.CreateChecked(Math.Abs(double.CreateChecked(x_end - a))); // 1.0; // interval is from 1 to 0 // Math.Abs(x_end - a);

            int kmax = 11;

            string myfile_dog = @"..\..\dog_kmax11_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt";

            ulong number_of_steps = 250;
            Console.WriteLine("The master-and-dog problem is solved with the RK31 method in single precision floating point.");
            Console.WriteLine("Calculating ...");

            for (int k = 0; k < kmax; k++)
            {
                var solver = new DifferentialEquationsSolverRK31_29feb2024<Half>(new DifferentialEquationsDog29Feb2024<Half>());

                //y1[0] = 0.0; // This is the location where the master starts walking.
                //y2[0] = 0.0;

                var ic = new ConditionInitial26feb2024<Half>(a, Half.Zero, Half.Zero);
                //ic.X = a; // x_begin                

                solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, out Half delta_x, out NumericalSolution26feb2024<Half> solution, interval: interval, sophisticated: true, x_end: x_end);

                System.Globalization.NumberFormatInfo numberFormatInfo = new System.Globalization.NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = ".";

                StringBuilder sb = new StringBuilder();
                sb.Append("Numerical solution: ");
                sb.Append(string.Format(numberFormatInfo, "x = {0} \t y = {1} \t", solution.X, solution.Y[0]));

                sb.Append("Analytic solution: ");
                sb.Append(string.Format(numberFormatInfo, "x = {0} \t y = {1} \t", solution.X, y_exact_function(double.CreateChecked(solution.X))));

                using (StreamWriter streamWriter = new StreamWriter(myfile_dog, append: true))
                {
                    streamWriter.WriteLine(sb.ToString());
                }

                number_of_steps *= 2;
            }

            Console.WriteLine("Opportunities don’t happen, you create them.");
            Console.WriteLine("Look in the text file for the results.");

            Console.WriteLine("Press Enter.");
            Console.ReadLine();

            /*
Numerical solution: x = 0 	 y = 0.612 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6304 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.647 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = NaN 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = NaN 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = NaN 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = NaN 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0.0004883 	 y = 0.6436 	Analytic solution: x = 0.0004883 	 y = 0.6445731762856599 	
Numerical solution: x = 0.0004883 	 y = 0.644 	Analytic solution: x = 0.0004883 	 y = 0.6445731762856599 	
Numerical solution: x = NaN 	 y = NaN 	Analytic solution: x = NaN 	 y = NaN 	
Numerical solution: x = NaN 	 y = NaN 	Analytic solution: x = NaN 	 y = NaN
            */
        }


        /// <summary>
        /// To check the numerical solution we compare with the exact analytical solution. 
        /// Here is the exact analytical solution to the problem.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static double y_exact_function(double x)
        {
            return (Math.Pow(x, 1.5) / 3.0) - Math.Sqrt(x) + 2.0 / 3.0;
        }
    }
}