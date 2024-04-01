namespace WinFormsKeplerCrudeDecimal21mar2024
{
    public partial class DecimalForm : Form
    {
        public DecimalForm()
        {
            InitializeComponent();

            Text = "Sophisticated Runge-Kutta versus crude Runge-Kutta for Kepler's elliptic planetary motion (using the decimal type)";

            this.ClientSize = new Size(1317, 672);

            ControlManager controlManager = new ControlManager(this.Size);

            foreach (Control control in controlManager.Controls)
            {
                this.Controls.Add(control);
            }
        }
    }
}
