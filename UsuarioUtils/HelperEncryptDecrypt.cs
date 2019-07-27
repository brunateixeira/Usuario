using System;
using System.Security.Cryptography;
using System.Text;

namespace UsuarioUtils
{
    public class HelperEncryptDecrypt
    {
        public static string Encrypt(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao encriptar senha" + e.Message);
            }
        }

        public static string Decrypt(string password)
        {
            try
            {
                UTF8Encoding encoder = new UTF8Encoding();
                Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(password);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao encriptar senha" + ex.Message);
            }
        }

        public static Guid EncryptPassword(string password)
        {
            try
            {
                using (MD5 md5 = MD5.Create())
                {
                    Guid guid = new Guid();

                    byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(password));
                    guid = new Guid(hash);
                    return guid;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao encriptar senha" + ex.Message);
            }
        }
    }
}