using System;
using System.Web.Services;
using UsuarioEntidade;
using Usuario.Proxy;
using System.Web.UI;

namespace Usuario
{
    public partial class Autenticacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static UsuarioDetalhe AutenticarUsuario(UsuarioDetalhe usuarioDetalhe)
        {
            var proxy = new UsuarioProxy();
            return proxy.AutenticarUsuario(usuarioDetalhe); 
        }

        [WebMethod]
        public static UsuarioDetalhe InserirUsuario(UsuarioDetalhe usuarioDetalhe)
        {
            var proxy = new UsuarioProxy();
            return proxy.InserirUsuario(usuarioDetalhe);
        }
    }
}