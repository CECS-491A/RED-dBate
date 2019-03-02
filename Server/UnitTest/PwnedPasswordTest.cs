using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KFC.Red.ManagerLayer.Password;

namespace KFC.Red.UnitTest
{
    [TestClass]
    public class PwnedPasswordTest
    {

        ValidationManager vManager = new ValidationManager();

        //---IsPasswordSafe() Test---//
        // Test values subject to change


        [TestMethod]
        public void IsPasswordSafe_SafePasswordSuccess_ReturnMatchingObjectValues()
        {
            PasswordStatus expected = new PasswordStatus(0, "Password is safe to use!");
            PasswordStatus actual = vManager.IsPasswordSafe("wgui90m24ve28c23").Result;

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void IsPasswordSafe_SafePasswordFail_ReturnMatchingObjectValues()
        {
            PasswordStatus expected = new PasswordStatus(0, "Password is safe to use!");
            PasswordStatus actual = vManager.IsPasswordSafe("password123").Result;

            Assert.AreNotEqual(expected.Status, actual.Status);
            Assert.AreNotEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void IsPasswordSafe_AcceptablePasswordPass_ReturnMatchingObjectValues()
        {
            PasswordStatus expected = new PasswordStatus(1, "Password has been breached a few times before! We recommend you change your password!");
            PasswordStatus actual = vManager.IsPasswordSafe("passwordpassword1234").Result;

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void IsPasswordSafe_AcceptablePasswordFail_ReturnMatchingObjectValues()
        {
            PasswordStatus expected = new PasswordStatus(1, "Password has been breached a few times before! We recommend you change your password!");
            PasswordStatus actual = vManager.IsPasswordSafe("password123").Result;

            Assert.AreNotEqual(expected.Status, actual.Status);
            Assert.AreNotEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void IsPasswordSafe_UnsafePasswordSuccess_ReturnMatchingObjectValues()
        {
            PasswordStatus expected = new PasswordStatus(2, "Password is unsafe! Use a different password!");
            PasswordStatus actual = vManager.IsPasswordSafe("passwordpassword").Result;

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void IsPasswordSafe_UnsafePasswordFail_ReturnMatchingObjectValues()
        {
            PasswordStatus expected = new PasswordStatus(2, "Password is unsafe! Use a different password!");
            PasswordStatus actual = vManager.IsPasswordSafe("oiwge80q92uen").Result;

            Assert.AreNotEqual(expected.Status, actual.Status);
            Assert.AreNotEqual(expected.Message, actual.Message);
        }
    }
}