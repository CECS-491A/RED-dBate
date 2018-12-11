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
    public class UserManagement_ConfigurationTest
    {
        IUnitOfWork _uow;
        Configuration _configuration;
        IRepository<User> _User;
        IRepository<Location> _Location;
        IRepository<DateOfBirth> _DOB;

        [TestInitialize]
        public void SetUp()
        {
            _uow = new MockUnitOfWork<MockDataContext>();
            _configuration = new Configuration(_uow);
            _User = _uow.GetRepository<User>();
            _Location = _uow.GetRepository<Location>();
            _DOB = _uow.GetRepository<DateOfBirth>();
        }

        [TestCleanup]
        public void TearDown()
        {
            // Clean resources
        }

        /// <summary>
        /// Test case Admin configuring User is valid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureName_AdminToUser_Valid()
        {
            var uName = "Bob2080"; //admin
            var uName2 = "VicePresident"; //user
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            Console.WriteLine(u1.Username);

            bool actual = _configuration.ConfigureName(u1, u2, "Donald Duck");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case System Admin configuring to Admin is valid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureName_SysAdminToAdmin_Valid()
        {
            var uName = "Bill2080"; //sys admin
            var uName2 = "Bob2080"; //admin
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            Console.WriteLine(u1.Username);

            bool actual = _configuration.ConfigureName(u1, u2, "Donald Duck");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case System Admin configuring to User is valid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureName_SysAdminToUser_Valid()
        {
            var uName = "Bill2080"; //sys admin
            var uName2 = "VicePresident"; //user
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            Console.WriteLine(u1.Username);

            bool actual = _configuration.ConfigureName(u1, u2, "Donald Duck");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case User coinfiguring Admin is invalid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureName_RegUserToAdmin_Invalid()
        {
            var uName = "VicePresident"; //reg user
            var uName2 = "Bob2080"; //admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            Console.WriteLine(u1.Username);

            bool actual = _configuration.ConfigureName(u1, u2, "Donald Duck");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case Admin to System Admin is valid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureName_AdminToSysAdmin_Invalid()
        {
            var uName = "Bob2080"; // admin
            var uName2 = "Bill2080"; //sys admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            Console.WriteLine(u1.Username);

            bool actual = _configuration.ConfigureName(u1, u2, "Donald Duck");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case System Admin to User is valid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureName_RegUserToSysAdmin_Invalid()
        {
            var uName = "VicePresident"; // user
            var uName2 = "Bill2080"; //sys admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            Console.WriteLine(u1.Username);

            bool actual = _configuration.ConfigureName(u1, u2, "Donald Duck");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case System Admin to User is valid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureName_AdminToAdmin_Invalid()
        {
            var uName = "Bob2080"; // admin
            var uName2 = "Bob2080"; //admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            Console.WriteLine(u1.Username);

            bool actual = _configuration.ConfigureName(u1, u2, "Donald Duck");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }
////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Test case Admin coinfiguring role to User is valid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureRole_AdminToUser_Valid()
        {
            var uName = "Bob2080"; //admin
            var uName2 = "VicePresident"; //user
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            
            bool actual = _configuration.ConfigureRole(u1, u2, "Registered User Level 2");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case System System Admin coinfiguring role to admin is valid 
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureRole_SysAdminToAdmin_Valid()
        {
            var uName = "Bill2080"; //sys admin
            var uName2 = "Bob2080"; //admin
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _configuration.ConfigureRole(u1, u2, "Reigstered User");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case System System Admin coinfiguring role to admin is valid 
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureRole_SysAdminToRegUser_Valid()
        {
            var uName = "Bill2080"; //sys admin
            var uName2 = "VicePresident"; //user
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _configuration.ConfigureRole(u1, u2, "Reigstered User");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case regular user coinfiguring role to Admin is invalid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureRole_RegUserToAdmin_Invalid()
        {
            var uName = "VicePresident"; //reg user
            var uName2 = "Bob2080"; //admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _configuration.ConfigureRole(u1, u2, "System Admin");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case User coinfiguring role to System is invalid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureRole_RegUserToSystemAdmin_Invalid()
        {
            var uName = "VicePresident"; //reg user
            var uName2 = "Bill2080"; //admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _configuration.ConfigureRole(u1, u2, "System Admin");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case Admin coinfiguring role to system admin is invalid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureRole_AdminToSysAdmin_Invalid()
        {
            var uName = "Bob2080"; // admin
            var uName2 = "Bill2080"; //sys admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            Console.WriteLine(u1.Username);

            bool actual = _configuration.ConfigureRole(u1, u2, "Admin");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case Admin coinfiguring role to system admin is invalid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureRole_AdminToAdmin_Invalid()
        {
            var uName = "Bob2080"; // admin
            var uName2 = "Bob2080"; //sys admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            Console.WriteLine(u1.Username);

            bool actual = _configuration.ConfigureRole(u1, u2, "Admin");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }
        ///////////////////////////////////////////////////////
        /// <summary>
        /// Test case Admin coinfiguring password to User is valid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigurePassword_AdminToUser_Valid()
        {
            var uName = "Bob2080"; //admin
            var uName2 = "VicePresident"; //user
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _configuration.ConfigurePassword(u1, u2, "DonaldDuck");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case Admin coinfiguring password to User is valid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigurePassword_SysAdminToAdmin_Valid()
        {
            var uName = "Bill2080"; //sys admin
            var uName2 = "Bob2080"; //admin
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _configuration.ConfigurePassword(u1, u2, "DonaldDuck");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case Admin coinfiguring password to User is valid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigurePassword_RegUserToAdmin_Invalid()
        {
            var uName = "VicePresident"; //reg user
            var uName2 = "Bob2080"; //admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            Console.WriteLine(u1.Username);

            bool actual = _configuration.ConfigurePassword(u1, u2, "DonaldDuck");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case Admin coinfiguring password to User is valid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigurePassword_AdminToSysAdmin_Invalid()
        {
            var uName = "Bob2080"; // admin
            var uName2 = "Bill2080"; //sys admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            Console.WriteLine(u1.Username);

            bool actual = _configuration.ConfigurePassword(u1, u2, "DonaldDuck");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case Admin coinfiguring password to User is valid
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureLocation_AdminToUser_Valid()
        {
            var uName = "Bob2080"; //admin
            var uName2 = "VicePresident"; //user

            var lC = "Long Beach";
            var lS = "CA";
            bool expected = true;

            Location loc = _Location.GetAll().Where(s => s.City == lC && s.State == lS).SingleOrDefault();
            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _configuration.ConfigureLocation(u1, u2, loc);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }
        ////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureLocation_SysAdminToAdmin_Valid()
        {
            var uName = "Bill2080"; //sys admin
            var uName2 = "Bob2080"; //admin

            var lC = "Long Beach";
            var lS = "CA";
            bool expected = true;

            Location loc = _Location.GetAll().Where(s => s.City == lC && s.State == lS).SingleOrDefault();
            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            
            bool actual = _configuration.ConfigureLocation(u1, u2, loc);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureLocation_RegUserToAdmin_Invalid()
        {
            var uName = "VicePresident"; //reg user
            var uName2 = "Bob2080"; //admin

            var lC = "Long Beach";
            var lS = "CA";
            bool expected = false;

            Location loc = _Location.GetAll().Where(s => s.City == lC && s.State == lS).SingleOrDefault();
            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            Console.WriteLine(u1.Username);

            bool actual = _configuration.ConfigureLocation(u1, u2, loc);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureLocation_AdminToSysAdmin_Invalid()
        {
            var uName = "Bob2080"; // admin
            var uName2 = "Bill2080"; //sys admin

            var lC = "Long Beach";
            var lS = "CA";
            bool expected = false;

            Location loc = _Location.GetAll().Where(s => s.City == lC && s.State == lS).SingleOrDefault();
            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _configuration.ConfigureLocation(u1, u2, loc);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureDOB_AdminToUser_Valid()
        {
            var uName = "Bob2080"; //admin
            var uName2 = "VicePresident"; //user

            var m = "12";
            var d = "15";
            var y = "1996";
            bool expected = true;

            DateOfBirth dob = _DOB.GetAll().Where(s => s.Month == m && s.Day == d && s.Year == y).SingleOrDefault();
            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            
            bool actual = _configuration.ConfigureDOB(u1, u2, dob);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureDOB_SysAdminToAdmin_Valid()
        {
            var uName = "Bill2080"; //sys admin
            var uName2 = "Bob2080"; //admin

            var m = "12";
            var d = "15";
            var y = "1996";
            bool expected = true;

            DateOfBirth dob = _DOB.GetAll().Where(s => s.Month == m && s.Day == d && s.Year == y).SingleOrDefault();
            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
           
            bool actual = _configuration.ConfigureDOB(u1, u2, dob);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureDOB_RegUserToAdmin_Invalid()
        {
            var uName = "VicePresident"; //reg user
            var uName2 = "Bob2080"; //admin

            var m = "12";
            var d = "15";
            var y = "1996";
            bool expected = false;

            DateOfBirth dob = _DOB.GetAll().Where(s => s.Month == m && s.Day == d && s.Year == y).SingleOrDefault();
            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            Console.WriteLine(u1.Username);

            bool actual = _configuration.ConfigureDOB(u1, u2, dob);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureDOB_AdminToSysAdmin_Invalid()
        {
            var uName = "Bob2080"; // admin
            var uName2 = "Bill2080"; //sys admin

            var m = "12";
            var d = "15";
            var y = "1996";
            bool expected = false;

            DateOfBirth dob = _DOB.GetAll().Where(s => s.Month == m && s.Day == d && s.Year == y).SingleOrDefault();
            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _configuration.ConfigureDOB(u1, u2, dob);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureUsername_AdminToUser_Valid()
        {
            var uName = "Bob2080"; //admin
            var uName2 = "VicePresident"; //user
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _configuration.ConfigureUsername(u1, u2, "Donald93");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureUsername_SysAdminToAdmin_Valid()
        {
            var uName = "Bill2080"; //sys admin
            var uName2 = "Bob2080"; //admin
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            Console.WriteLine(u1.Username);

            bool actual = _configuration.ConfigureUsername(u1, u2, "Bill34");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureUsername_RegUserToAdmin_Invalid()
        {
            var uName = "VicePresident"; //reg user
            var uName2 = "Bob2080"; //admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _configuration.ConfigureUsername(u1, u2, "KanyeWest39");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserManagement_ConfigureUsername_AdminToSysAdmin_Invalid()
        {
            var uName = "Bob2080"; // admin
            var uName2 = "Bill2080"; //sys admin
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _configuration.ConfigureUsername(u1, u2, "Pete49er");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }
    }
}
