using System;
using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.ManagerLayer.Logging;
using KFC.Red.ServiceLayer.Logging;
using MongoDB.Bson;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KFC.Red.UnitTest
{
    [TestClass]
    public class Logging_Test
    {

        [TestMethod]
        public void EmailNotification_Success_ReturnTrue()
        {
            //Arrange
           
            //Act
            
            //Assert
            
        }

        [TestMethod]
        public void EmailNotification_Success_ReturnFalse()
        {
            //Arrange
            
            //Act
            
            //Assert
            
        }

        [TestMethod]
        public void LoggingCreateErrorLog_Success_ReturnTrue()
        {
            //Arrange
            LoggingManager<ErrorLogDTO> logman = new LoggingManager<ErrorLogDTO>();

            //Act
            bool expectedResultTrue = true;
            var actualResult = logman.CreateErrorLog();

            //Assert
            Assert.AreEqual(expectedResultTrue, actualResult);
        }

        [TestMethod]
        public void LoggingCreateErrorLog_Fail_ReturnTrue()
        {
            //Arrange
            LoggingManager<ErrorLogDTO> logman = new LoggingManager<ErrorLogDTO>();

            //Act
            bool expectedResultTrue = false;
            var actualResult = logman.CreateErrorLog();

            //Assert
            Assert.AreNotEqual(expectedResultTrue, actualResult);

        }

        [TestMethod]
        public void LoggingCreateTelemetryLog_Success_ReturnTrue()
        {
            //Arrange
            LoggingManager<TelemetryLogDTO> logman = new LoggingManager<TelemetryLogDTO>();

            //Act
            bool expectedResultTrue = true;
            var actualResult = logman.CreateTelemetryLog();

            //Assert
            Assert.AreEqual(expectedResultTrue, actualResult);
        }
        

        [TestMethod]
        public void LoggingCreateTelemetryLog_Fail_ReturnTrue()
        {
            //Arrange
            LoggingManager<TelemetryLogDTO> logman = new LoggingManager<TelemetryLogDTO>();

            //Act
            bool expectedResultFalse = false;
            var actualResult = logman.CreateTelemetryLog();

            //Assert
            Assert.AreNotEqual(expectedResultFalse, actualResult);
        }

        [TestMethod]
        public void LoggingDeleteErrorLog_Success_ReturnTrue()
        {
            // Arrange
            var lm = new LoggingManager<ErrorLogDTO>();
            bool result;

            //using ()
            {
                // Act 


                // Assert

            }
        }

        [TestMethod]
        public void LoggingDeleteErrorLog_Fail_ReturnTrue()
        {
            // Arrange
            var lm = new LoggingManager<ErrorLogDTO>();
            bool result;

            //using ()
            {
                // Act 


                // Assert

            }
        }
    }
}
