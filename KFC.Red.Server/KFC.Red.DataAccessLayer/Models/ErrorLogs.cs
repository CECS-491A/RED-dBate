using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.RED.DataAccessLayer.Models
{
    public class ErrorLogs
    {
        public ErrorLogs()
        {
            Date = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
        }

        public int Id { get; set; }

        public string Date { get; set; }
        public string Error { get; set; }
        public string LineofCode { get; set; }
        public string CurrentLoggedInUser { get; set; }
        public string UserRequest { get; set; }
    }
}
