using AutoMapper;
using Domain.Entities;
using Persistence.Mongo.Collections;

namespace Application.Persons.ViewModels
{
  public class PersonViewModel
  {
    public long? Id { get; set; }
    public string? Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public ICollection<DocumentViewModel>? Documents { get; set; }

    public static void Mapping(Profile profile)
    {
      profile.CreateMap<Person, PersonViewModel>();
      profile.CreateMap<PersonViewModel, PersonCollection>();
    }
  }
}
