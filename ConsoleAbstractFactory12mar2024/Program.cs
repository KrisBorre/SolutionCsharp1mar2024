using LibraryAbstractFactoryDesignPattern12mar2024;
using LibraryDifferentialEquations25Feb2024;
using System.Text;

namespace ConsoleAbstractFactory12mar2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client of Abstract Factory Design Pattern.");

            SolverFactory12mar2024 solverDogFactory = new SolverDogFactory12mar2024();
            Console.WriteLine("master-and-dog problem");
            ISolverDouble12mar2024 solver1 = solverDogFactory.GetSolverDouble12mar2024(Method.Euler);
            double a = 1.0; // This is the location where the dog starts running.
            double x_end = 0;
            double interval = Math.Abs(x_end - a); // 1.0; // interval is from 1 to 0 
            ConditionInitial26feb2024<double> ic1 = new ConditionInitial26feb2024<double>(a, 0, 0);
            solver1.X_end = x_end;
            solver1.Interval = interval;
            solver1.InitialCondition = ic1;
            solver1.Number_of_steps = 10000;

            solver1.Solve(out double delta_x_1, out NumericalSolution26feb2024<double> solution1);

            System.Globalization.NumberFormatInfo numberFormatInfo = new System.Globalization.NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";

            StringBuilder sb1 = new StringBuilder();
            sb1.Append("Numerical solution using the Euler method in double precision floating point: ");
            sb1.Append(string.Format(numberFormatInfo, "{0} \t {1} \t", solution1.X, solution1.Y[0]));
            Console.WriteLine(sb1.ToString());

            ISolverHalf12mar2024 solver2 = solverDogFactory.GetSolverHalf12mar2024(Method.RKCV8);
            ConditionInitial26feb2024<Half> ic2 = new ConditionInitial26feb2024<Half>((Half)a, (Half)0, (Half)0);
            solver2.X_end = (Half)x_end;
            solver2.Interval = (Half)interval;
            solver2.InitialCondition = ic2;
            solver2.Number_of_steps = 1000; // 100; // 10;

            solver2.Solve(out Half delta_x_2, out NumericalSolution26feb2024<Half> solution2);

            StringBuilder sb2 = new StringBuilder();
            sb2.Append("Numerical solution using RKCV8 in half precision: ");
            sb2.Append(string.Format(numberFormatInfo, "{0} \t {1} \t", solution2.X, solution2.Y[0]));
            Console.WriteLine(sb2.ToString());


            SolverFactory12mar2024 solverKeplerFactory = new SolverKeplerFactory12mar2024();
            Console.WriteLine("Kepler problem");
            ISolverFloat12mar2024 solver3 = solverKeplerFactory.GetSolverFloat12mar2024(Method.RK41);

            double eccentricity = 0.5; // 3. / 4.; // 0.5; // 0;            
            double interval3 = Math.PI;
            double x_end3 = Math.PI;
            ulong number_of_steps3 = 2000;
            solver3.X_end = (float)x_end3;
            solver3.Interval = (float)interval3;
            ConditionInitial26feb2024<float> ic3 = new ConditionInitial26feb2024<float>(0,
                                               (float)y1_zero_exact_function(eccentricity),
                                               (float)y2_zero_exact_function(eccentricity),
                                               (float)y3_zero_exact_function(eccentricity),
                                               (float)y4_zero_exact_function(eccentricity));
            solver3.InitialCondition = ic3;
            solver3.Number_of_steps = number_of_steps3;

            solver3.Solve(out float delta_x_3, out NumericalSolution26feb2024<float> solution3);

            double y1_pi_exact = y1_pi_exact_function(eccentricity);
            double y2_pi_exact = y2_pi_exact_function(eccentricity);
            double y3_pi_exact = y3_pi_exact_function(eccentricity);
            double y4_pi_exact = y4_pi_exact_function(eccentricity);

            double[] y_sophisticated = new double[4];
            for (int i = 0; i < 4; i++)
            {
                y_sophisticated[i] = solution3.Y[i];
            }

            double error_sophisticated_1 = Math.Sqrt(Math.Pow((y1_pi_exact - y_sophisticated[0]), 2) + Math.Pow((y2_pi_exact - y_sophisticated[1]), 2) + Math.Pow((y3_pi_exact - y_sophisticated[2]), 2) + Math.Pow((y4_pi_exact - y_sophisticated[3]), 2));
            Console.WriteLine("error_sophisticated_1 = " + error_sophisticated_1);

            ISolverDouble12mar2024 solver4 = solverKeplerFactory.GetSolverDouble12mar2024(Method.RK22);
            solver4.X_end = (double)x_end3;
            solver4.Interval = (double)interval3;
            ConditionInitial26feb2024<double> ic4 = new ConditionInitial26feb2024<double>(0,
                                               (double)y1_zero_exact_function(eccentricity),
                                               (double)y2_zero_exact_function(eccentricity),
                                               (double)y3_zero_exact_function(eccentricity),
                                               (double)y4_zero_exact_function(eccentricity));
            solver4.InitialCondition = ic4;
            solver4.Number_of_steps = number_of_steps3;

            solver4.Solve(out double delta_x_4, out NumericalSolution26feb2024<double> solution4);

            for (int i = 0; i < 4; i++)
            {
                y_sophisticated[i] = solution4.Y[i];
            }

            double error_sophisticated_2 = Math.Sqrt(Math.Pow((y1_pi_exact - y_sophisticated[0]), 2) + Math.Pow((y2_pi_exact - y_sophisticated[1]), 2) + Math.Pow((y3_pi_exact - y_sophisticated[2]), 2) + Math.Pow((y4_pi_exact - y_sophisticated[3]), 2));
            Console.WriteLine("error_sophisticated_2 = " + error_sophisticated_2);
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
