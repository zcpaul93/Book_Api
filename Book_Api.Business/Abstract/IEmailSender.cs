using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Book_Api.Core.HelperModel.Email;

namespace Book_Api.Business.Abstract
{
    public interface IEmailSender
    {
        Task<SendEmailResponse> SendEmailAsync(string userEmail, string emailSubject, string message);
    }
}
