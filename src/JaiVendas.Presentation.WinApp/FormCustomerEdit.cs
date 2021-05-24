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
    public partial class FormCustomerEdit : Form
    {
        private Guid _customerId;

        private readonly ICustomerAppService _customerAppService;

        public FormCustomerEdit(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
            InitializeComponent();
        }

        public async void LoadCustomer(Guid id)
        {
            _customerId = id;
            ClearScreen<TextBox>(this);

            var customer = await _customerAppService.GetById(_customerId);

            if (customer == null)
                return;

            txtVatNumber.Text = customer.CPF;
            txtName.Text = customer.Name;
            chkActive.Checked = customer.Active;

            dgvAddresses.DataSource = customer.Addresses;
            dgvPhones.DataSource = customer.Phones;

        }

        private void ClearScreen<TControl>(Control control)
            where TControl : Control
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is TControl)
                {
                    var targetControl = ctrl as TControl;
                    targetControl.Text = String.Empty;
                }
                else
                    ClearScreen<TControl>(ctrl);
            }
        }
    }
}
