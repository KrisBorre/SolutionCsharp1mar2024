using LibraryDifferentialEquationKepler26Feb2024;
using LibraryDifferentialEquations25Feb2024;

namespace ConsoleDifferentialEquationKeplerRK61_1mar2024
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Don’t wait for your feelings to change to take the action. Take the action and your feelings will change.");

            Console.WriteLine("Kepler's planetary motion.          RK61");
            Console.WriteLine("Planet moves around the Sun in an elliptic orbit.");
            Console.WriteLine("The equations of motion are ordinary differential equations and are numerically calculated using a Runge-Kutta method.");

            int kmax = 5; //  15;

            DifferentialEquationsSolverBaseClass26feb2024<Half> solver = new DifferentialEquationsSolverRK61_1mar2024<Half>(new DifferentialEquationsKepler<Half>());

            const double eccentricity = 0.5; // 3. / 4.; // 0.5; // 0;
            Console.WriteLine("eccentricity = " + eccentricity);

            double interval = Math.PI;
            double x_end = Math.PI;

            string myfile_log10_error_versus_log10_delta_x_RK61 = @"..\..\log10_error_versus_log10_delta_x_half_kmax5_RK61_kepler_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt";

            ulong number_of_steps = 200;

            for (int k = 0; k < kmax; k++)
            {
                Console.WriteLine("number_of_steps = " + number_of_steps);

                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                ConditionInitial26feb2024<Half> ic = new ConditionInitial26feb2024<Half>(Half.Zero,
                                                           (Half)y1_zero_exact_function(eccentricity),
                                                           (Half)y2_zero_exact_function(eccentricity),
                                                           (Half)y3_zero_exact_function(eccentricity),
                                                           (Half)y4_zero_exact_function(eccentricity));
                //ic.X = 0;

                solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, delta_x: out Half delta_x, solution: out NumericalSolution26feb2024<Half> solutionSophisticated, interval: (Half)interval, sophisticated: true, x_end: (Half)x_end);

                double y1_pi_exact = y1_pi_exact_function(eccentricity);
                double y2_pi_exact = y2_pi_exact_function(eccentricity);
                double y3_pi_exact = y3_pi_exact_function(eccentricity);
                double y4_pi_exact = y4_pi_exact_function(eccentricity);

                double[] y_sophisticated = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    y_sophisticated[i] = double.CreateChecked(solutionSophisticated.Y[i]);
                }

                double error_sophisticated = sqrt(Math.Pow((y1_pi_exact - y_sophisticated[0]), 2) + Math.Pow((y2_pi_exact - y_sophisticated[1]), 2) + Math.Pow((y3_pi_exact - y_sophisticated[2]), 2) + Math.Pow((y4_pi_exact - y_sophisticated[3]), 2));
                Console.WriteLine("error_sophisticated = " + error_sophisticated);

                stopwatch.Stop();
                double cpu_duration = stopwatch.Elapsed.TotalSeconds;
                Console.WriteLine($"De computer tijd nodig voor deze berekening is {cpu_duration} seconden.");

                System.Globalization.NumberFormatInfo numberFormatInfo = new System.Globalization.NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = ".";
                string output1 = string.Format(numberFormatInfo, "{0} \t {1}", Math.Log10(double.CreateChecked(delta_x)), Math.Log10(Math.Abs(error_sophisticated)));

                using (StreamWriter streamWriter = new StreamWriter(myfile_log10_error_versus_log10_delta_x_RK61, append: true))
                {
                    streamWriter.WriteLine(output1);
                }

                number_of_steps *= 2;
            }

            Console.WriteLine("Opportunities don’t happen, you create them.");
            Console.WriteLine("Look in the text file for the results.");

            /*
eccentricity = 0,5
number_of_steps = 200
error_sophisticated = 0,006768550934425414
De computer tijd nodig voor deze berekening is 0,0110422 seconden.
number_of_steps = 400
error_sophisticated = 0,005110699363409647
De computer tijd nodig voor deze berekening is 0,0064834 seconden.
number_of_steps = 800
error_sophisticated = 0,006904539613336355
De computer tijd nodig voor deze berekening is 0,012656 seconden.
number_of_steps = 1600
error_sophisticated = 0,0063737325105117796
De computer tijd nodig voor deze berekening is 0,0294988 seconden.
number_of_steps = 3200
error_sophisticated = 0,005380087948707385
De computer tijd nodig voor deze berekening is 0,0769598 seconden.
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