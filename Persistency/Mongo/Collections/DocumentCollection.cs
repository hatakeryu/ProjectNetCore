using Domain.Enums;

namespace Persistence.Mongo.Collections
{
  public class DocumentCollection
  {
    public long PersonId { get; set; } 
    public EDocumentType TypeDocument { get; private set; }
    public string DocumentNumber { get; private set; }
    public DateTime? CreationDate { get; private set; }
    public DateTime? ExpirationDate { get; private set; }
  }
}
