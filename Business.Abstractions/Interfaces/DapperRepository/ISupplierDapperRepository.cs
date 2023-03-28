using Business.Abstractions.Interfaces.DapperRepository.Common;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.Supplier;
using Business.Abstractions.IO.User;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.Interfaces.DapperRepository
{
    public interface ISupplierDapperRepository : IBaseDapperRepository<SuppliersEntity>
    {
        Task<IEnumerable<SuppliersEntity>> GetListAsync(SupplierFilter storeFilter);
    }
}
