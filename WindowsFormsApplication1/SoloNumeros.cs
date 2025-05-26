using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace WindowsFormsApplication1
{
    public static class SoloNumeros
    { 
        public static bool ValidarNum(KeyPressEventArgs e)
        {
            if (char.ToString(e.KeyChar) == "," || char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            return e.Handled;
        }
    }
}
// ignorar por ahora, se vio sin terminar en clase otra forma de validacion