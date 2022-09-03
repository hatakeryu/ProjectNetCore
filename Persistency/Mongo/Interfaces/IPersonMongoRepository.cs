using Persistence.Mongo.Collections;
using System.Linq.Expressions;

namespace Persistence.Mongo.Interfaces
{
  public interface IPersonMongoRepository
  {
    bool Delete(PersonCollection entity);
    IList<PersonCollection> GetAll();
    PersonCollection GetById(Guid id);
    bool Insert(PersonCollection entity);
    IList<PersonCollection> SearchFor(Expression<Func<PersonCollection, bool>> predicate);
    bool Update(PersonCollection entity);
  }
}