using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.ManagerLayer.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ManagerLayer.Dashboard
{
    public class UADashboardManager
    {
        LoggingManager<ErrorLogDTO> elog = new LoggingManager<ErrorLogDTO>();
        LoggingManager<TelemetryLogDTO> tlog = new LoggingManager<TelemetryLogDTO>();


        public bool GetData()
        {
            return true;
        }
    }
}
