using System;
using ManagerLayer.Password;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
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
            PasswordStatus expectedStatus = StatusOfPassword();
            PasswordStatus actualStaus = StausOfPassword();

            Assert.AreEqual(expectedStatus, actualStaus);
        }

        [TestMethod]
        public void StatusOfPassword_Unsafe()
        {
            PasswordStatus expectedStatus = StatusOfPassword();
            PasswordStatus actualStaus = StausOfPassword();

            Assert.AreEqual(expectedStatus, actualStaus);
        }

        [TestMethod]
        public void StatusOfPassword_Dangerous()
        {
            PasswordStatus expectedStatus = StatusOfPassword();
            PasswordStatus actualStaus = StausOfPassword();

            Assert.AreEqual(expectedStatus, actualStaus);
        }

        [TestMethod]
        public void StatusOfPassword_Secured()
        {
            PasswordStatus expectedStatus = StatusOfPassword();
            PasswordStatus actualStaus = StausOfPassword();

            Assert.AreEqual(expectedStatus, actualStaus);
        }
    }
}
