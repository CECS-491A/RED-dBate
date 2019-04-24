using KFC.Red.ServiceLayer.Archiving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ManagerLayer.ArchivingManager
{
    public class ArchivingManager
    {
        private string archivePath;
        private ArchivingService archiveLogs = new ArchivingService();

        public ArchivingManager()
        {
        }
    }
}
