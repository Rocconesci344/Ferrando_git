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
        DataTable datos;

        public usuario()
        {
            InitializeComponent();
            registroUsuariosFunciones = new registroUsuariosFunciones();
            datos = registroUsuariosFunciones.DATOSUSUARIO();
        }


        Form1 form1 = new Form1();
        public usuario(Form1 F1Ins)
        {
            InitializeComponent();
            form1 = F1Ins;
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
                lblDNI.Text = "DNI: " + dni;
                lblEmail.Text = "Correo: " + email;
                lblNombre.Text = "Nombre y apellido:" + nombre + " " + apellido;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
