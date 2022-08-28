using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mapping
{
  public class PersonMapping : IEntityTypeConfiguration<Person>
  {
    public void Configure(EntityTypeBuilder<Person> builder)
    {
      builder.ToTable("Person");
      builder.HasKey(x => x.Id);

      builder.Property(p => p.Name)
        .IsRequired()
        .HasColumnType("varchar(200)");

      builder.Property(p => p.BirthDate)
       .IsRequired()
       .HasColumnType("varchar(200)");

      builder.HasMany(p => p.Documents)
        .WithOne(p => p.Person)
        .HasForeignKey(p => p.PersonId)
        .HasConstraintName("FK_Document_Person");

    }
  }
}
