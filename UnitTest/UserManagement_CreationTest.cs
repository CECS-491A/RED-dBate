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
    public class UserManagement_CreationTest
    {

        IUnitOfWork _uow;
        Creation _creation;
        //UserManagement_Manager _userManagement;

        [TestInitialize]
        public void SetUp()
        {
            _uow = new MockUnitOfWork<MockDataContext>();
            _creation = new Creation(_uow);
        }

        [TestCleanup]
        public void TearDown()
        {
            // Clean resources
        }

        [TestMethod]
        public void TestCreateAccountValid()
        {

            bool expected = true;
            User u = new User();
            u.ID = 5;
            u.Name = "Barrack Obama";
            u.Role = "Registered User";
            u.Username = "BObama";
            u.Password = "hope2010";
            u.DOB = "4/25/1959";
            u.Location = "Honolulu, Hawaii USA";
            u.IsAccountActivated = true;
            u.CollectionClaims = new List<string> { "View" };

            bool actual = _creation.CreateAccount(u);
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void TestCreateAccountInvalid()
        {
            bool expected = false;
            User u = new User();
            u.ID = 5;
            u.Name = "Michelle Obama";
            u.Role = "Registered";
            u.IsAccountActivated = false;
            u.CollectionClaims =  new List<string> { "View" };
            bool actual = _creation.CreateAccount(u);
            Console.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }
    }
}
