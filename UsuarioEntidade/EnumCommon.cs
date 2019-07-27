using System.Runtime.Serialization;
using System.ComponentModel;

namespace UsuarioEntidade
{
    public class EnumCommon
    {
        [DataContract]
        public enum ResultType : byte
        {
            [EnumMember]
            Success,
            [EnumMember]
            Failure
        }

        [DataContract]
        public enum ErrorType
        {
            [EnumMember]
            [Description("Validator")]
            Validator = 1,
            [EnumMember]
            [Description("Application")]
            Application,
            [EnumMember]
            [Description("Information")]
            Information
        }
    }
}
