using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
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

            User u = new User();
            u.ID = 5;
            u.Name = "Barrack Obama";
            u.Role = "Registered";
            u.IsAccountActivated = true;
            u.CollectionClaims = new List<string> {"View" };

            try
            {
                _userManagement.CreateAccount(u);
            }
            catch(Exception ex)
            {
                Assert.Fail("Exception: " + ex.Message);
            }
        }

/*        [TestMethod]
        public void TestCreateAccountInValid()
        {
            
            User u = new User();
            u.ID = 5;
            u.Name = "Michelle Obama";
            u.Role = "Registered";
            u.IsAccountActivated = true;
            u.CollectionClaims = new List<string> { "View" };

            try
            {
                _userManagement.CreateAccount(u);
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception: " + ex.Message);
            }
            
        }*/
    }
}
