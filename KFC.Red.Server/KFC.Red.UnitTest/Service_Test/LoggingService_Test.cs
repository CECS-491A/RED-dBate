using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KFC.Red.ServiceLayer.Logging;
using KFC.Red.DataAccessLayer.DTOs;

namespace KFC.Red.UnitTest.Service_Test
{
    [TestClass]
    public class LoggingService_Test
    {
        [TestMethod]
        public void FailCountEmail_Success_ReturnTrue()
        {
            //Arrange
            LoggingService<ErrorLogDTO> logserv = new LoggingService<ErrorLogDTO>("ErrorLogs");

            //Act
            bool expectedResultTrue = true;
            var actualResult = logserv.FailCountEmail(1);
            //Assert
            Assert.AreEqual(expectedResultTrue, actualResult);


        }

        [TestMethod]
        public void FailCountEmail_Success_ReturnFalse()
        {
            //Arrange
            LoggingService<ErrorLogDTO> logserv = new LoggingService<ErrorLogDTO>("ErrorLogs");

            //Act
            bool expectedResultTrue = false;
            var actualResult = logserv.FailCountEmail(1);
            //Assert
            Assert.AreNotEqual(expectedResultTrue, actualResult);

        }
    }
}
