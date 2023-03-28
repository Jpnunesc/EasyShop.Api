
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Storage.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(t => t.IdProduct);

            builder.Property(t => t.IdProduct)
                 .HasColumnName("IdProduct")
                 .ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
                .HasColumnName("Name")
                 .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Status)
                .HasColumnName("Status")
                 .HasMaxLength(1)
                .IsRequired();

            builder.Property(t => t.CodeCEST)
                   .HasColumnName("CodeCEST")
                   .IsRequired();

            builder.Property(t => t.CodeNCM)
                   .HasColumnName("CodeNCM")
                   .IsRequired();

            builder.Property(t => t.DateRegister)
                   .HasColumnName("DateRegister")
                   .HasColumnType("datetime")
                   .IsRequired();


            builder.Property(t => t.Description)
                   .HasColumnName("Description")
                   .HasMaxLength(100);

            builder.Property(t => t.Image)
                   .HasColumnName("Image")
                   .IsRequired();

        }
    }
}