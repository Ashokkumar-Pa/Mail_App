using Mail_App.Models;
using Mail_App.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.IRepository
{
    public interface IMailRepository
    {
        void CreateOnetoOneMail(OnetoOneMail mail);
        void CreateDraft(DraftMails mail);
        List<Inbox> GetInbox(int Id, int pointer);
    }
}
