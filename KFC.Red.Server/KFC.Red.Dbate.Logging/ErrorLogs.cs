using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Representing and fomatting the Logs into Bson attributes.
/// </summary>
namespace KFC.Red.Dbate.Logging.Repositories
{
    public class ErrorLogs
    {
        /// <summary>
        /// Using Bson format to 
        /// Accessing the id proerty as a string but have the id saveed as an ObjectId in MongoDB.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Object Id { get; set; }

        [BsonElement("Date")]
        public string Date { get; set; }

        [BsonElement("ErrorMessage")]
        public string ErrorMessage { get; set; }

        [BsonElement("Line of Code")]
        public string LineOfCode { get; set; }

        [BsonElement("Target Site")]
        public string TargetSite { get; set; }

        [BsonElement("Logged In User")]
        public string LoggedInUser { get; set; }

        [BsonElement("ProcessId")]
        public string ProcessId { get; set; }

        [BsonElement("ProcessName")]
        public string ProcessName { get; set; }

        [BsonElement("UserRequest")]
        public string UserRequest { get; set; }

        [BsonElement("UserId")]
        public string UserId { get; set; }

        [BsonElement("Username")]
        public string Username { get; set; }

        /*
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        */

    }
}
