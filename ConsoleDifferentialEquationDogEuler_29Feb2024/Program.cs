using LibraryDifferentialEquationDog29Feb2024;
using LibraryDifferentialEquations25Feb2024;
using System.Text;

namespace ConsoleDifferentialEquationDogEuler_29Feb2024
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
            Console.WriteLine("The master-and-dog problem is solved with the Euler method in double precision floating point.");

            for (int k = 0; k < kmax; k++)
            {
                DifferentialEquationsSolverBaseClass26feb2024<double> solver = new DifferentialEquationsSolverEuler26feb2024<double>(new DifferentialEquationsDog29Feb2024<double>());

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
Numerical solution: 0 	 0.5985495171225956 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.617878652611193 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6318420034901476 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6418724073805316 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6490471631977796 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6541631193691037 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6578025845110691 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6603872887138925 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6622206531609955 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6635199259628753 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6644401090103771 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6650915113466331 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6655524917553495 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6658786396096782 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6661093540040124 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6662725403445404 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6663879538676524 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.666469575245407 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.6665272961273105 	Analytic solution: 0 	 0.6666666666666666 	
Numerical solution: 0 	 0.666568113882582 	Analytic solution: 0 	 0.6666666666666666 
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