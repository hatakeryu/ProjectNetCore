using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public interface IProjectNetCoreDbContext
  {
    Task<int> SaveChangesAsync();
    DbSet<Person> Persons { get; set; }
    DbSet<Document> Documents { get; set; }

  }
}