using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DataContext, new()
    {
        private readonly DataContext Context;
        private Dictionary<Type, object> _repositories;
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

        // Disposes the context
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
