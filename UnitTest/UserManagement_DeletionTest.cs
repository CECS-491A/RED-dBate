using System;
using DataAccessLayer;
using DataAccessLayer.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserManagement;

namespace UnitTest
{
    [TestClass]
    public class UserManagement_DeletionTest
    {
        IUnitOfWork _uow;
        Deletion _deletion;
        //UserManagement_Manager _userManagement;

        [TestInitialize]
        public void SetUp()
        {
            _uow = new MockUnitOfWork<MockDataContext>();
            _deletion = new Deletion(_uow);
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
