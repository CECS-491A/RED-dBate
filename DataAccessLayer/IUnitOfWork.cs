using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Much of this code was gotten from https://www.gaui.is/how-to-mock-the-datacontext-linq/
/// Explanation: This code was used word for word because it was exactly what we needed in order to keep track 
/// of the changes in the repositoy layer when connecting to a database or creating mokc datacontext as the article states. 
/// Although we did used the code from the website tutorial, we did write comments throghout the code in order to understand it.
/// </summary>
namespace DataAccessLayer
{
    /// <summary>
    ///  List of methods that can be implemented wherever it is being called in the classes, mostly used for UOW classes
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// methods that would be implemented wherever this interface is called
        /// </summary>
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void Save();
    }
}
