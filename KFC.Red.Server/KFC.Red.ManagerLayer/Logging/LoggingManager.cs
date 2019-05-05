using KFC.Red.ServiceLayer.Logging;
using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.DataAccessLayer.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KFC.Red.ManagerLayer.SessionManagement;
using KFC.Red.ManagerLayer.UserManagement;

/// <summary>
/// This Manager Layer class contains the Logger method.
/// </summary>
namespace KFC.Red.ManagerLayer.Logging
{
    public class LoggingManager<T>
    {
        //Method failed logs is used if the system fails to log
        public int failedLogs;
        
        /// <summary>
        /// DisplayLogsAsync return a list of the displayment of the logs in BSON  format.
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public async Task<List<T>> DisplayLogsAsync(string collectionName)
        {
            //Created LoggingService object.
            LoggingService<T> logService = new LoggingService<T>(collectionName);
            //GetCollection is a built in mongo method to retrieve information.
            var collection = logService.GetCollection(collectionName);
            //
            var count = await collection.CountDocumentsAsync(new BsonDocument());
            //
            var documents = await logService._logCollection.Find(new BsonDocument()).ToListAsync();

            return documents;
        }

        /// <summary>
        /// Logger method to create an error log
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="token"></param>
        public void CreateErrorLog(Exception ex, string token)
        {
            UserManager userman = new UserManager();
            //Logging service type to be ErrorLogDTO
            LoggingService<ErrorLogDTO> elogService = new LoggingService<ErrorLogDTO>("ErrorLogs");

            BsonDocument log = new BsonDocument();
            IMongoCollection<BsonDocument> myDoc = elogService.GetCollection("ErrorLogs");

            //Getting token to log users.
            var session = GetLogInfo(token); 
            //var user = userman.GetUser(session.UId);

            try
            {
                BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")); //display date
                BsonElement error = new BsonElement("error", ex.Message.ToString()); //display message
                BsonElement target = new BsonElement("target", ex.TargetSite.ToString()); // display the method
                BsonElement currentLoggedUser = new BsonElement("loggedInUser", "user1"); // display user email
                BsonElement userRequest = new BsonElement("userRequest", ex.Source.ToString()); //display the request
                log.Add(date); log.Add(error); log.Add(target); log.Add(currentLoggedUser); log.Add(userRequest);

                myDoc.InsertOne(log); //builtin mongo method to insert inton the cluster
            }
            catch (MongoException)
            {
                elogService.FailCountEmail(failedLogs);
            }
        }

        /// <summary>
        /// Mock Data errorlog creator
        /// </summary>
        public bool CreateErrorLog()
        {
            UserManager userman = new UserManager();
            LoggingService<ErrorLogDTO> elogService = new LoggingService<ErrorLogDTO>("ErrorLogs");

            BsonDocument log = new BsonDocument();
            IMongoCollection<BsonDocument> myDoc = elogService.GetCollection("ErrorLogs");

            //var session = GetLogInfo(token);
            //var user = userman.GetUser(session.UId);

            try
            {
                BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement error = new BsonElement("error", "fail to join session");
                BsonElement target = new BsonElement("target", "chat");
                BsonElement currentLoggedUser = new BsonElement("loggedInUser", "testemail@gmail.com");
                BsonElement userRequest = new BsonElement("userRequest", "join session");
                log.Add(date); log.Add(error); log.Add(target); log.Add(currentLoggedUser); log.Add(userRequest);

                myDoc.InsertOne(log);
                return true;
            }
            catch (MongoException)
            {
                elogService.FailCountEmail(failedLogs);
                return false;
            }
        }


        /// <summary>
        /// Logger method to create an telemetry log
        /// </summary>
        /// <param name="token"></param>
        /// <param name="ip"></param>
        /// <param name="loc"></param>
        public void CreateTelemetryLog(string token, string ip, string loc)
        {
            BsonDocument log = new BsonDocument();
            LoggingService<TelemetryLogDTO> tlogService = new LoggingService<TelemetryLogDTO>("TelemetryLogs");
            IMongoCollection<BsonDocument> myDoc = tlogService.GetCollection("TelemetryLogs");

            var session = GetLogInfo(token);
            var logouttime = "12/15/1996";//session.DeleteTime;
            var logintime = "12/15/1996"; //session.CreateTime;
            try
            {
                BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement userlogin = new BsonElement("userLogin", logouttime);
                BsonElement userlogout = new BsonElement("userLogout", logintime);
                BsonElement functionalityexecution = new BsonElement("clickevent", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement pagevisit = new BsonElement("pageVisit", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement ipaddress = new BsonElement("IPAddress", ip);

                myDoc.InsertOne(log);

                log.Add(date); log.Add(userlogin); log.Add(userlogout); log.Add(functionalityexecution); log.Add(pagevisit); log.Add(ipaddress);

                myDoc.InsertOne(log);
            }
            catch (MongoException)
            {
                tlogService.FailCountEmail(failedLogs);
            }
        }

        /// <summary>
        /// Mock Data errorlog creator
        /// </summary>
        public bool CreateTelemetryLog()
        {
            BsonDocument log = new BsonDocument();
            LoggingService<TelemetryLogDTO> tlogService = new LoggingService<TelemetryLogDTO>("TelemetryLogs");
            IMongoCollection<BsonDocument> myDoc = tlogService.GetCollection("TelemetryLogs");

            //var session = GetLogInfo();
            var logouttime = "12/15/1996";//session.DeleteTime;
            var logintime = "12/15/1996"; //session.CreateTime;
            try
            {
                BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement userlogin = new BsonElement("userLogin", logouttime);
                BsonElement userlogout = new BsonElement("userLogout", logintime);
                BsonElement functionalityexecution = new BsonElement("clickevent", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement pagevisit = new BsonElement("pageVisit", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement ipaddress = new BsonElement("IPAddress", "255.255.255.0");

                log.Add(date); log.Add(userlogin); log.Add(userlogout); log.Add(functionalityexecution); log.Add(pagevisit); log.Add(ipaddress);

                myDoc.InsertOne(log);
                return true;
            }
            catch (MongoException)
            {
                tlogService.FailCountEmail(failedLogs);
                return false;
            }
        }

        /// <summary>
        /// Method to delete error logs from the collection
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collectionName"></param>
        public void DeleteLog(string id,string collectionName)
        {
            LoggingService<ErrorLogDTO> loggerService = new LoggingService<ErrorLogDTO>(collectionName); //Built in method from 
            loggerService._logCollection.FindOneAndDelete(new BsonDocument { { "_id", new ObjectId(id) } });
        }


        /// <summary>
        /// Method to get the token from the session class. 
        /// This method is used to get the token to keep track of user login/logout.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Session GetLogInfo(string token)
        {
            SessionManager sessman = new SessionManager();
            var session = sessman.GetSession(token);
            return session;
        }
    }
}
