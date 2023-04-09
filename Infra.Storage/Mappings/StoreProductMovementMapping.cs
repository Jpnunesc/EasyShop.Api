
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Storage.Mappings
{
    public class StoreProductMovementMapping : IEntityTypeConfiguration<StoreProductMovementEntity>
    {
        public void Configure(EntityTypeBuilder<StoreProductMovementEntity> builder)
        {
            builder.ToTable("StoreProductMovement"); 
            builder.HasKey(x => x.IdStoreProductMovement); 
            builder.Property(x => x.IdStoreProductMovement).HasColumnName("IdStoreProductMovement").ValueGeneratedOnAdd().IsRequired(); 
            builder.Property(x => x.IdInventoryMovement).HasColumnName("IdInventoryMovement").IsRequired(); 
            builder.Property(x => x.IdStoreProduct).HasColumnName("IdStoreProduct").IsRequired();
            builder.Property(x => x.DateRegister).HasColumnName("DateRegister").IsRequired(); 
            builder.Property(x => x.Amount).HasColumnName("Amount").IsRequired(); 
            builder.Property(x => x.PriceTotalItens).HasColumnName("PriceTotalItens");
            builder.HasOne(x => x.StoreProduct)
                .WithMany()
                .HasForeignKey(x => x.IdStoreProduct)
                .OnDelete(DeleteBehavior.Restrict); 
            builder.HasOne(x => x.InventoryMovement)
                .WithMany(x => x.StoreProductMovement)
                .HasForeignKey(x => x.IdInventoryMovement)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}