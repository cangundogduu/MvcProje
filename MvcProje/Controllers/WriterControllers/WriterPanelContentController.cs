using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers.WriterControllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult MyContent()
        {
            var contentValues = contentManager.GetListByWriter();
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.id = id;
            return View();
        }


        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterEmail"];
            content.WriterId = contentManager.GetList().Where(x => x.Writer.WriterEmail == mail).Select(y => y.WriterId).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.ContentStatus = true;
            contentManager.ContentAdd(content);
            return RedirectToAction("MyContent");
        }

        [HttpGet]
        public ActionResult ToDoList()
        {
            return View();
        }

        
    }
}