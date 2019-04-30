using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.ManagerLayer.Logging;
using KFC.Red.ServiceLayer.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KFC.Red.UnitTest
{
    [TestClass]
    public class Logging_Test
    {


        [TestMethod]
        public void LoggingGetLogAsync_Success_ReturnTrue()
        {
            // Arrange
            var ls = new LoggingService<ErrorLogDTO>("logCollection");
            bool result;




            //using ()
            {
                // Act 


                // Assert

            }
        }


        [TestMethod]
        public void LoggingGetLogAsync_Fail_ReturnTrue()
        {
            // Arrange
            var ls = new LoggingService<ErrorLogDTO>("logCollection");
            bool result;

            //using ()
            {
                // Act 


                // Assert

            }
        }

        [TestMethod]
        public void LoggingCreateErrorLog_Success_ReturnTrue()
        {
            // Arrange
            var lm = new LoggingManager<ErrorLogDTO>();
            bool result;
            BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));



            //using ()
            {
                // Act 


                // Assert

            }
        }

        [TestMethod]
        public void LoggingCreateErrorLog_Fail_ReturnTrue()
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
        public void LoggingCreateTelemetryLog_Success_ReturnTrue()
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
        public void LoggingCreateTelemetryLog_Fail_ReturnTrue()
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
