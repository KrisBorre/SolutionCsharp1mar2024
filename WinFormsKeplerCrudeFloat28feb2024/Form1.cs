using LibraryDifferentialEquationKepler26Feb2024;
using LibraryDifferentialEquations25Feb2024;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsKeplerCrudeFloat28feb2024
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

Reference: Numerical methods for ODEs, Butcher(2008)
           */

            Text = "Sophisticated Runge-Kutta versus crude Runge-Kutta for Kepler's elliptic planetary motion (using single precision floating points and generic numerics)";

            plotView = new PlotView();

            PlotModel plotModel = new PlotModel();

            LineSeries series1 = new LineSeries { MarkerType = MarkerType.Circle, Title = "Sophisticated RK (without accumulation of numerical errors)" };
            LineSeries series2 = new LineSeries { MarkerType = MarkerType.Circle, Title = "Crude RK (with accumulation of numerical errors)" };

            plotModel.Legends.Add(new Legend()
            {
                LegendTitle = "Legend",
                LegendPosition = LegendPosition.TopLeft,
            });

            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-4.9, -4.8), Text = "Many steps" });
            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-1.1, -2.2), Text = "Few steps" });
            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-4.5, -5.5), Text = "Accurate" });
            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-1.5, -1), Text = "Inaccurate" });

            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-3, -5.5), Text = "Log10(delta_x)" });
            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-4.8, -3), Text = "Log10(abs(error))" });

            plotView.Location = new Point(0, 0);

            const int kmax = 15;

            const double eccentricity = 3.0 / 4.0; // 0.5; // 0;
            Console.WriteLine("eccentricity of the elliptic trajectory of the planet = " + eccentricity);

            Console.WriteLine("Solver with Flags enum");
            var kepler = new DifferentialEquationsKepler<float>();
            int numberOfFirstOrderEquations = kepler.NumberOfFirstOrderEquations;
            ISolver26feb2024<float> solver1 = new DifferentialEquationsSolver26feb2024<float>(kepler, Method.RK41 | Method.Sophisticated);
            ISolver26feb2024<float> solver2 = new DifferentialEquationsSolver26feb2024<float>(kepler, Method.RK41 | Method.Crude);

            double interval = Math.PI;

            ulong number_of_steps = 25;

            for (int k = 0; k < kmax; k++)
            {
                Console.WriteLine("number_of_steps = " + number_of_steps);

                ConditionInitial26feb2024<float> ic = new ConditionInitial26feb2024<float>(0,
                                                         (float)y1_zero_exact_function(eccentricity),
                                                         (float)y2_zero_exact_function(eccentricity),
                                                         (float)y3_zero_exact_function(eccentricity),
                                                         (float)y4_zero_exact_function(eccentricity));
                //ic.X = 0;

                // T interval = T.CreateChecked(Math.PI) // default
                // T x_end = T.CreateChecked(Math.PI) // default
                double x_end = Math.PI;

                solver1.Solve(interval: (float)interval, x_end: (float)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out float delta_x, out NumericalSolution26feb2024<float> solutionSophisticated);
                solver2.Solve(interval: (float)interval, x_end: (float)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out float delta_x_crude, out NumericalSolution26feb2024<float> solutionCrude);

                double y1_pi_exact = y1_pi_exact_function(eccentricity);
                double y2_pi_exact = y2_pi_exact_function(eccentricity);
                double y3_pi_exact = y3_pi_exact_function(eccentricity);
                double y4_pi_exact = y4_pi_exact_function(eccentricity);

                double[] y_sophisticated = new double[numberOfFirstOrderEquations];
                for (int i = 0; i < numberOfFirstOrderEquations; i++)
                {
                    y_sophisticated[i] = solutionSophisticated.Y[i];
                }

                double[] y_crude = new double[numberOfFirstOrderEquations];
                for (int i = 0; i < numberOfFirstOrderEquations; i++)
                {
                    y_crude[i] = solutionCrude.Y[i];
                }

                double error_sophisticated = sqrt(Math.Pow((y1_pi_exact - y_sophisticated[0]), 2) + Math.Pow((y2_pi_exact - y_sophisticated[1]), 2) + Math.Pow((y3_pi_exact - y_sophisticated[2]), 2) + Math.Pow((y4_pi_exact - y_sophisticated[3]), 2));
                Console.WriteLine("error_sophisticated = " + error_sophisticated);

                double error_crude = sqrt(Math.Pow((y1_pi_exact - y_crude[0]), 2) + Math.Pow((y2_pi_exact - y_crude[1]), 2) + Math.Pow((y3_pi_exact - y_crude[2]), 2) + Math.Pow((y4_pi_exact - y_crude[3]), 2));
                Console.WriteLine("error_crude = " + error_crude);

                series1.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(abs(error_sophisticated))));
                series2.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(abs(error_crude))));

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