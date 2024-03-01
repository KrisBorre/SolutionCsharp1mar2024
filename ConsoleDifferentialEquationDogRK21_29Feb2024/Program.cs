using LibraryDifferentialEquationDog29Feb2024;
using LibraryDifferentialEquations25Feb2024;
using System.Text;

namespace ConsoleDifferentialEquationDogRK21_29Feb2024
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
            const double a = 1.0; // This is the location where the dog starts running.
            double x_end = 0;
            double interval = Math.Abs(x_end - a); // 1.0; // interval is from 1 to 0 // Math.Abs(x_end - a);

            int kmax = 20;

            string myfile_dog = @"..\..\dog_kmax20_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt";

            ulong number_of_steps = 250;
            Console.WriteLine("The master-and-dog problem is solved with the RK21 method in double precision floating point.");
            Console.WriteLine("Calculating ...");

            for (int k = 0; k < kmax; k++)
            {
                DifferentialEquationsSolverBaseClass26feb2024<double> solver = new DifferentialEquationsSolverRK21_29feb2024<double>(new DifferentialEquationsDog29Feb2024<double>());

                //y1[0] = 0.0; // This is the location where the master starts walking.
                //y2[0] = 0.0;

                ConditionInitial26feb2024<double> ic = new ConditionInitial26feb2024<double>(a, 0, 0);
                //ic.X = a; // x_begin                

                solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, out double delta_x, out NumericalSolution26feb2024<double> solution, interval: interval, sophisticated: true, x_end: x_end);

                System.Globalization.NumberFormatInfo numberFormatInfo = new System.Globalization.NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = ".";

                StringBuilder sb = new StringBuilder();
                sb.Append("Numerical solution: ");
                sb.Append(string.Format(numberFormatInfo, "{0} \t {1} \t", solution.X, solution.Y[0]));

                sb.Append("Analytic solution: ");
                sb.Append(string.Format(numberFormatInfo, "{0} \t {1} \t", solution.X, y_exact_function(solution.X)));

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
Numerical solution: 0 	 0.609196543985733 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.625462075891952 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6372487043730312 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6457247705351623 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6517886649762784 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6561115173023172 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6591856830972259 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6613681445620316 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6629157172824877 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6640121826581528 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6647885825998503 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6653381207281586 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6657269729347906 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.666002067943769 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6661966569578692 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6663342858958361 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6664316211118576 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6665004559325645 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6665491337155239 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6665835562129937 	Analytic solution: 0 	 0.6666666666666666 	
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