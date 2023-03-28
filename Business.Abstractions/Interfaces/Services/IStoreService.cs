using Business.Abstractions.Interfaces.IO;
using Business.Abstractions.IO.Store;


namespace Business.Abstractions.Interfaces.Services
{
    public interface IStoreService
    {
        Task<IResultOutput<StoreOutput>> SaveAsync(StoreInsertInput store);
        Task<IResultOutput<StoreOutput>> UpdateAsync(StoreUpdateInput store);
        Task<IResultOutput<StoreOutputPaged>> GetListAsync(StoreFilter store);
        Task<IResultOutput<StoreOutput>> DeleteAsync(int id);
        Task<IResultOutput<StoreOutput>> GetByIdAsync(int id);
    }
}
