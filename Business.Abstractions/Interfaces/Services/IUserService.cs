﻿using Business.Abstractions.Interfaces.IO;
using Business.Abstractions.IO.User;
using Business.Abstractions.IO.UserStore;

namespace Business.Abstractions.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserAuthOutput> AuthenticateAsync(string username, string password);
        Task<IResultOutput<UserOutput>> SaveAsync(UserInsertInput user);
        Task<IResultOutput<UserOutput>> UpdateAsync(UserUpdateInput user);
        Task<IResultOutput<UserOutputPaged>> GetListAsync(UserFilter userFilter);
        Task<IResultOutput<UserOutput>> DeleteAsync(int id);
        Task<IResultOutput<UserOutput>> GetByIdAsync(int id);
        Task<IResultOutput<UserStoresLinkedUnlinkedOutput>> GetListUserStoresLinkedUnlinkedAsync(int id);
        Task<IResultOutput<UserStoreOutput>> PostListUserStoresLinkedUnlinkedAsync(IEnumerable<UserStoreInsertInput> userStoreInput);
        Task<IResultOutput<UserOutput>> DeleteUserStoresLinkedAsync(int id);
    }
}
