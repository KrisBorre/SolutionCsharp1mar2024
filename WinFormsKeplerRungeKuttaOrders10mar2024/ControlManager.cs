using LibraryDifferentialEquationKepler26Feb2024;
using LibraryDifferentialEquations25Feb2024;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsKeplerRungeKuttaOrders10mar2024
{
    internal class ControlManager
    {
        private List<Control> controls;

        public List<Control> Controls
        {
            get { return controls; }
        }

        private PlotView plotView;

        public ControlManager()
        {
            /*
Comparison different Runge-Kutta methods.
The graph shows the numerical error of the calculation as a function of the stepsize.
You read this graph from top-left to bottom-right.
With a large stepsize the numerical error on the solution decreases when the stepsize is reduced.
As the stepsize decreases the numerical error gets smaller until it reaches machine-epsilon using sophisticated Runge-Kutta.

Here I pick Kepler's planetary motion. A planet moves around the Sun in an elliptic orbit. 
The equations of motion are ordinary differential equations and are numerically calculated using a Runge-Kutta method.

Reference: Numerical methods for ODEs, Butcher(2008)
           */
            this.controls = new List<Control>();

            this.plotView = new PlotView();

            PlotModel plotModel = new PlotModel();

            LineSeries series1 = new LineSeries { MarkerType = MarkerType.Circle, Title = "Euler" };
            LineSeries series2 = new LineSeries { MarkerType = MarkerType.Circle, Title = "RK21" };
            LineSeries series3 = new LineSeries { MarkerType = MarkerType.Circle, Title = "RK31" };
            LineSeries series4 = new LineSeries { MarkerType = MarkerType.Circle, Title = "RK41" };
            LineSeries series5 = new LineSeries { MarkerType = MarkerType.Circle, Title = "RK5" };
            LineSeries series6 = new LineSeries { MarkerType = MarkerType.Circle, Title = "RK61" };
            LineSeries series7 = new LineSeries { MarkerType = MarkerType.Circle, Title = "RKCV8" };

            plotModel.Legends.Add(new Legend()
            {
                LegendTitle = "Legend",
                LegendPosition = LegendPosition.TopLeft,
            });

            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-3, -14.7), Text = "Log10(delta_x)" });
            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-4.9, -9), Text = "Log10(abs(error))" });

            plotModel.Axes.Add(new LinearAxis
            {
                Maximum = 1,
                Minimum = -15,
                Position = AxisPosition.Left
            });

            this.plotView.Location = new Point(0, 0);

            const int kmax = 15;

            const double eccentricity = 3.0 / 4.0; // 0.5; // 0;
            Console.WriteLine("eccentricity of the elliptic trajectory of the planet = " + eccentricity);

            Console.WriteLine("Solver with Flags enum");
            var kepler = new DifferentialEquationsKepler<double>();
            int numberOfFirstOrderEquations = kepler.NumberOfFirstOrderEquations;

            var solver1 = new DifferentialEquationsSolver26feb2024<double>(kepler, Method.Euler | Method.Sophisticated);
            var solver2 = new DifferentialEquationsSolver26feb2024<double>(kepler, Method.RK21 | Method.Sophisticated);
            var solver3 = new DifferentialEquationsSolver26feb2024<double>(kepler, Method.RK31 | Method.Sophisticated);
            var solver4 = new DifferentialEquationsSolver26feb2024<double>(kepler, Method.RK41 | Method.Sophisticated);
            var solver5 = new DifferentialEquationsSolver26feb2024<double>(kepler, Method.RK5 | Method.Sophisticated);
            var solver6 = new DifferentialEquationsSolver26feb2024<double>(kepler, Method.RK61 | Method.Sophisticated);
            var solver7 = new DifferentialEquationsSolver26feb2024<double>(kepler, Method.RKCV8 | Method.Sophisticated);

            double interval = Math.PI;
            double x_end = Math.PI;

            ulong number_of_steps = 25;

            for (int k = 0; k < kmax; k++)
            {
                Console.WriteLine("number_of_steps = " + number_of_steps);

                ConditionInitial26feb2024<double> ic = new ConditionInitial26feb2024<double>(0,
                                                         (double)y1_zero_exact_function(eccentricity),
                                                         (double)y2_zero_exact_function(eccentricity),
                                                         (double)y3_zero_exact_function(eccentricity),
                                                         (double)y4_zero_exact_function(eccentricity));
                //ic.X = 0;                

                solver1.Solve(interval: (double)interval, x_end: (double)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, solution: out NumericalSolution26feb2024<double> solutionEuler);
                solver2.Solve(interval: (double)interval, x_end: (double)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x_2, solution: out NumericalSolution26feb2024<double> solutionRK21);
                solver3.Solve(interval: (double)interval, x_end: (double)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x_3, solution: out NumericalSolution26feb2024<double> solutionRK31);
                solver4.Solve(interval: (double)interval, x_end: (double)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x_4, solution: out NumericalSolution26feb2024<double> solutionRK41);
                solver5.Solve(interval: (double)interval, x_end: (double)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x_5, solution: out NumericalSolution26feb2024<double> solutionRK5);
                solver6.Solve(interval: (double)interval, x_end: (double)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x_6, solution: out NumericalSolution26feb2024<double> solutionRK61);
                solver7.Solve(interval: (double)interval, x_end: (double)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x_7, solution: out NumericalSolution26feb2024<double> solutionRKCV8);

                double y1_pi_exact = y1_pi_exact_function(eccentricity);
                double y2_pi_exact = y2_pi_exact_function(eccentricity);
                double y3_pi_exact = y3_pi_exact_function(eccentricity);
                double y4_pi_exact = y4_pi_exact_function(eccentricity);

                double[] y_Euler = new double[numberOfFirstOrderEquations];
                for (int i = 0; i < numberOfFirstOrderEquations; i++)
                {
                    y_Euler[i] = solutionEuler.Y[i];
                }

                double[] y_RK21 = new double[numberOfFirstOrderEquations];
                for (int i = 0; i < numberOfFirstOrderEquations; i++)
                {
                    y_RK21[i] = solutionRK21.Y[i];
                }

                double[] y_RK31 = new double[numberOfFirstOrderEquations];
                for (int i = 0; i < numberOfFirstOrderEquations; i++)
                {
                    y_RK31[i] = solutionRK31.Y[i];
                }

                double[] y_RK41 = new double[numberOfFirstOrderEquations];
                for (int i = 0; i < numberOfFirstOrderEquations; i++)
                {
                    y_RK41[i] = solutionRK41.Y[i];
                }

                double[] y_RK5 = new double[numberOfFirstOrderEquations];
                for (int i = 0; i < numberOfFirstOrderEquations; i++)
                {
                    y_RK5[i] = solutionRK5.Y[i];
                }

                double[] y_RK61 = new double[numberOfFirstOrderEquations];
                for (int i = 0; i < numberOfFirstOrderEquations; i++)
                {
                    y_RK61[i] = solutionRK61.Y[i];
                }

                double[] y_RKCV8 = new double[numberOfFirstOrderEquations];
                for (int i = 0; i < numberOfFirstOrderEquations; i++)
                {
                    y_RKCV8[i] = solutionRKCV8.Y[i];
                }

                double error_Euler = sqrt(Math.Pow((y1_pi_exact - y_Euler[0]), 2) + Math.Pow((y2_pi_exact - y_Euler[1]), 2) + Math.Pow((y3_pi_exact - y_Euler[2]), 2) + Math.Pow((y4_pi_exact - y_Euler[3]), 2));
                double error_RK21 = sqrt(Math.Pow((y1_pi_exact - y_RK21[0]), 2) + Math.Pow((y2_pi_exact - y_RK21[1]), 2) + Math.Pow((y3_pi_exact - y_RK21[2]), 2) + Math.Pow((y4_pi_exact - y_RK21[3]), 2));
                double error_RK31 = sqrt(Math.Pow((y1_pi_exact - y_RK31[0]), 2) + Math.Pow((y2_pi_exact - y_RK31[1]), 2) + Math.Pow((y3_pi_exact - y_RK31[2]), 2) + Math.Pow((y4_pi_exact - y_RK31[3]), 2));
                double error_RK41 = sqrt(Math.Pow((y1_pi_exact - y_RK41[0]), 2) + Math.Pow((y2_pi_exact - y_RK41[1]), 2) + Math.Pow((y3_pi_exact - y_RK41[2]), 2) + Math.Pow((y4_pi_exact - y_RK41[3]), 2));
                double error_RK5 = sqrt(Math.Pow((y1_pi_exact - y_RK5[0]), 2) + Math.Pow((y2_pi_exact - y_RK5[1]), 2) + Math.Pow((y3_pi_exact - y_RK5[2]), 2) + Math.Pow((y4_pi_exact - y_RK5[3]), 2));
                double error_RK61 = sqrt(Math.Pow((y1_pi_exact - y_RK61[0]), 2) + Math.Pow((y2_pi_exact - y_RK61[1]), 2) + Math.Pow((y3_pi_exact - y_RK61[2]), 2) + Math.Pow((y4_pi_exact - y_RK61[3]), 2));
                double error_RKCV8 = sqrt(Math.Pow((y1_pi_exact - y_RKCV8[0]), 2) + Math.Pow((y2_pi_exact - y_RKCV8[1]), 2) + Math.Pow((y3_pi_exact - y_RKCV8[2]), 2) + Math.Pow((y4_pi_exact - y_RKCV8[3]), 2));

                series1.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(abs(error_Euler))));
                series2.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(abs(error_RK21))));
                series3.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(abs(error_RK31))));
                series4.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(abs(error_RK41))));
                series5.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(abs(error_RK5))));
                series6.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(abs(error_RK61))));
                series7.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(abs(error_RKCV8))));

                number_of_steps *= 2;
            }

            plotModel.Series.Add(series1);
            plotModel.Series.Add(series2);
            plotModel.Series.Add(series3);
            plotModel.Series.Add(series4);
            plotModel.Series.Add(series5);
            plotModel.Series.Add(series6);
            plotModel.Series.Add(series7);

            this.plotView.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            this.plotView.Size = new Size(1317 - 40, 672 - 40);

            this.plotView.Model = plotModel;

            this.controls.Add(plotView);
        }


        static double sqrt(double x)
        {
            return Math.Sqrt(x);
        }

        static double abs(double x)
        {
            return Math.Abs(x);
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
    }
}
