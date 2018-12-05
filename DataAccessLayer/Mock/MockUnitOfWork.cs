using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mock
{

    /// <summary>
    /// Much of this code was gotten from https://www.gaui.is/how-to-mock-the-datacontext-linq/
    /// Explanation: This code was used word for word because it was exactly what we needed in order to keep track 
    /// of the changes in the repositoy layer when creating mokc datacontext as the article states. 
    /// Although we did used the code from the website tutorial, we did write comments throghout the code in order to understand it.
    /// </summary>
    public class MockUnitOfWork<T> : IUnitOfWork where T : class, new()
    {
        /// <summary>
        /// Generic type of context used
        /// </summary>
        private T Context;

        /// <summary>
        /// collection that stores different types of repositories
        /// </summary>
        private Dictionary<Type, object> _repositories;

        /// <summary>
        /// Constructor for class initiates context bariable and _repository dictionary
        /// </summary>
        public MockUnitOfWork()
        {
            Context = new T();
            _repositories = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Method that returns repositories
        /// </summary>
        /// <typeparam name="TEntity">type of entity being used(generic)</typeparam>
        /// <returns>mock repository object</returns>
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            var entityName = typeof(TEntity).Name;
            var prop = Context.GetType().GetProperty(entityName);
            MockRepository<TEntity> repository = null;
            if (prop != null)
            {
                var entityValue = prop.GetValue(Context, null);
                repository = new MockRepository<TEntity>(entityValue as List<TEntity>);
            }
            else
            {
                repository = new MockRepository<TEntity>(new List<TEntity>());
            }
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        /// <summary>
        /// Method that sets a specific repository context with a list of data if the mock repository isn't null
        /// </summary>
        /// <typeparam name="TEntity">represents generic type of object/class </typeparam>
        /// <param name="data">represents a list containing data in context of mock repo</param>
        public void SetRepository<TEntity>(List<TEntity> data) where TEntity : class
        {
            IRepository<TEntity> repo = GetRepository<TEntity>();

            var mockRepo = repo as MockRepository<TEntity>;
            if (mockRepo != null)
            {
                mockRepo._context = data;
            }
        }

        /// <summary>
        /// Empty method, normally used to save changes in data
        /// </summary>
        public void Save()
        {
        }

        /// <summary>
        /// Empty method, normally used to reclaim unused memory, works sort of like a garbage collector
        /// </summary>
        public void Dispose()
        {
        }
    }

}
