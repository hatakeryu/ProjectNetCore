using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public class ProjectNetCoreDbContext : DbContext, IProjectNetCoreDbContext
  {
    public ProjectNetCoreDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Document> Documents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectNetCoreDbContext).Assembly);
    }
  }
}
