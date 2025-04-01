using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers.WriterControllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox(string Email)
        {
            Email = (string)Session["WriterEmail"];
            var messageList = messageManager.GetListInbox(Email);
            ViewBag.InboxMessageCount = messageList.Count;
            return View(messageList);
        }

        public PartialViewResult MessageListMenu()
        {
            
            return PartialView();
        }

        public ActionResult Sendbox()
        {
            string Email = (string)Session["WriterEmail"];
            var messageList = messageManager.GetListSendbox(Email);
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
            string Sender = (string)Session["WriterEmail"];
            ValidationResult results = messageValidator.Validate(message);
            if (results.IsValid)
            {
                message.SenderMail = Sender;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(message);
                return RedirectToAction(nameof(Sendbox));
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}