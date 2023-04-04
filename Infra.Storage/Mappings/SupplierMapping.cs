using Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Storage.Mappings
{
    public class SupplierMapping : IEntityTypeConfiguration<SuppliersEntity>
    {
        public void Configure(EntityTypeBuilder<SuppliersEntity> builder)
        {
            builder.ToTable("Suppliers");

            builder.HasKey(s => s.IdSuppliers);
            builder.Property(s => s.IdSuppliers).HasColumnName("IdSuppliers").IsRequired();
            builder.Property(s => s.NumberDocument).HasColumnName("NumberDocument").HasMaxLength(20);
            builder.Property(s => s.FantasyName).HasColumnName("FantasyName").HasMaxLength(100).IsRequired();
            builder.Property(s => s.CorporateName).HasColumnName("CorporateName").HasMaxLength(100);
            builder.Property(s => s.ReferenceCode).HasColumnName("ReferenceCode").HasMaxLength(20);
            builder.Property(s => s.Contact).HasColumnName("Contact");
            builder.Property(s => s.Email).HasColumnName("Email").HasMaxLength(100);
            builder.Property(s => s.EmailBill).HasColumnName("EmailBill").HasMaxLength(100);
            builder.Property(s => s.PostalCode).HasColumnName("PostalCode");
            builder.Property(s => s.Address).HasColumnName("Address");
            builder.Property(s => s.Number).HasColumnName("Number").HasMaxLength(10);
            builder.Property(s => s.Complement).HasColumnName("Complement").HasMaxLength(50);
            builder.Property(s => s.Neighborhood).HasColumnName("Neighborhood").HasMaxLength(50);
            builder.Property(s => s.City).HasColumnName("City").HasMaxLength(50);
            builder.Property(s => s.State).HasColumnName("State").HasMaxLength(2);
            builder.Property(s => s.Status).HasColumnName("Status");
            builder.Property(s => s.PhoneNumber).HasColumnName("PhoneNumber");
            builder.Property(s => s.CellNumber).HasColumnName("CellNumber").HasMaxLength(15);
            builder.Property(s => s.Others).HasColumnName("Others").HasMaxLength(200);
        }
    }
}