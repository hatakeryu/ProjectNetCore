using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Persistence.Mongo.Base
{
  public abstract class EntityBase
  {
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public ObjectId _id { get; set; }
    public long Id { get; set; }
  }
}
