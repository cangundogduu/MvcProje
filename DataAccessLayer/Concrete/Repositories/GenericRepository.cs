﻿using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context context = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = context.Set<T>();
        }


        public void Delete(T entity)
        {
            _object.Remove(entity);
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public void Insert(T entity)
        {
            _object.Add(entity);
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
           return  _object.Where(filter).ToList();
        }

        public void Update(T entity)
        {
            context.SaveChanges();
        }
    }
}
