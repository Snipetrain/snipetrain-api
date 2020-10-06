using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace snipetrain_api.Models
{
    public enum Mod
    {
        TF2 = 440,
        CSGO = 730
    }

    public class ServersSchema
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("serverId")]
        public int ServerId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("ipAddress")]
        public string IpAddress { get; set; }

        [BsonElement("hostName")]
        public string Hostname { get; set; }

        [BsonElement("srcd_servers")]
        public SrcdServer[] SrcdServers { get; set; }
    }

    public class SrcdServer
    {
        [BsonElement("srcdId")]
        public int SrcdId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("port")]
        public int Port { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("mod")]
        public Mod Mod { get; set; }

        [BsonElement("user")]
        public string User { get; set; }
    }
}