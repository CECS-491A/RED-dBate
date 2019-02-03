using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CECS491_DBate.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        void Insert(T entity);

        void Delete(T entity);

        void Update(T entity);

        T GetById(int id);

        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll();

        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
    }
}