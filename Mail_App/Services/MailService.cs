using Mail_App.IRepository;
using Mail_App.IServices;
using Mail_App.Models;
using Mail_App.ResponseModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.Services
{
    public class MailService : IMailService
    {
        private readonly IUserRepository userRepository;
        private readonly IMailRepository mailRepository;
        public MailService(IUserRepository _userRepository, IMailRepository _mailRepository)
        {
            userRepository = _userRepository;
            mailRepository = _mailRepository;
        }
        public Response SaveMail(NewMail newMail)
        {
            var userId = userRepository.GetUserId(newMail.FromId, newMail.FromMail);
            if (userId > 0)
            {
                newMail.FromId = userId;
                newMail.CreationDateTime = DateTime.Now;
                AddMailCaller(newMail);
                return new Response
                {
                    Status = true,
                    data = "",
                    Messege = ""
                };
            }
            return new Response
            {
                Status = false,
                data = "",
                Messege = ""
            };
        }

        private void AddMailCaller(NewMail newMail)
        {
            var userId = userRepository.GetUserId(newMail.ToEmail);
            if (userId > 0)
            {
                newMail.ToId = userId;
                AddMail(newMail);
            }
            else
            {
                // 1. send status mail
                AddSystemMail(newMail);
                // 2 .draft mail
                AddDraftMail(newMail);
            }
        }

        private void AddMail(NewMail mail)
        {
            OnetoOneMail NewMail = new OnetoOneMail
            {
                FromUserId = mail.FromId,
                ToUserId = mail.ToId,
                Subject = mail.Subject,
                Content = mail.Content,
                SendDateTime = mail.CreationDateTime,
            };

            mailRepository.CreateOnetoOneMail(NewMail);

        }

        private void AddSystemMail(NewMail mail)
        {
            OnetoOneMail NewMail = new OnetoOneMail
            {
                ToUserId = mail.FromId,
                FromUserId = 1,
                Subject = mail.Subject,
                Content = mail.Content,
                SendDateTime = mail.CreationDateTime,
            };

            mailRepository.CreateOnetoOneMail(NewMail);
        }

        private void AddDraftMail(NewMail mail)
        {
            DraftMails NewMail = new DraftMails
            {
                ToUserId = mail.ToId,
                FromUserId = mail.FromId,
                Subject = mail.Subject,
                Content = mail.Content,
                LastSaveDateTime = mail.CreationDateTime,
            };
            mailRepository.CreateDraft(NewMail);
        }

        public Response GetInboxMails(int Id, string Email, int pointer)
        {
            var userId = userRepository.GetUserId(Id,Email);
            if (userId > 0)
            {
                pointer *= 10;
                var inbox = mailRepository.GetInbox(userId, pointer);
                return new Response
                {
                    Status = true,
                    data = inbox,
                    Messege = ""
                };
            }
            return new Response
            {
                Status = false,
                data = "",
                Messege = ""
            };
        }
    }
}
