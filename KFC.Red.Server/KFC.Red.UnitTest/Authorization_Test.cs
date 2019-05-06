using System;
using System.Collections.Generic;
using KFC.Red.DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KFC.Red.ServiceLayer.Authorization;
using KFC.Red.DataAccessLayer.Models;

namespace KFC.Red.UnitTest
{
    [TestClass]
    public class Authorization_Test
    {
        Authorization aM = new Authorization();

        [TestMethod]
        public void TestCheckAccessClaimInUserValid()
        {
            //Create Claim
            Claim claim = new Claim();
            claim.ID = 7;
            claim.ClaimName = "ChangeTime";

            bool expected = true;
            bool actual;

            aM.user.CollectionClaims.Add(claim);

            actual = aM.CheckAccess(claim);

            Console.WriteLine("Actual Value: " + actual);
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void TestCheckAccessClaimInUserInvalid()
        {

            //Create Claim
            Claim claim = new Claim();
            claim.ID = 7;
            claim.ClaimName = "ChangeTime";

            Claim invalidClaim = new Claim();
            invalidClaim.ID = 8;
            invalidClaim.ClaimName = "ChangeChatRules";

            bool expected = false;
            bool actual;

            aM.user.CollectionClaims.Add(claim);

            actual = aM.CheckAccess(invalidClaim);

            Console.WriteLine("Actual Value: " + actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckUserDoesNotExist()
        {
            Claim invalidClaim = new Claim();
            invalidClaim.ID = 8;
            invalidClaim.ClaimName = "ChangeChatRules";

            bool expected = false;
            bool actual;

            actual = aM.CheckAccess(invalidClaim);

            Console.WriteLine("Actual Value: " + actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckUserToUserValid()
        {
            // Used as a second user
            Authorization aM2 = new Authorization();

            bool expected = true;
            bool actual;

            Claim claim = new Claim();
            claim.ID = 8;
            claim.ClaimName = "ViewData";

            Claim claim2 = new Claim();
            claim2.ID = 9;
            claim2.ClaimName = "CreateRegUserAccount";


            aM.user.Role = "System Admin";
            aM.user.CollectionClaims.Add(claim2);

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
            Authorization aM2 = new Authorization();

            bool expected = false;
            bool result;

            Claim claim = new Claim();
            claim.ID = 8;
            claim.ClaimName = "ViewData";

            Claim claim2 = new Claim();
            claim2.ID = 9;
            claim2.ClaimName = "CreateRegUserAccount";


            aM.user.Role = "Registered User";
            aM.user.CollectionClaims.Add(claim2);

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