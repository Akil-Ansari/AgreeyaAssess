using Agreeya.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreeya.Interfaces
{
    public interface IMailService
    {
        Task<bool> SendMail(MailData mailData);
    }
}
