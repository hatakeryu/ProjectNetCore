using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public interface IProjectNetCoreDbContext
  {
    DbSet<Person> Persons { get; set; }
    DbSet<Document> Documents { get; set; }

  }
}