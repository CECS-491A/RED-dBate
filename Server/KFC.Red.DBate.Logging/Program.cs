using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog.Fluent;
//using DataAccessLayer.NLog.Mongo;
using NLog;
//using NLog.Web;

namespace CECS491Logging
{
    class Program
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Error("This is an error message");
            logger.Trace("This is a telemetry message");
        }
    }
}
