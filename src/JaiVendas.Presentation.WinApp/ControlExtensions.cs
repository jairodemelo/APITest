using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JaiVendas.Presentation.WinApp
{
    /// <summary>
    /// Decorator para classe Control
    /// </summary>
    static class ControlExtensions
    {
        public static void ClearScreen<TControl>(this Control control)
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
