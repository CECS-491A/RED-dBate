using System;
using DataAccessLayer;
using DataAccessLayer.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
using UserManagement;

namespace UnitTest
{
    [TestClass]
    public class UserManagement_DeletionTest
    {
        IUnitOfWork _uow;
        Deletion _deletion;
        IRepository<User> _User;


        [TestInitialize]
        public void SetUp()
        {
            _uow = new MockUnitOfWork<MockDataContext>();
            _deletion = new Deletion(_uow);
            _User = _uow.GetRepository<User>();
        }

        [TestCleanup]
        public void TearDown()
        {
            // Clean resources
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
