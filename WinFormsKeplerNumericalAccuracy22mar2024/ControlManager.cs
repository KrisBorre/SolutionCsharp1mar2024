using LibraryDifferentialEquationKepler26Feb2024;
using LibraryDifferentialEquations25Feb2024;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsKeplerNumericalAccuracy22mar2024
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

            PlotView plotView = new PlotView();
            PlotModel plotModel = new PlotModel();

            LineSeries seriesDoubleSophisticated = new LineSeries { MarkerType = MarkerType.Circle, Title = "Double Sophisticated RK41 (without accumulation of numerical errors)" };
            LineSeries seriesDoubleCrude = new LineSeries { MarkerType = MarkerType.Circle, Title = "Double Crude RK41 (with accumulation of numerical errors)" };

            LineSeries seriesFloatSophisticated = new LineSeries { MarkerType = MarkerType.Circle, Title = "Float Sophisticated RK31 (without accumulation of numerical errors)" };
            LineSeries seriesFloatCrude = new LineSeries { MarkerType = MarkerType.Circle, Title = "Float Crude RK31 (with accumulation of numerical errors)" };

            LineSeries seriesDecimalSophisticated = new LineSeries { MarkerType = MarkerType.Circle, Title = "Decimal Sophisticated RK61 (without accumulation of numerical errors)" };
            LineSeries seriesDecimalCrude = new LineSeries { MarkerType = MarkerType.Circle, Title = "Decimal Crude RK5 (with accumulation of numerical errors)" };


            plotModel.Legends.Add(new Legend()
            {
                LegendTitle = "Legend",
                LegendPosition = LegendPosition.TopLeft,
            });

            plotView.Location = new Point(0, 0);


            {
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

                    seriesDoubleSophisticated.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(DoubleHelper.abs(error_sophisticated))));
                    seriesDoubleCrude.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(DoubleHelper.abs(error_crude))));

                    number_of_steps *= 2;
                }
            }

            {
                const int kmax = 15;

                const double eccentricity = 3.0 / 4.0; // 0.5; // 0;
                Console.WriteLine("eccentricity of the elliptic trajectory of the planet = " + eccentricity);

                Console.WriteLine("Solver with Flags enum");
                var keplerFloat = new DifferentialEquationsKepler<float>();
                int numberOfFirstOrderEquations = keplerFloat.NumberOfFirstOrderEquations;
                ISolver26feb2024<float> solverFloatSophisticated = new DifferentialEquationsSolver26feb2024<float>(keplerFloat, Method.RK31 | Method.Sophisticated);
                ISolver26feb2024<float> solverFloatCrude = new DifferentialEquationsSolver26feb2024<float>(keplerFloat, Method.RK31 | Method.Crude);

                double interval = Math.PI;

                ulong number_of_steps = 25;

                for (int k = 0; k < kmax; k++)
                {
                    Console.WriteLine("number_of_steps = " + number_of_steps);

                    ConditionInitial26feb2024<float> initialConditionFloat = new ConditionInitial26feb2024<float>(0,
                                                             (float)DoubleHelper.y1_zero_exact_function(eccentricity),
                                                             (float)DoubleHelper.y2_zero_exact_function(eccentricity),
                                                             (float)DoubleHelper.y3_zero_exact_function(eccentricity),
                                                             (float)DoubleHelper.y4_zero_exact_function(eccentricity));
                    //ic.X = 0;

                    // T interval = T.CreateChecked(Math.PI) // default
                    // T x_end = T.CreateChecked(Math.PI) // default
                    double x_end = Math.PI;

                    solverFloatSophisticated.Solve(interval: (float)interval, x_end: (float)x_end, initialCondition: initialConditionFloat, number_of_steps: number_of_steps, delta_x: out float delta_x, out NumericalSolution26feb2024<float> solutionSophisticated);
                    solverFloatCrude.Solve(interval: (float)interval, x_end: (float)x_end, initialCondition: initialConditionFloat, number_of_steps: number_of_steps, delta_x: out float delta_x_crude, out NumericalSolution26feb2024<float> solutionCrude);

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

                    double float_error_sophisticated = DoubleHelper.sqrt(Math.Pow((y1_pi_exact - y_sophisticated[0]), 2) + Math.Pow((y2_pi_exact - y_sophisticated[1]), 2) + Math.Pow((y3_pi_exact - y_sophisticated[2]), 2) + Math.Pow((y4_pi_exact - y_sophisticated[3]), 2));
                    Console.WriteLine("error_sophisticated = " + float_error_sophisticated);

                    double float_error_crude = DoubleHelper.sqrt(Math.Pow((y1_pi_exact - y_crude[0]), 2) + Math.Pow((y2_pi_exact - y_crude[1]), 2) + Math.Pow((y3_pi_exact - y_crude[2]), 2) + Math.Pow((y4_pi_exact - y_crude[3]), 2));
                    Console.WriteLine("error_crude = " + float_error_crude);

                    seriesFloatSophisticated.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(DoubleHelper.abs(float_error_sophisticated))));
                    seriesFloatCrude.Points.Add(new DataPoint(Math.Log10(delta_x), Math.Log10(DoubleHelper.abs(float_error_crude))));

                    number_of_steps *= 2;
                }
            }

            {
                const int kmax = 12; // 13; // 10; // 21; // 20; // 15;

                const decimal eccentricity = (decimal)(3.0 / 4.0); // 0.5; // 0;
                Console.WriteLine("eccentricity of the elliptic trajectory of the planet = " + eccentricity);

                Console.WriteLine("Solver with Flags enum");
                var keplerDecimal = new DifferentialEquationsKepler<decimal>();
                int numberOfFirstOrderEquations = keplerDecimal.NumberOfFirstOrderEquations;
                ISolver26feb2024<decimal> solverDecimalSophisticated = new DifferentialEquationsSolver26feb2024<decimal>(keplerDecimal, Method.RK61 | Method.Sophisticated);
                ISolver26feb2024<decimal> solverDecimalCrude = new DifferentialEquationsSolver26feb2024<decimal>(keplerDecimal, Method.RK5 | Method.Crude);

                decimal interval = (decimal)Math.PI;

                ulong number_of_steps = 25;

                for (int k = 0; k < kmax; k++)
                {
                    Console.WriteLine("number_of_steps = " + number_of_steps);

                    ConditionInitial26feb2024<decimal> initialConditionDecimal = new ConditionInitial26feb2024<decimal>(0,
                                                             DecimalHelper.y1_zero_exact_function(eccentricity),
                                                             DecimalHelper.y2_zero_exact_function(eccentricity),
                                                             DecimalHelper.y3_zero_exact_function(eccentricity),
                                                             DecimalHelper.y4_zero_exact_function(eccentricity));
                    //ic.X = 0;

                    // T interval = T.CreateChecked(Math.PI) // default
                    // T x_end = T.CreateChecked(Math.PI) // default
                    decimal x_end = (decimal)Math.PI;

                    solverDecimalSophisticated.Solve(interval: interval, x_end: x_end, initialCondition: initialConditionDecimal, number_of_steps: number_of_steps, delta_x: out decimal delta_x, out NumericalSolution26feb2024<decimal> solutionSophisticated);
                    solverDecimalCrude.Solve(interval: interval, x_end: x_end, initialCondition: initialConditionDecimal, number_of_steps: number_of_steps, delta_x: out decimal delta_x_crude, out NumericalSolution26feb2024<decimal> solutionCrude);

                    decimal y1_pi_exact = DecimalHelper.y1_pi_exact_function(eccentricity);
                    decimal y2_pi_exact = DecimalHelper.y2_pi_exact_function(eccentricity);
                    decimal y3_pi_exact = DecimalHelper.y3_pi_exact_function(eccentricity);
                    decimal y4_pi_exact = DecimalHelper.y4_pi_exact_function(eccentricity);

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

                    decimal decimal_error_sophisticated = (decimal)DecimalHelper.sqrt((double)(((y1_pi_exact - y_sophisticated[0]) * (y1_pi_exact - y_sophisticated[0])) + ((y2_pi_exact - y_sophisticated[1]) * (y2_pi_exact - y_sophisticated[1])) + ((y3_pi_exact - y_sophisticated[2]) * (y3_pi_exact - y_sophisticated[2])) + ((y4_pi_exact - y_sophisticated[3]) * (y4_pi_exact - y_sophisticated[3]))));
                    Console.WriteLine("error_sophisticated = " + decimal_error_sophisticated);

                    decimal decimal_error_crude = (decimal)DecimalHelper.sqrt((double)(((y1_pi_exact - y_crude[0]) * (y1_pi_exact - y_crude[0])) + ((y2_pi_exact - y_crude[1]) * (y2_pi_exact - y_crude[1])) + ((y3_pi_exact - y_crude[2]) * (y3_pi_exact - y_crude[2])) + ((y4_pi_exact - y_crude[3]) * (y4_pi_exact - y_crude[3]))));
                    Console.WriteLine("error_crude = " + decimal_error_crude);

                    seriesDecimalSophisticated.Points.Add(new DataPoint(Math.Log10((double)delta_x), Math.Log10((double)DecimalHelper.abs(decimal_error_sophisticated))));
                    seriesDecimalCrude.Points.Add(new DataPoint(Math.Log10((double)delta_x), Math.Log10((double)DecimalHelper.abs(decimal_error_crude))));

                    number_of_steps *= 2;
                }
            }


            plotModel.Series.Add(seriesFloatCrude);
            plotModel.Series.Add(seriesFloatSophisticated);

            plotModel.Series.Add(seriesDoubleCrude);
            plotModel.Series.Add(seriesDoubleSophisticated);

            plotModel.Series.Add(seriesDecimalCrude);
            plotModel.Series.Add(seriesDecimalSophisticated);

            plotView.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            plotView.Size = new Size(size.Width - 50, size.Height - 50);

            plotView.Model = plotModel;
            this.controls.Add(plotView);

        }

    }
}
