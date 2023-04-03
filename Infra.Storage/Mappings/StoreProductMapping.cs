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
    public class StoreProductMapping : IEntityTypeConfiguration<StoreProductEntity>
    {
        public void Configure(EntityTypeBuilder<StoreProductEntity> builder)
        {
            builder.ToTable("StoreProducts");

            builder.HasKey(sp => sp.IdStoreProduct);
            builder.Property(sp => sp.IdStoreProduct).HasColumnName("IdStoreProduct").IsRequired();
            builder.Property(t => t.CodeCEST).HasColumnName("CodeCEST").IsRequired();
            builder.Property(t => t.CodeNCM).HasColumnName("CodeNCM").IsRequired();
            builder.Property(sp => sp.DateRegister).HasColumnName("DateRegister").IsRequired();
            builder.Property(t => t.Description).HasColumnName("Description").HasMaxLength(100).IsRequired();
            builder.Property(sp => sp.CostPrice).HasColumnName("CostPrice");
            builder.Property(sp => sp.SalePrice).HasColumnName("SalePrice");
            builder.Property(sp => sp.Unit).HasColumnName("Unit");
            builder.Property(sp => sp.IdGroup).HasColumnName("IdGroup");
            builder.Property(sp => sp.Status).HasColumnName("Status");
            builder.Property(t => t.CodeEAN).HasColumnName("CodeEAN").HasMaxLength(50);
            builder.Property(t => t.SaleBreak).HasColumnName("SaleBreak");
            builder.Property(t => t.MinimumStock).HasColumnName("MinimumStock");
            builder.Property(t => t.MaximumStock).HasColumnName("MaximumStock");
            builder.Property(t => t.CurrentStock).HasColumnName("CurrentStock");
            builder.Property(t => t.IdTaxGroup).HasColumnName("IdTaxGroup");
            builder.Property(t => t.Image).HasColumnName("Image");

            builder.Property(sp => sp.IdStore).HasColumnName("IdStore").IsRequired();
            builder.HasOne(sp => sp.Store)
                   .WithMany()
                   .HasForeignKey(sp => sp.IdStore);

            builder.Property(sp => sp.IdSuppliersEntity).HasColumnName("IdSuppliersEntity");
            builder.HasOne(sp => sp.Suppliers)
                   .WithMany()
                   .HasForeignKey(sp => sp.IdSuppliersEntity);
        }
    }
}
