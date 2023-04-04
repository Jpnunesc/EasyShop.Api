using Business.Abstractions.Interfaces.EFRepository;
using Business.Abstractions.IO.User;
using Entities.Data;
using Entities.Entities;
using Infra.Storage.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Infra.Storage.Repositories.EF
{
    public class SupplierEFRepository : ISupplierEFRepository
    {
        private readonly MarketplaceEFContext _context;
        protected readonly DbSet<StoreEntity> DbSet;

        public SupplierEFRepository(MarketplaceEFContext context)
        {
            _context = context;
            DbSet = _context.Set<StoreEntity>();

        }
        public IUnitOfWork UnitOfWork => _context;
        public void Dispose() => _context.Dispose();

        public async Task<SuppliersEntity> SaveAsync(SuppliersEntity supplierEntity)
        {
                await _context.Suppliers.AddAsync(supplierEntity);
                await _context.SaveChangesAsync();
                return supplierEntity;
        }

        public async Task<SuppliersEntity> UpdateAsync(SuppliersEntity supplierEntity)
        {
            _context.Suppliers.Update(supplierEntity);
            await _context.SaveChangesAsync();
            return supplierEntity;
        }

        public async Task<SuppliersEntity> GetByIdAsync(int? IdSuppliers)
        {
            return await _context.Suppliers.Where(x => x.IdSuppliers == IdSuppliers).FirstAsync();
        }

        public async Task DeleteAsync(SuppliersEntity supplierEntity)
        {
            await Task.Run(() => _context.Suppliers.Remove(supplierEntity));
        }
    }
}
