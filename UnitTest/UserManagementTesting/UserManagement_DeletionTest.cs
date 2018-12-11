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

        /// <summary>
        /// Test case admin on user
        /// </summary>
        [TestMethod]
        public void Deletion_AdminToUser_Valid()
        {
            var uName = "Bob2080"; //admin
            var uName2 = "VicePresident"; //regular user
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _deletion.DeleteAccount(u1, u2);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }
        
        /// <summary>
        /// Test case user on admin
        /// </summary>
        [TestMethod]
        public void Deletion_UserToAdmin_isNotValid()
        {
            var uName = "VicePresident"; //regular user
            var uName2 = "Bob2080"; //admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _deletion.DeleteAccount(u1, u2);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }
        
        /// <summary>
        /// Systen admin deleting admin
        /// </summary>
        [TestMethod]
        public void Deletion_SystemAdminToAdmin_isValid()
        {
            var uName = "Bill2080"; //system admin
            var uName2 = "Bob2080"; //admin
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _deletion.DeleteAccount(u1, u2);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// Admin deleting system admin fail
        /// </summary>
        [TestMethod]
        public void Deletion_AdminToSystemAdmin_isNotValid()
        {
            var uName = "Bob2080"; // admin
            var uName2 = "Bill2080"; // system admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _deletion.DeleteAccount(u1, u2);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// User deleting system admin fail
        /// </summary>
        [TestMethod]
        public void Deletion_UserToSystemAdmin_isNotValid()
        {
            var uName = "VicePresident"; // user
            var uName2 = "Bill2080"; // system admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _deletion.DeleteAccount(u1, u2);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Systen admin deleting user
        /// </summary>
        [TestMethod]
        public void Deletion_SystemAdminUser_isValid()
        {
            var uName = "Bill2080"; //system admin
            var uName2 = "VicePresident"; //user
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _deletion.DeleteAccount(u1, u2);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }


        /// <summary>
        /// Test Case for empty deletion
        /// </summary>
        [TestMethod]
        public void Creation_isEmptyDeleteAccount_Invalid()
        {
            var uName = "y";
            var uName2 = "i ";
            bool expected = true;
            bool actual;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = new User();
            u2.Name = uName2;

            var uList = _User.GetAll().AsEnumerable();

            bool userInDB = false;
            foreach (User u in uList)
            {

                if (!uList.Contains(u1) || !uList.Contains(u2))
                {
                    userInDB = false;
                }
                else if (uList.Contains(u1) && uList.Contains(u2))
                {
                    userInDB = true;
                }
            }

            if (userInDB == false)
            {
                actual = true;
            }
            else
            {
                actual = _deletion.DeleteAccount(u1, u2);
            }

            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }
    }
}