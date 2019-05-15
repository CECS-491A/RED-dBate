using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using KFC.Red.ServiceLayer.Dashboard.Interface;
using KFC.Red.ServiceLayer.Logging;
using KFC.Red.DataAccessLayer.DTOs;

namespace KFC.Red.ServiceLayer
{
        public MongoClient Client { get; set; }

        public IMongoDatabase mongoDatabase { get; set; }

        //public IMongoCollection<T> _logCollection;
        public IMongoCollection<TelemetryLogDTO> telemetryCollection;
        public IMongoCollection<ErrorLogDTO> errorCollection;

        //public IMongoCollection<ErrorLogDTOs> ErrorLogCollection;

        private string Collection { get; set; }
        public UADashboardService(string collectionName)
        {
            Client = new MongoClient("mongodb+srv://RedAdmin:admin123@teamredlogs-r6fsx.azure.mongodb.net/test?retryWrites=true");
            mongoDatabase = Client.GetDatabase("Logging");
            telemetryCollection = mongoDatabase.GetCollection<TelemetryLogDTO>("TelemetryLogs");
            errorCollection = mongoDatabase.GetCollection<ErrorLogDTO>("ErrorLogs");
            Collection = collectionName;
            //_logCollection = db.GetCollection<T>(collectionName);
        }

        public List<int> GetMonthLabels()
        {
            List<int> MonthsToTrack = null;
            int CurrentMonth = DateTime.Now.Month;
            MonthsToTrack.Add(CurrentMonth);
            for (int i = 0; i < 11; i++)
            {
                CurrentMonth--;
                if (CurrentMonth == 0)
                {
                    CurrentMonth = 12;
                }
                MonthsToTrack.Add(CurrentMonth);
            }
            return MonthsToTrack;
        }

        //Average successful login per month
        public List<int> CountSuccessfulLogin()
        {
            List<int> successLogin = new List<int>();
            var queryResult = telemetryCollection.Aggregate()
                            .Match(x => x.FunctionalityExecution == "Login")
                            .Group(
                x => x.Date,
                i => new
                {
                    Result = i.Select(x => x.Id).Count(),
                    Date = i.Select(x => x.Date).First()
                })
                .SortByDescending(x => x.Date)
                .Limit(12)
                .ToList();

            foreach (var monthly in queryResult)
            {
                successLogin.Add(monthly.Result);
            }
            return successLogin;
        }

        /*
        public List<int> GetNumberOfRegisteredUsers()
        {
            
        }
        */

        //Average session duration 
        /*
        public List<int> GetSessionDuration()
        {
            
        }
        */
}
