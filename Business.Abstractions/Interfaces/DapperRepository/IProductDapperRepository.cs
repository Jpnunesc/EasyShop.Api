using Business.Abstractions.Interfaces.DapperRepository.Common;
using Business.Abstractions.IO.Product;
using Entities.Entities;

namespace Business.Abstractions.Interfaces.DapperRepository
{
    public interface IProductDapperRepository : IBaseDapperRepository<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> GetListAsync(ProductFilter productFilter);
    }
}
