using Application.Persons.ViewModels;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence;
using Persistence.Mongo.Collections;
using Persistence.Mongo.Interfaces;

namespace Application.Persons.Commands.Create
{
  internal class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, PersonViewModel>
  {
    private readonly IProjectNetCoreDbContext _context;
    private readonly IMapper _mapper;
    private readonly IPersonMongoRepository _personMongo;
    public CreatePersonCommandHandler(IProjectNetCoreDbContext context, IMapper mapper, IPersonMongoRepository personMongo)
    {
      _context = context;
      _mapper = mapper;
      _personMongo = personMongo;
    }

    public async Task<PersonViewModel> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
      var person = new Person(request.Name, request.BirthDate, request.Documents);
      await _context.Persons.AddAsync(person, cancellationToken);
      var result = await _context.SaveChangesAsync();

      if (result > 0)
      {

        var viewModel = _mapper.Map<PersonViewModel>(person);

        var collection = _mapper.Map<PersonCollection>(viewModel);

        _personMongo.Insert(collection);

        return viewModel;
      }

      return new();
    }
  }
}
