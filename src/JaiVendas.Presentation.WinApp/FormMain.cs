using JaiVendas.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace JaiVendas.Presentation.WinApp
{
    public partial class FormMain : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public FormMain(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void tsFileClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsCustomers_Click(object sender, EventArgs e)
        {
            var formCustomerList = _serviceProvider.GetService<FormCustomerList>();
            formCustomerList.MdiParent = this;
            formCustomerList.Show();
        }
    }
}
