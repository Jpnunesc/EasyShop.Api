using Business.Abstractions.Interfaces.DapperRepository;
using Entities.Entities;
using Infra.Storage.Dapper;
using Dapper;
using System.Text;
using Infra.Storage.Dapper.Common;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.StoreProduct;
using Business.Abstractions.IO.Supplier;
using Business.Abstractions.IO.Inventory;

namespace Infra.Storage.Repositories.Dapper
{
    public class InventoryDapperRepository : BaseDapperRepository<MarketplaceDapperContext, InventoryMovementEntity>, IInventoryDapperRepository
    {
        public InventoryDapperRepository(MarketplaceDapperContext session) : base(session)
        {
        }

        public async Task<(IEnumerable<InventoryMovementEntity> inventoryMovementEntity, int totalRecords)> GetListAsync(InventoryMovementFilter filter)
        {
            return new();
        }

    }

}
