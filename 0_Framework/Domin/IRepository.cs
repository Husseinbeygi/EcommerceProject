using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _0_Framework.Domin
{
    public interface IRepository <TKey,T> where T : class
    {

        T Get(TKey id);
        void Create(T entity);
        List<T> GetAll();
        bool Exist(Expression<Func<T, bool>> expression);
        void SaveChanges();
        
    }
}
