using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApplication1.recuperar;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        registroUsuariosFunciones registroUsuariosFunciones = new registroUsuariosFunciones();
        bool ftchange = false; //la variable ftchange es para validar el cambio de fotos 
        string img1 = @"C:\Users\Usuario\Downloads\Mercedes\Mercedes\Ferrando_git-master\img\ojocerrado.png";
        string img2 = @"C:\Users\Usuario\Downloads\Mercedes\Mercedes\Ferrando_git-master\img\ojoabierto.png";
        

        bool pt = false; //la variable pt es para validar que el patron se esta cumpliendo
      

        private recuperar recuperar; //guardo el formulario recuperar como recuperar en este formulario

        public Form1() 
        {
            InitializeComponent();
        }

        public Form1(recuperar RecIns) //abro la instancia del recuperar en el form1
        {
            InitializeComponent();
            recuperar = RecIns; //digo que el formulario recuperar es la instancia
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ftchange) //valido si la foto cambio
            {
                pictureBox1.BackgroundImage = Image.FromFile(img1); //aca cambia al ojo cerrado
                textBox2.PasswordChar = '*'; //pone '*' para que no se vea
            }
            else {
                pictureBox1.BackgroundImage = Image.FromFile(img2); //aca cambia al ojo abierto
                textBox2.PasswordChar = '\0'; //esto hace que se vea cualquier tipo de caracter dentro del textbox (saca el passwordchar)

            }
            ftchange = !ftchange; //aca lo que hace es que niega el bool, para que cuando se clickee de nuevo este con otra valicion
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            recuperar f2 = new recuperar(); //abro el formulario recuperar
            f2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text.Trim();
            string contraseña = textBox2.Text.Trim();
            registroUsuariosFunciones.INICIOSESION(usuario,contraseña,pt, this);
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char)Keys.Enter)
            {
                string usuario = textBox1.Text.Trim();
                string contraseña = textBox2.Text.Trim();
                registroUsuariosFunciones.INICIOSESION(usuario, contraseña, pt, this);
                buscarusuario(textBox2.Text);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            buscarusuario(textBox2.Text);
        }

        private void buscarusuario(string text)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$"; //este es el patron de la escritura de la contraseña (eduardo nos hizo cambiarla pero dijo dejarla asi)
            if (!Regex.IsMatch(textBox2.Text, pattern)) //el regex lo que hace es verificar si el patron y el textbox2.text son iguales
            {
                errorProvider1.SetError(textBox2, "Debe tener al menos 6 caracteres, una mayúscula, una minúscula, un número y un símbolo.");
                pt = false;

            }
            else
            {
                errorProvider1.SetError(textBox2, "");
                pt = true;
            }
        }
        public string txtTextbox //aca hago una propiedad para el textbox2, asi este le pasa las intancias al formulario recuperar y asi cuando vuelva del formulario recuperar ya tenga la contraseña puesta
        {
            get { return textBox2.Text; } //devuelve el valor de la variable
            set { textBox2.Text = value; } // le da un valor a la variable
        }
    
    }
}
