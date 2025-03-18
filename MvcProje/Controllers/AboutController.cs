using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AboutController : Controller
    {
        


        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var values = aboutManager.GetList();
            return View(values);
        }



        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManager.AboutAdd(about);
            return RedirectToAction("Index");
        }


        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }


        public ActionResult ChangeStatusFalse(int id)
        {
            var aboutValue = aboutManager.GetById(id);

            if (aboutValue.Status == true)
            {
                aboutValue.Status = false;
            }
            return RedirectToAction("Index");
        }

        public ActionResult ChangeStatusTrue(int id)
        {
            var aboutValue = aboutManager.GetById(id);

            if (aboutValue.Status == false)
            {
                aboutValue.Status = true;
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var aboutValue = aboutManager.GetById(id);
            aboutManager.AboutDelete(aboutValue);
            return RedirectToAction("Index");
        }
    }
}