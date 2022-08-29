using Application.Persons.Commands.Create;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplication(this IServiceCollection service, IConfiguration configuration)
    {
      service.AddMediatR(Assembly.GetExecutingAssembly());
      service.AddScoped<IValidator<CreatePersonCommand>, CreatePersonCommandValidator>();

      return service;
    }
  }
}
