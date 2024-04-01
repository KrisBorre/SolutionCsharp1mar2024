namespace WinFormsKeplerCrudeDouble21mar2024
{
    public partial class DoubleForm : Form
    {
        public DoubleForm()
        {
            InitializeComponent();

            Text = "Sophisticated Runge-Kutta versus crude Runge-Kutta for Kepler's elliptic planetary motion (using double precision floating points and generic numerics)";
            this.ClientSize = new Size(1317, 672);

            ControlManager controlManager = new ControlManager(this.Size);

            foreach (Control control in controlManager.Controls)
            {
                this.Controls.Add(control);
            }
        }
    }
}
