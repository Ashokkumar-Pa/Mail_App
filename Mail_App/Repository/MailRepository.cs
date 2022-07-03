using Mail_App.DatabaseContext;
using Mail_App.IRepository;
using Mail_App.Models;
using Mail_App.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.Repository
{
    public class MailRepository : IMailRepository
    {
        private readonly DataContext db;

        public MailRepository(DataContext _Context)
        {
            db = _Context;
        }

        public void CreateDraft(DraftMails mail)
        {
            db.DraftMails.Add(mail);
            db.SaveChanges();
        }

        public void CreateOnetoOneMail(OnetoOneMail mail)
        {
            db.OnetoOneMails.Add(mail);
            db.SaveChanges();
        }

        public List<Inbox> GetInbox(int Id, int pointer)
        {
            return db.OnetoOneMails.Where(f => f.ToUserId == Id).OrderBy(o => o.SendDateTime).Select(s => new Inbox
            {
                FromUserId = s.FromUserId,
                Subject = s.Subject,
                ToUserId = s.ToUserId,
                Content = s.Content,
                IsReaded = s.IsReaded,
                Id = s.Id,
                SendDateTime = s.SendDateTime
            }).Skip(pointer).Take(10).ToList();
        }
    }
}
