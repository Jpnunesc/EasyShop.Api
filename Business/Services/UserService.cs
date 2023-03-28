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
using Business.Abstractions.IO.UserStore;
using Business.Validations.UserStore;
using Entities.Entities;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Threading;

namespace Business.Services
{
    public class UserService : IUserService
    {

        private readonly IUserEFRepository _userRepository;
        private readonly IUserDapperRepository _userDapperRepository;
        private readonly IMapper _mapper;
        private readonly IResultOutput<UserOutput> _resultOutput;
        public UserService(IMapper mapper,
                           IUserEFRepository userRepository,
                           IUserDapperRepository userDapperRepository,
                           IResultOutput<UserOutput> resultOutput)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _resultOutput = resultOutput;
            _userDapperRepository = userDapperRepository;
        }

        public async Task<UserAuthOutput> AuthenticateAsync(string username, string password)
        {
            return await _userRepository.AuthenticateAsync(username, password);
        }
        public async Task<IResultOutput<UserOutput>> SaveAsync(UserInsertInput userInput)
        {
            var userEntity = _mapper.Map<UserInsertInput, UserEntity>(userInput);
            userEntity.SetStatusTrue();
            userEntity.SetNewDateRegister();
            var savedUserEntity = await _userRepository.SaveAsync(userEntity);
            var savedUserOutput = _mapper.Map<UserEntity, UserOutput>(savedUserEntity);
            return _resultOutput.OperationOutputSuccess(savedUserOutput, Messages.SuccessMessage);
        }
        public async Task<IResultOutput<UserOutput>> UpdateAsync(UserUpdateInput userInput)
        {
            var userEntity = await _userRepository.GetByIdAsync(userInput.IdUser);
            var userEntityMapping = _mapper.Map<UserUpdateInput, UserEntity>(userInput);
            userEntity.SetEntityUpdate(userEntityMapping);
            await _userRepository.UnitOfWork.Commit();
            return _resultOutput.OperationOutputSuccess(new(), Messages.SuccessMessage);
        }
        public async Task<IResultOutput<UserOutputPaged>> GetListAsync(UserFilter userFilter)
        {
            var retorno = new ResultOutput<UserOutputPaged>();
            var userList = await _userRepository.GetListAsync(userFilter);
            var userOutputList = _mapper.Map<IEnumerable<UserEntity>, IEnumerable<UserOutput>>(userList.UserEntity);
            return retorno.OperationOutputSuccess(new() { ListUserOutput = userOutputList, TotalRecords = userList.totalRecords }, Messages.SuccessMessage);
        }
        public async Task<IResultOutput<UserOutput>> DeleteAsync(int id)
        {
            var userEntity = await _userRepository.GetByIdAsync(id);
            if (userEntity == null)
            {
                return _resultOutput.OperationOutputError(Messages.ErrorMessage);
            }
            await _userRepository.DeleteAsync(userEntity);
            await _userRepository.UnitOfWork.Commit();
            var deletedUserOutput = _mapper.Map<UserEntity, UserOutput>(userEntity);
            return _resultOutput.OperationOutputSuccess(deletedUserOutput, Messages.SuccessMessage);
        }
        public async Task<IResultOutput<UserOutput>> GetByIdAsync(int id)
        {
            var userEntity = await _userRepository.GetByIdAsync(id);
            var UserOutput = _mapper.Map<UserEntity, UserOutput>(userEntity);
            return _resultOutput.OperationOutputSuccess(UserOutput, Messages.SuccessMessage);
        }

        public async Task<IResultOutput<UserStoresLinkedUnlinkedOutput>> GetListUserStoresLinkedUnlinkedAsync(int id)
        {
            var retorno = new ResultOutput<UserStoresLinkedUnlinkedOutput>();
            var (storeLinkedEntity, storeUnlinkedEntity) = await _userRepository.GetListUserStoresLinkedUnlinkedAsync(id);
            var storesLinkedOutput = _mapper.Map<IEnumerable<StoreEntity>, IEnumerable<StoreOutput>>(storeLinkedEntity);
            var storesUnlinkedOutput = _mapper.Map<IEnumerable<StoreEntity>, IEnumerable<StoreOutput>>(storeUnlinkedEntity);
            return retorno.OperationOutputSuccess(new() { StoreLinked = storesLinkedOutput, StoreUnlinked = storesUnlinkedOutput }, Messages.SuccessMessage);
        }

        public async Task<IResultOutput<UserStoreOutput>> PostListUserStoresLinkedUnlinkedAsync(IEnumerable<UserStoreInsertInput> userStoreInput)
        {
            var retorno = new ResultOutput<UserStoreOutput>();
            var listUserStoreEntity = _mapper.Map<IEnumerable<UserStoreInsertInput>, IEnumerable<UserStoreEntity>>(userStoreInput);
            listUserStoreEntity.ToList().ForEach(userStore =>
            {
                userStore.DateRegister = DateTime.Now;
                userStore.Status = true;
            });
            var userStoreEntity = await _userRepository.PostListUserStoresLinkedUnlinkedAsync(listUserStoreEntity);
            var storesLinkedOutput = _mapper.Map<IEnumerable<UserStoreEntity>, IEnumerable<UserStoreOutput>>(userStoreEntity);
            return retorno.OperationListOutputSuccess(storesLinkedOutput, Messages.SuccessMessage);
        }

        public async Task<IResultOutput<UserOutput>> DeleteUserStoresLinkedAsync(int id)
        {
            await _userRepository.DeleteUserStoresLinkedAsync(id);
            return _resultOutput.OperationOutputSuccess(new(), Messages.SuccessMessage);
        }
    }
}
