using JaiVendas.Application.Interfaces;
using JaiVendas.Application.ViewModel.Customers;
using JaiVendas.Application.ViewModel.Customers.CustomerAddresses;
using JaiVendas.Application.ViewModel.Customers.CustomerPhones;
using JaiVendas.CrossCutting.Infra.Environment.Validation;
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
    public partial class FormCustomerAdd : Form
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly FormCustomerPhone _formCustomerPhone;

        private ICollection<CustomerAddressAddViewModel> _addresses = new List<CustomerAddressAddViewModel>();
        private ICollection<CustomerPhoneAddViewModel> _phones = new List<CustomerPhoneAddViewModel>();


        public FormCustomerAdd(ICustomerAppService customerAppService, 
            FormCustomerPhone formCustomerPhone)
        {
            _customerAppService = customerAppService;
            _formCustomerPhone = formCustomerPhone;
            InitializeComponent();

            dgvAddresses.DataSource = _addresses;
            dgvPhones.DataSource = _phones;
        }

        private void btnSave_Click(object sender, EventArgs e)
            => DoSave();

        private CustomerAddViewModel GetCustomerFromForm()
         => new CustomerAddViewModel 
         {
             CPF = txtVatNumber.Text,
             Name = txtName.Text,

             Adresses = _addresses,
             Phones = _phones
         };

        private async void DoSave()
        {
            using (new LockControl(this))
            {
                var customerAdd = GetCustomerFromForm();
                var result = await _customerAppService.Add(customerAdd);

                //Se ocorrerem erros de validacao
                if (!result.ValidationResult.IsValid)
                {
                    MessageBox.Show(this, result.ValidationResult.GetErrorMessage(),
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                //Sucesso
                MessageBox.Show(this, "Customer was Inserted successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormCustomerAdd_Shown(object sender, EventArgs e)
            => Clear();

        private void Clear()
        {
            this.ClearScreen<TextBox>();
            _addresses.Clear();
            _phones.Clear();
        }

        private void AddPhone()
        {
            using (new LockControl(this))
            {
                var dlgResult = _formCustomerPhone.ShowDialog(FormModeType.Add);
                if (dlgResult == DialogResult.OK)
                    _phones.Add(_formCustomerPhone.Phone);
            }
        }

        private void EditPhone()
        {
            using (new LockControl(this))
            {
                //var phone = dgvPhones.Bind
                //var dlgResult = _formCustomerPhone.ShowDialog(FormModeType.Edit, phone);
            }
        }

        private void btnNewPhone_Click(object sender, EventArgs e)
            => AddPhone();
    }
}
