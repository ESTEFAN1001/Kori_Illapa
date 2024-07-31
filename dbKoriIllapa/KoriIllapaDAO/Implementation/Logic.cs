using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASendMail;

namespace KoriIllapaDAO.Implementation
{
    public class Logic
    {
        public string emailSend(string correoDestino, string asunto, string message)
        {
            string sms = "";
            try
            {
                SmtpMail mail = new SmtpMail("Tryit");
                mail.From = "dori0110.echc@gmail.com";
                mail.To = correoDestino;
                mail.Subject = asunto;
                mail.TextBody = message;

                SmtpServer server = new SmtpServer("smtp.gmail.com");
                server.User = "dori0110.echc@gmail.com";
                server.Password = "iwubpormfmifjlvm";
                server.Port = 587;
                server.ConnectType = SmtpConnectType.ConnectSSLAuto;

                SmtpClient client = new SmtpClient();
                client.SendMail(server, mail);

                sms = "Correo enviado exitosamente";
            }
            catch(Exception error)
            {
                sms = "Error al enviar el correo";
                throw error;
            }
            return sms;
        }
    }
}
