using AutoMapper;
using Azure.Core;
using Business.Abstractions.Constants;
using Business.Abstractions.Interfaces.DapperRepository;
using Business.Abstractions.Interfaces.EFRepository;
using Business.Abstractions.Interfaces.IO;
using Business.Abstractions.Interfaces.Services;
using Business.Abstractions.IO.CoreResult;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.Supplier;
using Business.Abstractions.IO.User;
using Entities.Entities;


namespace Business.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IResultOutput<SupplierOutput> _resultOutput;
        private readonly ISupplierEFRepository _supplierRepository;
        private readonly ISupplierDapperRepository _supplierDapperRepository;
        private readonly IMapper _mapper;
        public SupplierService(IMapper mapper,
                            ISupplierEFRepository supplierRepository,
                            ISupplierDapperRepository supplierDapperRepository, 
                            IResultOutput<SupplierOutput> resultOutput)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
            _supplierDapperRepository = supplierDapperRepository;
            _resultOutput = resultOutput;
        }

        public async Task<IResultOutput<SupplierOutput>> SaveAsync(SupplierInsertInput supplierInput)
        {
            var suppliersEntity = _mapper.Map<SupplierInsertInput, SuppliersEntity>(supplierInput);
            var savedSupplierEntity = await _supplierRepository.SaveAsync(suppliersEntity);
            var savedSupplierOutput = _mapper.Map<SuppliersEntity, SupplierOutput>(savedSupplierEntity);
            return _resultOutput.OperationOutputSuccess(savedSupplierOutput, Messages.SuccessMessage);
        }
        public async Task<IResultOutput<SupplierOutput>> UpdateAsync(SupplierUpdateInput supplierInput)
        {
            var suppliersEntity = await _supplierRepository.GetByIdAsync(supplierInput.IdSuppliers);
            var suppliersEntityMapping = _mapper.Map<SupplierUpdateInput, SuppliersEntity>(supplierInput);
            suppliersEntity.SetEntityUpdate(suppliersEntityMapping);
            await _supplierRepository.UnitOfWork.Commit();
            return _resultOutput.OperationOutputSuccess(new(), Messages.SuccessMessage);
        }
        public async Task<IResultOutput<CoreOutputPaged<SupplierOutput>>> GetListAsync(SupplierFilter supplierFilter)
        {
            var retorno = new ResultOutput<CoreOutputPaged<SupplierOutput>>();
            var (suppliersEntity, totalRecords) = await _supplierDapperRepository.GetListAsync(supplierFilter);
            var storeOutputList = _mapper.Map<IEnumerable<SuppliersEntity>, IEnumerable<SupplierOutput>>(suppliersEntity);
            return retorno.OperationOutputSuccess(new() { ListOutput = storeOutputList, TotalRecords = totalRecords }, Messages.SuccessMessage);
        }
        public async Task<IResultOutput<SupplierOutput>> DeleteAsync(int id)
        {
            var supplierEntity = await _supplierRepository.GetByIdAsync(id);
            if (supplierEntity == null)
            {
                return _resultOutput.OperationOutputError(Messages.ErrorMessage);
            }
            await _supplierRepository.DeleteAsync(supplierEntity);
            await _supplierRepository.UnitOfWork.Commit();
            return _resultOutput.OperationOutputSuccess(new(), Messages.SuccessMessage);
        }
        public async Task<IResultOutput<SupplierOutput>> GetByIdAsync(int id)
        {
            var supplierEntity = await _supplierRepository.GetByIdAsync(id);
            var supplierOutput = _mapper.Map<SuppliersEntity, SupplierOutput>(supplierEntity);
            return _resultOutput.OperationOutputSuccess(supplierOutput, Messages.SuccessMessage);
        }
    }
}
