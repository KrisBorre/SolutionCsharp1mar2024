namespace WinFormsKeplerNumericalAccuracy22mar2024
{
    public partial class NumericalAccuracyForm : Form
    {
        public NumericalAccuracyForm()
        {
            InitializeComponent();

            Text = "Runge-Kutta for Kepler's elliptic planetary motion (double, float, decimal)";
            this.ClientSize = new Size(1317, 672);

            ControlManager controlManager = new ControlManager(this.Size);

            foreach (Control control in controlManager.Controls)
            {
                this.Controls.Add(control);
            }
        }
    }
}
