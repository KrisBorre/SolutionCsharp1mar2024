using LibraryDifferentialEquationKepler26Feb2024;
using LibraryDifferentialEquations25Feb2024;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsKeplerCrudeDecimal20mar2024
{
    public partial class Form1 : Form
    {
        private PlotView plotView;

        public Form1()
        {
            InitializeComponent();

            /*
Comparison between crude Runge-Kutta calculation and sophisticated Runge-Kutta calculation. 
The graph shows the numerical error of the calculation as a function of the stepsize for both, crude(orange) and sophisticated(blue).
You read this graph from top-left to bottom-right.
With a large stepsize the numerical error on the solution decreases when the stepsize is reduced.
As the stepsize decreases the numerical error gets smaller until it reaches machine-epsilon using sophisticated Runge-Kutta.

When we use a Runge-Kutta algorithm -- which I call crude Runge-Kutta -- and continue to lower the stepsize in an attempt to improve the accuracy of the result, the accumulation of the numerical error starts to dominate over the solution, rendering our computational effort worthless. 
We can study this pathological behaviour when we use a system of differential equations that we can solve analytically.
Here I pick Kepler's planetary motion. A planet moves around the Sun in an elliptic orbit. 
The equations of motion are ordinary differential equations and are numerically calculated using a Runge-Kutta method.

An Euler method or a higher order method, like Runge-Kutta, will both have a similar accumulation error for a certain stepsize.
We can correct for this accumulation of numerical errors and I call this method sophisticated Runge-Kutta.

For the numerical type 'decimal' crude RK and sophisticated RK give exactly the same accuracy.

Reference: Numerical methods for ODEs, Butcher(2008)
           */

            Text = "Sophisticated Runge-Kutta versus crude Runge-Kutta for Kepler's elliptic planetary motion (using the decimal type)";

            plotView = new PlotView();

            PlotModel plotModel = new PlotModel();

            LineSeries series1 = new LineSeries { MarkerType = MarkerType.Circle, Title = "Sophisticated RK (without accumulation of numerical errors)" };
            LineSeries series2 = new LineSeries { MarkerType = MarkerType.Circle, Title = "Crude RK (with accumulation of numerical errors)" };

            plotModel.Legends.Add(new Legend()
            {
                LegendTitle = "Legend",
                LegendPosition = LegendPosition.TopLeft,
            });

            plotView.Location = new Point(0, 0);

            // We can only get 12 points, not more.
            // 10E-14 is smallest accuracy that we can get with decimals.
            // The smallest stepsize is 10E-4.2
            // Crude RK and Sophisticated RK give for decimals exactly the same.

            const int kmax = 12; // 13; // 10; // 21; // 20; // 15;

            const decimal eccentricity = (decimal)(3.0 / 4.0); // 0.5; // 0;
            Console.WriteLine("eccentricity of the elliptic trajectory of the planet = " + eccentricity);

            Console.WriteLine("Solver with Flags enum");
            var kepler = new DifferentialEquationsKepler<decimal>();
            int numberOfFirstOrderEquations = kepler.NumberOfFirstOrderEquations;
            ISolver26feb2024<decimal> solver1 = new DifferentialEquationsSolver26feb2024<decimal>(kepler, Method.RK41 | Method.Sophisticated);
            ISolver26feb2024<decimal> solver2 = new DifferentialEquationsSolver26feb2024<decimal>(kepler, Method.RK41 | Method.Crude);

            decimal interval = (decimal)Math.PI;

            ulong number_of_steps = 25;

            for (int k = 0; k < kmax; k++)
            {
                Console.WriteLine("number_of_steps = " + number_of_steps);

                ConditionInitial26feb2024<decimal> ic = new ConditionInitial26feb2024<decimal>(0,
                                                         y1_zero_exact_function(eccentricity),
                                                         y2_zero_exact_function(eccentricity),
                                                         y3_zero_exact_function(eccentricity),
                                                         y4_zero_exact_function(eccentricity));
                //ic.X = 0;

                // T interval = T.CreateChecked(Math.PI) // default
                // T x_end = T.CreateChecked(Math.PI) // default
                decimal x_end = (decimal)Math.PI;

                solver1.Solve(interval: interval, x_end: x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out decimal delta_x, out NumericalSolution26feb2024<decimal> solutionSophisticated);
                solver2.Solve(interval: interval, x_end: x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out decimal delta_x_crude, out NumericalSolution26feb2024<decimal> solutionCrude);

                decimal y1_pi_exact = y1_pi_exact_function(eccentricity);
                decimal y2_pi_exact = y2_pi_exact_function(eccentricity);
                decimal y3_pi_exact = y3_pi_exact_function(eccentricity);
                decimal y4_pi_exact = y4_pi_exact_function(eccentricity);

                decimal[] y_sophisticated = new decimal[numberOfFirstOrderEquations];
                for (int i = 0; i < numberOfFirstOrderEquations; i++)
                {
                    y_sophisticated[i] = solutionSophisticated.Y[i];
                }

                decimal[] y_crude = new decimal[numberOfFirstOrderEquations];
                for (int i = 0; i < numberOfFirstOrderEquations; i++)
                {
                    y_crude[i] = solutionCrude.Y[i];
                }

                decimal error_sophisticated = (decimal)sqrt((double)(((y1_pi_exact - y_sophisticated[0]) * (y1_pi_exact - y_sophisticated[0])) + ((y2_pi_exact - y_sophisticated[1]) * (y2_pi_exact - y_sophisticated[1])) + ((y3_pi_exact - y_sophisticated[2]) * (y3_pi_exact - y_sophisticated[2])) + ((y4_pi_exact - y_sophisticated[3]) * (y4_pi_exact - y_sophisticated[3]))));
                Console.WriteLine("error_sophisticated = " + error_sophisticated);

                decimal error_crude = (decimal)sqrt((double)(((y1_pi_exact - y_crude[0]) * (y1_pi_exact - y_crude[0])) + ((y2_pi_exact - y_crude[1]) * (y2_pi_exact - y_crude[1])) + ((y3_pi_exact - y_crude[2]) * (y3_pi_exact - y_crude[2])) + ((y4_pi_exact - y_crude[3]) * (y4_pi_exact - y_crude[3]))));
                Console.WriteLine("error_crude = " + error_crude);

                series1.Points.Add(new DataPoint(Math.Log10((double)delta_x), Math.Log10((double)abs(error_sophisticated))));
                series2.Points.Add(new DataPoint(Math.Log10((double)delta_x), Math.Log10((double)abs(error_crude))));

                number_of_steps *= 2;
            }

            plotModel.Series.Add(series1);
            plotModel.Series.Add(series2);
            this.plotView.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            this.plotView.Size = new Size(this.Size.Width - 50, this.Size.Height - 50);

            this.plotView.Model = plotModel;
            Controls.Add(plotView);
        }


        static double sqrt(double x)
        {
            return Math.Sqrt(x);
        }

        static decimal abs(decimal x)
        {
            return Math.Abs(x);
        }


        static decimal y1_zero_exact_function(decimal eccentricity)
        {
            return 1 - eccentricity;
        }

        static decimal y2_zero_exact_function(decimal eccentricity)
        {
            return 0;
        }

        static decimal y3_zero_exact_function(decimal eccentricity)
        {
            return 0;
        }

        static decimal y4_zero_exact_function(decimal eccentricity)
        {
            return (decimal)sqrt((double)((1 + eccentricity) / (1 - eccentricity)));
        }


        static decimal y1_pi_exact_function(decimal eccentricity)
        {
            return -1 - eccentricity;
        }

        static decimal y2_pi_exact_function(decimal eccentricity)
        {
            return 0;
        }

        static decimal y3_pi_exact_function(decimal eccentricity)
        {
            return 0;
        }

        static decimal y4_pi_exact_function(decimal eccentricity)
        {
            return -(decimal)sqrt((double)((1 - eccentricity) / (1 + eccentricity))); // Notice the minus and plus sign!
        }
    }
}