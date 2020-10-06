using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace snipetrain_api.Models
{
    public class NewsSchema
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("body")]
        public string Body { get; set; }

        [BsonElement("author")]
        public string Author { get; set; }

        [BsonElement("date")]
        public DateTime PostedDate { get; set; }
    }
}