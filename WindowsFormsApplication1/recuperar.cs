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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApplication1
{
    public partial class recuperar : Form
    {
        bool correorecu = false;
        public recuperar()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (correorecu == true)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Correo electronico no encontrado");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            
            if (!Regex.IsMatch(input,pattern))
            {
                errorProvider1.SetError(textBox1, "No es un formato de correo valido");
                correorecu = false;
            }
            else
            {
                errorProvider1.SetError(textBox1, string.Empty); // Limpiar el error si es válido
                correorecu = true;
            }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
