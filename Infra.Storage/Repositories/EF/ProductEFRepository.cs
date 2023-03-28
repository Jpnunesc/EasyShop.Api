using Business.Abstractions.Interfaces.EFRepository;
using Business.Abstractions.IO.Product;
using Entities.Data;
using Entities.Entities;
using Infra.Storage.Dapper.Common;
using Infra.Storage.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Storage.Repositories.EF
{
   
    public class ProductEFRepository : IProductEFRepository
    {
        private readonly MarketplaceEFContext _context;

        public ProductEFRepository(MarketplaceEFContext context)
        {
            _context = context;

        }
        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<ProductEntity> SaveAsync(ProductEntity productEntity)
        {
            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();
            return productEntity;
        }

        public async Task<ProductEntity> UpdateAsync(ProductEntity productEntity)
        {
            _context.Products.Update(productEntity);
            await _context.SaveChangesAsync();
            return productEntity;
        }

        public async Task<ProductEntity> GetByIdAsync(int? idProduct)
        {
            return await _context.Products.Where(x => x.IdProduct == idProduct).FirstAsync();
        }

        public async Task DeleteAsync(ProductEntity productEntity)
        {
            await Task.Run(() => _context.Products.Remove(productEntity));
        }
    }
}
