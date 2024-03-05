using OxyPlot.WindowsForms;

namespace WinFormsRelativisticOscillatorTextBox4mar2024
{
    public partial class Form1 : Form
    {
        private PlotView plotView1;
        private PlotView plotView2;
        private PlotView plotView3;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Solving a system of differential equations: Relativistic oscillator.";

            int width = 1456;
            int height = 557;
            this.ClientSize = new Size(width, height);

            ControlManager controlManager = new ControlManager();

            foreach (Control control in controlManager.Controls)
            {
                this.Controls.Add(control);
            }

            this.plotView1 = controlManager.PlotView1;
            this.plotView2 = controlManager.PlotView2;
            this.plotView3 = controlManager.PlotView3;

            SizeChanged += Form1_SizeChanged;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            int numberOfPlots = 3;

            if (this.plotView1 != null)
            {
                this.plotView1.Size = new Size(width, (height - 40) / numberOfPlots);
                this.plotView1.Location = new Point(0, 40);
            }

            if (this.plotView2 != null)
            {
                this.plotView2.Size = new Size(width, (height - 40) / numberOfPlots);
                this.plotView2.Location = new Point(0, 40 + ((height - 40) / numberOfPlots));
            }

            if (this.plotView3 != null)
            {
                this.plotView3.Size = new Size(width, (height - 40) / numberOfPlots);
                this.plotView3.Location = new Point(0, 40 + 2 * ((height - 40) / numberOfPlots));
            }
        }
    }
}
