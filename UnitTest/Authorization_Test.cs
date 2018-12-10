using System;
using System.Collections.Generic;
using System.Security.Claims;
using Authorization;
using DataAccessLayer;
using DataAccessLayer.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
using Claim = ModelLayer.Claim;

namespace UnitTest
{
    [TestClass]
    public class Authorization_Test
    {
        AuthorizationManager aM = new AuthorizationManager();

        [TestMethod]
        public void TestCheckAccessClaimInUserValid()
        {
            //Create Claim
            Claim claim = new Claim();
            claim.ID = 7;
            claim.ClaimName = "ChangeTime";

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

            //Create Claim
            Claim claim = new Claim();
            claim.ID = 7;
            claim.ClaimName = "ChangeTime";

            Claim invalidClaim = new Claim();
            invalidClaim.ID = 8;
            invalidClaim.ClaimName = "ChangeChatRules";

            bool expected = false;
            bool actual;

            aM.user.Name = "Bob";
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
            AuthorizationManager aM2 = new AuthorizationManager();

            bool expected = true;
            bool actual;

            Claim claim = new Claim();
            claim.ID = 8;
            claim.ClaimName = "ViewData";

            Claim claim2 = new Claim();
            claim2.ID = 8;
            claim2.ClaimName = "CreateRegUserAccount";


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

            bool expected = false;
            bool result;

            Claim claim = new Claim();
            claim.ID = 8;
            claim.ClaimName = "ViewData";

            Claim claim2 = new Claim();
            claim2.ID = 8;
            claim2.ClaimName = "CreateRegUserAccount";


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

        //THIS IS COMMENTED OUT BECAUSE I MAY OR MAY NOT DELETE METHOD. IT'S PROBABLY NOT HOW THE 
        // HOW THE PROFESSOR WANTS IT
       /* [TestMethod]
        public void TestCheckUserToSystemInvalid()
        {
            string claim = "ViewData";
            bool expected = false;

            bool actual = aM.CheckAccessSystem(claim);

            Console.WriteLine("Actual Value: " + actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckUserToSystemValid()
        {
            string claim = "View Documents";
            bool expected = true;

            bool actual = aM.CheckAccessSystem(claim);

            Console.WriteLine("Actual Value: " + actual);
            Assert.AreEqual(expected, actual);
        }*/
    }
}
