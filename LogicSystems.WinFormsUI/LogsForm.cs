using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LogicSystems.WinFormsUI
{
    public partial class LogsForm : Form
    {
        public LogsForm()
        {
            InitializeComponent();
            LoadLogs();
        }

        private void LoadLogs()
        {
            string path = "DataFiles/logs.txt";

            if (File.Exists(path))
            {
                rtbLogs.Text =
                    File.ReadAllText(path);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLogs();
        }
    }
}
