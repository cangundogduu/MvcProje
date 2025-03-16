using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator validationRules = new ContactValidator();
        public ActionResult Index()
        {
            var values = contactManager.GetList();

            return View(values);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValue = contactManager.GetById(id);
            return View(contactValue);
        }

        public PartialViewResult MessageListMenu()
        {
            ViewBag.InboxMessageCount = messageManager.GetListInbox().Count;
            ViewBag.SendboxMessageCount = messageManager.GetListSendbox().Count;
            return PartialView();
        }
    }
}