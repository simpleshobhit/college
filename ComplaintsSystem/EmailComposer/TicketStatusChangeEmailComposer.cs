using ComplaintsSystem.Interfaces;
using ComplaintsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComplaintsSystem.EmailComposer
{
    public class TicketStatusChangeEmailComposer:IEmailComposer
    {
        private readonly string _emailAddress;
        private readonly string _status;
        public TicketStatusChangeEmailComposer(string emailAddress,string status)
        {
            _emailAddress = emailAddress;
            _status = status;
        }
        public EmailMessage Compose()
        {

            var body = $"Your complaint is moved to next status:{_status}";


            var noReplyEmailAddress = "noreply@noreply.com";
            return new EmailMessage
            {
                From = noReplyEmailAddress,
                To = _emailAddress,
                Subject = "Ticket Updated",
                Body = body
            };
        }
    }
}