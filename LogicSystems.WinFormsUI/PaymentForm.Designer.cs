namespace LogicSystems.WinFormsUI
{
    partial class PaymentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbPayment = new ComboBox();
            btnPay = new Button();
            lblResult = new Label();
            SuspendLayout();
            // 
            // cmbPayment
            // 
            cmbPayment.FormattingEnabled = true;
            cmbPayment.Location = new Point(185, 101);
            cmbPayment.Name = "cmbPayment";
            cmbPayment.Size = new Size(151, 28);
            cmbPayment.TabIndex = 0;
            // 
            // btnPay
            // 
            btnPay.Location = new Point(185, 168);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(94, 36);
            btnPay.TabIndex = 1;
            btnPay.Text = "Pay";
            btnPay.UseVisualStyleBackColor = true;
            btnPay.Click += btnPay_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(185, 61);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(49, 20);
            lblResult.TabIndex = 2;
            lblResult.Text = "Result";
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(641, 320);
            Controls.Add(lblResult);
            Controls.Add(btnPay);
            Controls.Add(cmbPayment);
            Name = "PaymentForm";
            Text = "PaymentForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbPayment;
        private Button btnPay;
        private Label lblResult;
    }
}