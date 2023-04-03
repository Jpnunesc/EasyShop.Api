using Business.Abstractions.Interfaces.DapperRepository.Common;
using Business.Abstractions.IO.StoreProduct;
using Entities.Entities;

namespace Business.Abstractions.Interfaces.DapperRepository
{
    public interface IProductDapperRepository : IBaseDapperRepository<ProductEntity>
    {
        Task<IEnumerable<StoreProductEntity>> GetListAsync(StoreProductFilter productFilter);
    }
}
