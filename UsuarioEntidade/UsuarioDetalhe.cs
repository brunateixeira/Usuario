using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UsuarioEntidade
{
    [DataContract]
    public class UsuarioDetalhe
    {
        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Senha { get; set; }

        [DataMember]
        public bool Ativo { get; set; }

        [DataMember]
        public EnumCommon.ResultType Result { get; set; }

        [DataMember]
        public List<Error> Errors { get; set; }

    }
}
