using Business.Abstractions.IO.User;
using Business.Abstractions.IO.UserStore;
using Entities.Entities;


namespace Business.Abstractions.Interfaces.EFRepository
{
    public interface IUserEFRepository : IBaseEFRepository<UserEntity>
    {
        Task<UserAuthOutput> AuthenticateAsync(string username, string password);
        Task<UserEntity> SaveAsync(UserEntity product);
        Task<UserEntity> UpdateAsync(UserEntity userEntity);
        Task<UserEntity> GetByIdAsync(int? idUser);
        Task DeleteAsync(UserEntity userEntity);
        Task<(IEnumerable<UserEntity> UserEntity, int totalRecords)> GetListAsync(UserFilter storeFilter);
        Task<(IEnumerable<StoreEntity> LinkedOutput, IEnumerable<StoreEntity> UnlinkedOutput)> GetListUserStoresLinkedUnlinkedAsync(int id);
        Task<IEnumerable<UserStoreEntity>> PostListUserStoresLinkedUnlinkedAsync(IEnumerable<UserStoreEntity> userStoreEntity);
        Task DeleteUserStoresLinkedAsync(int id);
    }
}
