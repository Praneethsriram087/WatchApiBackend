using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WatchApiBackend.Models
{
  public class ResponseLog
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("url")]
    public string Url { get; set; } = null!;

    [BsonElement("timeStamp")]
    public DateTime TimeStamp;

    [BsonElement("statusCode")]
    public int StatusCode { get; set; }

    [BsonElement("responseTime")]
    public long ResponseTime { get; set; }

    [BsonElement("success")]
    public bool Success { get; set; }

    [BsonElement("errorMessage")]
    public string? ErrorMessage { get; set; }
  }
}