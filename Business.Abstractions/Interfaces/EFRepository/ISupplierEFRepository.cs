using Business.Abstractions.IO.User;
using Entities.Entities;


namespace Business.Abstractions.Interfaces.EFRepository
{
    public interface ISupplierEFRepository : IBaseEFRepository<SuppliersEntity>
    {
        Task<SuppliersEntity> SaveAsync(SuppliersEntity supplierEntity);
        Task<SuppliersEntity> UpdateAsync(SuppliersEntity supplierEntity);
        Task<SuppliersEntity> GetByIdAsync(int? id);
        Task DeleteAsync(SuppliersEntity supplierEntity);
    }
}
