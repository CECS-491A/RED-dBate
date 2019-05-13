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

namespace KFC.Red.ServiceLayer
{
    public class UADashboardService<T> : IUADashboardService
    {
        public UADashboardService(string collectionName)
        {
            LoggingService<T> logService = new LoggingService<T>(collectionName);

        }

    }
}
