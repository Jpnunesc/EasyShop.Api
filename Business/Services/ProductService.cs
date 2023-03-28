using AutoMapper;
using Business.Abstractions.Constants;
using Business.Abstractions.Interfaces.DapperRepository;
using Business.Abstractions.Interfaces.EFRepository;
using Business.Abstractions.Interfaces.IO;
using Business.Abstractions.Interfaces.Services;
using Business.Abstractions.IO.CoreResult;
using Business.Abstractions.IO.Product;
using Business.Abstractions.IO.Store;
using Business.Validations.Product;
using Business.Validations.User;
using Entities.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IResultOutput<ProductOutput> _resultOutput;
        private readonly IMapper _mapper;
        private readonly IProductEFRepository _productRepository;
        private readonly IProductDapperRepository _productDapperRepository;
        public ProductService(IMapper mapper, 
                              IProductEFRepository productRepository, 
                              IResultOutput<ProductOutput> resultOutput,
                              IProductDapperRepository productDapperRepository
                              )
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _resultOutput = resultOutput;
            _productDapperRepository = productDapperRepository;
        }

        public async Task<IResultOutput<ProductOutput>> SaveAsync(ProductInsertInput productInput)
        {
            var productEntity = _mapper.Map<ProductInsertInput, ProductEntity>(productInput);
            productEntity.SetStatusTrue();
            productEntity.SetNewDateRegister();
            var savedProductEntity = await _productRepository.SaveAsync(productEntity);
            var savedProductOutput = _mapper.Map<ProductEntity, ProductOutput>(savedProductEntity);
            return _resultOutput.OperationOutputSuccess(savedProductOutput, Messages.SuccessMessage);
        }
        public async Task<IResultOutput<ProductOutput>> UpdateAsync(ProductUpdateInput productInput)
        {
            var productEntity = await _productRepository.GetByIdAsync(productInput.IdProduct);
            var productEntityMapping = _mapper.Map<ProductUpdateInput, ProductEntity>(productInput);
            productEntity.SetEntityUpdate(productEntityMapping);
            await _productRepository.UnitOfWork.Commit();
            return _resultOutput.OperationOutputSuccess(new(), Messages.SuccessMessage);
        }
        public async Task<IResultOutput<ProductOutput>> GetListAsync(ProductFilter productFilter)
        {
            var productList = await _productDapperRepository.GetListAsync(productFilter);
            var productOutputList = _mapper.Map<IEnumerable<ProductEntity>, IEnumerable<ProductOutput>>(productList);
            return _resultOutput.OperationListOutputSuccess(productOutputList, Messages.SuccessMessage);
        }
        public async Task<IResultOutput<ProductOutput>> DeleteAsync(int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            if (productEntity == null)
            {
                return _resultOutput.OperationOutputError(Messages.ErrorMessage);
            }
            await _productRepository.DeleteAsync(productEntity);
            await _productRepository.UnitOfWork.Commit();
            return _resultOutput.OperationOutputSuccess(new(), Messages.SuccessMessage);
        }
        public async Task<IResultOutput<ProductOutput>> GetByIdAsync(int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            var productOutput = _mapper.Map<ProductEntity, ProductOutput>(productEntity);
            return _resultOutput.OperationOutputSuccess(productOutput, Messages.SuccessMessage);
        }
    }
}
