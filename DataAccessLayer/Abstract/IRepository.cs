﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
