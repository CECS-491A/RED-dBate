using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KFC.Red.DataAccessLayer.DTOs
{
    public class TelemetryLogDTO
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("date")]
        public string Date { get; set; }

        [BsonElement("userLogin")]
        public string UserLogin { get; set; }

        [BsonElement("userLogout")]
        public string UserLogout { get; set; }

        [BsonElement("pageVisit")]
        public string PageVisit { get; set; }

        [BsonElement("functionalityExecution")]
        public string FunctionalityExecution { get; set; }

        [BsonElement("ipAddress")]
        public string IPAddress { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }

    }
}
