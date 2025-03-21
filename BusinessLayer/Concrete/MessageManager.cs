﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetById(int id)
        {
           return _messageDal.Get(x=>x.MessageId==id);
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@admin.com");
        }

        public List<Message> GetListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@admin.com");
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
