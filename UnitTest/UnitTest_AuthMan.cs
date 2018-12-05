using System;
using System.Collections.Generic;
using System.Security.Claims;
using Authorization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest_AuthMan
    {
        /// <summary>
        /// blah blah
        /// </summary>
        AuthorizationManager aM = new AuthorizationManager();
        //ClaimStorage cs = new ClaimStorage();

        [TestMethod]
        public void TestCheckAccessValid()
        {
            string claim = "View Documents";
            bool expected = true;
            bool actual;

            aM.user.Name = "Bob";
            aM.user.CollectionClaims.Add(claim);

            actual = aM.CheckAccess(claim);

            Console.WriteLine("Actual Value: " + actual);
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void TestCheckAccessInvalid()
        {
            string claim = "View Documents";
            bool expected = false;
            bool actual;

            aM.user.Name = "Bob";
            aM.user.CollectionClaims.Add(claim);

            actual = aM.CheckAccess("Update Documents");

            Console.WriteLine("Actual Value: " + actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckUserDoesNotExist()
        {
            bool expected = false;
            bool actual;

            actual = aM.CheckAccess("Update Documents");

            Console.WriteLine("Actual Value: " + actual);
            Assert.AreEqual(expected, actual);
        }

        /*
        [TestMethod]
        public void TestCheckUsertoUser()
        {
            string claim = "Authorize ID User";
            bool expected = true;
            bool actual;

            aM.identity.Name = "123";
            aM.identity.CollectionClaims.Add(claim);


            actual = aM.CheckAccess("Update Documents");

            Console.WriteLine("Actual Value: " + actual);
            Assert.AreEqual(expected, actual);
        }
        */


    }
}
