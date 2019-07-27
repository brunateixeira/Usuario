using System.ServiceModel;
using UsuarioEntidade;

namespace WcfServiceUsuario
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        UsuarioDetalhe InserirUsuario(UsuarioDetalhe usuario);

        [OperationContract]
        void AtivarUsuario(int IdUsuario);

        [OperationContract]
        UsuarioDetalhe AutenticarUsuario(UsuarioDetalhe usuario);
    }    
}
