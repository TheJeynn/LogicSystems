namespace LogicSystems.WinFormsUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPayments = new Button();
            btnOrder = new Button();
            btnCargo = new Button();
            btnProducts = new Button();
            btnLogs = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // btnPayments
            // 
            btnPayments.Location = new Point(246, 47);
            btnPayments.Name = "btnPayments";
            btnPayments.Size = new Size(129, 45);
            btnPayments.TabIndex = 0;
            btnPayments.Text = "Payments";
            btnPayments.UseVisualStyleBackColor = true;
            btnPayments.Click += btnPayments_Click;
            // 
            // btnOrder
            // 
            btnOrder.Location = new Point(246, 98);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(129, 45);
            btnOrder.TabIndex = 1;
            btnOrder.Text = "Order";
            btnOrder.UseVisualStyleBackColor = true;
            btnOrder.Click += btnOrder_Click;
            // 
            // btnCargo
            // 
            btnCargo.Location = new Point(246, 251);
            btnCargo.Name = "btnCargo";
            btnCargo.Size = new Size(129, 45);
            btnCargo.TabIndex = 4;
            btnCargo.Text = "Cargo";
            btnCargo.UseVisualStyleBackColor = true;
            btnCargo.Click += btnCargo_Click;
            // 
            // btnProducts
            // 
            btnProducts.Location = new Point(246, 149);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(129, 45);
            btnProducts.TabIndex = 2;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnLogs
            // 
            btnLogs.Location = new Point(246, 200);
            btnLogs.Name = "btnLogs";
            btnLogs.Size = new Size(129, 45);
            btnLogs.TabIndex = 3;
            btnLogs.Text = "Logs";
            btnLogs.UseVisualStyleBackColor = true;
            btnLogs.Click += btnLogs_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(246, 302);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(129, 45);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 405);
            Controls.Add(btnPayments);
            Controls.Add(btnOrder);
            Controls.Add(btnProducts);
            Controls.Add(btnLogs);
            Controls.Add(btnCargo);
            Controls.Add(btnExit);
            Name = "MainForm";
            Text = "LogicSystems";
            ResumeLayout(false);
        }

        private Button btnPayments;
        private Button btnOrder;
        private Button btnCargo;
        private Button btnProducts;
        private Button btnLogs;
        private Button btnExit;

        #endregion
    }
}
