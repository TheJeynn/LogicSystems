using LogicSystems.Core;
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
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
            LoadProducts();

        }

        private void LoadProducts()
        {
            ProductRepository repo =
                new ProductRepository();

            dgvProducts.DataSource = null;

            dgvProducts.DataSource =
                repo.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductRepository repo =
                new ProductRepository();

            repo.Add(new Product
            {
                Name = txtName.Text,
                Stock = (int)numStock.Value
            });

            Logger.GetInstance()
                .Log("Product added");

            LoadProducts();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }
    }
}
