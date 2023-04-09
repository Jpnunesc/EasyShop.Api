using Business.Abstractions.Interfaces.DapperRepository.Common;
using Business.Abstractions.IO.Inventory;
using Entities.Entities;

namespace Business.Abstractions.Interfaces.DapperRepository
{
    public interface IInventoryDapperRepository : IBaseDapperRepository<InventoryMovementEntity>
    {
        Task<(IEnumerable<InventoryMovementEntity> inventoryMovementEntity, int totalRecords)> GetListAsync(InventoryMovementFilter filter);
    }
}
