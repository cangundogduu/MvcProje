using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Inbox()
        {
            var messageList = messageManager.GetListInbox();
            ViewBag.InboxMessageCount = messageList.Count;
            return View(messageList);
        }

        public ActionResult Sendbox() 
        {
            var messageList= messageManager.GetListSendbox();
            ViewBag.SendboxMessageCount = messageList.Count;
            return View(messageList);
        }


        public ActionResult GetInboxDetails(int id)
        {
            var messageValue = messageManager.GetById(id);
            return View(messageValue);
        }

        public ActionResult GetSendboxDetails(int id)
        {
            var messageValue = messageManager.GetById(id);
            return View(messageValue);
        }


        public ActionResult NewMessage() 
        {
        
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message) 
        {
            return RedirectToAction(nameof(Inbox));
        }
    }
}