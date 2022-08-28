using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mapping
{
  public class DocumentMapping : IEntityTypeConfiguration<Document>
  {
    public void Configure(EntityTypeBuilder<Document> builder)
    {
      builder.ToTable("Document");
      builder.HasKey(x => x.Id);

      builder.Property(p => p.TypeDocument)
        .IsRequired()
        .HasColumnType("tinyint");

      builder.Property(p => p.DocumentNumber)
        .IsRequired()
        .HasColumnType("varchar(100)");

      builder.Property(p => p.CreationDate)
        .IsRequired(false);

      builder.Property(p => p.ExpirationDate)
        .IsRequired(false);
    }
  }
}
