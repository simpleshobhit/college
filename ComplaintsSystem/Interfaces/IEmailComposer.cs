using ComplaintsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComplaintsSystem.Interfaces
{
    public interface IEmailComposer
    {
        EmailMessage Compose();
    }
}