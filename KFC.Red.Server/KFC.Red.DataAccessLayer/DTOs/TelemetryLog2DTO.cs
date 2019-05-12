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
    public class TelemetryLog2DTO
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("date")]
        public string Date { get; set; }

        [BsonElement("loggedInUser")]
        public string CurrentLoggedInUser { get; set; }

        [BsonElement("pageVisit")]
       public string PageVisit { get; set; }

       [BsonElement("clickevent")]
       public string FunctionalityExecution { get; set; }
    }
}
