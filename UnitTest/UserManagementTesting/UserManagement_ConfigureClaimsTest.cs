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
    public class UserManagement_ConfigureClaimsTest
    {
        IUnitOfWork _uow;
        ConfigureClaims _configureClaims;
        IRepository<User> _User;
        IRepository<Claim> _Claim;

        [TestInitialize]
        public void SetUp()
        {
            _uow = new MockUnitOfWork<MockDataContext>();
            _configureClaims = new ConfigureClaims(_uow);
            _User = _uow.GetRepository<User>();
            _Claim = _uow.GetRepository<Claim>();

        }

        [TestCleanup]
        public void TearDown()
        {

            // Clean resources
        }

        [TestMethod]
        public void ConfigureClaims_AddClaims_Valid()
        {
            var uName = "Bob2080";
            var uName2 = "VicePresident";
            var cName = "Update";
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            Claim c = _Claim.GetAll().Where(s => s.ClaimName == cName).SingleOrDefault();
            Console.WriteLine(u1.Username);

            bool actual =  _configureClaims.AddClaim(u1, u2, c);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ConfigureClaims_AddClaims_Invalid()
        {
            var uName = "Bob2080";
            var uName2 = "VicePresident";
            var cName = "Update";
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            Claim c = _Claim.GetAll().Where(s => s.ClaimName == cName).SingleOrDefault();

            bool actual = _configureClaims.AddClaim(u1, u2, c);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConfigureClaims_DeleteClaims_Valid()
        {
            var uName = "Bob2080";
            var uName2 = "VicePresident";
            var cName = "View";
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            Claim c = _Claim.GetAll().Where(s => s.ClaimName == cName).SingleOrDefault();

            bool actual = _configureClaims.DeletedClaim(u1,u2,c);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConfigureClaims_DeleteClaims_Invalid()
        {
            //Registered Users can't delete claims
            var uName = "Bob2080";
            var uName2 = "VicePresident";
            var cName = "Update";
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            Claim c = _Claim.GetAll().Where(s => s.ClaimName == cName).SingleOrDefault();

            bool actual = _configureClaims.DeletedClaim(u1, u2, c);
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }
    }
}
