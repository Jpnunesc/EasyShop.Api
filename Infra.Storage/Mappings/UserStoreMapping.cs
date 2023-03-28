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
    public class UserStoreMapping : IEntityTypeConfiguration<UserStoreEntity>
    {
        public void Configure(EntityTypeBuilder<UserStoreEntity> builder)
        {
            builder.ToTable("UserStore");
                
            builder.HasKey(sp => sp.IdUserStore);
            builder.Property(sp => sp.IdUserStore).HasColumnName("IdUserStore").IsRequired();
            builder.Property(sp => sp.DateRegister).HasColumnName("DateRegister").IsRequired();
            builder.Property(sp => sp.Status).HasColumnName("Status").IsRequired();

            builder.Property(sp => sp.IdUser).HasColumnName("IdUser").IsRequired();
            builder.HasOne(sp => sp.User)
                   .WithMany()
                   .HasForeignKey(sp => sp.IdUser);
            builder.Property(sp => sp.IdStore).HasColumnName("IdStore").IsRequired();
            builder.HasOne(sp => sp.Store)
                   .WithMany()
                   .HasForeignKey(sp => sp.IdStore);

        }
    }
}
