using Business.Abstractions.Interfaces.IO;
using Business.Abstractions.IO.CoreResult;
using Business.Abstractions.IO.Store;


namespace Business.Abstractions.Interfaces.Services
{
    public interface IStoreService
    {
        Task<IResultOutput<StoreOutput>> SaveAsync(StoreInsertInput store);
        Task<IResultOutput<StoreOutput>> UpdateAsync(StoreUpdateInput store);
        Task<IResultOutput<CoreOutputPaged<StoreOutput>>> GetListAsync(StoreFilter userFilter);
        Task<IResultOutput<StoreOutput>> DeleteAsync(int id);
        Task<IResultOutput<StoreOutput>> GetByIdAsync(int id);
    }
}
