using AutoMapper;
using Business.Abstractions.Constants;
using Business.Abstractions.Interfaces.DapperRepository;
using Business.Abstractions.Interfaces.EFRepository;
using Business.Abstractions.Interfaces.IO;
using Business.Abstractions.Interfaces.Services;
using Business.Abstractions.IO.CoreResult;
using Business.Abstractions.IO.Inventory;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.StoreProduct;
using Entities.Entities;


namespace Business.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IResultOutput<InventoryMovementOutput> _resultOutput;
        private readonly IMapper _mapper;
        private readonly IInventoryEFRepository _inventoryRepository;
        private readonly IInventoryDapperRepository _inventoryDapperRepository;
        public InventoryService(IMapper mapper,
                              IInventoryEFRepository inventoryRepository, 
                              IResultOutput<InventoryMovementOutput> resultOutput,
                              IInventoryDapperRepository inventoryDapperRepository
                              )
        {
            _mapper = mapper;
            _inventoryRepository = inventoryRepository;
            _resultOutput = resultOutput;
            _inventoryDapperRepository = inventoryDapperRepository;
        }

        public async Task<IResultOutput<InventoryMovementOutput>> SaveAsync(InventoryMovementInsertInput inventoryInput)
        {
            var inventoryEntity = _mapper.Map<InventoryMovementInsertInput, InventoryMovementEntity>(inventoryInput);
            inventoryEntity.SumTotalPriceProducts();
            inventoryEntity.SumTotalPriceOperation();
            var savedInventoryEntity = await _inventoryRepository.SaveInventoryMovementAsync(inventoryEntity);
            var savedInventoryOutput = _mapper.Map<InventoryMovementEntity, InventoryMovementOutput>(savedInventoryEntity);
            return _resultOutput.OperationOutputSuccess(savedInventoryOutput, Messages.SuccessMessage);
        }
        public async Task<IResultOutput<InventoryMovementOutput>> UpdateAsync(InventoryMovementUpdateInput inventoryInput)
        {
            var inventoryEntity = await _inventoryRepository.GetByIdInventoryMovementAsync(inventoryInput.IdInventoryMovement);
            var inventoryEntityMapping = _mapper.Map<InventoryMovementUpdateInput, InventoryMovementEntity>(inventoryInput);
            //inventoryEntity.SetEntityUpdate(inventoryEntityMapping);
            await _inventoryRepository.UnitOfWork.Commit();
            return _resultOutput.OperationOutputSuccess(new(), Messages.SuccessMessage);
        }

        public async Task<IResultOutput<CoreOutputPaged<InventoryMovementOutput>>> GetListAsync(InventoryMovementFilter inventoryFilter)
        {
            var retorno = new ResultOutput<CoreOutputPaged<InventoryMovementOutput>>();
            var inventoryList = await _inventoryDapperRepository.GetListAsync(inventoryFilter);
            var inventoryOutputList = _mapper.Map<IEnumerable<InventoryMovementEntity>, IEnumerable<InventoryMovementOutput>>(inventoryList.inventoryMovementEntity);
            return retorno.OperationOutputSuccess(new() { ListOutput = inventoryOutputList, TotalRecords = inventoryList.totalRecords }, Messages.SuccessMessage);
        }
        public async Task<IResultOutput<InventoryMovementOutput>> DeleteAsync(Guid id)
        {
            var inventoryEntity = await _inventoryRepository.GetByIdInventoryMovementAsync(id);
            if (inventoryEntity == null)
            {
                return _resultOutput.OperationOutputError(Messages.ErrorMessage);
            }
            await _inventoryRepository.DeleteInventoryMovementAsync(inventoryEntity);
            await _inventoryRepository.UnitOfWork.Commit();
            return _resultOutput.OperationOutputSuccess(new(), Messages.SuccessMessage);
        }
        public async Task<IResultOutput<InventoryMovementOutput>> GetByIdAsync(Guid id)
        {
            var inventoryEntity = await _inventoryRepository.GetByIdInventoryMovementAsync(id);
            var inventoryOutput = _mapper.Map<InventoryMovementEntity, InventoryMovementOutput>(inventoryEntity);
            return _resultOutput.OperationOutputSuccess(inventoryOutput, Messages.SuccessMessage);
        }
    }
}
