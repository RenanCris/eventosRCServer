using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EventoRc.Shared
{
    public class EmailHelper
    {
        public static string EnviarEmail(string msg, string emailPara)
        {
            MailMessage mail = new MailMessage
            {
                From = new MailAddress("eeventosrc@gmail.com"),
                Subject = "Confirmação de compra de ingresso no sistema EventosRC ",
                BodyEncoding = Encoding.UTF8
            };

            mail.To.Add(emailPara);
            mail.Body = "Seus Ingressos foram comprados com sucesso! " + msg;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("eeventosrc@gmail.com", "d41d8cd98f00b204e9800998ecf8427e")
            };

            try
            {
                smtp.Send(mail);
                return "Mensagem enviada para  " + " às " + DateTime.Now.ToString() + ".";
            }
            catch (Exception e) {
                string erro = e.InnerException.ToString();
                return e.Message.ToString() + erro;
            }
        }
    }
}
