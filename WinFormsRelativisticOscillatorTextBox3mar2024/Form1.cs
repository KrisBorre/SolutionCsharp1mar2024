namespace WinFormsRelativisticOscillatorTextBox3mar2024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "Solving a system of differential equations: Relativistic oscillator.";

            this.ClientSize = new Size(1456, 557);

            ControlManager controlManager = new ControlManager();

            foreach (Control control in controlManager.Controls)
            {
                this.Controls.Add(control);
            }
        }
    }
}
