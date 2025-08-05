using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WatchApiBackend.Models
{
  public class Team
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("projectName")]
    public string ProjectName { get; set; } = null!;

    [BsonElement("role")]
    public string Role { get; set; } = null!;

    [BsonElement("url")]
    public string URL { get; set; } = null!;

    [BsonElement("interval")]
    public long Interval { get; set; }

    [BsonElement("email")]
    public string Email { get; set; } = null!;

    [BsonElement("password")]
    public string Password { get; set; } = null!;
  }
}