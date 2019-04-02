using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog.Fluent;
using NLog;
using NLog.Config;



namespace DemoProject
{
    class ProgramLogging
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            try
            {
                int zero = 0;
                int result = 5 / zero;
            }
            catch(DivideByZeroException ex)
            {
                Logger logger = LogManager.GetLogger("Mongo");
                logger.ErrorException("woops", ex);
            }
            logger.Error("error message");
            logger.Info("telemetry message");


        }
    }
}