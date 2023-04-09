using Business.Abstractions.Interfaces.IO;
using Business.Abstractions.IO.CoreResult;
using Business.Abstractions.IO.Inventory;
using Business.Abstractions.IO.StoreProduct;


namespace Business.Abstractions.Interfaces.Services
{
    public interface IInventoryService
    {
        Task<IResultOutput<InventoryMovementOutput>> SaveAsync(InventoryMovementInsertInput inventory);
        Task<IResultOutput<InventoryMovementOutput>> UpdateAsync(InventoryMovementUpdateInput inventory);
        Task<IResultOutput<CoreOutputPaged<InventoryMovementOutput>>> GetListAsync(InventoryMovementFilter inventory);
        Task<IResultOutput<InventoryMovementOutput>> DeleteAsync(Guid id);
        Task<IResultOutput<InventoryMovementOutput>> GetByIdAsync(Guid id);
    }
}
