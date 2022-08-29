using Application.Persons.Commands.Create;
using Application.Persons.ViewModels;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProjectNetCore.Controllers
{
  [Route("api/person")]
  public class PersonController : ControllerBase
  {
    private readonly IMediator _mediator;

    public PersonController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<ActionResult<PersonViewModel>> CreatePerson([FromBody] CreatePersonCommand command)
    {
      return await _mediator.Send(command);
    }
  }
}
