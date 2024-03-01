using LibraryDifferentialEquationKepler26Feb2024;
using LibraryDifferentialEquations25Feb2024;

namespace ConsoleDifferentialEquationKeplerRK5Crude_1mar2024
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Don’t wait for your feelings to change to take the action. Take the action and your feelings will change.");

            Console.WriteLine("Kepler's planetary motion.");
            Console.WriteLine("Planet moves around the Sun in an elliptic orbit.");
            Console.WriteLine("The equations of motion are ordinary differential equations and are numerically calculated using a Runge-Kutta method.");
            Console.WriteLine("Comparison between crude Runge-Kutta calculation and sophisticated Runge-Kutta calculation.");

            int kmax = 8; // 5; //  15;

            DifferentialEquationsSolverBaseClass26feb2024<float> solver = new DifferentialEquationsSolverRK5_1mar2024<float>(new DifferentialEquationsKepler<float>());

            const double eccentricity = 0.5; // 3. / 4.; // 0.5; // 0;
            Console.WriteLine("eccentricity = " + eccentricity);

            double interval = Math.PI;
            double x_end = Math.PI;

            string myfile_log10_error_versus_log10_delta_x = @"..\..\log10_error_versus_log10_delta_x_float_kmax8_kepler_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt";

            ulong number_of_steps = 200;

            for (int k = 0; k < kmax; k++)
            {
                Console.WriteLine("number_of_steps = " + number_of_steps);

                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                ConditionInitial26feb2024<float> ic = new ConditionInitial26feb2024<float>(0,
                                                           (float)y1_zero_exact_function(eccentricity),
                                                           (float)y2_zero_exact_function(eccentricity),
                                                           (float)y3_zero_exact_function(eccentricity),
                                                           (float)y4_zero_exact_function(eccentricity));
                //ic.X = 0;

                solver.Solve(interval: (float)interval, x_end: (float)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out float delta_x, solution: out NumericalSolution26feb2024<float> solutionSophisticated, sophisticated: true);
                solver.Solve(interval: (float)interval, x_end: (float)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out float delta_x_crude, solution: out NumericalSolution26feb2024<float> solutionCrude, sophisticated: false);

                double y1_pi_exact = y1_pi_exact_function(eccentricity);
                double y2_pi_exact = y2_pi_exact_function(eccentricity);
                double y3_pi_exact = y3_pi_exact_function(eccentricity);
                double y4_pi_exact = y4_pi_exact_function(eccentricity);

                double[] y_sophisticated = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    y_sophisticated[i] = solutionSophisticated.Y[i];
                }

                double[] y_crude = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    y_crude[i] = solutionCrude.Y[i];
                }

                double error_sophisticated = sqrt(Math.Pow((y1_pi_exact - y_sophisticated[0]), 2) + Math.Pow((y2_pi_exact - y_sophisticated[1]), 2) + Math.Pow((y3_pi_exact - y_sophisticated[2]), 2) + Math.Pow((y4_pi_exact - y_sophisticated[3]), 2));
                Console.WriteLine("error_sophisticated = " + error_sophisticated);

                double error_crude = sqrt(Math.Pow((y1_pi_exact - y_crude[0]), 2) + Math.Pow((y2_pi_exact - y_crude[1]), 2) + Math.Pow((y3_pi_exact - y_crude[2]), 2) + Math.Pow((y4_pi_exact - y_crude[3]), 2));
                Console.WriteLine("error_crude = " + error_crude);

                double total_energy_numerical = total_energy_function(y_sophisticated[0], y_sophisticated[1], y_sophisticated[2], y_sophisticated[3]);
                double angular_momentum_numerical = angular_momentum_function(y_sophisticated[0], y_sophisticated[1], y_sophisticated[2], y_sophisticated[3]);

                double total_energy_exact = total_energy_function(y1_pi_exact, y2_pi_exact, y3_pi_exact, y4_pi_exact);
                double angular_momentum_exact = angular_momentum_function(y1_pi_exact, y2_pi_exact, y3_pi_exact, y4_pi_exact);

                stopwatch.Stop();
                double cpu_duration = stopwatch.Elapsed.TotalSeconds;
                Console.WriteLine($"De computer tijd nodig voor deze berekening is {cpu_duration} seconden.");

                System.Globalization.NumberFormatInfo numberFormatInfo = new System.Globalization.NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = ".";
                string output1 = string.Format(numberFormatInfo, "{0} \t {1} \t {2}", Math.Log10(delta_x), Math.Log10(Math.Abs(error_sophisticated)), Math.Log10(Math.Abs(error_crude)));

                using (StreamWriter streamWriter = new StreamWriter(myfile_log10_error_versus_log10_delta_x, append: true))
                {
                    streamWriter.WriteLine(output1);
                }

                number_of_steps *= 2;
            }

            Console.WriteLine("Opportunities don’t happen, you create them.");
            Console.WriteLine("Look in the text file for the results.");

            /*
-1.8038801005848035 	 -6.222435053867796 	 -5.612495260306016
-2.104910096248785 	     -6.389916593221807 	 -6.099742493801399
-2.4059400919127656 	 -6.202058059949446 	 -5.332358559135952
-2.706970087576747 	     -6.3206811355524195 	 -4.979682797857516
-3.008000083240728 	     -6.276588614435309 	 -4.9572448800106175
-3.3090300789047093 	 -6.216990693222484 	 -4.836360190876962
-3.6100600745686906 	 -6.206356401239253 	 -5.554033831518075
-3.911090070232672 	    -6.210287732880378 	     -4.601748163035178
            */

            /*
eccentricity = 0,5
number_of_steps = 200
error_sophisticated = 5,991905372589403E-07
error_crude = 2,440645704002416E-06
De computer tijd nodig voor deze berekening is 0,009255 seconden.
number_of_steps = 400
error_sophisticated = 4,0745852319031995E-07
error_crude = 7,947993553692358E-07
De computer tijd nodig voor deze berekening is 0,0030994 seconden.
number_of_steps = 800
error_sophisticated = 6,279744005759427E-07
error_crude = 4,652018582647449E-06
De computer tijd nodig voor deze berekening is 0,0072332 seconden.
number_of_steps = 1600
error_sophisticated = 4,778800103727245E-07
error_crude = 1,0478936343263982E-05
De computer tijd nodig voor deze berekening is 0,0229987 seconden.
number_of_steps = 3200
error_sophisticated = 5,289460588393E-07
error_crude = 1,1034562528547336E-05
De computer tijd nodig voor deze berekening is 0,0265927 seconden.
number_of_steps = 6400
error_sophisticated = 6,067493318732919E-07
error_crude = 1,457604864869889E-05
De computer tijd nodig voor deze berekening is 0,0422341 seconden.
number_of_steps = 12800
error_sophisticated = 6,217898075504237E-07
error_crude = 2,7923263106869038E-06
De computer tijd nodig voor deze berekening is 0,0918007 seconden.
number_of_steps = 25600
error_sophisticated = 6,161866248153467E-07
error_crude = 2,501795672525674E-05
De computer tijd nodig voor deze berekening is 0,1938989 seconden.
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


        static double total_energy_function(double y1, double y2, double y3, double y4)
        {
            return 0.5 * (y3 * y3 + y4 * y4) - 1.0 / sqrt(y1 * y1 + y2 * y2);
        }

        static double angular_momentum_function(double y1, double y2, double y3, double y4)
        {
            return y1 * y4 - y2 * y3; // Notice the minus sign!
        }
    }
}