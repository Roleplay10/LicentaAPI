using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Models;

public class Document
{
    [BsonId]
    public ObjectId Id { get; set; }
    [BsonElement("user_id")]
    public ObjectId UserId { get; set; }
    [BsonElement("type")]
    public string? Type { get; set; }
    [BsonElement("path")]
    public string? Path { get; set; }
    [BsonElement("valid")]
    public bool? Valid { get; set; }
}