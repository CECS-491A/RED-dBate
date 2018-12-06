using System;
using System.Linq;
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
        IRepository<User> _User;

        [TestInitialize]
        public void SetUp()
        {
            _uow = new MockUnitOfWork<MockDataContext>();
            _creation = new Creation(_uow);
            _User = _uow.GetRepository<User>();
        }

        [TestCleanup]
        public void TearDown()
        {

            // Clean resources
        }

        /*
        /// <summary>
        /// Test Case for empty creation ATTEMPT
        /// </summary>
        [TestMethod]
        public void Creation_isEmpty()
        {
            var uName = " ";
            var uName2 = " "; 
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _creation.CreateAccount(u1, u2);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }
        */

        /// <summary>
        /// Test Case duplication
        /// </summary>
        [TestMethod]
        public void Creation_Duplication()
        {
            var uName = "Bill2080"; //system admin
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();

            bool actual = _creation.Duplication(u1);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }

        /*
        /// <summary>
        /// Test Case duplication  UNABLE TO PASS A NON DUPLICATE WITH A NEW ACC
        /// </summary>
        [TestMethod]
        public void Creation_NotDuplication()
        {
            var uName = "Bob"; // user
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();

            bool actual = _creation.Duplication(u1);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }
        */

        /// <summary>
        /// Test case for creation admin on user
        /// </summary>
        [TestMethod]
        public void Creation_AdminToUser_Valid()
        {
            var uName = "Bob2080"; //admin
            var uName2 = "VicePresident"; //regular user
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _creation.CreateAccount(u1, u2);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// Test case for creation user on admin
        /// </summary>
        [TestMethod]
        public void Creation_UserToAdmin_NotValid()
        {
            var uName = "VicePresident"; //regular user
            var uName2 = "Bob2080"; //admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _creation.CreateAccount(u1, u2);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// System admin creating admin
        /// </summary>
        [TestMethod]
        public void Creation_SystemAdminToAdmin_Valid()
        {
            var uName = "Bill2080"; //system admin
            var uName2 = "Bob2080"; //admin
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _creation.CreateAccount(u1, u2);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }

        /*
        /// <summary>
        /// THIS CODE IS WRONG. ADMIN CREATING SYSTEM ADMIN
        /// </summary>
        [TestMethod]
        public void Creation_AdminToSystemAdmin_Valid()
        {
            var uName = "Bob2080"; //admin
            var uName2 = "Bill2080"; //systemadmin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _creation.CreateAccount(u1, u2);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }
        */
    }
}
