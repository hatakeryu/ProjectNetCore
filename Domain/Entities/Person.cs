namespace Domain.Entities
{
  public class Person
  {
    public Person(string? name, DateTime? birthDate, List<Document> documents)
    {
      Name = name;
      BirthDate = birthDate;
      Documents = documents;
    }
    private Person() { Documents = new List<Document>(); }

    public long Id { get; set; }
    public string? Name { get; private set; }
    public DateTime? BirthDate { get; private set; }
    public ICollection<Document> Documents { get; private set; }
  }
}
