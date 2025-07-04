using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApplication1
{
    public partial class recuperar : Form
    {
        private bool pswnew; //hago a este bool privado (siempre vienen privadas, pero porlas lo vuelvo a poner jej)

        public bool Pswnew //hago una propiedad de la contraseña nueva para que sea publica, para que no haya problemas con la instancia 
        {
            get { return pswnew; } //devuelve el valor de la variable
            set { pswnew = value; } // le da un valor a la variable
        }
        public static class EstadoRecuperacion //hace una clase
        {
            public static bool Pswnew = false; //aca hace que la propiedad se haga falsa para que esta no tenga problemas con el form1 cuando el form recuperar no se abre
        }

        Form1 form1; //guardo  el formulario form como form1 en este formulario

        public recuperar()
        {
            InitializeComponent();
            pswnew = false; //lo inicio siendo falso, porque necesito eso
        }
        public recuperar(Form1 F1Ins)
        {
            InitializeComponent();
            form1 = F1Ins;
        }
        

        private void label3_Click(object sender, EventArgs e) //volver
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (pswnew == true) //valido si la variable de tipo bool que cree es verdadera
            {
                Form1 form1 = new Form1(this);
                form1.Show();
                this.Hide();
                form1.txtTextbox = "12345!!ARGentinaTecnica2"; //paso la contraseña hecha automatica al textbox2 para que no la tenga que escribir
                EstadoRecuperacion.Pswnew = true; //llamo a la clase y a la propiedad para que sean verdadera, asi se pasa la contraseña al form1
            }
            else 
            {
                MessageBox.Show("Error con al encontrar el correo");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string correo = textBox1.Text.Trim(); // trim es para los espacios

            if (string.IsNullOrEmpty(correo)) //se fija si el correo esta vacio o no
            {
                errorProvider1.SetError(textBox1, "El correo no puede estar vacío.");
                return;
            }
            try //hace un intento para que no me de ningun error
            {

                MailAddress mail = new MailAddress(correo);//valida si el texto de la variable correo este bien puesta
                errorProvider1.SetError(textBox1, "");
                pswnew = true;

            }
            catch (Exception ex) //tira un error o excepcion si el error es muy grave
            {
                errorProvider1.SetError(textBox1, "Error: " + ex.Message);
                pswnew = false;

            }
        }

        private void recuperar_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
