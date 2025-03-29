using HelloSioux.API.Base.Entity;
using MongoDB.Bson.Serialization.Attributes;

namespace HelloSioux.API.Models.Entities
{
  public class JobTitle : Entity
  {
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("__v")]
    public int? Version { get; set; }
  }
}