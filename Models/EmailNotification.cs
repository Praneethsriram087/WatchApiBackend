using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WatchApiBackend.Models
{
    public class EmailNotification
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("sentTo")]
        public ResponseLog SentTo { get; set; } = null!;

        [BsonElement("timeStamp")]
        public DateTime TimeStamp;

        [BsonElement("statusCode")]
        public int StatusCode { get; set; }

        [BsonElement("responseTime")]
        public long ResponseTime { get; set; }

        [BsonElement("success")]
        public bool Success { get; set; }

        [BsonElement("errorMessage")]
        public string ErrorMessage { get; set; } = null!;

        [BsonElement("sentTime")]
        public DateTime SentTime { get; set; }
    }
}