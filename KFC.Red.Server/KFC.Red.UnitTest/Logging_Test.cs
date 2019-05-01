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
using static KFC.Red.ServiceLayer.Logging.EmailTest;

namespace KFC.Red.UnitTest
{
    [TestClass]
    public class Logging_Test
    {

        [TestMethod]
        public void EmailNotification_Success_ReturnTrue()
        {
            FakeSmtpClient fakeClient = new FakeSmtpClient();
            EmailHelper helper = new EmailHelper(fakeClient);

            helper.SendSupportMail("your mail address");

            Assert.IsFalse(fakeClient.MailSent);
        }

        [TestMethod]
        public void EmailNotification_Success_ReturnFalse()
        {
            FakeSmtpClient fakeClient = new FakeSmtpClient();
            EmailHelper helper = new EmailHelper(fakeClient);

            helper.SendSupportMail("your mail address");

            Assert.IsFalse(fakeClient.MailSent);
        }

        [TestMethod]
        public void LoggingCreateErrorLog_Success_ReturnTrue()
        {
            //Arrange
            LoggingService<ErrorLogDTO> elogger = new LoggingService<ErrorLogDTO>("ErrorLogs");
            BsonDocument log = new BsonDocument();
            IMongoCollection<BsonDocument> myDoc = elogger.GetCollection("ErrorLogs");
                BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement error = new BsonElement("error", "fail to join session");
                BsonElement target = new BsonElement("target", "chat");
                BsonElement currentLoggedUser = new BsonElement("loggedInUser", "testemail@gmail.com");
                BsonElement userRequest = new BsonElement("userRequest", "join session");
            //Act
                log.Add(date); log.Add(error); log.Add(target); log.Add(currentLoggedUser); log.Add(userRequest);
                myDoc.InsertOne(log);

            Assert.AreEqual(myDoc, log);

        }

        [TestMethod]
        public void LoggingCreateErrorLog_Fail_ReturnTrue()
        {
            //Arrange
            LoggingService<ErrorLogDTO> elogger = new LoggingService<ErrorLogDTO>("ErrorLogs");
            BsonDocument log = new BsonDocument();
            IMongoCollection<BsonDocument> myDoc = elogger.GetCollection("ErrorLogs");
            BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
            BsonElement error = new BsonElement("error", "fail to join session");
            BsonElement target = new BsonElement("target", "chat");
            BsonElement currentLoggedUser = new BsonElement("loggedInUser", "testemail@gmail.com");
            BsonElement userRequest = new BsonElement("userRequest", "join session");
            //Act
            log.Add(date); log.Add(error); log.Add(target); log.Add(currentLoggedUser); log.Add(userRequest);
            myDoc.InsertOne(log);

            Assert.AreEqual(myDoc, log);
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
