namespace LogicSystems.WinFormsUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            PaymentForm form =
                new PaymentForm();

            form.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderForm form =
                new OrderForm();

            form.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ProductsForm form =
                new ProductsForm();

            form.ShowDialog();
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            LogsForm form =
                new LogsForm();

            form.ShowDialog();
        }

        private void btnCargo_Click(object sender, EventArgs e)
        {
            CargoForm form =
                new CargoForm();

            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
