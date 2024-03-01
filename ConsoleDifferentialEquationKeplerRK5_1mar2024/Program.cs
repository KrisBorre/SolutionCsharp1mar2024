using LibraryDifferentialEquationKepler26Feb2024;
using LibraryDifferentialEquations25Feb2024;

namespace ConsoleDifferentialEquationKeplerRK5_1mar2024
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Don’t wait for your feelings to change to take the action. Take the action and your feelings will change.");

            Console.WriteLine("Kepler's planetary motion.");
            Console.WriteLine("Planet moves around the Sun in an elliptic orbit.");
            Console.WriteLine("The equations of motion are ordinary differential equations and are numerically calculated using a Runge-Kutta method.");

            int kmax = 5; //  15;

            var solver = new DifferentialEquationsSolver26feb2024<double>(new DifferentialEquationsKepler<double>(), Method.RK5);

            const double eccentricity = 0.5; // 3. / 4.; // 0.5; // 0;
            Console.WriteLine("eccentricity = " + eccentricity);

            double interval = Math.PI;
            double x_end = Math.PI;

            string myfile_log10_error_versus_log10_delta_x = @"..\..\log10_error_versus_log10_delta_x_double_kmax5_kepler_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt";

            ulong number_of_steps = 200;

            for (int k = 0; k < kmax; k++)
            {
                Console.WriteLine("number_of_steps = " + number_of_steps);

                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                var ic = new ConditionInitial26feb2024<double>(0,
                                                           y1_zero_exact_function(eccentricity),
                                                           y2_zero_exact_function(eccentricity),
                                                           y3_zero_exact_function(eccentricity),
                                                           y4_zero_exact_function(eccentricity));
                //ic.X = 0;

                solver.Solve(interval: interval, x_end: x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, out NumericalSolution26feb2024<double> solutionSophisticated);

                double y1_pi_exact = y1_pi_exact_function(eccentricity);
                double y2_pi_exact = y2_pi_exact_function(eccentricity);
                double y3_pi_exact = y3_pi_exact_function(eccentricity);
                double y4_pi_exact = y4_pi_exact_function(eccentricity);

                double[] y_sophisticated = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    y_sophisticated[i] = solutionSophisticated.Y[i];
                }

                double error_sophisticated = sqrt(Math.Pow((y1_pi_exact - y_sophisticated[0]), 2) + Math.Pow((y2_pi_exact - y_sophisticated[1]), 2) + Math.Pow((y3_pi_exact - y_sophisticated[2]), 2) + Math.Pow((y4_pi_exact - y_sophisticated[3]), 2));
                Console.WriteLine("error_sophisticated = " + error_sophisticated);

                stopwatch.Stop();
                double cpu_duration = stopwatch.Elapsed.TotalSeconds;
                Console.WriteLine($"De computer tijd nodig voor deze berekening is {cpu_duration} seconden.");

                System.Globalization.NumberFormatInfo numberFormatInfo = new System.Globalization.NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = ".";
                string output1 = string.Format(numberFormatInfo, "{0} \t {1}", Math.Log10(delta_x), Math.Log10(Math.Abs(error_sophisticated)));

                using (StreamWriter streamWriter = new StreamWriter(myfile_log10_error_versus_log10_delta_x, append: true))
                {
                    streamWriter.WriteLine(output1);
                }

                number_of_steps *= 2;
            }

            Console.WriteLine("Opportunities don’t happen, you create them.");
            Console.WriteLine("Look in the text file for the results.");

            /*
-1.8038801229698473 	 -8.155564910928184
-2.1049101186338284 	 -9.656278638787464
-2.4059401142978096 	 -11.159451772948868
-2.706970109961791 	 -12.666488370497875
-3.008000105625772 	 -14.275749969403504
            */

            /*
eccentricity = 0,5
number_of_steps = 200
error_sophisticated = 6,989322644867612E-09
De computer tijd nodig voor deze berekening is 0,0081024 seconden.
number_of_steps = 400
error_sophisticated = 2,206588554676911E-10
De computer tijd nodig voor deze berekening is 0,0025694 seconden.
number_of_steps = 800
error_sophisticated = 6,92704847884871E-12
De computer tijd nodig voor deze berekening is 0,0044621 seconden.
number_of_steps = 1600
error_sophisticated = 2,1553193577589413E-13
De computer tijd nodig voor deze berekening is 0,0074878 seconden.
number_of_steps = 3200
error_sophisticated = 5,2996846778980195E-15
De computer tijd nodig voor deze berekening is 0,0194025 seconden.
             */
            Console.WriteLine("Press Enter.");
            Console.ReadLine();
        }


        static double sqrt(double x)
        {
            return Math.Sqrt(x);
        }

        static double y1_zero_exact_function(double eccentricity)
        {
            return 1.0 - eccentricity;
        }

        static double y2_zero_exact_function(double eccentricity)
        {
            return 0.0;
        }

        static double y3_zero_exact_function(double eccentricity)
        {
            return 0.0;
        }

        static double y4_zero_exact_function(double eccentricity)
        {
            return sqrt((1.0 + eccentricity) / (1.0 - eccentricity));
        }


        /// <summary>
        /// To check the numerical solution we compare with the exact analytical solution. 
        /// Here is the exact analytical solution to the problem.
        /// </summary>
        static double y1_pi_exact_function(double eccentricity)
        {
            return -1.0 - eccentricity;
        }

        static double y2_pi_exact_function(double eccentricity)
        {
            return 0.0;
        }

        static double y3_pi_exact_function(double eccentricity)
        {
            return 0.0;
        }

        static double y4_pi_exact_function(double eccentricity)
        {
            return -sqrt((1.0 - eccentricity) / (1.0 + eccentricity)); // Notice the minus and plus sign!
        }
    }
}