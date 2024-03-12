using LibraryDifferentialEquations25Feb2024;
using LibraryPendulum8mar2024;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsPendulum8mar2024
{
    internal class ControlManager
    {
        private List<Control> controls;

        public List<Control> Controls
        {
            get { return controls; }
        }

        private TextBox textBox1;
        private PlotView plotView1;

        public ControlManager()
        {
            this.controls = new List<Control>();

            this.textBox1 = new TextBox();
            Button button1 = new Button();
            Label label2 = new Label();

            this.textBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.textBox1.Location = new Point(1352, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(54, 22);
            this.textBox1.TabIndex = 0;

            button1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            button1.Location = new Point(1113, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Calculate";
            button1.UseVisualStyleBackColor = true;
            button1.MouseClick += new MouseEventHandler(this.button1_MouseClick);

            label2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            label2.AutoSize = true;
            label2.Location = new Point(1232, 15);
            label2.Name = "label2";
            label2.Size = new Size(45, 17);
            label2.TabIndex = 2;
            label2.Text = "p_theta_max:";

            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(label2, "Hint use 1 or 2.\r\n 1 will result in a sine function.\r\n 2 will result in an elliptic function.");

            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new Point(13, 13);
            label1.Name = "label1";
            label1.Size = new Size(46, 18);
            label1.TabIndex = 0;

            label1.Text = "Solving a system of differential equations: Pendulum.";

            this.plotView1 = new PlotView();
            this.plotView1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            this.plotView1.Size = new Size(1456, 557 - 40);
            this.plotView1.Location = new Point(0, 40);

            // Hint use 1 and 2.
            // 1 will result in a sine function.
            // 2 will result in elliptic function.
            double p_theta_max = 2; // 1; // 0.1; // 1; // 2;

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            this.textBox1.Text = p_theta_max.ToString(provider);

            this.Calculate(p_theta_max);

            this.controls.Add(this.plotView1);
            this.controls.Add(label1);
            this.controls.Add(label2);
            this.controls.Add(button1);
            this.controls.Add(this.textBox1);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            string input = this.textBox1.Text;

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            if (double.TryParse(s: input, style: System.Globalization.NumberStyles.AllowDecimalPoint, provider: provider, result: out double p_theta_max))
            {
                this.Calculate(p_theta_max);
            }
        }

        private void Calculate(double p_theta_max)
        {
            Console.WriteLine("Don’t wait for your feelings to change to take the action. Take the action and your feelings will change.");

            double interval = 25.0 * 2.0 * Math.PI; // 25 oscillations    

            ulong number_of_steps = 1000;
            Console.WriteLine("Pendulum (slinger)      RKCV8");

            var solver = new DifferentialEquationsSolver26feb2024<double>(new DifferentialEquationsPendulum8mar2024<double>(), Method.RKCV8);
            // angle: theta, canonical momentum: p_theta

            var ic = new ConditionInitial26feb2024<double>(0,
                                           0.0,
                                           p_theta_max);

            solver.Solve(initialCondition: ic, number_of_steps: number_of_steps, delta_x: out double delta_x, solutions: out NumericalSolutions26feb2024<double> solutions, number_of_solutions: 1000, interval: interval, x_end: interval);

            PlotModel plotModel = new PlotModel();
            LineSeries series = new LineSeries();

            for (int i = 0; i < solutions.Length; i++)
            {
                NumericalSolution26feb2024<double> solution = solutions[i];
                series.Points.Add(new DataPoint(solution.X, solution.Y[0]));
            }

            plotModel.Series.Add(series);

            this.plotView1.Model = plotModel;
        }
    }
}
