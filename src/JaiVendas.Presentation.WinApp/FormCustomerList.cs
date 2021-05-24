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

namespace JaiVendas.Presentation.WinApp
{
    public partial class FormCustomerList : Form
    {
        private readonly ICustomerAppService _customerAppService;
        public FormCustomerList(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (new LockControl(this))
            {
                var customers = _customerAppService.GetAll();
                dataGridViewCustomers.DataSource = customers;
            }
        }
    }
}
