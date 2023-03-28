
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Storage.Mappings
{
    public class StoreMapping : IEntityTypeConfiguration<StoreEntity>
    {
        public void Configure(EntityTypeBuilder<StoreEntity> builder)
        {
            builder.ToTable("Store");
            builder.HasKey(t => t.IdStore);

            builder.Property(t => t.IdStore)
                   .HasColumnName("IdStore")
                   .ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
                   .HasColumnName("Name")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(t => t.Status)
                   .HasColumnName("Status")
                   .IsRequired();

            builder.Property(t => t.Cnpj)
                   .HasColumnName("Cnpj")
                   .HasMaxLength(18)
                   .IsRequired();

            builder.Property(t => t.DateRegister)
                   .HasColumnName("DateRegister")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(t => t.Image)
                   .HasColumnName("Image")
                   .HasMaxLength(5000000);


            builder.Property(t => t.PostalCode)
                   .HasColumnName("PostalCode")
                   .IsRequired();

            builder.Property(t => t.Address)
                   .HasColumnName("Address")
                   .IsRequired();

            builder.Property(t => t.Number)
                   .HasColumnName("Number")
                   .IsRequired();

            builder.Property(t => t.Complement)
                   .HasColumnName("Complement");

            builder.Property(t => t.City)
                   .HasColumnName("City")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(t => t.State)
                   .HasColumnName("State")
                   .HasMaxLength(2)
                   .IsRequired();

            builder.Property(t => t.PhoneNumber)
                   .HasColumnName("PhoneNumber")
                   .IsRequired();

        }
    }
}