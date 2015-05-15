using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using CardSite1.Abstract;
using CardSite1.Models;

namespace CardSite1.Concrete
{
    public class RegistrationConfirmation : IRegistrationConfirmation
    {
        private Context db = new Context();

        public void SendConfirmationLetter(RegistrationModel user)
        {
            var firstOfDeafault = db.Users.FirstOrDefault(m => m.Email == user.Email);
            if (firstOfDeafault != null)
            {
                string confirmationGuid = firstOfDeafault.Cookie;
                string verifyUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) +
                    "/Account/Verify/" + confirmationGuid;
                MailMessage mail = new MailMessage();
                string from = "olg.nosik@yandex.ru";
                string password = "221996olga";
                mail.From=new MailAddress(from);
                mail.To.Add(new MailAddress(user.Email));
                mail.Subject = "Email confirmation";
                mail.Body = "Please verify your account by clicking the following link: " + "" + verifyUrl;

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.yandex.ru";
                client.Port = 25;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from, password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
        }
    }
}