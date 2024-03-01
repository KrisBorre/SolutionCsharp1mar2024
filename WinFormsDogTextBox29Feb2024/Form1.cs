using LibraryDifferentialEquationDog29Feb2024;
using LibraryDifferentialEquations25Feb2024;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsDogTextBox29Feb2024
{
    public partial class Form1 : Form
    {
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private PlotView plotView1;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Solving a system of differential equations: master-and-dog problem.";

            this.textBox1 = new TextBox();
            this.button1 = new Button();
            this.label2 = new Label();

            this.textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.textBox1.Location = new Point(653, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(54, 22);
            this.textBox1.TabIndex = 0;

            this.button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.button1.Location = new Point(713, 12);
            this.button1.Name = "button1";
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new MouseEventHandler(this.button1_MouseClick);

            this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(602, 15);
            this.label2.Name = "label2";
            this.label2.Size = new Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ratio:";

            this.label1 = new Label();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(46, 18);
            this.label1.TabIndex = 0;

            this.label1.Text = "Solving a system of differential equations: master-and-dog problem.";

            this.plotView1 = new PlotView();
            this.plotView1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            this.plotView1.Size = new Size(800, 450 - 40);
            this.plotView1.Location = new Point(0, 40);

            const double ratio = 1.0 / 2; // v / w
                                          // Dog is twice as fast as the master.

            var provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            this.textBox1.Text = ratio.ToString(provider);

            this.Calculate(ratio);

            Controls.Add(plotView1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            string input = textBox1.Text;

            var provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            if (double.TryParse(s: input, style: System.Globalization.NumberStyles.AllowDecimalPoint, provider: provider, result: out double ratio))
            {
                this.Calculate(ratio);
            }
        }

        private void Calculate(double ratio)
        {
            // Solving ODEs I (2000) page 14 master-and-dog problem

            // A master and her dog are going for a walk and the dog runs towards the master with the intent to join.
            // The dog is in the graph at the top-right. The master walks from the bottom-left along the y-axis. The dog runs straight to the master.
            // Probably because during previous walks she waited to let the dog reach her, but now she doesn't stop and continues to walk.
            // The result is that the dog will run in an arc towards his master.

            // If the dog is twice as fast as the master, then the ratio is 0.5.
            // The ratio is v / w
            // You can type a ratio in the TextBox and press the Calculate Button.
            // We stop calculating when the dog reaches the master.

            // https://mathcurve.com/courbes2d.gb/poursuite/poursuite.shtml           

            var solver = new DifferentialEquationsSolver26feb2024<double>(new DifferentialEquationsDog29Feb2024<double>(ratio), Method.RK41);

            double b = 0; // 1.0; //-1.0; // 0; //-1.0; // This is the location where the master starts walking.
            //y1[0] = 0.0; // This is the location where the master starts walking.
            //y2[0] = 0.0;

            // This is the distance at the outset of the problem between the dog and the master.
            const double a = 1.0; // This is the location where the dog starts running.
            double x_end = 0;
            double interval = Math.Abs(x_end - a); // 1.0; // interval is from 1 to 0
            const double c = -1; // 1; // 0;
            var ic = new ConditionInitial26feb2024<double>(a, b, c);
            //ic.X = a; // x_begin

            ulong number_of_steps = 1000;

            solver.Solve(interval: interval, x_end: x_end, initialCondition: ic, number_of_steps: number_of_steps, out double delta_x, out NumericalSolutions26feb2024<double> solutions, number_of_solutions: 1000);

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