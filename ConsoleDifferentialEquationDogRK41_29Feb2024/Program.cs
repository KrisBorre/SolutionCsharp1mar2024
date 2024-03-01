using LibraryDifferentialEquationDog29Feb2024;
using LibraryDifferentialEquations25Feb2024;
using System.Text;

namespace ConsoleDifferentialEquationDogRK41_29Feb2024
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
            double a = 1; // This is the location where the dog starts running.
            double x_end = 0;
            double interval = Math.Abs(x_end - a); // 1.0; // interval is from 1 to 0 // Math.Abs(x_end - a);

            int kmax = 10;

            string myfile_dog = @"..\..\dog_kmax10_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt";

            ulong number_of_steps = 250;
            Console.WriteLine("The master-and-dog problem is solved with the RK41 method in double precision floating point.");
            Console.WriteLine("Calculating ...");

            for (int k = 0; k < kmax; k++)
            {
                var solver = new DifferentialEquationsSolver26feb2024<double>(new DifferentialEquationsDog29Feb2024<double>(), Method.RK41);

                //y1[0] = 0.0; // This is the location where the master starts walking.
                //y2[0] = 0.0;

                var ic = new ConditionInitial26feb2024<double>(a, 0, 0);
                //ic.X = a; // x_begin                

                solver.Solve(interval: interval, x_end: x_end, initialCondition: ic, number_of_steps: number_of_steps, out double delta_x, out NumericalSolution26feb2024<double> solution);

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
Numerical solution: x = 0 	 y = 0.6077656512504226 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6244719948191864 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6365567403821716 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6452384724428191 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6514458904917712 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6558695327595362 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6590147154542277 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6612473026651688 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6628302871426199 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6639517808200829 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
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