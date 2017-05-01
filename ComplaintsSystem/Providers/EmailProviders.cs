using ComplaintsSystem.Interfaces;
using ComplaintsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ComplaintsSystem.Providers
{
    public class EmailProviders : IEmailProvider
    {
        public void Send(EmailMessage message)
        {
            var mail = new MailMessage(message.From, message.To)
            {

                Subject = message.Subject,
                Body = message.Body
            };
            mail.IsBodyHtml = true;
            var smtpClient = new SmtpClient();
            smtpClient.Send(mail);
        }
    }
}