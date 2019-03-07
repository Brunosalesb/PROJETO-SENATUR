using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {        
             private string StringConexao = @"Data Source=.\SqlExpress;Initial catalog=SENATUR_TARDE;user id=sa; password=132";

        public Usuarios BuscarPorEmailESenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT UsuarioId, EMAIL, SENHA, TipoUsuario FROM USUARIOS WHERE EMAIL = @EMAIL AND SENHA = @SENHA";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        Usuarios usuarioBuscado = new Usuarios();

                        while (sdr.Read())
                        {
                            usuarioBuscado.UsuarioId = Convert.ToInt32(sdr["UsuarioId"]);
                            usuarioBuscado.Email = sdr["Email"].ToString();
                            usuarioBuscado.TipoUsuario = sdr["TipoUsuario"].ToString();
                        }

                        return usuarioBuscado;
                    }
                }
            }
            return null;
        }
    }
}
