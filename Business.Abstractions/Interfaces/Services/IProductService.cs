using Business.Abstractions.Interfaces.IO;
using Business.Abstractions.IO.CoreResult;
using Business.Abstractions.IO.Product;
using Business.Abstractions.IO.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.Interfaces.Services
{
    public interface IProductService
    {
        Task<IResultOutput<ProductOutput>> SaveAsync(ProductInsertInput product);
        Task<IResultOutput<ProductOutput>> UpdateAsync(ProductUpdateInput product);
        Task<IResultOutput<ProductOutput>> GetListAsync(ProductFilter product);
        Task<IResultOutput<ProductOutput>> DeleteAsync(int id);
        Task<IResultOutput<ProductOutput>> GetByIdAsync(int id);
    }
}
