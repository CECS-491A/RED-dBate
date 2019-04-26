using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KFC.RED.DataAccessLayer.DTOs
{
    public class LogDTO
    {

        [BsonElement("error")]
        public string Error { get; set; }

        [BsonElement("target")]
        public string LineofCode { get; set; }

        [BsonElement("loggedInUser")]
        public string CurrentLoggedInUser { get; set; }

        [BsonElement("userRequest")]
        public string UserRequest { get; set; }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("date")]
        public string Date { get; set; }

        [BsonElement("userLogin")]
        public string UserLogin { get; set; }

        [BsonElement("userLogout")]
        public string UserLogout { get; set; }

        [BsonElement("IPAddress")]
        public string IPAddress { get; set; }

    }
}
