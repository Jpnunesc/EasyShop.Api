using Business.Abstractions.Interfaces.EFRepository;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.StoreProduct;
using Entities.Data;
using Entities.Entities;
using Infra.Storage.EF;
using Microsoft.EntityFrameworkCore;

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

        public async Task<StoreProductEntity> SaveStoreProductAsync(StoreProductEntity storeProductEntity)
        {
            await _context.StoreProducts.AddAsync(storeProductEntity);
            await _context.SaveChangesAsync();
            return storeProductEntity;
        }

        public async Task<StoreProductEntity> UpdateStoreProductAsync(StoreProductEntity storeProductEntity)
        {
            _context.StoreProducts.Update(storeProductEntity);
            await _context.SaveChangesAsync();
            return storeProductEntity;
        }

        public async Task<StoreProductEntity> GetByIdStoreProductAsync(int? idStoreProduct)
        {
            return await _context.StoreProducts.Where(x => x.IdStoreProduct == idStoreProduct).FirstAsync();
        }

        public async Task DeleteStoreProductAsync(StoreProductEntity storeProductEntity)
        {
            await Task.Run(() => _context.StoreProducts.Remove(storeProductEntity));
        }

        public async Task<(IEnumerable<StoreProductEntity>, int)> GetListAsync(StoreProductFilter productFilter)
        {
            var query = _context.StoreProducts.AsQueryable();

            if (productFilter.IdStoreProduct.HasValue)
            {
                query = query.Where(s => s.IdStoreProduct == productFilter.IdStoreProduct.Value);
            }
            if (productFilter.IdStore.HasValue)
            {
                query = query.Where(s => s.IdStore == productFilter.IdStore.Value);
            }

            if (!string.IsNullOrEmpty(productFilter.Description))
            {
                query = query.Where(s => s.Description.Contains(productFilter.Description));
            }

            if (!string.IsNullOrEmpty(productFilter.CodeEAN))
            {
                query = query.Where(s => s.CodeEAN == productFilter.CodeEAN);
            }

            if (productFilter.Status.HasValue)
            {
                query = query.Where(s => s.Status == productFilter.Status.Value);
            }

            if (!string.IsNullOrEmpty(productFilter.CodeCEST))
            {
                query = query.Where(s => s.CodeCEST.Contains(productFilter.CodeCEST));
            }
            if (!string.IsNullOrEmpty(productFilter.CodeNCM))
            {
                query = query.Where(s => s.CodeNCM.Contains(productFilter.CodeNCM));
            }
            //if (!string.IsNullOrEmpty(productFilter.SortField))
            //{
            //    query = query.OrderBy($"{productFilter.SortField} {productFilter.SortOrder ?? "ASC"}");
            //}

            var totalRecords = await query.CountAsync();

            int page = productFilter.Page ?? 1;
            int pageSize = productFilter.PageSize ?? 10;
            int offset = (page - 1) * pageSize;

            var storeList = await query.Skip(offset).Take(pageSize).ToListAsync();

            return (storeList, totalRecords);
        }
    }
}
