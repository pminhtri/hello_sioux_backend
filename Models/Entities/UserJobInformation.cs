using HelloSioux.API.Base.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HelloSioux.API.Models.Entities
{
  public class UserJobInformation : Entity
  {
    [BsonElement("userId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; } = string.Empty;

    [BsonElement("contractType")]
    public string ContractType { get; set; } = string.Empty;

    [BsonElement("joiningDate")]
    public DateTime JoiningDate { get; set; }

    [BsonElement("probationStartDate")]
    public DateTime ProbationStartDate { get; set; }

    [BsonElement("ContractStartDate")]
    public DateTime ContractStartDate { get; set; }

    [BsonElement("contractEndDate")]
    public DateTime ContractEndDate { get; set; }

    [BsonElement("JobTitle")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string JobTitle { get; set; } = string.Empty;

    [BsonElement("lineManagerId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string LineManagerId { get; set; } = string.Empty;

    [BsonElement("employeeStatus")]
    public string EmployeeStatus { get; set; } = string.Empty;

    [BsonElement("jobHistory")]
    public string JobHistory { get; set; } = string.Empty;

    [BsonElement("grade")]
    public int Grade { get; set; } = 0;

    [BsonElement("__v")]
    public int? Version { get; set; }
  }
}