using System;
using System.Collections.Generic;
using System.Security.Claims;
using Authorization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;

namespace UnitTest
{
    [TestClass]
    public class UnitTest_AuthMan
    {
        AuthorizationManager aM = new AuthorizationManager();

        [TestMethod]
        public void TestCheckAccessClaimInUserValid()
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
        public void TestCheckAccessClaimInUserInvalid()
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

        [TestMethod]
        public void TestCheckUserToUserValid()
        {
            // Used as a second user
            AuthorizationManager aM2 = new AuthorizationManager();

            string claim = "ViewData";
            bool expected = true;
            bool actual;
            string claim2 = "CreateRegUserAccount";

            aM.user.Name = "Luis";
            aM.user.Role = "System Admin";
            aM.user.CollectionClaims.Add(claim2);

            aM2.user.Name = "Alexander";
            aM2.user.Role = "Registered User";
            aM2.user.CollectionClaims.Add(claim);

            actual = aM.CheckAccess(claim2);
            Console.WriteLine(actual);

            bool actual2 = true;

            if (actual == true && aM2.user.Role=="Registered User")
            {
                actual2 = true;
            }
            else
            {
                actual2 = false;
            }

            Console.WriteLine("Actual Value: " + actual2);
            Assert.AreEqual(expected, actual2);

        }

        [TestMethod]
        public void TestCheckUserToUserInvalid()
        {
            // Used as a second user
            AuthorizationManager aM2 = new AuthorizationManager();

            string claim = "ViewData";
            bool expected = false;
            bool result;
            string claim2 = "CreateRegUserAccount";

            aM.user.Name = "Luis";
            aM.user.Role = "Registered User";
            aM.user.CollectionClaims.Add(claim2);

            aM2.user.Name = "Alexander";
            aM2.user.Role = "System Admin";
            aM2.user.CollectionClaims.Add(claim);

            result = aM.CheckAccess(claim2);
            
            bool actual = true;

            if (result == true && aM2.user.Role == "Registered User")
            {
                actual = true;
            }
            else
            {
                actual = false;
            }

            Console.WriteLine("Actual Value: " + actual);
            Assert.AreEqual(expected, actual);

        }
    }
}
