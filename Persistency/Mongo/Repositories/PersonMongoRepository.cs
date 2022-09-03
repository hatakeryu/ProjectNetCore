using Persistence.Mongo.Base;
using Persistence.Mongo.Collections;
using Persistence.Mongo.Interfaces;
using System.Linq.Expressions;

namespace Persistence.Mongo.Repositories
{
  public class PersonMongoRepository : IPersonMongoRepository
    {
        private readonly IMongoRepository<PersonCollection> _repository;

        public PersonMongoRepository(IMongoRepository<PersonCollection> repository)
        {
            _repository = repository;
        }

        public bool Delete(PersonCollection entity)
        {
            return _repository.Delete(entity);
        }

        public IList<PersonCollection> GetAll()
        {
            return _repository.GetAll();
        }

        public PersonCollection GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public bool Insert(PersonCollection entity)
        {
            return _repository.Insert(entity);
        }

        public IList<PersonCollection> SearchFor(Expression<Func<PersonCollection, bool>> predicate)
        {
            return _repository.SearchFor(predicate);
        }

        public bool Update(PersonCollection entity)
        {
            return _repository.Update(entity);
        }
    }
}
