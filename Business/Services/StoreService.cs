using AutoMapper;
using Azure.Core;
using Business.Abstractions.Constants;
using Business.Abstractions.Interfaces.DapperRepository;
using Business.Abstractions.Interfaces.EFRepository;
using Business.Abstractions.Interfaces.IO;
using Business.Abstractions.Interfaces.Services;
using Business.Abstractions.IO.CoreResult;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.User;
using Entities.Entities;


namespace Business.Services
{
    public class StoreService : IStoreService
    {
        private readonly IResultOutput<StoreOutput> _resultOutput;
        private readonly IStoreEFRepository _storeRepository;
        private readonly IStoreDapperRepository _storeDapperRepository;
        private readonly IMapper _mapper;
        public StoreService(IMapper mapper, 
                            IStoreEFRepository storeRepository, 
                            IStoreDapperRepository storeDapperRepository, 
                            IResultOutput<StoreOutput> resultOutput)
        {
            _mapper = mapper;
            _storeRepository = storeRepository;
            _storeDapperRepository = storeDapperRepository;
            _resultOutput = resultOutput;
        }

        public async Task<IResultOutput<StoreOutput>> SaveAsync(StoreInsertInput storeInput)
        {
            var storeEntity = _mapper.Map<StoreInsertInput, StoreEntity>(storeInput);
            storeEntity.SetStatusTrue();
            storeEntity.SetNewDateRegister();
            var savedStoreEntity = await _storeRepository.SaveAsync(storeEntity);
            var savedStoreOutput = _mapper.Map<StoreEntity, StoreOutput>(savedStoreEntity);
            return _resultOutput.OperationOutputSuccess(savedStoreOutput, Messages.SuccessMessage);
        }
        public async Task<IResultOutput<StoreOutput>> UpdateAsync(StoreUpdateInput storeInput)
        {
            var storeEntity = await _storeRepository.GetByIdAsync(storeInput.IdStore);
            var storeEntityMapping = _mapper.Map<StoreUpdateInput, StoreEntity>(storeInput);
            storeEntity.SetEntityUpdate(storeEntityMapping);
            await _storeRepository.UnitOfWork.Commit();
            return _resultOutput.OperationOutputSuccess(new(), Messages.SuccessMessage);
        }
        public async Task<IResultOutput<StoreOutputPaged>> GetListAsync(StoreFilter userFilter)
        {
            var retorno = new ResultOutput<StoreOutputPaged>();
            var storeList = await _storeRepository.GetListAsync(userFilter);
            var storeOutputList = _mapper.Map<IEnumerable<StoreEntity>, IEnumerable<StoreOutput>>(storeList.StoreEntity);
            return retorno.OperationOutputSuccess(new() { ListStoreOutput = storeOutputList, TotalRecords = storeList.totalRecords }, Messages.SuccessMessage);
        }
        public async Task<IResultOutput<StoreOutput>> DeleteAsync(int id)
        {
            var storeEntity = await _storeRepository.GetByIdAsync(id);
            if (storeEntity == null)
            {
                return _resultOutput.OperationOutputError(Messages.ErrorMessage);
            }
            storeEntity.SetNegationStatus();
            await _storeRepository.UnitOfWork.Commit();
            return _resultOutput.OperationOutputSuccess(new(), Messages.SuccessMessage);
        }
        public async Task<IResultOutput<StoreOutput>> GetByIdAsync(int id)
        {
            var storeEntity = await _storeRepository.GetByIdAsync(id);
            var storeOutput = _mapper.Map<StoreEntity, StoreOutput>(storeEntity);
            return _resultOutput.OperationOutputSuccess(storeOutput, Messages.SuccessMessage);
        }
    }
}
