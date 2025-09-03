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
using System.Collections.ObjectModel;

namespace WindowsFormsApplication1
{
    internal class registroUsuariosFunciones
    {

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|DB.accdb");
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dtproyects;

        public void INICIOSESION(string u,string c, bool pt, Form Form1)
        {
            if (!EstadoRecuperacion.boolpsw) //me fijo si el form recuperar se abrio, si se abrio pasa al else, sino, valida el login como siempre, sin cambios de contraseña 
            {
                // aca valida como usuario normal
                con.Open();
                //usuario
                string stn = @"SELECT id_usuario FROM usuario WHERE usuario = ? AND psw = ?";
                cmd = new OleDbCommand(stn, con);
                cmd.Parameters.AddWithValue("?", u);
                cmd.Parameters.AddWithValue("?", c);
                object valor = cmd.ExecuteScalar();
                if ( valor  != null && pt == true)
                {
                    GuardadoSesion.id_usuario = Convert.ToInt32(valor);
                    //tipo de usuario
                    string stn2 = @"SELECT id_tipo_user FROM usuario WHERE id_usuario = ?";
                    cmd = new OleDbCommand(stn2, con);
                    cmd.Parameters.AddWithValue("?", GuardadoSesion.id_usuario);
                    object rol= cmd.ExecuteScalar();
                    if (rol != null)
                    {
                        GuardadoSesion.id_tipo_usuario = Convert.ToInt32(rol);
                        // foto de perifl
                        string stn3 = @"SELECT Foto_Perfil FROM usuario WHERE id_usuario = ?";
                        cmd = new OleDbCommand(stn3, con);
                        cmd.Parameters.AddWithValue("?", GuardadoSesion.id_usuario);
                        object foto = cmd.ExecuteScalar();
                        if (foto != null && foto != DBNull.Value)
                        {
                            GuardadoSesion.Foto_Perfil = foto.ToString();
                        } 
                        else
                        {
                            GuardadoSesion.Foto_Perfil = null;
                        }
                    }
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
                string stn = @"SELECT id_usuario FROM usuario WHERE usuario = ? AND psw = ?";
                cmd = new OleDbCommand(stn, con);
                cmd.Parameters.AddWithValue("?", u);
                cmd.Parameters.AddWithValue("?", Contraseñanueva.newpsw);  
                object valor = cmd.ExecuteScalar();
                // aca pasa si se abrio el formulario recuperar, si se abrio pone la contraseña hecha automaticamente por el administrador (por ahora)
                if ( valor != null && pt == true)
                {
                    GuardadoSesion.id_usuario = Convert.ToInt32(valor);
                    string stn2 = @"SELECT id_tipo_user FROM usuario WHERE id_usuario = ?";
                    cmd = new OleDbCommand(stn2, con);
                    cmd.Parameters.AddWithValue("?", GuardadoSesion.id_usuario);
                    object rol = cmd.ExecuteScalar();
                    if (rol != null)
                    {
                        GuardadoSesion.id_tipo_usuario = Convert.ToInt32(rol);
                    }
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
        public void CAMBIOCONTRASEÑA()
        {
            con.Open();
            
            string stn =@"UPDATE usuario SET psw = ? WHERE id_usuario= ?";
            cmd = new OleDbCommand(stn, con);
            cmd.Parameters.AddWithValue("?", "Tecnica21!");
            cmd.Parameters.AddWithValue("?", GuardadoSesion.id_usuario);
            con.Close();
        }
        public DataTable DATOSUSUARIO()
        {
            string stn;

            DataTable dtProyects = new DataTable();
                con.Open();
            switch (GuardadoSesion.id_tipo_usuario)
            {
                case 1:
                    stn = @"SELECT datos_estudiantes.DNI, datos_estudiantes.nombre, datos_estudiantes.apellido, 
                    usuario.email, usuario.usuario, tipo_usuario.descripcion 
                    FROM (datos_estudiantes 
                    INNER JOIN usuario ON datos_estudiantes.email = usuario.email) 
                    INNER JOIN tipo_usuario ON usuario.id_tipo_user = tipo_usuario.id_tipo_usuario 
                    WHERE usuario.id_usuario = ?";
                    break;

                case 2:
                    stn = @"SELECT profesor.DNI, profesor.nombre, profesor.apellido, 
                    usuario.email, usuario.usuario, tipo_usuario.descripcion 
                    FROM (profesor 
                    INNER JOIN usuario ON profesor.email = usuario.email) 
                    INNER JOIN tipo_usuario ON usuario.id_tipo_user = tipo_usuario.id_tipo_usuario 
                    WHERE usuario.id_usuario = ?";
                    break;

                case 3:
                    stn = @"SELECT preceptor.DNI, preceptor.nombre, preceptor.apellido, 
                    usuario.email, usuario.usuario, tipo_usuario.descripcion 
                    FROM (preceptor 
                    INNER JOIN usuario ON preceptor.email = usuario.email) 
                    INNER JOIN tipo_usuario ON usuario.id_tipo_user = tipo_usuario.id_tipo_usuario 
                    WHERE usuario.id_usuario = ?";
                    break;

                case 4:
                    stn = @"SELECT Directivo.DNI, Directivo.nombre, Directivo.apellido, 
                    usuario.email, usuario.usuario, tipo_usuario.descripcion 
                    FROM (directivo 
                    INNER JOIN usuario ON Directivo.email = usuario.email) 
                    INNER JOIN tipo_usuario ON usuario.id_tipo_user = tipo_usuario.id_tipo_usuario 
                    WHERE usuario.id_usuario = ?";
                    break;

                default:
                    MessageBox.Show("Tipo de usuario no reconocido.");
                    return dtProyects;
            }
            try
                {
                    cmd = new OleDbCommand(stn, con);
                    cmd.Parameters.AddWithValue("?", GuardadoSesion.id_usuario);
                    adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(dtProyects);
                }
                catch
                {
                    MessageBox.Show("error al cargar la consulta");
                }
                finally
                {
                    con.Close();
                }

            return dtProyects;

        }

    }

    }
