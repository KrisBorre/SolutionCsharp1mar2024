namespace WinFormsKeplerRungeKuttaOrders11mar2024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ClientSize = new Size(1317, 672);

            Text = "Several Runge-Kutta Orders for Kepler's elliptic planetary motion (with accumulation of numerical errors).";

            ControlManager controlManager = new ControlManager();

            foreach (Control control in controlManager.Controls)
            {
                this.Controls.Add(control);
            }
        }
    }
}
