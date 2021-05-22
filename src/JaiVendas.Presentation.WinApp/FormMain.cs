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
    public partial class FormMain : Form
    {
        private readonly ICustomerAppService _customerAppService;

        public FormMain(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
            var customers = _customerAppService.GetAll();
            InitializeComponent();
        }

    }
}
