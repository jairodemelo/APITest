using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JaiVendas.Presentation.WinApp
{
    public class LockControl : IDisposable
    {
        private readonly Control _control;

        public LockControl(Control control)
        {
            _control = control;
            _control.Enabled = false;
        }

        public void Dispose()
         => _control.Enabled = true;
    }
}
