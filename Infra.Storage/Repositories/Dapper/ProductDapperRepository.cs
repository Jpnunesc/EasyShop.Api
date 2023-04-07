using Business.Abstractions.Interfaces.DapperRepository;
using Entities.Entities;
using Infra.Storage.Dapper;
using Dapper;
using System.Text;
using Infra.Storage.Dapper.Common;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.StoreProduct;
using Business.Abstractions.IO.Supplier;

namespace Infra.Storage.Repositories.Dapper
{
    public class ProductDapperRepository : BaseDapperRepository<MarketplaceDapperContext, ProductEntity>, IProductDapperRepository
    {
        public ProductDapperRepository(MarketplaceDapperContext session) : base(session)
        {
        }

        public async Task<(IEnumerable<StoreProductEntity>, int)> GetListAsync(StoreProductFilter productFilter)
        {
            var query = new StringBuilder(@"
        SELECT *
        FROM (
            SELECT *, ROW_NUMBER() OVER (ORDER BY IdStoreProduct ASC) AS RowNumber
            FROM StoreProducts
            WHERE 1 = 1");

            var countQuery = new StringBuilder("SELECT COUNT(*) FROM StoreProducts WHERE 1 = 1");
            var parameters = new DynamicParameters();

            if (productFilter.IdStoreProduct.HasValue)
            {
                query.Append(" AND IdStoreProduct = @IdStoreProduct");
                countQuery.Append(" AND IdStoreProduct = @IdStoreProduct");
                parameters.Add("@IdStoreProduct", productFilter.IdStoreProduct.Value);
            }

            if (productFilter.IdStore.HasValue)
            {
                query.Append(" AND IdStore = @IdStore");
                countQuery.Append(" AND IdStore = @IdStore");
                parameters.Add("@IdStore", productFilter.IdStore.Value);
            }

            if (!string.IsNullOrEmpty(productFilter.Description))
            {
                query.Append(" AND Description LIKE @Description");
                countQuery.Append(" AND Description LIKE @Description");
                parameters.Add("@Description", "%" + productFilter.Description + "%");
            }

            if (!string.IsNullOrEmpty(productFilter.CodeEAN))
            {
                query.Append(" AND CodeEAN = @CodeEAN");
                countQuery.Append(" AND CodeEAN = @CodeEAN");
                parameters.Add("@CodeEAN", productFilter.CodeEAN);
            }

            if (productFilter.Status.HasValue)
            {
                query.Append(" AND Status = @Status");
                countQuery.Append(" AND Status = @Status");
                parameters.Add("@Status", productFilter.Status.Value);
            }

            if (!string.IsNullOrEmpty(productFilter.CodeCEST))
            {
                query.Append(" AND CodeCEST LIKE @CodeCEST");
                countQuery.Append(" AND CodeCEST LIKE @CodeCEST");
                parameters.Add("@CodeCEST", "%" + productFilter.CodeCEST + "%");
            }

            if (!string.IsNullOrEmpty(productFilter.CodeNCM))
            {
                query.Append(" AND CodeNCM LIKE @CodeNCM");
                countQuery.Append(" AND CodeNCM LIKE @CodeNCM");
                parameters.Add("@CodeNCM", "%" + productFilter.CodeNCM + "%");
            }
            if (productFilter.IdSuppliers.HasValue)
            {
                query.Append(" AND IdSuppliers = @IdSuppliers");
                countQuery.Append(" AND IdSuppliers = @IdSuppliers");
                parameters.Add("@IdSuppliers", productFilter.IdSuppliers.Value);
            }
            countQuery.Append(";");

            query.Append(@"
        ) AS ProductWithRowNumber
        WHERE ProductWithRowNumber.RowNumber BETWEEN @StartRow AND @EndRow");


            if (!string.IsNullOrEmpty(productFilter.SortField))
            {
                query.Append($" ORDER BY {productFilter.SortField} {(productFilter.SortOrder == "desc" ? "DESC" : "ASC")}");
            }

            var totalRecordsTask = _session.Connection.ExecuteScalarAsync<int>(countQuery.ToString(), parameters, transaction: _session.Transaction);

            if (productFilter.PageSize.HasValue && productFilter.Page.HasValue)
            {
                var startRow = (productFilter.Page.Value - 1) * productFilter.PageSize.Value + 1;
                var endRow = startRow + productFilter.PageSize.Value - 1;
                parameters.Add("@StartRow", startRow);
                parameters.Add("@EndRow", endRow);
            }

            var itemsTask = _session.Connection.QueryAsync<StoreProductEntity>(query.ToString(), parameters, transaction: _session.Transaction);

            await Task.WhenAll(itemsTask, totalRecordsTask);

            var items = itemsTask.Result;
            var totalRecords = totalRecordsTask.Result;
            return (items, totalRecords);
        }

    }

}
