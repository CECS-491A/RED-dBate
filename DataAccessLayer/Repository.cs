using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Linq;

namespace DataAccessLayer
{
  
    /// <summary>
    /// Generic repository class used used to coomunicate with data acces layer  or any databases conected to it
    /// </summary>
    /// <typeparam name="T">place holder generic</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        ///Object obtained from System.Data.Linq, represent entry point for LINQ to SQL framework 
        /// </summary>
        private DataContext Context;

        /// <summary>
        /// Constructor Used to initialize context with parameter being passed 
        /// </summary>
        /// <param name="ctx"></param>
        public Repository(DataContext ctx)
        {
            Context = ctx;
        }

        /// <summary>
        /// returns datacontext object of collections in Iqueryable format
        /// </summary>
        /// <returns>collections of objets in IQueryable format</returns>
        public virtual IQueryable<T> GetAll()
        {
            return Context.GetTable<T>();
        }

        /// <summary>
        /// Methid that inserts a type of entity to the dataxontext.
        /// </summary>
        /// <param name="entity">generic type of entity unknowned for now</param>
        public void Add(T entity)
        {
            Context.GetTable<T>().InsertOnSubmit(entity);
        }

        /// <summary>
        /// Method used to delete a specific entity from the datacontext
        /// </summary>
        /// <param name="entity">generic type of entity unknown unless repository connected to a more sepcifc repository</param>
        public void Delete(T entity)
        {
            Context.GetTable<T>().DeleteOnSubmit(entity);
        }

        /// <summary>
        /// Delete all the entities that parameter passes
        /// </summary>
        /// <param name="entity">a genric collection of entities</param>
        public void DeleteAll(IEnumerable<T> entity)
        {
            Context.GetTable<T>().DeleteAllOnSubmit(entity);
        }

        /// <summary>
        /// Updated a specific entity in context
        /// </summary>
        /// <param name="entity">placeholder for type of entity</param>
        public void Update(T entity)
        {
            var entry = Context.GetTable<T>().Where(s => s == entity);
            Context.GetTable<T>().Attach(entity);
        }

        /// <summary>
        /// bool method that determines whether context contains any objects/elements
        /// </summary>
        /// <returns>true or false</returns>
        public bool Any()
        {
            return Context.GetTable<T>().Any();
        }

        /// <summary>
        /// Method that returns the collection objects of a particular type from the datacontext
        /// </summary>
        /// <returns>returns collection of objects</returns>
        public virtual ITable GetTable()
        {
            return Context.GetTable<T>();
        }
    }

}
