using LibraryDifferentialEquationKepler26Feb2024;
using LibraryDifferentialEquations25Feb2024;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsKepler2mar2024
{
    internal class ControlManager
    {
        private List<Control> controls;
        private TextBox textBox;
        private ComboBox comboBoxExoplanet;
        private ComboBox comboBoxStar;

        private List<PlotView> plotViews;

        public List<Control> Controls
        {
            get { return controls; }
        }

        public List<PlotView> PlotViews
        {
            get { return plotViews; }
        }

        public ControlManager()
        {
            this.controls = new List<Control>();

            ComboBox comboBoxExoplanet1;
            ComboBox comboBoxStar2;
            Label label3;
            Label label4;

            Label label1;
            TextBox textBox1;
            Button button1;
            Label label2;

            comboBoxExoplanet1 = new ComboBox();
            comboBoxStar2 = new ComboBox();
            label3 = new Label();
            label4 = new Label();

            comboBoxExoplanet1.FormattingEnabled = true;
            comboBoxExoplanet1.Location = new Point(565, 12);
            comboBoxExoplanet1.Name = "comboBoxExoplanet";
            comboBoxExoplanet1.Size = new Size(113, 23);
            comboBoxExoplanet1.TabIndex = 0;

            comboBoxStar2.FormattingEnabled = true;
            comboBoxStar2.Location = new Point(804, 12);
            comboBoxStar2.Name = "comboBoxStar";
            comboBoxStar2.Size = new Size(113, 23);
            comboBoxStar2.TabIndex = 1;

            label3.AutoSize = true;
            label3.Location = new Point(453, 15);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 2;
            label3.Text = "Mass of exoplanet:";

            label4.AutoSize = true;
            label4.Location = new Point(725, 15);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 3;
            label4.Text = "Mass of star:";

            Console.WriteLine("Kepler's planetary motion.");
            Console.WriteLine("Planet moves around the Sun in an elliptic orbit.");
            Console.WriteLine("The equations of motion are ordinary differential equations and are numerically calculated using a Runge-Kutta method.");

            textBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();

            textBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            textBox1.Location = new Point(1352, 13);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(54, 22);
            textBox1.TabIndex = 0;

            button1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            button1.Location = new Point(1013, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Calculate";
            button1.UseVisualStyleBackColor = true;
            button1.MouseClick += new MouseEventHandler(button1_MouseClick);

            label2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            label2.AutoSize = true;
            label2.Location = new Point(1132, 15);
            label2.Name = "label2";
            label2.Size = new Size(45, 17);
            label2.TabIndex = 2;
            label2.Text = "Eccentricity (between 0 and 1):";

            label1 = new Label();
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new Point(13, 13);
            label1.Name = "label1";
            label1.Size = new Size(46, 18);
            label1.TabIndex = 0;

            label1.Text = "Solving a system of differential equations: Star with exoplanet";
            // https://en.wikipedia.org/wiki/List_of_nearest_exoplanets

            comboBoxExoplanet1.Items.AddRange(new string[] { "Constant", "Decrease", "Increase" });
            comboBoxStar2.Items.AddRange(new string[] { "Constant", "Decrease", "Increase" });
            comboBoxExoplanet1.SelectedIndex = 0;
            comboBoxStar2.SelectedIndex = 0;

            double eccentricity = 0.7; // 3. / 4.; // 0.5; // 0;     

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            textBox1.Text = eccentricity.ToString(provider);

            this.textBox = textBox1;

            this.comboBoxExoplanet = comboBoxExoplanet1;
            this.comboBoxStar = comboBoxStar2;

            int width = 1456;
            int height = 557;            

            this.plotViews = new List<PlotView>();
            int numberOfPlots = 4;
            for (int i = 0; i < numberOfPlots; i++)
            {
                PlotView plotView = new PlotView();
                this.Controls.Add(plotView);
                plotView.Size = new Size(width, (height - 40) / numberOfPlots);
                plotView.Location = new Point(0, 40 + i * ((height - 40) / numberOfPlots));
                this.plotViews.Add(plotView);
            }

            this.Calculate(eccentricity);

            this.controls.Add(comboBoxExoplanet1);
            this.controls.Add(comboBoxStar2);
            this.controls.Add(label3);
            this.controls.Add(label4);

            this.controls.Add(label1);
            this.controls.Add(textBox1);
            this.controls.Add(button1);
            this.controls.Add(label2);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            string input = this.textBox.Text;

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            if (double.TryParse(s: input, style: System.Globalization.NumberStyles.AllowDecimalPoint, provider: provider, result: out double eccentricity)
                && (eccentricity >= 0 && eccentricity <= 1))
            {
                this.Calculate(eccentricity);
            }
            else
            {
                eccentricity = 0.7;
                this.textBox.Text = eccentricity.ToString(provider);
                this.Calculate(eccentricity);
            }
        }

        private void Calculate(double eccentricity)
        {
            Console.WriteLine("Don’t wait for your feelings to change to take the action. Take the action and your feelings will change.");
            ulong number_of_oscillations = 1000;
            double interval = number_of_oscillations * 5.0 * 2.0 * Math.PI;  // 5.0 * 2.0 * Math.PI; // 5 oscillations    

            ulong number_of_steps = number_of_oscillations * 1000; // 10000;//(non-adiabatic invariant behavior) // 100000;//(adiabatic invariant behavior) // 1000;
            int number_of_solutions = (int)number_of_oscillations * 100;

            ParameterConfiguration mass_exoplanet_configuration = ParameterConfiguration.Constant;
            if (comboBoxExoplanet.SelectedIndex == 1)
            {
                mass_exoplanet_configuration = ParameterConfiguration.Decrease;
            }
            else if (comboBoxExoplanet.SelectedIndex == 2)
            {
                mass_exoplanet_configuration = ParameterConfiguration.Increase;
            }

            ParameterConfiguration mass_star_configuration = ParameterConfiguration.Constant;
            if (comboBoxStar.SelectedIndex == 1)
            {
                mass_star_configuration = ParameterConfiguration.Decrease;
            }
            else if (comboBoxStar.SelectedIndex == 2)
            {
                mass_star_configuration = ParameterConfiguration.Increase;
            }

            var problem = new DifferentialEquationsKepler<double>(mass_exoplanet_configuration: mass_exoplanet_configuration, mass_star_configuration: mass_star_configuration);

            var solver = new DifferentialEquationsSolver26feb2024<double>(problem, Method.RKCV8 | Method.Sophisticated);

            ConditionInitial26feb2024<double> ic = new ConditionInitial26feb2024<double>(0,
                                           y1_zero_exact_function(eccentricity),
                                           y2_zero_exact_function(eccentricity),
                                           y3_zero_exact_function(eccentricity),
                                           y4_zero_exact_function(eccentricity));

            // Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;

            // Execute our time-intensive code
            solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, solutions: out NumericalSolutions26feb2024<double> solutions, number_of_solutions: number_of_solutions, interval: interval, x_end: interval);

            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;

            #region         Mass Exoplanet
            {
                PlotModel plotModel1 = new PlotModel();
                LineSeries series1 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution26feb2024<double> solution = solutions[i];
                    series1.Points.Add(new DataPoint(solution.X, problem.GetMassExoplanet(interval, solution.X)));
                }

                plotModel1.Series.Add(series1);
                plotModel1.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 1), Text = "Mass Exoplanet" });

                this.plotViews[0].Model = plotModel1;
            }
            #endregion

            #region         Mass Star
            {
                PlotModel plotModel2 = new PlotModel();
                LineSeries series2 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution26feb2024<double> solution = solutions[i];
                    series2.Points.Add(new DataPoint(solution.X, problem.GetMassStar(interval, solution.X)));
                }

                plotModel2.Series.Add(series2);
                plotModel2.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 1), Text = "Mass Star" });

                this.plotViews[1].Model = plotModel2;
            }
            #endregion

            #region solution.X is the time and solution.Y[0] is the X coordinate
            {
                PlotModel plotModel3 = new PlotModel();
                LineSeries series3 = new LineSeries();

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution26feb2024<double> solution = solutions[i];
                    series3.Points.Add(new DataPoint(solution.X, solution.Y[0]));
                }

                plotModel3.Series.Add(series3);
                plotModel3.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, 0), Text = "X coordinate" });

                this.plotViews[2].Model = plotModel3;
            }
            #endregion


            #region           Energy
            {
                PlotModel plotModel4 = new PlotModel();
                LineSeries series4 = new LineSeries();

                double[] energies = new double[solutions.Length];

                for (int i = 0; i < solutions.Length; i++)
                {
                    NumericalSolution26feb2024<double> solution = solutions[i];
                    double energy = this.energy_function(mass_exoplanet: problem.GetMassExoplanet(interval, solution.X), mass_star: problem.GetMassStar(interval, solution.X), y1: solution.Y[0], y2: solution.Y[1], y3: solution.Y[2], y4: solution.Y[3]);
                    energies[i] = energy;
                    series4.Points.Add(new DataPoint(solution.X, energy));
                }

                double energyMax = energies.Max();
                double energyMin = energies.Min();
                double y = energyMin + (energyMax - energyMin) / 2.0;

                plotModel4.Series.Add(series4);
                plotModel4.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(interval / 4, y), Text = "Energy" });

                this.plotViews[3].Model = plotModel4;
            }
            #endregion
        }

        double energy_function(double mass_exoplanet, double mass_star, double y1, double y2, double y3, double y4)
        {
            return ((y3 * y3 + y4 * y4) / (2.0 * mass_exoplanet)) - ((mass_exoplanet * mass_star) / Math.Sqrt(y1 * y1 + y2 * y2));
        }


        double y1_zero_exact_function(double eccentricity)
        {
            return 1.0 - eccentricity;
        }

        double y2_zero_exact_function(double eccentricity)
        {
            return 0.0;
        }

        double y3_zero_exact_function(double eccentricity)
        {
            return 0.0;
        }

        double y4_zero_exact_function(double eccentricity)
        {
            return Math.Sqrt((1.0 + eccentricity) / (1.0 - eccentricity));
        }
    }
}
