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
using System.Net.Mail;

namespace KFC.Red.UnitTest
{
    [TestClass]
    public class Logging_Test
    {


        [TestMethod]
        public void EmailNotification_Success_ReturnTrue()
        {
            /*
            //Mock<SmtpClient> smtpClient = new Mock<SmtpClient>();
            //SmtpProvider smtpProvider = new SmtpProvider(smtpClient.Object);
            string @from = "from@from.com";
            string to = "to@to.com";
            bool send = smtpProvider.Send(@from, to);
            Assert.IsTrue(send);*/
        }

        [TestMethod]
        public void EmailNotification_Success_ReturnFalse()
        {/*
            //Mock<SmtpClient> smtpClient = new Mock<SmtpClient>();
            //SmtpProvider smtpProvider = new SmtpProvider(smtpClient.Object);
            string @from = "to@to.com";
            string to = "from@from.com";
            bool send = smtpProvider.Send(@from, to);
            Assert.IsTrue(send);*/
        }

        [TestMethod]
        public void LoggingCreateErrorLog_Success_ReturnTrue()
        {
            // Arrange
            var ls = new LoggingService<ErrorLogDTO>("logCollection");
            BsonDocument log = new BsonDocument();
            IMongoCollection<BsonDocument> myDoc = ls.GetCollection("ErrorLogs");
            bool result;
            BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
            BsonElement error = new BsonElement("error", "fail to join session");
            BsonElement target = new BsonElement("target", "chat");
            BsonElement currentLoggedUser = new BsonElement("loggedInUser", "testemail@gmail.com");
            BsonElement userRequest = new BsonElement("userRequest", "join session");
            //Act
            //result = ls.CreateLog();
            //Assert
            //Assert.IsTrue(result);

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
