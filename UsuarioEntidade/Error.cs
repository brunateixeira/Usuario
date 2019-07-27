using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UsuarioEntidade
{
    [DataContract]
    public class Error
    {
        public Error()
        {
            this.Message = string.Empty;
            this.ErrorType = EnumCommon.ErrorType.Application;
        }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public EnumCommon.ErrorType? ErrorType { get; set; }

    }
}
