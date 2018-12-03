using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Authorization
{
    public class ClaimStorage
    {
        public List<Claim> ClaimsStorage = new List<Claim>();

        public ClaimStorage()
        {
            ClaimsStorage.Add(new Claim("ViewUser","True"));
            /*XmlWriter xmlWriter = XmlWriter.Create("test.xml");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("users");

            xmlWriter.WriteStartElement("user");
            xmlWriter.WriteAttributeString("Claim", ClaimsStorage);
            xmlWriter.WriteString("John Doe");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();*/
        }

        public List<Claim> GetClaims()
        {
            return ClaimsStorage;
        }

        public void SetClaims(Claim claim)
        {
            ClaimsStorage.Add(claim);
        }
    }
}
