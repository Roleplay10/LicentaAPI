using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Models;

public class Profile
{
    [BsonId]
    public ObjectId Id { get; set; }
    [BsonElement("user_id")]
    public ObjectId UserId { get; set; }
    [BsonElement("name")]
    public string? Name { get; set; }
    [BsonElement("surname")]
    public string? Surname { get; set; }
    [BsonElement("phone")]
    public string? Phone { get; set; }
    [BsonElement("address")]
    public string? Address { get; set; }
    [BsonElement("city")]
    public string? City { get; set; }
    [BsonElement("country")]
    public string? County { get; set; }
    [BsonElement("ci")]
    public string? CI { get; set; }
    [BsonElement("mother_name")]
    public string? MotherName { get; set; }
    [BsonElement("father_name")]
    public string? FatherName { get; set; }
    [BsonElement("birth_date")]
    public string? BirthDate { get; set; }
    [BsonElement("verified")]
    public string? isVerified { get; set; } = "not verified";
}