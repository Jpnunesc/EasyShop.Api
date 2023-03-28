using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.User;
using Entities.Entities;


namespace Business.Abstractions.Interfaces.EFRepository
{
    public interface IStoreEFRepository : IBaseEFRepository<StoreEntity>
    {
        Task<StoreEntity> SaveAsync(StoreEntity store);
        Task<StoreEntity> UpdateAsync(StoreEntity store);
        Task<StoreEntity> GetByIdAsync(int? idStore);
        Task DeleteAsync(StoreEntity store);
        Task<(IEnumerable<StoreEntity> StoreEntity, int totalRecords)> GetListAsync(StoreFilter storeFilter);
    }
}
