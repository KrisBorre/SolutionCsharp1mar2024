using LibraryDifferentialEquationDog29Feb2024;
using LibraryDifferentialEquations25Feb2024;
using System.Text;

namespace ConsoleDifferentialEquationDogRK22_29Feb2024
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
            float a = 1.0f; // This is the location where the dog starts running.
            float x_end = 0;
            float interval = Math.Abs(x_end - a); // 1.0; // interval is from 1 to 0 // Math.Abs(x_end - a);

            int kmax = 13;

            string myfile_dog = @"..\..\dog_kmax13_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt";

            ulong number_of_steps = 250;
            Console.WriteLine("The master-and-dog problem is solved with the RK22 method in single precision floating point.");
            Console.WriteLine("Calculating ...");

            for (int k = 0; k < kmax; k++)
            {
                DifferentialEquationsSolverBaseClass26feb2024<float> solver = new DifferentialEquationsSolverRK22_29feb2024<float>(new DifferentialEquationsDog29Feb2024<float>());

                //y1[0] = 0.0; // This is the location where the master starts walking.
                //y2[0] = 0.0;

                ConditionInitial26feb2024<float> ic = new ConditionInitial26feb2024<float>(a, 0, 0);
                //ic.X = a; // x_begin                

                solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, out float delta_x, out NumericalSolution26feb2024<float> solution, interval: interval, sophisticated: true, x_end: x_end);

                System.Globalization.NumberFormatInfo numberFormatInfo = new System.Globalization.NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = ".";

                StringBuilder sb = new StringBuilder();
                sb.Append("Numerical solution: ");
                sb.Append(string.Format(numberFormatInfo, $"x = {solution.X} \t y = {solution.Y[0]} \t"));

                sb.Append("Analytic solution: ");
                sb.Append(string.Format(numberFormatInfo, $"x = {solution.X} \t y = {y_exact_function(solution.X)} \t"));

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
Numerical solution: x = 0 	 y = 0,608816 	Analytic solution: x = 0 	 y = 0,6666666666666666 	
Numerical solution: x = 0 	 y = 0,62520564 	Analytic solution: x = 0 	 y = 0,6666666666666666 	
Numerical solution: x = 0 	 y = 0,6370726 	Analytic solution: x = 0 	 y = 0,6666666666666666 	
Numerical solution: x = 0 	 y = 0,6456027 	Analytic solution: x = 0 	 y = 0,6666666666666666 	
Numerical solution: x = 0 	 y = 0,6517037 	Analytic solution: x = 0 	 y = 0,6666666666666666 	
Numerical solution: x = 0 	 y = 0,65605295 	Analytic solution: x = 0 	 y = 0,6666666666666666 	
Numerical solution: x = 0 	 y = 0,65914595 	Analytic solution: x = 0 	 y = 0,6666666666666666 	
Numerical solution: x = 0 	 y = 0,66134286 	Analytic solution: x = 0 	 y = 0,6666666666666666 	
Numerical solution: x = 0 	 y = 0,66290164 	Analytic solution: x = 0 	 y = 0,6666666666666666 	
Numerical solution: x = 0 	 y = 0,6640077 	Analytic solution: x = 0 	 y = 0,6666666666666666 	
Numerical solution: x = 0 	 y = 0,6647915 	Analytic solution: x = 0 	 y = 0,6666666666666666 	
Numerical solution: x = 0 	 y = 0,6653486 	Analytic solution: x = 0 	 y = 0,6666666666666666 	
Numerical solution: x = 0 	 y = 0,665747 	Analytic solution: x = 0 	 y = 0,6666666666666666 		
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