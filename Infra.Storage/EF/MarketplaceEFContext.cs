using Entities.Data;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Storage.EF
{
    public partial class MarketplaceEFContext : DbContext, IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        public MarketplaceEFContext(DbContextOptions<MarketplaceEFContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<StoreEntity> Stores { get; set; }
        public virtual DbSet<StoreProductEntity> StoreProducts { get; set; }
        public virtual DbSet<SuppliersEntity> Suppliers { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<UserStoreEntity> UserStores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarketplaceEFContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection") ?? "";

            optionsBuilder.UseSqlServer(connectionString);
        }
        public bool HasUnsavedChanges()
        {
            return ChangeTracker.Entries().Any(e => e.State == EntityState.Added
                                                      || e.State == EntityState.Modified
                                                      || e.State == EntityState.Deleted);
        }
        public async Task<bool> Commit()
        {       
           return await base.SaveChangesAsync() > 1;
        }
    }
}
