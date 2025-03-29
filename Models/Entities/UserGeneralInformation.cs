using HelloSioux.API.Base.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HelloSioux.API.Models.Entities
{
  public class EmergencyContact
  {
    [BsonElement("fullName")]
    public string FullName { get; set; } = string.Empty;

    [BsonElement("relationship")]
    public string Relationship { get; set; } = string.Empty;

    [BsonElement("phoneNumber")]
    public string PhoneNumber { get; set; } = string.Empty;
  }

  public class UserGeneralInformation : Entity
  {
    [BsonElement("userId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; } = string.Empty;

    [BsonElement("firstName")]
    public string FirstName { get; set; } = string.Empty;

    [BsonElement("lastName")]
    public string LastName { get; set; } = string.Empty;

    [BsonElement("fullName")]
    public string FullName { get; set; } = string.Empty;

    [BsonElement("dateOfBirth")]
    public DateTime DateOfBirth { get; set; }

    [BsonElement("avatarUrl")]
    public string AvatarUrl { get; set; } = string.Empty;

    [BsonElement("phoneNumber")]
    public string PhoneNumber { get; set; } = string.Empty;

    [BsonElement("address")]
    public string Address { get; set; } = string.Empty;

    [BsonElement("nationality")]
    public string Nationality { get; set; } = string.Empty;

    [BsonElement("gender")]
    public string Gender { get; set; } = string.Empty;

    [BsonElement("emergencyContact")]
    public EmergencyContact EmergencyContact { get; set; } = new EmergencyContact();

    [BsonElement("department")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Department { get; set; } = string.Empty;

    [BsonElement("office")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Office { get; set; } = string.Empty;

    [BsonElement("__v")]
    public int? Version { get; set; }
  }
}