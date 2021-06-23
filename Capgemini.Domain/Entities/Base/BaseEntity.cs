using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Capgemini.Domain.Entities.Base
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }
    }
}
