using System;
using DataAccessLayer;
using DataAccessLayer.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserManagement;

namespace UnitTest
{
    [TestClass]
    public class UserManagement_ActivationTest
    {

        IUnitOfWork _uow;
        Activation _activation;
        //UserManagement_Manager _userManagement;

        [TestInitialize]
        public void SetUp()
        {
            _uow = new MockUnitOfWork<MockDataContext>();
            _activation = new Activation(_uow);
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
