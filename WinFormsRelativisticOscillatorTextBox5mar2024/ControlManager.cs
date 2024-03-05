using LibraryDifferentialEquations25Feb2024;
using LibraryRelativisticOscillator3mar2024;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsRelativisticOscillatorTextBox5mar2024
{
    internal class ControlManager
    {
        private List<Control> controls;

        public List<Control> Controls
        {
            get { return controls; }
        }

        private List<PlotView> plotViews;

        public List<PlotView> PlotViews
        {
            get { return plotViews; }
        }

        private TextBox textBox1;
        private ComboBox comboBoxSpring;
        private ComboBox comboBoxMass;

        public ControlManager()
        {
            this.controls = new List<Control>();

            this.comboBoxSpring = new ComboBox();
            this.comboBoxMass = new ComboBox();
            Label label3 = new Label();
            Label label4 = new Label();

            label3.AutoSize = true;
            label3.Location = new Point(453, 15);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 2;
            label3.Text = "Spring:";

            this.comboBoxSpring.FormattingEnabled = true;
            this.comboBoxSpring.Location = new Point(565, 12);
            this.comboBoxSpring.Name = "comboBoxSpring";
            this.comboBoxSpring.Size = new Size(113, 23);
            this.comboBoxSpring.TabIndex = 0;

            label4.AutoSize = true;
            label4.Location = new Point(725, 15);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 3;
            label4.Text = "Mass:";

            this.comboBoxMass.FormattingEnabled = true;
            this.comboBoxMass.Location = new Point(804, 12);
            this.comboBoxMass.Name = "comboBoxMass";
            this.comboBoxMass.Size = new Size(113, 23);
            this.comboBoxMass.TabIndex = 1;

            this.controls.Add(label4);
            this.controls.Add(label3);
            this.controls.Add(this.comboBoxMass);
            this.controls.Add(this.comboBoxSpring);

            this.textBox1 = new TextBox();
            this.textBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.textBox1.Location = new Point(1352, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(54, 22);
            this.textBox1.TabIndex = 0;

            Button button1 = new Button();
            button1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            button1.Location = new Point(1113, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Calculate";
            button1.UseVisualStyleBackColor = true;
            button1.MouseClick += new MouseEventHandler(this.button1_MouseClick);

            Label label2 = new Label();
            label2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            label2.AutoSize = true;
            label2.Location = new Point(1232, 15);
            label2.Name = "label2";
            label2.Size = new Size(45, 17);
            label2.TabIndex = 2;
            label2.Text = "Ratio of v over c:";

            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new Point(13, 13);
            label1.Name = "label1";
            label1.Size = new Size(46, 18);
            label1.TabIndex = 0;

            label1.Text = "Solving a system of differential equations: Relativistic oscillator.";

            this.controls.Add(label1);
            this.controls.Add(label2);
            this.controls.Add(button1);
            this.controls.Add(this.textBox1);

            this.comboBoxSpring.Items.AddRange(new string[] { "Constant", "Decrease", "Increase" });
            this.comboBoxMass.Items.AddRange(new string[] { "Constant", "Decrease", "Increase" });
            this.comboBoxSpring.SelectedIndex = 0;
            this.comboBoxMass.SelectedIndex = 0;

            int width = 1456;
            int height = 557;

            this.plotViews = new List<PlotView>();
            int numberOfPlots = 4;
            for (int i = 0; i < numberOfPlots; i++)
            {
                PlotView plotView = new PlotView();
                this.controls.Add(plotView);
                plotView.Size = new Size(width, (height - 40) / numberOfPlots);
                plotView.Location = new Point(0, 40 + i * ((height - 40) / numberOfPlots));
                this.plotViews.Add(plotView);
            }

            double ratio = 0.9;

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            this.textBox1.Text = ratio.ToString(provider);

            this.Calculate(ratio);
        }


        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            string input = this.textBox1.Text;

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            if (double.TryParse(s: input, style: System.Globalization.NumberStyles.AllowDecimalPoint, provider: provider, result: out double ratio)
                && (ratio > 0 && ratio < 1))
            {
                this.Calculate(ratio);
            }
            else
            {
                ratio = 0.9;
                this.textBox1.Text = ratio.ToString(provider);
                this.Calculate(ratio);
            }
        }

        private void Calculate(double ratio)
        {
            Console.WriteLine("Don’t wait for your feelings to change to take the action. Take the action and your feelings will change.");
            ulong number_of_oscillations = 100;
            double interval = number_of_oscillations * 5.0 * 2.0 * Math.PI;  // 5.0 * 2.0 * Math.PI; // 5 oscillations    

            ulong number_of_steps = number_of_oscillations * 1000;

            ParameterConfiguration spring_configuration = ParameterConfiguration.Constant;
            if (this.comboBoxSpring.SelectedIndex == 1)
            {
                spring_configuration = ParameterConfiguration.Decrease;
            }
            else if (this.comboBoxSpring.SelectedIndex == 2)
            {
                spring_configuration = ParameterConfiguration.Increase;
            }

            ParameterConfiguration mass_configuration = ParameterConfiguration.Constant;
            if (this.comboBoxMass.SelectedIndex == 1)
            {
                mass_configuration = ParameterConfiguration.Decrease;
            }
            else if (this.comboBoxMass.SelectedIndex == 2)
            {
                mass_configuration = ParameterConfiguration.Increase;
            }

            var problem = new DifferentialEquationsRelativisticOscillator3mar2024<double>(spring_configuration: spring_configuration, mass_configuration: mass_configuration);

            var solver = new DifferentialEquationsSolver26feb2024<double>(problem, Method.RKCV8);

            var ic = new ConditionInitial26feb2024<double>(0,
                                           0.0,
                                           ratio);

            Cursor.Current = Cursors.WaitCursor;

            solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, solutions: out NumericalSolutions26feb2024<double> solutions, number_of_solutions: (int)(1000 * number_of_oscillations), interval: interval, x_end: interval);

            Cursor.Current = Cursors.Default;

            #region          Spring
            {
                PlotModel plotModel0 = new PlotModel();
                LineSeries series0 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution26feb2024<double> solution = solutions[i];
                    series0.Points.Add(new DataPoint(solution.X, problem.GetSpring(interval, solution.X)));
                }

                plotModel0.Series.Add(series0);
                plotModel0.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 1), Text = "Spring" });

                this.plotViews[0].Model = plotModel0;
            }
            #endregion


            #region          Mass
            {
                PlotModel plotModel1 = new PlotModel();
                LineSeries series1 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution26feb2024<double> solution = solutions[i];
                    series1.Points.Add(new DataPoint(solution.X, problem.GetMass(interval, solution.X)));
                }

                plotModel1.Series.Add(series1);
                plotModel1.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 1), Text = "Mass" });

                this.plotViews[1].Model = plotModel1;
            }
            #endregion

            #region       Displacement
            {
                PlotModel plotModel2 = new PlotModel();
                LineSeries series2 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution26feb2024<double> solution = solutions[i];
                    series2.Points.Add(new DataPoint(solution.X, solution.Y[0]));
                }

                plotModel2.Series.Add(series2);
                plotModel2.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 0), Text = "Displacement" });

                this.plotViews[2].Model = plotModel2;
            }
            #endregion

            #region          Energy
            {
                PlotModel plotModel3 = new PlotModel();
                LineSeries series3 = new LineSeries();

                double[] energies = new double[solutions.Length];

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution26feb2024<double> solution = solutions[i];
                    double energy = this.energy_function(k: problem.GetSpring(interval, solution.X), m: problem.GetMass(interval, solution.X), y1: solution.Y[0], y2: solution.Y[1]);
                    energies[i] = energy;
                    series3.Points.Add(new DataPoint(solution.X, energy));
                }

                double energyMax = energies.Max();
                double energyMin = energies.Min();
                double y = energyMin + (energyMax - energyMin) / 2.0;

                plotModel3.Series.Add(series3);
                plotModel3.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, y), Text = "Energy" });

                this.plotViews[3].Model = plotModel3;
            }
            #endregion
        }

        private double energy_function(double k, double m, double y1, double y2)
        {
            //double kinetic_energy = (m * y2 * y2) / 2.0; // non-relativistic
            double gamma = Math.Pow(1 - y2 * y2, -0.5);
            double kinetic_energy = gamma * m;
            double potential_energy = (k * y1 * y1) / 2.0;
            return kinetic_energy + potential_energy;
        }
    }

}
