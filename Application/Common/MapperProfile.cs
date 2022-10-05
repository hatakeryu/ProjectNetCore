using Application.Persons.ViewModels;
using AutoMapper;
using Domain.Entities;
using Persistence.Mongo.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
  public class MapperProfile : Profile
  {
    public MapperProfile()
    {
      CreateMap<Person, PersonViewModel>().ReverseMap();
      CreateMap<PersonViewModel, PersonCollection>().ReverseMap();
      CreateMap<Document, DocumentViewModel>().ReverseMap();
      CreateMap<DocumentViewModel, DocumentCollection>().ReverseMap();
    }
  }
}
