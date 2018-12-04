using System;
using DataAccessLayer;
using DataAccessLayer.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserManagement;

namespace UnitTest
{
    [TestClass]
    public class UserServiceTest
    {
        IUnitOfWork _uow;
       UserService _userService;

        [TestInitialize]
        public void SetUp()
        {
            _uow = new MockUnitOfWork<MockDataContext>();
            _userService = new UserService(_uow);
        }

        [TestCleanup]
        public void TearDown()
        {
            // Clean resources
        }

        [TestMethod]
        public void TestGetUser()
        {
            var user = _userService.GetUserByID(1);
            Assert.AreEqual(user.Name, "Bob");
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            try
            {
                _userService.DeleteUserByID(1);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }

}
