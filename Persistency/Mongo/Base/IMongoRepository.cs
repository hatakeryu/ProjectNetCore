using System.Linq.Expressions;

namespace Persistence.Mongo.Base
{
  public interface IMongoRepository<TEntity> where TEntity : EntityBase
  {
    bool Insert(TEntity entity);
    bool Update(TEntity entity);
    bool Delete(TEntity entity);
    IList<TEntity>
    SearchFor(Expression<Func<TEntity, bool>> predicate);
    IList<TEntity> GetAll();
    TEntity GetById(Guid id);
  }
}
