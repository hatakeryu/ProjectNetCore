using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Persistence.Mongo.Collections;

namespace Application.Persons.ViewModels
{
  public class DocumentViewModel
  {
    public long Id { get; set; }
    public long PersonId { get; set; }
    public EDocumentType TypeDocument { get; private set; }
    public string DocumentNumber { get; private set; }
    public DateTime? CreationDate { get; private set; }
    public DateTime? ExpirationDate { get; private set; }

    public static void Mapping(Profile profile)
    {
      profile.CreateMap<Document, DocumentViewModel>();
      profile.CreateMap<DocumentViewModel, DocumentCollection>();
    }
  }
}
