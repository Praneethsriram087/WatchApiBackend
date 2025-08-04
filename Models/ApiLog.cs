

using MongoDB.Bson.Serialization.Attributes;

namespace Watch_Api_Backend.Models;

public class ApiLog
{
  [BsonId]
  [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
  public string? Id { get; set; }
  [BsonElement("monitoredApi")]
  public MonitoredApi MonitoredApi { get; set; } = null!;

  [BsonElement("timeStamp")]
  public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

  [BsonElement("statusCode")]
  public string? StatusCode { get; set; }

  [BsonElement("responseTimeMs")]
  public double ResponseTimeMs { get; set; }

  [BsonElement("success")]
  public bool Success { get; set; } = true;

  [BsonElement("errorMessage")]
  public string? ErrorMessage { get; set; }

  


}