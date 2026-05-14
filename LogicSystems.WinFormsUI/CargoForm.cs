using LogicSystems.Business.Factories;
using LogicSystems.Business.Shipping.Decorators;
using LogicSystems.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LogicSystems.WinFormsUI
{
    public partial class CargoForm : Form
    {
        public CargoForm()
        {
            InitializeComponent();

            cmbCargo.Items.Add("1.ArasKargo");
            cmbCargo.Items.Add("2.YurtiçiKargo");

            // Set default selection
            cmbCargo.SelectedIndex = 0;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if something is selected in combo box
                if (string.IsNullOrEmpty(cmbCargo.Text))
                {
                    MessageBox.Show("Please select a cargo method");
                    return;
                }

                // Extract only the number part (1 or 2) from the selected item
                string[] parts = cmbCargo.Text.Split('.');
                if (parts.Length == 0)
                {
                    MessageBox.Show("Invalid cargo format");
                    return;
                }

                var selectedCargo = parts[0];

                var shipping =
                    ShippingFactory.Create(
                        selectedCargo);

                if (chkInsurance.Checked)
                {
                    shipping =
                        new InsuranceDecorator(
                            shipping);
                }

                if (chkFragile.Checked)
                {
                    shipping =
                        new FragileDecorator(
                            shipping);
                }

                lblTracking.Text =
                    shipping.GenerateTrackingNumber();

                lblPrice.Text =
                    shipping.CalculatePrice(5)
                    .ToString();

                Logger.GetInstance()
                    .Log("Cargo created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Invalid cargo selection: {ex.Message}");
            }
        }
    }
}
