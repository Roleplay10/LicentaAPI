using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Models
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("password")]
        
        public string Password { get; set; }
    }
}