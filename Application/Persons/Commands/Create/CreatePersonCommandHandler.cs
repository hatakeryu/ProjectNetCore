using Application.Persons.ViewModels;
using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Persons.Commands.Create
{
  internal class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, PersonViewModel>
  {
    private readonly IProjectNetCoreDbContext _context;

    public CreatePersonCommandHandler(IProjectNetCoreDbContext context)
    {
      _context = context;
    }

    public async Task<PersonViewModel> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
      var person = new Person(request.Name, request.BirthDate, request.Documents);
      await _context.Persons.AddAsync(person, cancellationToken);
      var result = await _context.SaveChangesAsync();

      if (result > 0)
      {
        var viewModel = new PersonViewModel()
        {
          BirthDate = person.BirthDate,
          Documents = person.Documents,
          Id = person.Id,
          Name = person.Name
        };

        return viewModel;
      }

      return new();
    }
  }
}
