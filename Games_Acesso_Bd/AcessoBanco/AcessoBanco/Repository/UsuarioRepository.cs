using AcessoBanco.Model;
using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AcessoBanco.Repository
{
    public class UsuarioRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public Usuario Incluir(Usuario usu)
        {
            string sql = "INSERT INTO USUARIO ( NOME, EMAIL, SENHA ) "
               + "VALUES ('" + usu.Nome + "', '" + usu.Email + "', '" + usu.Senha + "')";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                  usu.UsuarioId = this.ObterUltimoId();
                  return usu;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return usu;
        }

        public Usuario Alterar(Usuario usu)
        {
            string sql = "UPDATE USUARIO SET NOME=@Nome, EMAIL=@EMAIL, SENHA=@SENHA WHERE USUARIOID=@UsuarioId";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@usuarioId", usu.UsuarioId);
            cmd.Parameters.AddWithValue("@Nome", usu.Nome);
            cmd.Parameters.AddWithValue("@Email", usu.Email);
            cmd.Parameters.AddWithValue("@senha", usu.Senha);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    //MessageBox.Show("Registro atualizado com sucesso!");
                    return usu;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return null;
        }

        public bool Excluir(int usuarioId)
        {
            bool retorno = false;
            string sql = "DELETE FROM USUARIO WHERE USUARIOID=@usuarioId";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
            cmd.CommandType = CommandType.Text;
            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    return true;
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return false;
        }

        
        public IEnumerable<Usuario> ConsultarTodos()
        {
            List<Usuario> lista = new List<Usuario>();
            string sql = "SELECT * FROM USUARIO";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Usuario usu = new Usuario();
                    usu.UsuarioId = Convert.ToInt32(reader["usuarioId"].ToString());
                    usu.Nome = reader["nome"].ToString();
                    usu.Email = reader["email"].ToString();
                    usu.Senha = reader["senha"].ToString();

                    lista.Add(usu);
                }
                con.Close();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }
        

        public int ObterUltimoId()
        {
            Usuario usu = new Usuario();
            string sql = "SELECT MAX(USUARIOID) FROM USUARIO";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int valor = Convert.ToInt32( cmd.ExecuteScalar() );
                con.Close();
                return valor;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
            return 0;
        }

        public Usuario Consultar(int usuarioId)
        {
            Usuario usu = new Usuario();
            string sql = "SELECT * FROM USUARIO WHERE USUARIOID=@Id";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Id", usuarioId);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usu.UsuarioId = Convert.ToInt32(reader["usuarioId"].ToString());
                    usu.Nome = reader["nome"].ToString();
                    usu.Email = reader["email"].ToString();
                    usu.Senha = reader["senha"].ToString();
                }
                con.Close();
                return usu;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Usuario ConsultarPorEmail(string email )
        {
            Usuario usu = new Usuario();
            string sql = "SELECT * FROM USUARIO WHERE EMAIL=@MAIL";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MAIL", email);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usu.UsuarioId = Convert.ToInt32(reader["usuarioId"].ToString());
                    usu.Nome = reader["nome"].ToString();
                    usu.Email = reader["email"].ToString();
                    usu.Senha = reader["senha"].ToString();
                }
                con.Close();
                return usu;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }




    }
}
