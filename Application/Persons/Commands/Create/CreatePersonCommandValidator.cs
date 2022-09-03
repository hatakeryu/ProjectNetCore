using Domain.Entities;
using FluentValidation;

namespace Application.Persons.Commands.Create
{
  public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
  {
    public CreatePersonCommandValidator()
    {
      ClassLevelCascadeMode = CascadeMode.Stop;

      RuleFor(c => c.Name).NotEmpty().WithMessage("Name not informed.");

      RuleFor(p => p.BirthDate).NotEmpty().WithMessage("BirthDate not informed.");

      RuleForEach(p => p.Documents)
        .Custom(ValidateDocument)
        .When(p => p.Documents is not null && p.Documents.Any());
    }

    private void ValidateDocument(Document document, ValidationContext<CreatePersonCommand> context)
    {
      if (!Document.ValidateDocument(document))
      {
        context.AddFailure($"The {document.TypeDocument} informed is invalid.");
      }
    } 
  }
}
