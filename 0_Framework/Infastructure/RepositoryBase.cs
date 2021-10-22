using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using _0_Framework.Domin;
using Microsoft.EntityFrameworkCore;

namespace _0_Framework.Infastructure
{
    public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T : class
    {

        public DbContext _Context { get; set; }

        public RepositoryBase(DbContext context)
        {
            _Context = context;
        }

        public void Create(T entity)
        {
            _Context.Add(entity);
        }

        public bool Exist(Expression<Func<T, bool>> expression)
        {
            return _Context.Set<T>().Any(expression);
        }

        public T Get(TKey id)
        {
            return _Context.Find<T>(id);
        }

        public List<T> GetAll()
        {
            return _Context.Set<T>().ToList();
        }

        public void SaveChanges()
        {
            _Context.SaveChanges();
        }
    }
}
