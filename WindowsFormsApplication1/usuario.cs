using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class usuario : Form
    {
        registroUsuariosFunciones registroUsuariosFunciones = new registroUsuariosFunciones();
        DataTable datos;
        public usuario()
        {
            InitializeComponent();
            datos = registroUsuariosFunciones.DATOSUSUARIO();

        }



        private void usuario_Load(object sender, EventArgs e)
        {

            if (datos.Rows.Count > 0)
            {
                
                DataRow fila = datos.Rows[0];
                string dni = fila["DNI"].ToString();
                string nombre = fila["nombre"].ToString();
                string apellido = fila["apellido"].ToString();
                string email = fila["email"].ToString();
                string usuario = fila["usuario"].ToString();
                string tipo = fila["descripcion"].ToString();

                // Por ejemplo, mostrar en labels
                if (GuardadoSesion.Foto_Perfil != null)
                {
                    pictureBox3.ImageLocation = GuardadoSesion.Foto_Perfil;
                }
                else
                {

                    pictureBox3.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "user.png");
                }
                lblDNI.Text = "DNI: " + dni;
                lblEmail.Text = "Correo: " + email;
                lblNombre.Text = "Nombre y apellido: " + nombre + " " + apellido;
                lbl_tipo_us.Text = "Rol: " + tipo;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;

        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            inicio FRMinicio = new inicio();
            FRMinicio.Show();
            this.Close();
        }

        private void btn_cerrarsesion_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
