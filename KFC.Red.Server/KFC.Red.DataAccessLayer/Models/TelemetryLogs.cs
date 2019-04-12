using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.DataAccessLayer.Models
{
    public class TelemetryLogs
    {
        public TelemetryLogs()
        {
            Date = DateTime.Now.ToString("mm/dd/yyyy hh:mm tt");

        }

        public DateTime UserLogin { get; set; }
        public DateTime UserLogout { get; set; }
        public DateTime PageVisit { get; set; }
        public DateTime FunctionalityExecution { get; set; }
        public int Id { get; set; }
        public string Date { get; set; }
        public string IPAddress { get; set; }
        public string Location { get; set; }
    }
}
