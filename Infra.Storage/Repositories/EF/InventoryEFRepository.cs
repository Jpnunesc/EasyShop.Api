using Business.Abstractions.Interfaces.EFRepository;
using Business.Abstractions.IO.Inventory;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.StoreProduct;
using Entities.Data;
using Entities.Entities;
using Infra.Storage.EF;
using Microsoft.EntityFrameworkCore;

namespace Infra.Storage.Repositories.EF
{
   
    public class InventoryEFRepository : IInventoryEFRepository
    {
        private readonly MarketplaceEFContext _context;

        public InventoryEFRepository(MarketplaceEFContext context)
        {
            _context = context;

        }
        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<InventoryMovementEntity> SaveInventoryMovementAsync(InventoryMovementEntity inventoryEntity)
        {
            await _context.InventoryMovement.AddAsync(inventoryEntity);
            await UpdateCurrentStockStoreProducts(inventoryEntity);
            await _context.SaveChangesAsync();

            return inventoryEntity;
        }

        private async Task UpdateCurrentStockStoreProducts(InventoryMovementEntity inventoryEntity)
        {
            var storeProductsList = await _context.StoreProducts.Where(x => inventoryEntity.StoreProductMovement
                                                                                           .Select(spm => spm.IdStoreProduct)
                                                                                           .ToList()
                                                                                           .Contains(x.IdStoreProduct))
                                                               .ToListAsync();
            storeProductsList.ForEach(storeProducts =>
            {
                var invertory = inventoryEntity.StoreProductMovement.Where(x => x.IdStoreProduct == storeProducts.IdStoreProduct).First();
                storeProducts.CurrentStock = storeProducts.CurrentStock.HasValue ? storeProducts.CurrentStock += invertory.Amount : invertory.Amount;
            });
        }

        public async Task<InventoryMovementEntity> UpdateInventoryMovementAsync(InventoryMovementEntity inventoryEntity)
        {
            _context.InventoryMovement.Update(inventoryEntity);
            await UpdateCurrentStockStoreProducts(inventoryEntity);
            await _context.SaveChangesAsync();
            return inventoryEntity;
        }

        public async Task<InventoryMovementEntity> GetByIdInventoryMovementAsync(Guid? idInventory)
        {
            return await _context.InventoryMovement.FirstAsync(x => x.IdInventoryMovement == idInventory);
        }

        public async Task DeleteInventoryMovementAsync(InventoryMovementEntity inventoryEntity)
        {
            await Task.Run(() => _context.InventoryMovement.Remove(inventoryEntity));
        }

        public async Task<(IEnumerable<InventoryMovementEntity> InventoryMovementEntity, int totalRecords)> GetListAsync(InventoryMovementFilter inventoryFilter)
        {
            var query = _context.InventoryMovement.AsQueryable();

            if (inventoryFilter.IdStore.HasValue)
            {
                query = query.Where(s => s.IdStore == inventoryFilter.IdStore.Value);
            }
            if (inventoryFilter.MovementType.HasValue)
            {
                query = query.Where(s => s.MovementType == inventoryFilter.MovementType.Value);
            }

            if (inventoryFilter.NumberDocumentation.HasValue)
            {
                query = query.Where(s => s.NumberDocumentation == inventoryFilter.NumberDocumentation);
            }

            //if (!string.IsNullOrEmpty(productFilter.SortField))
            //{
            //    query = query.OrderBy($"{productFilter.SortField} {productFilter.SortOrder ?? "ASC"}");
            //}

            var totalRecords = await query.CountAsync();

            int page = inventoryFilter.Page ?? 1;
            int pageSize = inventoryFilter.PageSize ?? 10;
            int offset = (page - 1) * pageSize;

            var inventoryList = await query.Skip(offset).Take(pageSize).ToListAsync();

            return (inventoryList, totalRecords);
        }
    }
}
