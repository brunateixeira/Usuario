using UsuarioUtils;
using System.ServiceModel;
using UsuarioEntidade;
using Usuario.Utils;

namespace Usuario.Proxy
{
    public class UsuarioProxy
    {
        public UsuarioDetalhe AutenticarUsuario(UsuarioDetalhe usuarioDetalhe)
        {
            var retorno = new UsuarioDetalhe();

            try
            {
                using (var proxy = new WCFUsuario.Service1Client())
                {
                    retorno =  proxy.AutenticarUsuario(usuarioDetalhe);               
                }
            }
            catch (FaultException<Error> ex)
            {
                throw new FaultException<Error>(ex.Detail);
            }

            return retorno;
        }

        public UsuarioDetalhe InserirUsuario(UsuarioDetalhe usuarioDetalhe)
        {
            var retorno = new UsuarioDetalhe();

            try
            {
                using (var proxy = new WCFUsuario.Service1Client())
                {
                    retorno = proxy.InserirUsuario(usuarioDetalhe);
                    HelperEnviarEmail.EnviaMensagemEmail(HelperFormataEmail.LinkAtivacao(retorno.IdUsuario), retorno.Nome, HelperFormataEmail.Remetente(), retorno.Email, HelperFormataEmail.Senha(), HelperFormataEmail.CorpoEmail());
                }
            }
            catch (FaultException<Error> ex)
            {
                throw new FaultException<Error>(ex.Detail);
            }

            return retorno;
        }

        public void AtivarUsuario(int IdUsuario)
        {
            try
            {
                using (var proxy = new WCFUsuario.Service1Client())
                {
                    proxy.AtivarUsuario(IdUsuario);
                }
            }
            catch (FaultException<Error> ex)
            {
                throw new FaultException<Error>(ex.Detail);
            }
        }

    }
}