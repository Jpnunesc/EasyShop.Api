using Business.Abstractions.Interfaces.IO;
using Business.Abstractions.IO.StoreProduct;


namespace Business.Abstractions.Interfaces.Services
{
    public interface IStoreProductService
    {
        Task<IResultOutput<StoreProductOutput>> SaveAsync(StoreProductInsertInput product);
        Task<IResultOutput<StoreProductOutput>> UpdateAsync(StoreProductUpdateInput product);
        Task<IResultOutput<StoreProductOutputPaged>> GetListAsync(StoreProductFilter productFilter);
        Task<IResultOutput<StoreProductOutput>> DeleteAsync(int id);
        Task<IResultOutput<StoreProductOutput>> GetByIdAsync(int id);
    }
}
