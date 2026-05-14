namespace LogicSystems.WinFormsUI
{
    partial class OrderForm
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
            lblState = new Label();
            btnNext = new Button();
            SuspendLayout();
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Location = new Point(208, 79);
            lblState.Name = "lblState";
            lblState.Size = new Size(43, 20);
            lblState.TabIndex = 0;
            lblState.Text = "State";
            // 
            // btnNext
            // 
            btnNext.Location = new Point(208, 139);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 1;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNext);
            Controls.Add(lblState);
            Name = "OrderForm";
            Text = "OrderForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblState;
        private Button btnNext;
    }
}