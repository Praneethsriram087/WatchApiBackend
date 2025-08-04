using MongoDB.Bson.Serialization.Attributes;

namespace Watch_Api_Backend.Models;

public class MonitoredApi
{
  [BsonId]
  [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
  public string? Id { get; set; }

  public List<User> Users {get;set;} = [];
  [BsonElement("url")]
  public string Url { get; set; } = null!;
  [BsonElement("interval")]
  public int Interval { get; set; }

}