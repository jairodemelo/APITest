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
        private readonly FormCustomerEdit _formCustomerEdit;
        private readonly FormCustomerAdd _formCustomerAdd;

        public FormCustomerList(ICustomerAppService customerAppService,
            FormCustomerEdit formCustomerEdit, 
            FormCustomerAdd formCustomerAdd)
        {
            _customerAppService = customerAppService;
            _formCustomerEdit = formCustomerEdit;
            _formCustomerAdd = formCustomerAdd;
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
            => DoSearch();

        private async void DoSearch()
        {
            using (new LockControl(this))
            {
                var customers = await _customerAppService.GetAll();
                dataGridViewCustomers.DataSource = customers;
            }
        }

        private void dataGridViewCustomers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender != dataGridViewCustomers 
                || dataGridViewCustomers.SelectedRows.Count == 0)
                return;

            var selectedId = dataGridViewCustomers
                .SelectedRows[0].Cells["colId"].Value.ToString();

            if (Guid.TryParse(selectedId, out var id))
                EditCustomer(id);

        }

        private void EditCustomer(Guid id)
        {
            _formCustomerEdit.LoadCustomer(id);
            _formCustomerEdit.ShowDialog();
            DoSearch();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            _formCustomerAdd.ShowDialog();
            DoSearch();
        }
    }
}
