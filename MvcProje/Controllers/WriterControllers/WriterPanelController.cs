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
    public class WriterPanelController : Controller
    {

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();


        [HttpGet]
        public ActionResult WriterProfile(int id)
        {


            var writerEmail = (string)Session["WriterEmail"];
            var writerPassword = (string)Session["WriterPassword"];


            var writer = wm.GetByWriter(writerEmail, writerPassword);
            var getWriterValue = wm.GetById(writer.WriterId);

            return View(getWriterValue);


        }


        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {

            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("AllHeading","WriterPanel");
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




        public ActionResult MyHeading(string emailaddress)
        {
            emailaddress= (string)Session["WriterEmail"];
            var writeridinfo = hm.GetByWriterEmail(emailaddress); 
            return View(writeridinfo);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                                  ).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }



        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {

            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = hm.GetByWriterEmail((string)Session["WriterEmail"]).FirstOrDefault().WriterId;

            heading.HeadingStatus = true;
            hm.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }



        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                                  ).ToList();
            ViewBag.vlc = valueCategory;

            var HeadingValue = hm.GetById(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetById(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading()
        {
            var headings = hm.GetList();
            return View(headings);
        }

    }
}