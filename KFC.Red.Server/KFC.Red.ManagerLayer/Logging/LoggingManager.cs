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
using KFC.Red.ManagerLayer.ChatroomManager;
using System.Web;

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
            var _database = await logService._logCollection.Find(new BsonDocument()).ToListAsync();

            return _database;
        }

        /// <summary>
        /// Logger method to create an error log
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="token"></param>
        public void CreateErrorLog(Exception ex, string sessToken)
        {
            UserManager userMan = new UserManager();
            //Logging service type to be ErrorLogDTO
            LoggingService<ErrorLogDTO> elogService = new LoggingService<ErrorLogDTO>("ErrorLogs");

            BsonDocument log = new BsonDocument();
            IMongoCollection<BsonDocument> collection = elogService.GetCollection("ErrorLogs");

            var session = GetLogInfo(sessToken);
            var user = userMan.GetUser(session.UId);
            try
            {
                BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")); 
                BsonElement error = new BsonElement("error", ex.Message.ToString()); 
                BsonElement target = new BsonElement("target", ex.TargetSite.ToString()); 
                BsonElement currentLoggedUser = new BsonElement("loggedInUser", user.Email); 
                BsonElement userRequest = new BsonElement("userRequest", ex.Source.ToString());
                log.Add(date); log.Add(error); log.Add(target); log.Add(currentLoggedUser); log.Add(userRequest);

                collection.InsertOne(log); 
            }
            catch (MongoException)
            {
                elogService.FailCountEmail(failedLogs);
            }
        }


        /// <summary>
        /// Logger method to create an telemetry log
        /// </summary>
        /// <param name="token"></param>
        /// <param name="ip"></param>
        /// <param name="loc"></param>
        public void CreateTelemetryLog(string sesstoken)
        {
            BsonDocument log = new BsonDocument();
            LoggingService<TelemetryLogDTO> tlogService = new LoggingService<TelemetryLogDTO>("TelemetryLogs");
            IMongoCollection<BsonDocument> collection = tlogService.GetCollection("TelemetryLogs");

            var session = GetLogInfo(sesstoken);
            var loginTime = session.CreateTime.ToString();
            //var gameSession = GetGameLogInfo(gametoken);
            //var gameFunctionality = gameSession.CreateTime;
            //var ipAddr = tlogService.GetIPAddress();
            try
            {
                BsonElement Token = new BsonElement("token", sesstoken);
                BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement userLogin = new BsonElement("userLogin", loginTime);
                BsonElement userLogout = new BsonElement("userLogout", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                //BsonElement functionalityExecution = new BsonElement("clickevent", gameFunctionality);
               // BsonElement ipAddress = new BsonElement("IPAddress", tlogService.GetIPAddress().ToBsonDocument());

                log.Add(date); log.Add(userLogin); log.Add(userLogout); //log.Add(functionalityExecution);
                //log.Add(ipAddress);

                collection.InsertOne(log);
            }
            catch (MongoException)
            {
                tlogService.FailCountEmail(failedLogs);
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
            IMongoCollection<BsonDocument> collection = elogService.GetCollection("ErrorLogs");

            //var session = GetLogInfo(token);
            //var user = userman.GetUser(session.UId);

            try
            {
                BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement error = new BsonElement("error", "fail to join session");
                BsonElement target = new BsonElement("target", "chat");
                BsonElement currentLoggedUser = new BsonElement("loggedInUser", "testemail@gmail.com");
                BsonElement userRequest = new BsonElement("userRequest", "testRequest");
                log.Add(date); log.Add(error); log.Add(target); log.Add(currentLoggedUser); log.Add(userRequest);

                collection.InsertOne(log);
                return true;
            }
            catch (MongoException)
            {
                elogService.FailCountEmail(failedLogs);
                return false;
            }
        }

        /// <summary>
        /// Mock Data errorlog creator
        /// </summary>
        public bool CreateTelemetryLog()
        {
            BsonDocument log = new BsonDocument();
            LoggingService<TelemetryLogDTO> tlogService = new LoggingService<TelemetryLogDTO>("TelemetryLogs");
            IMongoCollection<BsonDocument> collection = tlogService.GetCollection("TelemetryLogs");

            //var session = GetLogInfo();
            var logouttime = "12/16/1996";//session.DeleteTime;
            var logintime = "12/15/1996"; //session.CreateTime;
            try
            {
                BsonElement date = new BsonElement("date", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                BsonElement userlogin = new BsonElement("userLogin", logintime);
                BsonElement userlogout = new BsonElement("userLogout", logouttime);
                //BsonElement ipaddress = new BsonElement("IPAddress", "255.255.255.0");

                log.Add(date); log.Add(userlogin); log.Add(userlogout); //log.Add(ipaddress);

                collection.InsertOne(log);
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
            SessionManager sessMan = new SessionManager();
            var session = sessMan.GetSession(token);
            return session;
        }

        /// <summary>
        /// Method to get the token from the game session class. 
        /// This method is used to get the token to keep track of user game sessions.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public GameSession GetGameLogInfo(string gametoken)
        {
            GameSessionManager gameSessman = new GameSessionManager();
            var gameSession = gameSessman.GetGameSession(gametoken);
            return gameSession;
        }
    }
}
