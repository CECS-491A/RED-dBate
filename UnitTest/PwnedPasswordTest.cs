using Microsoft.VisualStudio.TestTools.UnitTesting;
using PwnedPassword;

namespace UnitTest
{
    [TestClass]
    public class PwnedPasswordTest
    {

        ValidationManager vManager = new ValidationManager();

        [TestMethod]
        public void StatusMessages_SafePassword_ReturnsStatusZeroMessage()
        {
            string expected = "Password is safe to use!";
            string actual;

            int statusNumber = 0;
            actual = vManager.StatusMessages(statusNumber);

            Assert.AreEqual(expected, actual);
        }
    }
}
