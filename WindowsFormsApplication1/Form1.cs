using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        bool fa = false;
        string img1 = @"C:\Users\Usuario\Desktop\FERRANDO_TP\WindowsFormsApplication1\img\ojocerrado.png";
        string img2 = @"C:\Users\Usuario\Desktop\FERRANDO_TP\WindowsFormsApplication1\img\ojoabierto.png";
        bool psw = false;


        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (fa)
            {
                pictureBox1.BackgroundImage = Image.FromFile(img1);
                textBox2.PasswordChar = '*';
            }
            else {
                pictureBox1.BackgroundImage = Image.FromFile(img2);
                textBox2.PasswordChar = '\0';

            }
            fa = !fa;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            recuperar f2 = new recuperar();
            f2.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string input = textBox2.Text;

            // Expresión regular: al menos 6 caracteres, una mayúscula, una minúscula y un carácter especial
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).{6,}$";

            if (!Regex.IsMatch(input, pattern))
            {
                errorProvider1.SetError(textBox2, "Debe tener al menos 6 caracteres, una mayúscula, una minúscula y un carácter especial.");
                psw = false;
            }
            else
            {
                errorProvider1.SetError(textBox2, string.Empty); // Limpiar el error si es válido
                psw = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (psw == true) 
            {
                MessageBox.Show("Bienvenido");
            
            }
            else
            {
                MessageBox.Show("error");
            }
        }
    }
}
