using OxyPlot.WindowsForms;

namespace WinFormsPendulum9mar2024
{
    public partial class Form1 : Form
    {
        private List<PlotView> plotViews;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Solving a system of differential equations: Pendulum.";

            int width = 1456;
            int height = 557;
            this.ClientSize = new Size(width, height);

            ControlManager controlManager = new ControlManager();

            foreach (Control control in controlManager.Controls)
            {
                this.Controls.Add(control);
            }

            this.plotViews = controlManager.PlotViews;

            SizeChanged += Form1_SizeChanged;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            if (this.plotViews != null)
            {
                int numberOfPlots = this.plotViews.Count; // 5;
                for (int i = 0; i < numberOfPlots; i++)
                {
                    if (this.plotViews[i] != null)
                    {
                        plotViews[i].Size = new Size(width, (height - 40) / numberOfPlots);
                        plotViews[i].Location = new Point(0, 40 + i * ((height - 40) / numberOfPlots));
                    }
                }
            }
        }
    }
}
