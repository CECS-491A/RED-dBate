using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Linq;

namespace DataAccessLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext Context;

        public Repository(DataContext ctx)
        {
            Context = ctx;
        }

        public virtual IQueryable<T> GetAll()
        {
            return Context.GetTable<T>();
        }

        public void Add(T entity)
        {
            Context.GetTable<T>().InsertOnSubmit(entity);
        }

        public void Delete(T entity)
        {
            Context.GetTable<T>().DeleteOnSubmit(entity);
        }

        public void DeleteAll(IEnumerable<T> entity)
        {
            Context.GetTable<T>().DeleteAllOnSubmit(entity);
        }

        public void Update(T entity)
        {
            var entry = Context.GetTable<T>().Where(s => s == entity);
            Context.GetTable<T>().Attach(entity);
        }

        public bool Any()
        {
            return Context.GetTable<T>().Any();
        }

        public virtual ITable GetTable()
        {
            return Context.GetTable<T>();
        }
    }

}
