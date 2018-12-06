using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PwnedPassword;

namespace UnitTest
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
            PasswordStatus actual = vManager.IsPasswordSafe("pwnage142").Result;

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
            PasswordStatus actual = vManager.IsPasswordSafe("password123").Result;

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


        //---StatusOfPassWord() Test---//


        [TestMethod]
        public void StatusOfPassword_FewBreachesSuccess_ReturnsOne()
        {
            int expected = 1;
            int actual;
            string testHash = "TESTINGHASHVALUE:1";

            actual = vManager.StatusOfPassword(5, testHash);
            Console.WriteLine("Actual:" + actual);
            Console.WriteLine("Actual" + expected);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StatusOfPassword_FewBreachesFail_ReturnsOne()
        {
            int expected = 1;
            int actual;
            string testHash = "TESTINGHASHVALUE:111";

            actual = vManager.StatusOfPassword(5, testHash);
            Console.WriteLine("Actual:" + actual);
            Console.WriteLine("Actual" + expected);
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void StatusOfPassword_MultipleBreachesSuccess_ReturnsTwo()
        {
            int expected = 2;
            int actual;
            string testHash = "TESTINGHASHVALUE:11";

            actual = vManager.StatusOfPassword(5, testHash);
            Console.WriteLine("Actual:" + actual);
            Console.WriteLine("Actual" + expected);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StatusOfPassword_MultipleBreachesFail_ReturnsTwo()
        {
            int expected = 2;
            int actual;
            string testHash = "TESTINGHASHVALUE:10";

            actual = vManager.StatusOfPassword(5, testHash);
            Console.WriteLine("Actual:" + actual);
            Console.WriteLine("Actual" + expected);
            Assert.AreNotEqual(expected, actual);
        }


        //---StatusMessages() Test---//


        [TestMethod]
        public void StatusMessages_SafePasswordSuccess_ReturnsStatusZeroMessage()
        {
            string expected = "Password is safe to use!";
            string actual;

            int statusNumber = 0;
            actual = vManager.StatusMessages(statusNumber);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StatusMessages_SafePasswordFail_ReturnsStatusZeroMessage()
        {
            string expected = "Password is safe to use!";
            string actual;

            int statusNumber = 3;
            actual = vManager.StatusMessages(statusNumber);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void StatusMessages_AcceptablePasswordSuccess_ReturnsStatusOneMessage()
        {
            string expected = "Password has been breached a few times before! We recommend you change your password!";
            string actual;

            int statusNumber = 1;
            actual = vManager.StatusMessages(statusNumber);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StatusMessages_AcceptablePasswordFail_ReturnsStatusOneMessage()
        {
            string expected = "Password has been breached a few times before! We recommend you change your password!";
            string actual;

            int statusNumber = 3;
            actual = vManager.StatusMessages(statusNumber);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void StatusMessages_UnsafePasswordSuccess_ReturnsStatusTwoMessage()
        {
            string expected = "Password is unsafe! Use a different password!";
            string actual;

            int statusNumber = 3;
            actual = vManager.StatusMessages(statusNumber);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StatusMessages_UnsafePasswordFail_ReturnsStatusTwoMessage()
        {
            string expected = "Password is unsafe! Use a different password!";
            string actual;

            int statusNumber = 0;
            actual = vManager.StatusMessages(statusNumber);

            Assert.AreNotEqual(expected, actual);
        }
    }
}