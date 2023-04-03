using Business.Abstractions.IO.StoreProduct;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.Interfaces.EFRepository
{
    public interface IProductEFRepository : IBaseEFRepository<ProductEntity>
    {
        Task<StoreProductEntity> SaveStoreProductAsync(StoreProductEntity storeProduct);
        Task<StoreProductEntity> UpdateStoreProductAsync(StoreProductEntity storeProduct);
        Task<StoreProductEntity> GetByIdStoreProductAsync(int? idStoreProduct);
        Task DeleteStoreProductAsync(StoreProductEntity storeProduct);
        Task<(IEnumerable<StoreProductEntity> storeProductEntity, int totalRecords)> GetListAsync(StoreProductFilter productFilter);
    }
}
