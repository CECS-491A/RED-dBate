using System;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.Mock;
using DataAccessLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.UserManagement;

namespace UnitTest
{
    [TestClass]
    public class UserManagement_ActivationTest
    {

        IUnitOfWork _uow;
        Activation _activation;
        IRepository<User> _User;

        [TestInitialize]
        public void SetUp()
        {
            _uow = new MockUnitOfWork<MockDataContext>();
            _activation = new Activation(_uow);
            _User = _uow.GetRepository<User>();
        }

        [TestCleanup]
        public void TearDown()
        {
            // Clean resources
        }

        [TestMethod]
        public void Test_UserManagement_EnableAccount_SystemAdmin_to_Admin_Valid()
        {
            var uName = "Bill2080"; //system admin
            var uName2 = "Bob2080"; //admin
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            u2.IsAccountActivated = false;

            bool actual = _activation.EnableAccount(u1,u2);

            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_UserManagement_EnableAccount_SystemAdmin_to_RegUser_Valid()
        {
            var uName = "Bill2080"; //system admin
            var uName2 = "VicePresident"; //user
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            u2.IsAccountActivated = false;

            bool actual = _activation.EnableAccount(u1, u2);

            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_UserManagement_EnableAccount_Admin_to_SystemAdmin_Invalid()
        {
            var uName = "Bill2080"; //system admin
            var uName2 = "VicePresident"; //admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();

            bool actual = _activation.EnableAccount(u1, u2);

            Console.WriteLine(actual);
            Console.WriteLine(uName);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_UserManagement_EnableAccount_Admin_to_RegUser_Valid()
        {
            var uName = "Bob2080"; //admin
            var uName2 = "VicePresident"; //reg user
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            u2.IsAccountActivated = false;

            bool actual = _activation.EnableAccount(u1, u2);

            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_UserManagement_EnableAccount_RegUser_to_Admin_Invalid()
        {
            var uName = "Bob2080"; //admin
            var uName2 = "VicePresident"; //reg user
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            u2.IsAccountActivated = true;

            bool actual = _activation.EnableAccount(u1, u2);

            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_UserManagement_EnableAccount_RegUser_to_SystemAdmin_Invalid()
        {
            var uName = "Bill2080"; //system admin
            var uName2 = "VicePresident"; //reg user
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            u2.IsAccountActivated = true;

            bool actual = _activation.EnableAccount(u1, u2);

            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// System Admin disabling admin is valid
        /// </summary>
        [TestMethod]
        public void Test_UserManagement_DisableAccount_SystemAdmin_to_Admin_Valid()
        {
            var uName = "Bill2080"; //system admin
            var uName2 = "Bob2080"; //admin
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            u2.IsAccountActivated = false;

            bool actual = _activation.EnableAccount(u1, u2);

            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// System Admin disabling users is valid
        /// </summary>
        [TestMethod]
        public void Test_UserManagement_DisableAccount_SystemAdmin_to_User_Valid()
        {
            var uName = "Bill2080"; //system admin
            var uName2 = "VicePresident"; //admin
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            u2.IsAccountActivated = false;

            bool actual = _activation.EnableAccount(u1, u2);

            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// Admin Disabling system admin is invalid
        /// </summary>
        [TestMethod]
        public void Test_UserManagement_DisableAccount_Admin_to_SystemAdmin_Invalid()
        {
            var uName = "Bill2080"; //system admin
            var uName2 = "Bob2080"; //admin
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            u2.IsAccountActivated = true;

            bool actual = _activation.DisableAccount(u1, u2);

            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// Test case Admin disabling regular user is valid
        /// </summary>
        [TestMethod]
        public void Test_UserManagement_DisableAccount_Admin_to_RegUser_Valid()
        {
            var uName = "Bob2080"; //admin
            var uName2 = "VicePresident"; //reg user
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            u2.IsAccountActivated = true;

            bool actual = _activation.DisableAccount(u1, u2);

            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case regulare user disabling admin is invalid
        /// </summary>
        [TestMethod]
        public void Test_UserManagement_DisableAccount_RegUser_to_Admin_Invalid()
        {
            var uName = "Bob2080"; //admin
            var uName2 = "VicePresident"; //reg user
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            u2.IsAccountActivated = true;

            bool actual = _activation.DisableAccount(u1, u2);

            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case regulare user disabling system admin is invalid
        /// </summary>
        [TestMethod]
        public void Test_UserManagement_DisableAccount_RegUser_to_SystemAdmin_Invalid()
        {
            var uName = "Bill2080"; //system admin
            var uName2 = "VicePresident"; //reg user
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            u2.IsAccountActivated = true;

            bool actual = _activation.DisableAccount(u1, u2);

            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }
    }
}
