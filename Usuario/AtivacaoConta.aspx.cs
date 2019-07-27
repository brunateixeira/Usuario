using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Usuario.Proxy;
using UsuarioUtils;

namespace Usuario
{
    public partial class AtivacaoConta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                var decrypt = HelperEncryptDecrypt.Decrypt(Request.QueryString["Id"]);
                int IdUsuario = Convert.ToInt32(decrypt);

                var proxy = new UsuarioProxy();
                proxy.AtivarUsuario(IdUsuario);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "showalert", "alert('Sua conta foi ativada. Para continuar efetue login.');", true);

                Response.Redirect("Autenticacao.aspx");
            }
        }
    }
}