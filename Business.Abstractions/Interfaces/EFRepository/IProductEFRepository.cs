using Business.Abstractions.IO.Product;
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
        Task<ProductEntity> SaveAsync(ProductEntity product);
        Task<ProductEntity> UpdateAsync(ProductEntity product);
        Task<ProductEntity> GetByIdAsync(int? idproduct);
        Task DeleteAsync(ProductEntity product);
    }
}
