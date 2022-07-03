using Mail_App.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.IServices
{
    public interface IMailService
    {
        Response SaveMail(NewMail newMail);

        Response GetInboxMails(int Id, string Email, int pointer);
    }
}
