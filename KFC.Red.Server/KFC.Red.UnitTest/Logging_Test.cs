using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFC.Red.ManagerLayer.Logging;
using KFC.Red.ServiceLayer.Logging;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KFC.Red.UnitTest
{
    [TestClass]
    public class Logging_Test
    {
        LoggingManager lm;
        LoggingService ls;

        public LoggingManagerUnitTest()
        {
            lm = new LoggingManager;
            ls = new LoggingService;

        }

        [TestMethod]
        public void LoggingCreateErrorLog_Success_ReturnTrue()
        {
            // Arrange


            //using ()
            {
                // Act 


                // Assert

            }
        }

        [TestMethod]
        public void LoggingCreateErrorLog_Fail_ReturnTrue()
        {
            // Arrange


            //using ()
            {
                // Act 


                // Assert

            }
        }

        [TestMethod]
        public void LoggingCreateTelemetryLog_Success_ReturnTrue()
        {
            // Arrange


            //using ()
            {
                // Act 


                // Assert

            }
        }

        [TestMethod]
        public void LoggingCreateTelemetryLog_Fail_ReturnTrue()
        {
            // Arrange


            //using ()
            {
                // Act 


                // Assert

            }
        }

        [TestMethod]
        public void LoggingDeleteErrorLog_Success_ReturnTrue()
        {
            // Arrange


            //using ()
            {
                // Act 


                // Assert

            }
        }

        [TestMethod]
        public void LoggingDeleteErrorLog_Fail_ReturnTrue()
        {
            // Arrange


            //using ()
            {
                // Act 


                // Assert

            }
        }
    }
}
