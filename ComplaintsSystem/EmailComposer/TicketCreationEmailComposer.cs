using ComplaintsSystem.Interfaces;
using ComplaintsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComplaintsSystem.EmailComposer
{
    public class TicketCreationEmailComposer:IEmailComposer
    {
        private readonly string _emailAddress;
        public TicketCreationEmailComposer(string emailAddress)
        {
            _emailAddress = emailAddress;
        }
        public EmailMessage Compose()
        {
            
               var body = $"Thanks for creating a new complaint, we will verify the same and keep you updated regarding the progress of your complaint";


            var noReplyEmailAddress = "noreply@noreply.com";
            return new EmailMessage
            {
                From = noReplyEmailAddress,
                To = _emailAddress,
                Subject = "New Ticket Created",
                Body = body
            };
        }
    }
}