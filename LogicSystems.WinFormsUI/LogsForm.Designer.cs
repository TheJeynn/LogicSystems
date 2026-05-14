namespace LogicSystems.WinFormsUI
{
    partial class LogsForm
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
            rtbLogs = new RichTextBox();
            btnRefresh = new Button();
            SuspendLayout();
            // 
            // rtbLogs
            // 
            rtbLogs.Location = new Point(38, 37);
            rtbLogs.Name = "rtbLogs";
            rtbLogs.Size = new Size(377, 277);
            rtbLogs.TabIndex = 0;
            rtbLogs.Text = "";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(496, 90);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 39);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "LoadLogs";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // LogsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRefresh);
            Controls.Add(rtbLogs);
            Name = "LogsForm";
            Text = "LogsForm";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbLogs;
        private Button btnRefresh;
    }
}