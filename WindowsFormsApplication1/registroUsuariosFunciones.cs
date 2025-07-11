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
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq.Expressions;

namespace WindowsFormsApplication1
{
    internal class registroUsuariosFunciones
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|DB.accdb");
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dtProyects;
     /*   public DataTable datos()
        {
            dtProyects = new DataTable();
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
        }*/
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
            if (!EstadoRecuperacion.boolpsw) //me fijo si el form recuperar se abrio, si se abrio pasa al else, sino, valida el login como siempre, sin cambios de contraseña 
            {
                con.Open();
                // aca valida como usuario normal
                string stn = @"SELECT COUNT(*) FROM usuario WHERE usuario = ? AND psw = ?";
                cmd = new OleDbCommand(stn, con);
                cmd.Parameters.AddWithValue("?", u);
                cmd.Parameters.AddWithValue("?", c);
                    int count = (int)cmd.ExecuteScalar();

                if ( count  > 0 && pt == true)
                {
                    MessageBox.Show("Bienvenido");
                    new inicio().Show();
                    Form1.Hide();
                    con.Close();
                }
                else //negacion de la validacion
                {
                    MessageBox.Show("Contraseña y/o usuario incorrecto");
                    con.Close();
                }
            }
            else
            {
                con.Open();
                string stn = @"SELECT COUNT(*) FROM usuario WHERE usuario = ? AND psw = ?";
                cmd = new OleDbCommand(stn, con);
                cmd.Parameters.AddWithValue("?", u);
                cmd.Parameters.AddWithValue("?", Contraseñanueva.newpsw);  
                int count = (int)cmd.ExecuteScalar();
                // aca pasa si se abrio el formulario recuperar, si se abrio pone la contraseña hecha automaticamente por el administrador (por ahora)
                if ( count > 0 && pt == true)
                {
                    MessageBox.Show("Bienvenido");
                    new inicio().Show();
                    Form1.Hide();
                    con.Close();
                }
                else //negacion de la validacion
                {
                    MessageBox.Show("Contraseña y/o usuario incorrecto");
                    con.Close();
                }
            }

        }
        public void CAMBIOCONTRASEÑA(string mail)
        {
            con.Open();
            
            string stn =@"UPDATE usuario SET psw = ? WHERE email= ?";
            cmd = new OleDbCommand(stn, con);
            cmd.Parameters.AddWithValue("?", "12345!!ARGentinaTecnica2");
            cmd.Parameters.AddWithValue("?", mail);
            con.Close();
        }
        public DataTable DATOSUSUARIO(int id_usuario)
        {
            DataTable dtProyects = new DataTable();
                con.Open();
                string stn = @"SELECT datos_estudiantes.DNI, datos_estudiantes.nombre, datos_estudiantes.apellido, " +
                    "usuario.email, usuario.usuario, tipo_usuario.descripcion " +
                    "FROM (datos_estudiantes " +
                    "INNER JOIN usuario ON datos_estudiantes.email = usuario.email)" +
                    "INNER JOIN tipo_usuario ON usuario.id_tipo_user = tipo_usuario.id_tipo_usuario"+
                    "WHERE  id_usuario = ?";
            cmd.Parameters.AddWithValue("?", id_usuario);
            try
            {
                cmd = new OleDbCommand(stn, con);
                adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dtProyects);
            }
            catch
            {
                MessageBox.Show("error al cargar la consulta");
            }
            finally {
                con.Close();
            }

            return dtProyects;

        }

    }

    }
