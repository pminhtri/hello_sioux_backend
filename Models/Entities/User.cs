using HelloSioux.API.Base.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HelloSioux.API.Models.Entities
{
    public class User : Entity
    {
        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("activatedUser")]
        public bool ActivatedUser { get; set; } = true;

        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;

        [BsonElement("roleIds")]
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> RoleIds { get; set; } = [];

        [BsonElement("__v")]
        public int? Version { get; set; }
    }
}
