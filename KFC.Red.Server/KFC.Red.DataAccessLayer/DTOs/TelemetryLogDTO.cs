using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

/// <summary>
/// This class contains the telemetry data transfer method
/// </summary>
namespace KFC.Red.DataAccessLayer.DTOs
{

    /// <summary>
    /// Telemetry data transfer method
    /// </summary>
    public class TelemetryLogDTO
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement]
        public string Token { get; set; }

        [BsonElement("date")]
        public string Date { get; set; }

        [BsonElement("userLogin")]
        public string UserLogin { get; set; }

        [BsonElement("userLogout")]
        public string UserLogout { get; set; }

       // [BsonElement("pageVisit")]
       // public string PageVisit { get; set; }

       // [BsonElement("clickevent")]
       // public string FunctionalityExecution { get; set; }

       // [BsonElement("IPAddress")]
       // public string IPAddress { get; set; }
    }
}
