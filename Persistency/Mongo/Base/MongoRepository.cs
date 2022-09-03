using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace Persistence.Mongo.Base
{
  public class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : EntityBase
  {
    private MongoDatabase database;
    private MongoCollection<TEntity> collection;
    private readonly IConfiguration _configuration;

    public MongoRepository(IConfiguration configuration)
    {
      _configuration = configuration;
      GetDatabase();
      GetCollection();
    }

    public bool Insert(TEntity entity)
    {
      return collection.Insert(entity).DocumentsAffected > 0;
    }

    public bool Update(TEntity entity)
    {
      if (entity._id == null)
        return Insert(entity);

      return collection.Save(entity).DocumentsAffected > 0;
    }

    public bool Delete(TEntity entity)
    {
      return collection.Remove(Query.EQ("_id", BsonBinaryData.Create(entity._id))).DocumentsAffected > 0;
    }

    public IList<TEntity>
    SearchFor(Expression<Func<TEntity, bool>> predicate)
    {
      return collection.AsQueryable().Where(predicate.Compile()).ToList();
    }

    public IList<TEntity> GetAll()
    {
      return collection.FindAllAs<TEntity>().ToList();
    }

    public TEntity GetById(Guid id)
    {
      return collection.FindOneByIdAs<TEntity>(id);
    }

    private void GetDatabase()
    {
      var client = new MongoClient(GetConnectionString());
      var server = client.GetServer();

      database = server.GetDatabase(GetDatabaseName());
    }

    private string GetConnectionString()
    {
      return _configuration.GetConnectionString("MongoDbConnectionString");
    }

    private string GetDatabaseName()
    {
      return _configuration.GetConnectionString("MongoDbDatabaseName");
    }

    private void GetCollection()
    {
      collection = database
      .GetCollection<TEntity>(typeof(TEntity).Name);
    }
  }
}
