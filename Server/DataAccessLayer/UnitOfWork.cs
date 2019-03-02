using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Much of this code was gotten from https://www.gaui.is/how-to-mock-the-datacontext-linq/
/// Explanation: This code was used word for word because it was exactly what we needed in order to keep track 
/// of the changes in the repositoy layer when connecting to a database or creating mokc datacontext as the article states. 
/// Although we did used the code from the website tutorial, we did write comments throghout the code in order to understand it.
/// </summary>
namespace KFC.Red.DataAccessLayer
{
    /// <summary>
    /// Class that keeos tracks of data changes 
    /// </summary>
    /// <typeparam name="TContext">type of contect being used, generic</typeparam>
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DataContext, new()
    {
        /// <summary>
        /// Object obtained from System.Data.Linq, represent entry point for LINQ to SQL framework 
        /// </summary>
        private readonly DataContext Context;

        /// <summary>
        /// Object obtained from System.Collections.Generic, represents a collections of keys and values
        /// </summary>
        private Dictionary<Type, object> _repositories;

        /// <summary>
        /// boolean variable that checks whether the context was disposed
        /// </summary>
        private bool _disposed;

        // Default constructor that news the context and the dictionary containing all the repositories
        public UnitOfWork()
        {
            Context = new TContext();
            _repositories = new Dictionary<Type, object>();
            _disposed = false;
        }

        // Retrieves the repository for some Model class T
        // If it doesn't exist, we create an instance of it
        public IRepository<T> GetRepository<T>() where T : class
        {
            // Checks if the Dictionary Key contains the Model class
            if (_repositories.Keys.Contains(typeof(T)))
            {
                // Return the repository for that Model class
                return _repositories[typeof(T)] as IRepository<T>;
            }

            // If the repository for that Model class doesn't exist, then create it
            var repository = new Repository<T>(Context);

            // Add it to the dictionary
            _repositories.Add(typeof(T), repository);

            // Return it
            return repository;
        }

        // Saves all changes done to the context
        public void Save()
        {
            Context.SubmitChanges();
        }

        // Disposes the context, garbage collector to reclaims unused memory
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Disposes the context only once if not disposed
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                    Context.Dispose();

                this._disposed = true;
            }
        }
    }

}
