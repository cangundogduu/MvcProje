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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutAdd(About about)
        {
            _aboutDal.Insert(about);
        }

        public void AboutDelete(About about)
        {
            _aboutDal.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            _aboutDal.Update(about);
        }

        public void AboutUpdateByStatus(bool status)
        {
           var value=  _aboutDal.Get(x => x.Status == status);
            _aboutDal.Update(value);
        }

        public About GetById(int id)
        {
          return  _aboutDal.Get(x => x.AboutId == id);
        }

        public List<About> GetList()
        {
            return _aboutDal.GetAll();
        }
    }
}
