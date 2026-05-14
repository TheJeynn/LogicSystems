using LogicSystems.Business.Factories;
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
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();

            cmbPayment.Items.Add("1.BankTransfer");
            cmbPayment.Items.Add("2.CreditCard");

            // Set default selection
            cmbPayment.SelectedIndex = 0;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if something is selected in combo box
                if (string.IsNullOrEmpty(cmbPayment.Text))
                {
                    lblResult.Text = "Please select a payment method";
                    return;
                }

                // Extract only the number part (1 or 2) from the selected item
                string[] parts = cmbPayment.Text.Split('.');
                if (parts.Length == 0)
                {
                    lblResult.Text = "Invalid payment format";
                    return;
                }

                var selectedPayment = parts[0];

                var payment =
                    PaymentFactory.CreatePayment(
                        selectedPayment);

                payment.Pay(1000);

                lblResult.Text =
                    "Payment completed";

                Logger.GetInstance()
                    .Log("Payment completed");
            }
            catch (Exception ex)
            {
                lblResult.Text =
                    $"Invalid payment: {ex.Message}";
            }
        }
    }
}
