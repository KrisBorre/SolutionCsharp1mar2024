﻿using LibraryDifferentialEquationKepler26Feb2024;
using LibraryDifferentialEquations25Feb2024;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsKeplerCrudeDouble21mar2024
{
    internal class ControlManager
    {
        private List<Control> controls;

        public List<Control> Controls
        {
            get { return controls; }
        }

        public ControlManager(Size size)
        {
            this.controls = new List<Control>();

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

            PlotView plotView = new PlotView();

            PlotModel plotModel = new PlotModel();

            LineSeries series1 = new LineSeries { MarkerType = MarkerType.Circle, Title = "Sophisticated RK (without accumulation of numerical errors)" };
            LineSeries series2 = new LineSeries { MarkerType = MarkerType.Circle, Title = "Crude RK (with accumulation of numerical errors)" };

            plotModel.Legends.Add(new Legend()
            {
                LegendTitle = "Legend",
                LegendPosition = LegendPosition.TopLeft,
            });

            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-4.5, -12), Text = "Many steps" });
            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-2, -7), Text = "Few steps" });
            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-4.5, -14), Text = "Accurate" });
            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-2.5, -5), Text = "Inaccurate" });

            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-3, -14.7), Text = "Log10(delta_x)" });
            plotModel.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(-4.8, -9), Text = "Log10(abs(error))" });

            plotView.Location = new Point(0, 0);

            const int kmax = 15;

            const double eccentricity = 3.0 / 4.0; // 0.5; // 0;
            Console.WriteLine("eccentricity of the elliptic trajectory of the planet = " + eccentricity);

            Console.WriteLine("Solver with Flags enum");
            var keplerDouble = new DifferentialEquationsKepler<double>();
            int numberOfFirstOrderEquations = keplerDouble.NumberOfFirstOrderEquations;
            ISolver26feb2024<double> solverDoubleSophisticated = new DifferentialEquationsSolver26feb2024<double>(keplerDouble, Method.RK41 | Method.Sophisticated);
            ISolver26feb2024<double> solverDoubleCrude = new DifferentialEquationsSolver26feb2024<double>(keplerDouble, Method.RK41 | Method.Crude);

            double interval = Math.PI;

            ulong number_of_steps = 25;

            for (int k = 0; k < kmax; k++)
            {
                Console.WriteLine("number_of_steps = " + number_of_steps);

                ConditionInitial26feb2024<double> ic = new ConditionInitial26feb2024<double>(0,
                                                         (double)DoubleHelper.y1_zero_exact_function(eccentricity),
                                                         (double)DoubleHelper.y2_zero_exact_function(eccentricity),
                                                         (double)DoubleHelper.y3_zero_exact_function(eccentricity),
                                                         (double)DoubleHelper.y4_zero_exact_function(eccentricity));
                //ic.X = 0;

                // T interval = T.CreateChecked(Math.PI) // default
                // T x_end = T.CreateChecked(Math.PI) // default
                double x_end = Math.PI;

                solverDoubleSophisticated.Solve(interval: (double)interval, x_end: (double)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, out NumericalSolution26feb2024<double> solutionSophisticated);
                solverDoubleCrude.Solve(interval: (double)interval, x_end: (double)x_end, initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x_crude, out NumericalSolution26feb2024<double> solutionCrude);

                double y1_pi_exact = DoubleHelper.y1_pi_exact_function(eccentricity);
                double y2_pi_exact = DoubleHelper.y2_pi_exact_function(eccentricity);
                double y3_pi_exact = DoubleHelper.y3_pi_exact_function(eccentricity);
                double y4_pi_exact = DoubleHelper.y4_pi_exact_function(eccentricity);

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

                double error_sophisticated = DoubleHelper.sqrt(Math.Pow((y1_pi_exact - y_sophisticated[0]), 2) + Math.Pow((y2_pi_exact - y_sophisticated[1]), 2) + Math.Pow((y3_pi_exact - y_sophisticated[2]), 2) + Math.Pow((y4_pi_exact - y_sophisticated[3]), 2));
                Console.WriteLine("error_sophisticated = " + error_sophisticated);

                double error_crude = DoubleHelper.sqrt(Math.Pow((y1_pi_exact - y_crude[0]), 2) + Math.Pow((y2_pi_exact - y_crude[1]), 2) + Math.Pow((y3_pi_exact - y_crude[2]), 2) + Math.Pow((y4_pi_exact - y_crude[3]), 2));
                Console.WriteLine("error_crude = " + error_crude);

                series1.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(DoubleHelper.abs(error_sophisticated))));
                series2.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(DoubleHelper.abs(error_crude))));

                number_of_steps *= 2;
            }

            plotModel.Series.Add(series1);
            plotModel.Series.Add(series2);
            plotView.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            plotView.Size = new Size(size.Width - 50, size.Height - 50);

            plotView.Model = plotModel;
            this.controls.Add(plotView);
        }
    }
}
