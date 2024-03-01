using LibraryDifferentialEquationDog29Feb2024;
using LibraryDifferentialEquations25Feb2024;
using System.Text;

namespace ConsoleDifferentialEquationDogRK42_29Feb2024
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

            int kmax = 21;

            string myfile_dog = @"..\..\dog_kmax21_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt";

            ulong number_of_steps = 250;
            Console.WriteLine("The master-and-dog problem is solved with the RK42 method in double precision floating point.");
            Console.WriteLine("Calculating ...");

            for (int k = 0; k < kmax; k++)
            {
                var solver = new DifferentialEquationsSolver26feb2024<double>(new DifferentialEquationsDog29Feb2024<double>(), Method.RK42 | Method.Crude);

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
                sb.Append(string.Format(numberFormatInfo, "x = {0} \t y = {1} \t", solution.X, y_exact_function(solution.X)));

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
Numerical solution: x = 0 	 y = 0.6077530978924796 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6244632112075764 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6365505628400514 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6452341161718915 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6514428143719996 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6558673591127083 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6590131789841143 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6612462164043212 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6628295191065515 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6639512377600305 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6647454903264296 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6653076506967721 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6657054276549551 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6659868332315624 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.666185884425364 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6663266685777377 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6664262348591415 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.666496647278249 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6665464405907009 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6665816518864482 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
Numerical solution: x = 0 	 y = 0.6666065510859513 	Analytic solution: x = 0 	 y = 0.6666666666666666 	
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