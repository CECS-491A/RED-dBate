using System;
using DataAccessLayer;
using DataAccessLayer.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserManagement;

namespace UnitTest
{
    [TestClass]
    public class UserManagement_ConfigurationTest
    {
        IUnitOfWork _uow;
        Configuration _configuration;
        
        [TestInitialize]
        public void SetUp()
        {
            _uow = new MockUnitOfWork<MockDataContext>();
            _configuration = new Configuration(_uow);
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
