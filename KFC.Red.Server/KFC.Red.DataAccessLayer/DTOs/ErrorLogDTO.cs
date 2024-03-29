﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This class contains the error log format method
/// </summary>
namespace KFC.Red.DataAccessLayer.DTOs
{
    /// <summary>
    /// Error Log Data Transfer Format Method
    /// </summary>
    public class ErrorLogDTO
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("date")]
        public string Date { get; set; }

        [BsonElement("error")]
        public string Error { get; set; }

        [BsonElement("target")]
        public string LineofCode { get; set; }

        //[BsonElement("loggedInUser")]
        //public string CurrentLoggedInUser { get; set; }

        [BsonElement("userRequest")]
        public string UserRequest { get; set; }
    }
}
