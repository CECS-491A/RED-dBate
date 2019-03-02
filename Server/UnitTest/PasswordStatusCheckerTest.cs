using System;
using KFC.Red.ManagerLayer.Password;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KFC.Red.UnitTest
{
    [TestClass]
    public class PasswordStatusCheckerTest
    {
        PasswordStatusChecker sCheck = new PasswordStatusChecker();

        [TestMethod]
        public void StatusMessages_Error()
        {
            string actual = sCheck.StatusMessages(-1);
            string expected = "An ERROR has occurred with the request while checking password security.";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StatusMessages_Safe()
        {
            string actual = sCheck.StatusMessages(0);
            string expected = "Password is safe to use!";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StatusMessages_Breached()
        {
            string actual = sCheck.StatusMessages(1);
            string expected = "Password has been breached a few times before! We recommend you change your password!";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StatusMessages_Unsafe()
        {
            string actual = sCheck.StatusMessages(-99);
            string expected = "Password is unsafe! Use a different password!";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StatusOfPassword_Error()
        {
            PasswordStatus expectedStatus = new PasswordStatus(-1, "An ERROR has occurred with the request while checking password security.");
            PasswordStatus actualStatus = sCheck.StatusOfPassword("","");

            Assert.AreEqual(expectedStatus.Status, actualStatus.Status);
            Assert.AreEqual(expectedStatus.Message, actualStatus.Message);
        }
        
        [TestMethod]
        public void StatusOfPassword_Unsafe()
        {
            PasswordStatus expectedStatus = new PasswordStatus(2, "Password is unsafe! Use a different password!");
            PasswordStatus actualStatus = sCheck.StatusOfPassword("TESTPREFIX:100", "TESTPREFIX");

            Assert.AreEqual(expectedStatus.Status, actualStatus.Status);
            Assert.AreEqual(expectedStatus.Message, actualStatus.Message);
        }

        
        [TestMethod]
        public void StatusOfPassword_Dangerous()
        {
            PasswordStatus expectedStatus = new PasswordStatus(1, "Password has been breached a few times before! We recommend you change your password!");
            PasswordStatus actualStatus = sCheck.StatusOfPassword("TESTPREFIX:10", "TESTPREFIX");

            Assert.AreEqual(expectedStatus.Status, actualStatus.Status);
            Assert.AreEqual(expectedStatus.Message, actualStatus.Message);
        }
        
        [TestMethod]
        public void StatusOfPassword_Secured()
        {
            PasswordStatus expectedStatus = new PasswordStatus(0, "Password is safe to use!");
            PasswordStatus actualStatus = sCheck.StatusOfPassword("TESTPREFIX:100", "NOPREFIXFOUND");

            Assert.AreEqual(expectedStatus.Status, actualStatus.Status);
            Assert.AreEqual(expectedStatus.Message, actualStatus.Message);
        }
        
    }
}
