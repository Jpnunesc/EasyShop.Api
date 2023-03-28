using Business.Abstractions.Interfaces.DapperRepository;
using Entities.Entities;
using Infra.Storage.Dapper.Common;
using Infra.Storage.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstractions.IO.User;
using Dapper;
using Business.Abstractions.IO.Store;

namespace Infra.Storage.Repositories.Dapper
{
    public class StoreDapperRepository : BaseDapperRepository<MarketplaceDapperContext, StoreEntity>, IStoreDapperRepository
    {
        public StoreDapperRepository(MarketplaceDapperContext session) : base(session)
        {
        }

        public async Task<IEnumerable<StoreEntity>> GetListAsync(StoreFilter storeFilter)
        {
            var query = new StringBuilder(@"SELECT * FROM Store WHERE 1 = 1");
            var parameters = new DynamicParameters();

            if (storeFilter.IdStore.HasValue)
            {
                query.Append(" AND IdStore = @IdStore");
                parameters.Add("IdStore", storeFilter.IdStore.Value);
            }
            if (!string.IsNullOrEmpty(storeFilter.Name))
            {
                query.Append(" AND Name = @Name");
                parameters.Add("Name", storeFilter.Name);
            }
            if (!string.IsNullOrEmpty(storeFilter.Cnpj))
            {
                query.Append(" AND Cnpj = @Cnpj");
                parameters.Add("Cnpj", storeFilter.Cnpj);
            }
            if (storeFilter.Status.HasValue)
            {
                query.Append(" AND Status = @Status");
                parameters.Add("Status", storeFilter.Status.Value);
            }
            if (storeFilter.DateRegister.HasValue)
            {
                query.Append(" AND DateRegister = @DateRegister");
                parameters.Add("DateRegister", storeFilter.DateRegister.Value);
            }
            if (storeFilter.PostalCode.HasValue)
            {
                query.Append(" AND PostalCode = @PostalCode");
                parameters.Add("PostalCode", storeFilter.PostalCode.Value);
            }
            if (!string.IsNullOrEmpty(storeFilter.Number))
            {
                query.Append(" AND Number = @Number");
                parameters.Add("Number", storeFilter.Number);
            }
            if (!string.IsNullOrEmpty(storeFilter.Complement))
            {
                query.Append(" AND Complement = @Complement");
                parameters.Add("Complement", storeFilter.Complement);
            }
            if (!string.IsNullOrEmpty(storeFilter.City))
            {
                query.Append(" AND City = @City");
                parameters.Add("City", storeFilter.City);
            }
            if (!string.IsNullOrEmpty(storeFilter.State))
            {
                query.Append(" AND State = @State");
                parameters.Add("State", storeFilter.State);
            }
            if (storeFilter.PhoneNumber.HasValue)
            {
                query.Append(" AND PhoneNumber = @PhoneNumber");
                parameters.Add("PhoneNumber", storeFilter.PhoneNumber.Value);
            }

            var storeList = await _session.Connection.QueryAsync<StoreEntity>(query.ToString(), parameters, transaction: _session.Transaction);
            return storeList;
        }

    }
}
