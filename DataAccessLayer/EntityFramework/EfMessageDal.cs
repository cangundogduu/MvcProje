﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageDal:GenericRepository<Message>,IMessageDal
    {
    }
}
