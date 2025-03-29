using HelloSioux.API.Base.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HelloSioux.API.Models.Entities
{
    public class Permission : Entity
    {
        [BsonElement("action")]
        public string Action { get; set; } = string.Empty;

        [BsonElement("resource")]
        public string Resource { get; set; } = string.Empty;

        [BsonElement("scope")]
        public string Scope { get; set; } = string.Empty;

        [BsonElement("__v")]
        public int? Version { get; set; }
    }
}
