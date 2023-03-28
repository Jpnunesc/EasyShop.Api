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
            builder.Property(sp => sp.PriceOld).HasColumnName("PriceOld").IsRequired();
            builder.Property(sp => sp.PriceCurrent).HasColumnName("PriceCurrent");
            builder.Property(sp => sp.Unit).HasColumnName("Unit");
            builder.Property(sp => sp.IdGroup).HasColumnName("IdGroup").IsRequired();
            builder.Property(sp => sp.DateRegister).HasColumnName("DateRegister").IsRequired();
            builder.Property(sp => sp.Status).HasColumnName("Status").IsRequired();

            builder.Property(sp => sp.IdProduct).HasColumnName("IdProduct").IsRequired();
            builder.HasOne(sp => sp.Product)
                   .WithMany()
                   .HasForeignKey(sp => sp.IdProduct);

            builder.Property(sp => sp.IdStore).HasColumnName("IdStore").IsRequired();
            builder.HasOne(sp => sp.Store)
                   .WithMany()
                   .HasForeignKey(sp => sp.IdStore);

            builder.Property(sp => sp.IdSuppliersEntity).HasColumnName("IdSuppliersEntity").IsRequired();
            builder.HasOne(sp => sp.Suppliers)
                   .WithMany()
                   .HasForeignKey(sp => sp.IdSuppliersEntity);
        }
    }
}
