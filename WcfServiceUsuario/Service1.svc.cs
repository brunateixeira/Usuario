using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UsuarioEntidade;
using UsuarioUtils;

namespace WcfServiceUsuario
{
    public class Service1 : IService1
    {
        public class AcessoDB
        {
            static public String ConnectionString
            {
                get
                {
                    return ConfigurationManager.ConnectionStrings["dbUsuario"].ConnectionString;
                }
            }
        }
        public UsuarioDetalhe InserirUsuario(UsuarioDetalhe usuario)
        {
            SqlConnection con = new SqlConnection(AcessoDB.ConnectionString);

            var retorno = new UsuarioDetalhe();
            retorno.Errors = new List<Error>();

            try
            {
                if (!HelperValidacoes.ValidaEnderecoEmail(usuario.Email))
                {
                    retorno.Result = EnumCommon.ResultType.Failure;
                    retorno.Errors.Add(new Error() { Message = "E-mail inválido.", ErrorType = EnumCommon.ErrorType.Validator });
                    return retorno;
                }

                con.Open();

                SqlCommand cmd = new SqlCommand("USP_USUARIO_INSERIR_I", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Senha", HelperEncryptDecrypt.EncryptPassword(usuario.Senha));

                retorno.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar());

                if (retorno.IdUsuario > 0)
                {
                    retorno.Nome = usuario.Nome;
                    retorno.Email = usuario.Email;
                    retorno.Result = EnumCommon.ResultType.Success;
                    retorno.Errors.Add(new Error() { Message = "Usuário cadastrado com sucesso. Verifique seu e-mail para ativar sua conta.", ErrorType = EnumCommon.ErrorType.Information });
                }

            }
            catch (SqlException)
            {
                retorno.Result = EnumCommon.ResultType.Failure;
                retorno.Errors.Add(new Error() { Message = "Este e-mail já está vinculado a uma conta.", ErrorType = EnumCommon.ErrorType.Validator });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

            return retorno;
        }

        public void AtivarUsuario(int IdUsuario)
        {
            SqlConnection con = new SqlConnection(AcessoDB.ConnectionString);

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_ATIVAR_USUARIO_U", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public UsuarioDetalhe AutenticarUsuario(UsuarioDetalhe usuario)
        {
            SqlConnection con = new SqlConnection(AcessoDB.ConnectionString);
            var retorno = new UsuarioDetalhe();
            retorno.Errors = new List<Error>();

            try
            {
                if (!HelperValidacoes.ValidaEnderecoEmail(usuario.Email))
                {
                    retorno.Result = EnumCommon.ResultType.Failure;
                    retorno.Errors.Add(new Error() { Message = "E-mail inválido.", ErrorType = EnumCommon.ErrorType.Validator });
                    return retorno;
                }

                con.Open();

                SqlCommand cmd = new SqlCommand("USP_OBTEM_USUARIO_SEL", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Senha", HelperEncryptDecrypt.EncryptPassword(usuario.Senha));

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    retorno.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    retorno.Nome = reader["Nome"].ToString();
                    retorno.Email = reader["Email"].ToString();
                    retorno.Ativo = Convert.ToBoolean(reader["Ativo"]);
                }
                else
                {
                    retorno.Result = EnumCommon.ResultType.Failure;
                    retorno.Errors.Add(new Error() { Message = "Usuário não cadastrado.", ErrorType = EnumCommon.ErrorType.Validator });
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

    }
}
