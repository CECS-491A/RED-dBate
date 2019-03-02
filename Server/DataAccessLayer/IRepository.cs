using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.DataAccessLayer
{
    /// <summary>
    /// IRepository class that contains methods that can be implemented in classed that this interface is called upon
    /// </summary>
    /// <typeparam name="T">place holder/generic object</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// List of methods that can be implemented wherever it is being called in the classes
        /// </summary>
        IQueryable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void DeleteAll(IEnumerable<T> entity);
        void Update(T entity);
        bool Any();
    }
}
