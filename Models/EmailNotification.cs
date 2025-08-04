using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Watch_Api_Backend.Models;

public class EmailNotification
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonElement("monitoredApiId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string MonitoredApiId { get; set; } = null!;

    [BsonElement("timestamp")]
    public DateTime Timestamp { get; set; }

    [BsonElement("statusCode")]
    public string StatusCode { get; set; } = null!;

    [BsonElement("responseTimeMs")]
    public double ResponseTimeMs { get; set; }

    [BsonElement("success")]
    public bool Success { get; set; }

    [BsonElement("errorMessage")]
    public string? ErrorMessage { get; set; }

    [BsonElement("sentAt")]
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
}
