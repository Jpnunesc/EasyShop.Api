using Business.Abstractions.IO.Inventory;
using Business.Abstractions.IO.StoreProduct;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.Interfaces.EFRepository
{
    public interface IInventoryEFRepository : IBaseEFRepository<InventoryMovementEntity>
    {
        Task<InventoryMovementEntity> SaveInventoryMovementAsync(InventoryMovementEntity inventoryEntity);
        Task<InventoryMovementEntity> UpdateInventoryMovementAsync(InventoryMovementEntity inventoryEntity);
        Task<InventoryMovementEntity> GetByIdInventoryMovementAsync(Guid? idInventory);
        Task DeleteInventoryMovementAsync(InventoryMovementEntity inventoryEntity);
        Task<(IEnumerable<InventoryMovementEntity> InventoryMovementEntity, int totalRecords)> GetListAsync(InventoryMovementFilter inventoryFilter);
    }
}
