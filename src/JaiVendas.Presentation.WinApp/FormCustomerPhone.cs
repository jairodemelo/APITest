using JaiVendas.Application.ViewModel.Customers.CustomerPhones;
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
    public partial class FormCustomerPhone : Form
    {
        public CustomerPhoneAddViewModel Phone 
        { 
            get 
            {
                return new CustomerPhoneAddViewModel
                {
                    Area = txtArea.Text,
                    Number = txtPhoneNumber.Text
                };
            }
            private set
            {
                txtArea.Text = value.Area;
                txtPhoneNumber.Text = value.Number;
            }
        }

        private FormModeType _mode;
        public FormModeType Mode
        {
            get { return _mode; }
            private set
            {
                _mode = value;
                Text = $"{_mode.ToString()} Customer Phone";
            }
        }

        public FormCustomerPhone()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        #region :: ShowDialog

        public DialogResult ShowDialog(FormModeType mode, CustomerPhoneAddViewModel phone)
        {
            Mode = mode;
            Phone = phone;
            return ShowDialog();
        }
        public DialogResult ShowDialog(FormModeType mode)
        {
            this.ClearScreen<TextBox>();
            return ShowDialog();
        }

        #endregion
    }
}
