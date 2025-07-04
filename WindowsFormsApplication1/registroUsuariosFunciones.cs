using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApplication1.recuperar;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.Security.Cryptography;

namespace WindowsFormsApplication1
{
    internal class registroUsuariosFunciones
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\miBase\\Calificacines-Trayectorias.accdb");
        OleDbCommand cmd;
        OleDbDataAdapter adapter;

        public DataTable datos()
        {
            DataTable dtProyects = new DataTable();
            cmd = new OleDbCommand();
            adapter = new OleDbDataAdapter(cmd);

            try
            {
                con.Open();
                adapter.Fill(dtProyects);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return dtProyects;
        }
        public static string HashPassword_SHA256(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la contraseña a bytes y calcular hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convertir a string hexadecimal
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // formato hexadecimal
                }

                return builder.ToString(); // Devuelve el hash como texto (64 caracteres)
            }
        }
        public void INICIOSESION(string u,string c, bool pt, Form Form1)
        {
            if (!EstadoRecuperacion.Pswnew) //me fijo si el form recuperar se abrio, si se abrio pasa al else, sino, valida el login como siempre, sin cambios de contraseña 
            {
                con.Open();
                // aca valida como usuario normal
                string query = "SELECT COUNT(*) FROM Usuarios WHERE usuario = ? AND contrasenia = ?";
                cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("?", u);
                cmd.Parameters.AddWithValue("?", c);
                    int count = (int)cmd.ExecuteScalar();

                if ( count  > 0 && pt == true)
                {
                    MessageBox.Show("Bienvenido");
                    new inicio().Show();
                    Form1.Hide();
                }
                else //negacion de la validacion
                {
                    MessageBox.Show("Contraseña y/o usuario incorrecto");
                }
            }
            else
            {
                con.Open();
                // aca pasa si se abrio el formulario recuperar, si se abrio pone la contraseña hecha automaticamente por el administrador (por ahora)
                if (  ==  &&   == "12345!!ARGentinaTecnica2")
                {
                    MessageBox.Show("Bienvenido");
                    new inicio().Show();
                    Form1.Hide();
                }
                else //negacion de la validacion
                {
                    MessageBox.Show("Contraseña y/o usuario incorrecto");
                }
            }

        }
    
    }

    }
