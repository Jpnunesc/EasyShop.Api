using Business.Abstractions.Interfaces.DapperRepository;
using Entities.Entities;
using Infra.Storage.Dapper;
using Dapper;
using System.Text;
using Infra.Storage.Dapper.Common;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.Product;

namespace Infra.Storage.Repositories.Dapper
{
    public class ProductDapperRepository : BaseDapperRepository<MarketplaceDapperContext, ProductEntity>, IProductDapperRepository
    {
        public ProductDapperRepository(MarketplaceDapperContext session) : base(session)
        {
        }

        public async Task<IEnumerable<ProductEntity>> GetListAsync(ProductFilter productFilter)
        {
            var query = new StringBuilder(@"SELECT * FROM Product WHERE 1 = 1");
            var parameters = new DynamicParameters();

            if (productFilter.IdProduct.HasValue)
            {
                query.Append(" AND IdProduct = @IdProduct");
                parameters.Add("IdProduct", productFilter.IdProduct.Value);
            }
            if (!string.IsNullOrEmpty(productFilter.Name))
            {
                query.Append(" AND Name = @Name");
                parameters.Add("Name", productFilter.Name);
            }
            if (!string.IsNullOrEmpty(productFilter.CodeNCM))
            {
                query.Append(" AND CodeNCM = @CodeNCM");
                parameters.Add("CodeNCM", productFilter.CodeNCM);
            }
            if (productFilter.Status.HasValue)
            {
                query.Append(" AND Status = @Status");
                parameters.Add("Status", productFilter.Status.Value);
            }

            var productList = await _session.Connection.QueryAsync<ProductEntity>(query.ToString(), parameters, transaction: _session.Transaction);
            return productList;
        }
    }
}
