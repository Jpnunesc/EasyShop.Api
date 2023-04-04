using Business.Abstractions.Interfaces.IO;
using Business.Abstractions.IO.CoreResult;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.Supplier;

namespace Business.Abstractions.Interfaces.Services
{
    public interface ISupplierService
    {
        Task<IResultOutput<SupplierOutput>> SaveAsync(SupplierInsertInput store);
        Task<IResultOutput<SupplierOutput>> UpdateAsync(SupplierUpdateInput store);
        Task<IResultOutput<CoreOutputPaged<SupplierOutput>>> GetListAsync(SupplierFilter supplierFilter);
        Task<IResultOutput<SupplierOutput>> DeleteAsync(int id);
        Task<IResultOutput<SupplierOutput>> GetByIdAsync(int id);
    }
}
