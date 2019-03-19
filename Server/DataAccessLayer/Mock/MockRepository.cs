using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.DataAccessLayer.Mock
{
    /// <summary>
    /// Much of this code was gotten from https://www.gaui.is/how-to-mock-the-datacontext-linq/
    /// Explanation: This code was used word for word because it was exactly what we needed in order to keep track 
    /// of the changes in the repositoy layer when creating mock datacontext as the article states. 
    /// Although we did used the code from the website tutorial, we did write comments throghout the code in order to understand it.
    /// </summary>
    public class MockRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Generic type of context used
        /// </summary>
        public List<T> _context;

        /// <summary>
        /// Constructor for class intiates _Context list
        /// </summary>
        /// <param name="ctx"></param>
        public MockRepository(List<T> ctx)
        {
            _context = ctx;
        }

        /// <summary>
        /// virtual method that gets all of the _context data in iqueryable format
        /// </summary>
        /// <returns>_Context in asqueryable format</returns>
        public virtual IQueryable<T> GetAll()
        {
            return _context.AsQueryable();
        }

        /// <summary>
        /// Adds type of entity to context
        /// </summary>
        /// <param name="entity">type of entity t is generic placeholder</param>
        public virtual void Add(T entity)
        {
            _context.Add(entity);
        }

        /// <summary>
        /// Method used to remove an entity from context
        /// </summary>
        /// <param name="entity">t represents place holder for type of entity being used as parameter</param>
        public virtual void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public T RetrieveByID(int id)
        {
            return _context.ElementAt(id);
        }

        /// <summary>
        /// removes all the entity in context passed  from the parameter
        /// </summary>
        /// <param name="entity">a collect of entities stored in generic format</param>
        public virtual void DeleteAll(IEnumerable<T> entity)
        {
            _context.RemoveAll(s => s == entity);
        }

        /// <summary>
        /// Updates generic variable with a specific valued that is obtained from the context using the parameter passed from the method
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            var entry = _context.Where(s => s == entity).SingleOrDefault();
            entry = entity;
        }

        /// <summary>
        /// bool method that determines whether the _Context any elements in the sequence
        /// </summary>
        /// <returns>true or false</returns>
        public virtual bool Any()
        {
            return _context.Any();
        }
    }

}
