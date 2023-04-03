using Business.Abstractions.Interfaces.DapperRepository;
using Entities.Entities;
using Infra.Storage.Dapper;
using Dapper;
using System.Text;
using Infra.Storage.Dapper.Common;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.StoreProduct;

namespace Infra.Storage.Repositories.Dapper
{
    public class ProductDapperRepository : BaseDapperRepository<MarketplaceDapperContext, ProductEntity>, IProductDapperRepository
    {
        public ProductDapperRepository(MarketplaceDapperContext session) : base(session)
        {
        }

        public async Task<IEnumerable<StoreProductEntity>> GetListAsync(StoreProductFilter productFilter)
        {
            var query = new StringBuilder(@"SELECT * FROM StoreProduct WHERE 1 = 1");
            var parameters = new DynamicParameters();

            if (productFilter.IdStoreProduct.HasValue)
            {
                query.Append(" AND IdStoreProduct = @IdStoreProduct");
                parameters.Add("IdStoreProduct", productFilter.IdStoreProduct.Value);
            }
            if (productFilter.IdStore.HasValue)
            {
                query.Append(" AND IdStore = @IdStore");
                parameters.Add("IdStore", productFilter.IdStore.Value);
            }
            if (!string.IsNullOrEmpty(productFilter.Description))
            {
                query.Append(" AND Description = @Description");
                parameters.Add("Description", productFilter.Description);
            }
            if (!string.IsNullOrEmpty(productFilter.CodeNCM))
            {
                query.Append(" AND CodeNCM = @CodeNCM");
                parameters.Add("CodeNCM", productFilter.CodeNCM);
            }
            if (!string.IsNullOrEmpty(productFilter.CodeEAN))
            {
                query.Append(" AND CodeEAN = @CodeEAN");
                parameters.Add("CodeEAN", productFilter.CodeEAN);
            }
            if (productFilter.Status.HasValue)
            {
                query.Append(" AND Status = @Status");
                parameters.Add("Status", productFilter.Status.Value);
            }

            var productList = await _session.Connection.QueryAsync<StoreProductEntity>(query.ToString(), parameters, transaction: _session.Transaction);
            return productList;
        }
    }
}
