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

        public async Task<(IEnumerable<SuppliersEntity>, int)> GetListAsync(SupplierFilter filter)
        {
            var query = new StringBuilder(@"
        SELECT *
        FROM (
            SELECT *, ROW_NUMBER() OVER (ORDER BY IdSuppliers ASC) AS RowNumber
            FROM Suppliers
            WHERE 1 = 1");
            var countQuery = new StringBuilder("SELECT COUNT(*) FROM Suppliers WHERE 1 = 1");
            var parameters = new DynamicParameters();
            var countParameters = new DynamicParameters();

            if (filter.IdSuppliers.HasValue)
            {
                query.Append(" AND IdSuppliers = @IdSuppliers");
                countQuery.Append(" AND IdSuppliers = @IdSuppliers");
                parameters.Add("@IdSuppliers", filter.IdSuppliers.Value);
                countParameters.Add("@IdSuppliers", filter.IdSuppliers.Value);
            }

            if (!string.IsNullOrEmpty(filter.NumberDocument))
            {
                query.Append(" AND NumberDocument = @NumberDocument");
                countQuery.Append(" AND NumberDocument = @NumberDocument");
                parameters.Add("@NumberDocument", filter.NumberDocument);
                countParameters.Add("@NumberDocument", filter.NumberDocument);
            }

            if (!string.IsNullOrEmpty(filter.FantasyName))
            {
                query.Append(" AND FantasyName = @FantasyName");
                countQuery.Append(" AND FantasyName = @FantasyName");
                parameters.Add("@FantasyName", filter.FantasyName);
                countParameters.Add("@FantasyName", filter.FantasyName);
            }

            if (!string.IsNullOrEmpty(filter.CorporateName))
            {
                query.Append(" AND CorporateName = @CorporateName");
                countQuery.Append(" AND CorporateName = @CorporateName");
                parameters.Add("@CorporateName", filter.CorporateName);
                countParameters.Add("@CorporateName", filter.CorporateName);
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                query.Append(" AND Email = @Email");
                countQuery.Append(" AND Email = @Email");
                parameters.Add("@Email", filter.Email);
                countParameters.Add("@Email", filter.Email);
            }

            if (filter.Status.HasValue)
            {
                query.Append(" AND Status = @Status");
                countQuery.Append(" AND Status = @Status");
                parameters.Add("@Status", filter.Status.Value);
                countParameters.Add("@Status", filter.Status.Value);
            }

            if (!string.IsNullOrEmpty(filter.CellNumber))
            {
                query.Append(" AND CellNumber = @CellNumber");
                countQuery.Append(" AND CellNumber = @CellNumber");
                parameters.Add("@CellNumber", filter.CellNumber);
                countParameters.Add("@CellNumber", filter.CellNumber);
            }

            countQuery.Append(";");

            query.Append(@"
        ) AS SuppliersWithRowNumber
        WHERE SuppliersWithRowNumber.RowNumber BETWEEN @StartRow AND @EndRow");

            if (!string.IsNullOrEmpty(filter.SortField))
            {
                query.Append($" ORDER BY {filter.SortField} {(filter.SortOrder == "desc" ? "DESC" : "ASC")}");
            }

            if (filter.PageSize.HasValue && filter.Page.HasValue)
                {
                var startRow = (filter.Page.Value - 1) * filter.PageSize.Value + 1;
                var endRow = startRow + filter.PageSize.Value - 1;
                parameters.Add("@StartRow", startRow);
                parameters.Add("@EndRow", endRow);
            }

            var itemsTask = _session.Connection.QueryAsync<SuppliersEntity>(query.ToString(), parameters, transaction: _session.Transaction);
            var totalRecordsTask = _session.Connection.ExecuteScalarAsync<int>(countQuery.ToString(), countParameters, transaction: _session.Transaction);

            await Task.WhenAll(itemsTask, totalRecordsTask);

            var items = itemsTask.Result;
            var totalRecords = totalRecordsTask.Result;
            return (items, totalRecords);
        }

    }
}
