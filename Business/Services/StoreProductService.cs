using AutoMapper;
using Business.Abstractions.Constants;
using Business.Abstractions.Interfaces.DapperRepository;
using Business.Abstractions.Interfaces.EFRepository;
using Business.Abstractions.Interfaces.IO;
using Business.Abstractions.Interfaces.Services;
using Business.Abstractions.IO.CoreResult;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.StoreProduct;
using Entities.Entities;


namespace Business.Services
{
    public class StoreProductService : IStoreProductService
    {
        private readonly IResultOutput<StoreProductOutput> _resultOutput;
        private readonly IMapper _mapper;
        private readonly IProductEFRepository _productRepository;
        private readonly IProductDapperRepository _productDapperRepository;
        public StoreProductService(IMapper mapper, 
                              IProductEFRepository productRepository, 
                              IResultOutput<StoreProductOutput> resultOutput,
                              IProductDapperRepository productDapperRepository
                              )
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _resultOutput = resultOutput;
            _productDapperRepository = productDapperRepository;
        }

        public async Task<IResultOutput<StoreProductOutput>> SaveAsync(StoreProductInsertInput productInput)
        {
            var productEntity = _mapper.Map<StoreProductInsertInput, StoreProductEntity>(productInput);
           // productEntity.SetStatusTrue();
            productEntity.SetNewDateRegister();
            productEntity.SetSuppliersStandard(productEntity);
            var savedProductEntity = await _productRepository.SaveStoreProductAsync(productEntity);
            var savedProductOutput = _mapper.Map<StoreProductEntity, StoreProductOutput>(savedProductEntity);
            return _resultOutput.OperationOutputSuccess(savedProductOutput, Messages.SuccessMessage);
        }
        public async Task<IResultOutput<StoreProductOutput>> UpdateAsync(StoreProductUpdateInput productInput)
        {
            var productEntity = await _productRepository.GetByIdStoreProductAsync(productInput.IdStoreProduct);
            var productEntityMapping = _mapper.Map<StoreProductUpdateInput, StoreProductEntity>(productInput);
            productEntity.SetEntityUpdate(productEntityMapping);
            productEntity.SetSuppliersStandard(productEntity);
            await _productRepository.UnitOfWork.Commit();
            return _resultOutput.OperationOutputSuccess(new(), Messages.SuccessMessage);
        }

        public async Task<IResultOutput<CoreOutputPaged<StoreProductOutput>>> GetListAsync(StoreProductFilter productFilter)
        {
            var retorno = new ResultOutput<CoreOutputPaged<StoreProductOutput>>();
            var storeProductList = await _productDapperRepository.GetListAsync(productFilter);
            var storeProductOutputList = _mapper.Map<IEnumerable<StoreProductEntity>, IEnumerable<StoreProductOutput>>(storeProductList.storeProductEntity);
            return retorno.OperationOutputSuccess(new() { ListOutput = storeProductOutputList, TotalRecords = storeProductList.totalRecords }, Messages.SuccessMessage);
        }
        public async Task<IResultOutput<StoreProductOutput>> DeleteAsync(int id)
        {
            var productEntity = await _productRepository.GetByIdStoreProductAsync(id);
            if (productEntity == null)
            {
                return _resultOutput.OperationOutputError(Messages.ErrorMessage);
            }
            await _productRepository.DeleteStoreProductAsync(productEntity);
            await _productRepository.UnitOfWork.Commit();
            return _resultOutput.OperationOutputSuccess(new(), Messages.SuccessMessage);
        }
        public async Task<IResultOutput<StoreProductOutput>> GetByIdAsync(int id)
        {
            var productEntity = await _productRepository.GetByIdStoreProductAsync(id);
            var productOutput = _mapper.Map<StoreProductEntity, StoreProductOutput>(productEntity);
            return _resultOutput.OperationOutputSuccess(productOutput, Messages.SuccessMessage);
        }
    }
}
