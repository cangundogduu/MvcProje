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
            return View(messageList);
        }

        public ActionResult Sendbox() 
        {
            var messageList= messageManager.GetListSendbox();
            return View(messageList);
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