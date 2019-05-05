using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.ManagerLayer.Logging;
using KFC.Red.ManagerLayer.SSO;
using KFC.Red.ServiceLayer.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ManagerLayer.Dashboard
{
    public class UADashboardManager<T>
    {
        LoggingManager<ErrorLogDTO> elog = new LoggingManager<ErrorLogDTO>();
        LoggingManager<TelemetryLogDTO> tlog = new LoggingManager<TelemetryLogDTO>();
        private const string url = "mongodb+srv://RedAdmin:admin123@teamredlogs-r6fsx.azure.mongodb.net/test?retryWrites=true";


        public UADashboardManager(string url, string database)
        {

        }

        //BarCharts 
        public void TotalRegisteredUsers()
        {

        }

        public void AvgSessionDurationPerMonth()
        {

        }

        public void AvgLoginSuccessVSFail()
        {
            SSO_Manager ssoman = new SSO_Manager();
           // var avgLogin = ssoman.LoginFromSSO();
            
        }

        public void AverageTimeSpent()
        {

        }

        public void TimeSpentMostVisitedPages()
        {

        }

        public void MostUsedFeature()
        {

        }

        //Line Charts BRD
        public void TimelineAvgSessionDuration()
        {

        }

        public void NumberOfLoggedUsers()
        {

        }
    }
}
