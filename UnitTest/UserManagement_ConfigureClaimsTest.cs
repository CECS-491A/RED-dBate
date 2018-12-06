﻿using System;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
using UserManagement;

namespace UnitTest
{
    [TestClass]
    public class UserManagement_ConfigureClaimsTest
    {
        IUnitOfWork _uow;
        ConfigureClaims _configureClaims;
        IRepository<User> _User;

        [TestInitialize]
        public void SetUp()
        {
            _uow = new MockUnitOfWork<MockDataContext>();
            _configureClaims = new ConfigureClaims(_uow);
            _User = _uow.GetRepository<User>();
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
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault(); 
            Console.WriteLine(u1.Username);

            bool actual =  _configureClaims.AddClaim(u1, u2, "Create Documents");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ConfigureClaims_AddClaims_Invalid()
        {
            var uName = "Bob2080";
            var uName2 = "VicePresident";
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            //Console.WriteLine(u1.Username);

            bool actual = _configureClaims.AddClaim(u1, u2, "Create Documents");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConfigureClaims_DeleteClaims_Valid()
        {
            var uName = "Bob2080";
            var uName2 = "VicePresident";
            bool expected = true;

            User u1 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();

            bool actual = _configureClaims.DeletedClaim(u1,u2,"ViewDocuments");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        
        }

        [TestMethod]
        public void ConfigureClaims_DeleteClaims_Invalid()
        {
            //Registered Users can't delete claims
            var uName = "Bob2080";
            var uName2 = "VicePresident";
            bool expected = false;

            User u1 = _User.GetAll().Where(s => s.Username == uName2).SingleOrDefault();
            User u2 = _User.GetAll().Where(s => s.Username == uName).SingleOrDefault();

            bool actual = _configureClaims.DeletedClaim(u1, u2, "Update");
            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);

        }
    }
}
