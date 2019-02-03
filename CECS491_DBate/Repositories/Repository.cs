using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CECS491_DBate.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext context;
        protected DbSet<T> dbset;

        public Repository(DbContext context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }

        public void Insert(T entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            //context.Entry(entity).State = EntityState.Modified;
            //_dbContext.Entry(entity).CurrentValues.SetValues(employee);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public T GetById(int id)
        {
            return dbset.Find(id);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return dbset.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return dbset;
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            // This method will find the related records by passing two argument
            //First argument: lambda expression to search a record such as d => d.StandardName.Equals(standardName) to search am record by standard name
            //Second argument: navigation property that leads to the related records such as d => d.Students
            //The method returns the related records that met the condition in the first argument.
            //An example of the method GetStandardByName(string standardName)
            //public Standard GetStandardByName(string standardName)
            //{
            //return _standardRepository.GetSingle(d => d.StandardName.Equals(standardName), d => d.Students);
            //} 
            T item = null;
            IQueryable<T> dbQuery = context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            item = dbQuery
                .AsNoTracking() //Don't track any changes for the selected item
                .FirstOrDefault(where); //Apply where clause

            return item;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}