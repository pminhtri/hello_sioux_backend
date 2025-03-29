using HelloSioux.API.Base.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HelloSioux.API.Models.Entities
{
    public class Role : Entity
    {
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("accessLevel")]
        public int AccessLevel { get; set; } = 0;
        
        [BsonElement("permissions")]
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> Permissions { get; set; } = [];
    }
}
