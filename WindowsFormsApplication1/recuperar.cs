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
        registroUsuariosFunciones registroUsuariosFunciones = new registroUsuariosFunciones();


        private string newpsw;

        private bool boolpsw; //hago a este bool privado (siempre vienen privadas, pero porlas lo vuelvo a poner jej)

        public bool Boolpsw //hago una propiedad de la contraseña nueva para que sea publica, para que no haya problemas con la instancia 
        {
            get { return boolpsw; } //devuelve el valor de la variable
            set { boolpsw = value; }
        }
        public string Newpsw //hago una propiedad de la contraseña nueva para que sea publica, para que no haya problemas con la instancia 
        {
            get { return newpsw; } //devuelve el valor de la variable
            set { newpsw = value; }
        }
        public string Textbox1_recuperar //aca hago una propiedad para el textbox2, asi este le pasa las intancias al formulario recuperar y asi cuando vuelva del formulario recuperar ya tenga la contraseña puesta
        {
            get { return textBox1.Text; } //devuelve el valor de la variable
        }

        public static class EstadoRecuperacion //hace una clase
        {
            public static bool boolpsw = false; //aca hace que la propiedad se haga falsa para que esta no tenga problemas con el form1 cuando el form recuperar no se abre
        }
        public static class Contraseñanueva
        {
            public static string newpsw = "12345!!ARGentinaTecnica2";
        }

        Form1 form1; //guardo  el formulario form como form1 en este formulario

        public recuperar()
        {
            InitializeComponent();
            boolpsw = false; //lo inicio siendo falso, porque necesito eso
            //mail = textBox1.Text;
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
            if (boolpsw == true) //valido si la variable de tipo bool que cree es verdadera
            {
                registroUsuariosFunciones.CAMBIOCONTRASEÑA();
                Form1 form1 = new Form1(this);
                form1.Show();
                this.Hide();
                form1.txtTextbox = newpsw; //paso la contraseña hecha automatica al textbox2 para que no la tenga que escribir
                EstadoRecuperacion.boolpsw = true; //llamo a la clase y a la propiedad para que sean verdadera, asi se pasa la contraseña al form1

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
                boolpsw = true;

            }
            catch (Exception ex) //tira un error o excepcion si el error es muy grave
            {
                errorProvider1.SetError(textBox1, "Error: " + ex.Message);
                boolpsw = false;

            }
        }
        
    }
}
