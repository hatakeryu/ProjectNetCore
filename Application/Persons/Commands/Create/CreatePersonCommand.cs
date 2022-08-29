using Application.Persons.ViewModels;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Application.Persons.Commands.Create
{
  public class CreatePersonCommand : IRequest<PersonViewModel>
  {
    public long? Id { get; set; }
    public string? Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public List<Document>? Documents { get; set; }

    public CreatePersonCommand()
    {
      Documents = new();
    }
  }
}
