using System;
using DataAccessLayer;
using DataAccessLayer.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserManagement;

namespace UnitTest
{
    [TestClass]
    public class UserManagementTest
    {
        IUnitOfWork _uow;
        UserManagement_Manager _userManagement;

        [TestInitialize]
        public void SetUp()
        {
            _uow = new MockUnitOfWork<MockDataContext>();
            _userManagement = new UserManagement_Manager(_uow);
        }

        [TestCleanup]
        public void TearDown()
        {
            // Clean resources
        }

        [TestMethod]
        public void TestCreateAccountValid()
        {
            //_userService.
            try
            {
                
            }
            catch(Exception ex)
            {

            }
        }

        [TestMethod]
        public void TestCreateAccountInValid()
        {

        }
    }
}
