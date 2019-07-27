using System.Configuration;
using System.IO;
using System.Web;
using UsuarioUtils;

namespace Usuario.Utils
{
    public static class HelperFormataEmail
    {
        public static string CorpoEmail()
        {
            string Body = File.ReadAllText(
                            HttpContext.Current.Server.
                            MapPath("TemplateEmail/AtivacaoConta.html"));

            return Body;
        }

        public static string LinkAtivacao(int IdUsuario)
        {
            string linkAtivacao = string.Concat(ConfigurationManager.AppSettings["host"].ToString(),
                          "AtivacaoConta.aspx?Id=", HelperEncryptDecrypt.Encrypt(IdUsuario.ToString()));

            return linkAtivacao;
        }

        public static string Remetente()
        {
            return ConfigurationManager.AppSettings["remetente"].ToString();
        }

        public static string Senha()
        {
            return ConfigurationManager.AppSettings["senha"].ToString();
        }
    }
}