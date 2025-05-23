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
    public partial class Form1 : Form
    {
        bool fa = false;
        string img1 = @"C:\Users\Usuario\Desktop\FERRANDO_TP\WindowsFormsApplication1\img\ojocerrado.png";
        string img2 = @"C:\Users\Usuario\Desktop\FERRANDO_TP\WindowsFormsApplication1\img\ojoabierto.png";


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
    }
}
