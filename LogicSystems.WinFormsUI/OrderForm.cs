using LogicSystems.Business;
using LogicSystems.Business.States;
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
    public partial class OrderForm : Form
    {
        private OrderContext order;

        public OrderForm()
        {
            InitializeComponent();

            order =
                new OrderContext(
                    new PendingState());

            lblState.Text =
                "Pending";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            order.Next();

            lblState.Text =
                order.GetStateName();

            Logger.GetInstance()
                .Log(
                    "Order state changed to "
                    + lblState.Text);
        }
    }
}
