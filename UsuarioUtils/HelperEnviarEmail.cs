using System;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace UsuarioUtils
{
    public class HelperEnviarEmail
    {
        public static void EnviaMensagemEmail(string LinkAtivacao, string Nome, string Remetente, string Destinatario, string Senha, string Body)
        {
            try
            {
                string CorpoMensagem = Body.Replace("{0}", Nome).Replace("{1}", LinkAtivacao);

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(Remetente);
                mail.To.Add(Destinatario);
                mail.Subject = "Ativação de conta de usuário";
                mail.IsBodyHtml = true;
                mail.Body = new HtmlString(CorpoMensagem).ToHtmlString();

                SmtpClient SmtpServer = new SmtpClient("smtp-mail.outlook.com");

                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential(Remetente, Senha);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
    }
}
