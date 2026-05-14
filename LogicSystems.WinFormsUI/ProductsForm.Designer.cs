namespace LogicSystems.WinFormsUI
{
    partial class ProductsForm
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
            dgvProducts = new DataGridView();
            txtName = new TextBox();
            numStock = new NumericUpDown();
            btnAdd = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(42, 121);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(393, 238);
            dgvProducts.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(42, 33);
            txtName.Name = "txtName";
            txtName.Size = new Size(149, 27);
            txtName.TabIndex = 1;
            // 
            // numStock
            // 
            numStock.Location = new Point(539, 34);
            numStock.Name = "numStock";
            numStock.Size = new Size(150, 27);
            numStock.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(539, 121);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(105, 40);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add Button";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(539, 251);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(105, 49);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh Button";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRefresh);
            Controls.Add(btnAdd);
            Controls.Add(numStock);
            Controls.Add(txtName);
            Controls.Add(dgvProducts);
            Name = "ProductsForm";
            Text = "ProductsForm";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProducts;
        private TextBox txtName;
        private NumericUpDown numStock;
        private Button btnAdd;
        private Button btnRefresh;
    }
}