using Persistence.Mongo.Base;

namespace Persistence.Mongo.Collections
{
  public class PersonCollection : EntityBase
  {
    public string? Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public ICollection<DocumentCollection>? Documents { get; set; }
  }
}
