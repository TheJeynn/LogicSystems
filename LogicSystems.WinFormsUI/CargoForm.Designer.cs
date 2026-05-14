namespace LogicSystems.WinFormsUI
{
    partial class CargoForm
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
            cmbCargo = new ComboBox();
            chkInsurance = new CheckBox();
            chkFragile = new CheckBox();
            btnCalculate = new Button();
            lblTracking = new Label();
            lblPrice = new Label();
            SuspendLayout();
            // 
            // cmbCargo
            // 
            cmbCargo.FormattingEnabled = true;
            cmbCargo.Location = new Point(124, 106);
            cmbCargo.Name = "cmbCargo";
            cmbCargo.Size = new Size(151, 28);
            cmbCargo.TabIndex = 0;
            // 
            // chkInsurance
            // 
            chkInsurance.AutoSize = true;
            chkInsurance.Location = new Point(124, 21);
            chkInsurance.Name = "chkInsurance";
            chkInsurance.Size = new Size(93, 24);
            chkInsurance.TabIndex = 1;
            chkInsurance.Text = "Insurance";
            chkInsurance.UseVisualStyleBackColor = true;
            // 
            // chkFragile
            // 
            chkFragile.AutoSize = true;
            chkFragile.Location = new Point(124, 67);
            chkFragile.Name = "chkFragile";
            chkFragile.Size = new Size(76, 24);
            chkFragile.TabIndex = 2;
            chkFragile.Text = "Fragile";
            chkFragile.UseVisualStyleBackColor = true;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(124, 164);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(94, 40);
            btnCalculate.TabIndex = 3;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // lblTracking
            // 
            lblTracking.AutoSize = true;
            lblTracking.Location = new Point(110, 255);
            lblTracking.Name = "lblTracking";
            lblTracking.Size = new Size(64, 20);
            lblTracking.TabIndex = 4;
            lblTracking.Text = "Tracking";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(203, 255);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(41, 20);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Price";
            // 
            // CargoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 328);
            Controls.Add(lblPrice);
            Controls.Add(lblTracking);
            Controls.Add(btnCalculate);
            Controls.Add(chkFragile);
            Controls.Add(chkInsurance);
            Controls.Add(cmbCargo);
            Name = "CargoForm";
            Text = "CargoForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCargo;
        private CheckBox chkInsurance;
        private CheckBox chkFragile;
        private Button btnCalculate;
        private Label lblTracking;
        private Label lblPrice;
    }
}