using Domain.Entities;

namespace Application.Persons.ViewModels
{
  public class PersonViewModel
  {
    public long? Id { get; set; }
    public string? Name { get;  set; }
    public DateTime? BirthDate { get;  set; }
    public ICollection<Document>? Documents { get;  set; }
  }
}
