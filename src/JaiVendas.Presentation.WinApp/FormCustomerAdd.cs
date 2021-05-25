using JaiVendas.Application.Interfaces;
using JaiVendas.Application.ViewModel.Customers;
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

        public FormCustomerAdd(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
            => DoSave();

        private CustomerAddViewModel GetCustomerFromForm()
         => new CustomerAddViewModel 
         {
             CPF = txtVatNumber.Text,
             Name = txtName.Text,

             //Todo: Comming soon
             //Adresses
             //Phones
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
        {
            this.ClearScreen<TextBox>();
        }
    }
}
