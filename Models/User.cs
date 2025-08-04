using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Watch_Api_Backend.Models;

public class User
{
  [BsonId]
  [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
  public string? Id { get; set; }
  [BsonElement("email")]
  public string Email { get; set; } = null!;
  [BsonElement("role")]
  public string Role { get; set; } = null!;
  [BsonElement("password")]
  public string Password { get; set; } = null!;
  public MonitoredApi MonitoredApi {get;set}
}