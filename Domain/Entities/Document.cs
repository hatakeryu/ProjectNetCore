using Domain.Enums;

namespace Domain.Entities
{
  public class Document
  {
    public Document(EDocumentType typeDocument, string documentNumber, DateTime? creationDate, DateTime? expirationDate)
    {
      TypeDocument = typeDocument;
      DocumentNumber = documentNumber;
      CreationDate = creationDate;
      ExpirationDate = expirationDate;
    }

    private Document() { }

    public long Id { get; set; }
    public long PersonId { get; set; }
    public Person Person { get; set; }
    public EDocumentType TypeDocument { get; private set; }
    public string DocumentNumber { get; private set; }
    public DateTime? CreationDate { get; private set; }
    public DateTime? ExpirationDate { get; private set; }

  }
}
