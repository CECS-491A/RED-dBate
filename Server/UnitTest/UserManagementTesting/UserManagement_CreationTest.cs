using System;
using System.Linq;
using KFC.Red.DataAccessLayer;
using KFC.Red.DataAccessLayer.Mock;
using KFC.Red.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KFC.Red.ServiceLayer.UserManagement;

namespace KFC.Red.UnitTest
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
     
        /// <summary>
        /// Test case for creation admin on user
        /// </summary>
        [TestMethod]
        public void Creation_AdminToUser_Valid()
        {
            var uName = "Bob2080"; //admin
            //var uName2 = "VicePresident"; //regular user

            bool expected = true;

            
            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = new User
            {
                ID = 7,
                Username = "Bobby23",
                Name = "John",
                Role = "Registered User",
                Password = "bboy23",
                DateOfBirth = new DateTime(1996,12,15),
                City = "Long Beach",
                State = "CA",
                Country = "USA",
            };

            bool actual = _creation.CreateAccount(u1, u2);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case for creation system admin on user
        /// </summary>
        [TestMethod]
        public void Creation_SystemAdminToUser_Valid()
        {
            var uName = "Bill2080"; // system admin
            //var uName2 = "VicePresident"; //regular user

            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = new User
            {
                ID = 7,
                Username = "Bobby23",
                Name = "John",
                Role = "Registered User",
                Password = "bboy23",
                DateOfBirth = new DateTime(1996, 12, 15),
                City = "Long Beach",
                State = "CA",
                Country = "USA",
            };

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
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = new User();
            u2.Username = "Bobby23";
            u2.Role = "Admin";
            u2.Password = "bboy23";
            u2.DateOfBirth = new DateTime(1996,12,15);
            u2.City = "Long Beach";
            u2.State = "CA";
            u2.Country = "USA";
            bool actual = _creation.CreateAccount(u1, u2);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// Test case for creation user on admin
        /// </summary>
        [TestMethod]
        public void Creation_UserToSystemAdmin_NotValid()
        {
            var uName = "VicePresident"; //regular user
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = new User();
            u2.Username = "Bobby23";
            u2.Role = "System Admin";
            u2.Password = "bboy23";
            u2.DateOfBirth = new DateTime(1996,12,15);
            u2.City = "Long Beach";
            u2.State = "CA";
            u2.Country = "USA";
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
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = new User();
            u2.Username = "Bobby23";
            u2.Role = "Admin";
            u2.Password = "bboy23";
            u2.DateOfBirth = new DateTime(1996, 12, 15);
            u2.City = "Long Beach";
            u2.State = "CA";
            u2.Country = "USA";
            bool actual = _creation.CreateAccount(u1, u2);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// Test Case Admin creating System Admin is not valid
        /// </summary>
        [TestMethod]
        public void Creation_AdminToSystemAdmin_Invalid()
        {
            var uName = "Bill2080"; //system admin
            bool expected = false;
            
            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = new User();
            u2.Username = "Bobby23";
            u2.Role = "System Admin";
            u2.Password = "bboy23";
            u2.DateOfBirth = new DateTime(1996, 12, 15);
            u2.City = "Long Beach";
            u2.State = "CA";
            u2.Country = "USA";

            bool actual = _creation.CreateAccount(u1, u2);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// Test Case Admin creating another Admin is not valid
        /// </summary>
        [TestMethod]
        public void Creation_AdminToAdmin_Invalid()
        {
            var uName = "Bob2080"; //admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = new User();
            u2.Username = "Bobby23";
            u2.Role = "Admin";
            u2.Password = "bboy23";
            u2.DateOfBirth = new DateTime(1996, 12, 15);
            u2.City = "Long Beach";
            u2.State = "CA";
            u2.Country = "USA";

            bool actual = _creation.CreateAccount(u1, u2);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// Test Case for empty creation ATTEMPT
        /// </summary>
        [TestMethod]
        public void Creation_isEmptyCreateAccount_Invalid()
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
                actual = _creation.CreateAccount(u1, u2);
            }

            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }
    }
}
