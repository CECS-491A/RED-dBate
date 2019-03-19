using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System;

namespace KFC.Red.DataAccessLayer
{
  
    /// <summary>
    /// Generic repository class used used to comunicate with data acces layer  or any databases conected to it
    /// </summary>
    /// <typeparam name="T">place holder generic</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext Context;

        /// <summary>
        /// Constructor Used to initialize context with parameter being passed 
        /// </summary>
        /// <param name="ctx"></param>
        public Repository(DataContext cntx)
        {
            if (cntx == null)
            {
                throw new ArgumentNullException("datacontext empty");
            }
            Context = cntx;
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
        /// Method that inserts a type of entity to the dataxontext.
        /// </summary>
        /// <param name="entity">generic type of entity unknowned for now</param>
        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity empty");
            }
            Context.GetTable<T>().InsertOnSubmit(entity);
        }

        /// <summary>
        /// Method used to delete a specific entity from the datacontext
        /// </summary>
        /// <param name="entity">generic type of entity unknown unless repository connected to a more sepcifc repository</param>
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity empty");
            }
            Context.GetTable<T>().DeleteOnSubmit(entity);
        }

        /// <summary>
        /// Delete all the entities that parameter passes
        /// </summary>
        /// <param name="entity">a genric collection of entities</param>
        public void DeleteAll(IEnumerable<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity empty");
            }
            Context.GetTable<T>().DeleteAllOnSubmit(entity);
        }

        /// <summary>
        /// Updated a specific entity in context
        /// </summary>
        /// <param name="entity">placeholder for type of entity</param>
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity empty");
            }
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
        
        /// <summary>
        /// Method that returns an object by ID 
        /// </summary>
        /// <returns>returns generic object by ID</returns>        
        public T RetrieveByID(int id)
        {
            //HAVE TO FUX THIS SOON
            //return Context.;
            return null;
        }

    }

}
