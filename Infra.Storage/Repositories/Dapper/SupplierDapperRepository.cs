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
using Business.Abstractions.IO.Supplier;

namespace Infra.Storage.Repositories.Dapper
{
    public class SupplierDapperRepository : BaseDapperRepository<MarketplaceDapperContext, SuppliersEntity>, ISupplierDapperRepository
    {
        public SupplierDapperRepository(MarketplaceDapperContext session) : base(session)
        {
        }

        public async Task<IEnumerable<SuppliersEntity>> GetListAsync(SupplierFilter filter)
        {
            var query = new StringBuilder(@"SELECT * FROM Suppliers WHERE 1 = 1");
            var parameters = new DynamicParameters();

            if (filter.IdSuppliersEntity.HasValue)
            {
                query.Append(" AND IdSuppliersEntity = @IdSuppliersEntity");
                parameters.Add("@IdSuppliersEntity", filter.IdSuppliersEntity.Value);
            }

            if (!string.IsNullOrEmpty(filter.NumberDocument))
            {
                query.Append(" AND NumberDocument = @NumberDocument");
                parameters.Add("@NumberDocument", filter.NumberDocument);
            }

            if (filter.DocumentType.HasValue)
            {
                query.Append(" AND DocumentType = @DocumentType");
                parameters.Add("@DocumentType", filter.DocumentType.Value);
            }

            if (!string.IsNullOrEmpty(filter.FantasyName))
            {
                query.Append(" AND FantasyName = @FantasyName");
                parameters.Add("@FantasyName", filter.FantasyName);
            }

            if (!string.IsNullOrEmpty(filter.CorporateName))
            {
                query.Append(" AND CorporateName = @CorporateName");
                parameters.Add("@CorporateName", filter.CorporateName);
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                query.Append(" AND Email = @Email");
                parameters.Add("@Email", filter.Email);
            }

            if (filter.Status.HasValue)
            {
                query.Append(" AND Status = @Status");
                parameters.Add("@Status", filter.Status.Value);
            }

            if (!string.IsNullOrEmpty(filter.CellNumber))
            {
                query.Append(" AND CellNumber = @CellNumber");
                parameters.Add("@CellNumber", filter.CellNumber);
            }

            var suppliers = await _session.Connection.QueryAsync<SuppliersEntity>(query.ToString(), parameters, transaction: _session.Transaction);
            return suppliers;
        }


    }
}
