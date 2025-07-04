using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class usuario : Form
    {
        registroUsuariosFunciones registroUsuariosFunciones = new registroUsuariosFunciones();
        public usuario()
        {
            InitializeComponent();
        }
        Form1 form1;
        public usuario(Form1 frmins)
        {
            InitializeComponent();
            form1 = frmins;
           
        }

        private void usuario_Load(object sender, EventArgs e)
        {
            label1.Text = "Usuario: " && ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
