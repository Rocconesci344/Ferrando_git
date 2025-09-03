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
    public partial class inicio : Form
    {
        registroUsuariosFunciones registroUsuariosFunciones = new registroUsuariosFunciones();
        public inicio()
        {
            InitializeComponent();
            if (GuardadoSesion.id_tipo_usuario < 3)
            {
                pictureBox3.Visible = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            usuario user = new usuario();
            user.Show();
            this.Hide();
        }

       

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmPermisos permisos = new frmPermisos();
            permisos.Show();
            this.Close();
        }

        private void inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
