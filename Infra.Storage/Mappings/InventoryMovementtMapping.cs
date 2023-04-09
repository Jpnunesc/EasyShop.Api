
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Storage.Mappings
{
    public class InventoryMovementtMapping : IEntityTypeConfiguration<InventoryMovementEntity>
    {
        public void Configure(EntityTypeBuilder<InventoryMovementEntity> builder)
        {
            builder.ToTable("InventoryMovement"); 
            builder.HasKey(x => x.IdInventoryMovement); 

            builder.Property(x => x.IdInventoryMovement)
                    .HasColumnName("IdInventoryMovement")
                    .IsRequired()
                    .ValueGeneratedOnAdd(); 
            builder.Property(x => x.DateRegister).HasColumnName("DateRegister").IsRequired();
            builder.Property(x => x.NumberDocumentation).HasColumnName("NumberDocumentation").IsRequired(); 
            builder.Property(x => x.CodeDocumentClassification).HasColumnName("CodeDocumentClassification").IsRequired(); 
            builder.Property(x => x.MovementType).HasColumnName("MovementType").IsRequired(); 
            builder.Property(x => x.IdSuppliers).HasColumnName("IdSuppliers"); 
            builder.Property(x => x.IdStore).HasColumnName("IdStore").IsRequired(); 
            builder.Property(x => x.TotalPriceProducts).HasColumnName("TotalPriceProducts"); 
            builder.Property(x => x.Discount).HasColumnName("Discount"); 
            builder.Property(x => x.Increase).HasColumnName("Increase"); 
            builder.Property(x => x.TotalPriceOperation).HasColumnName("TotalPriceOperation"); 

            builder.HasMany(x => x.StoreProductMovement)
                .WithOne()
                .HasForeignKey(x => x.IdInventoryMovement)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}