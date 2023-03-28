using Business.Abstractions.Interfaces.DapperRepository.Common;
using Business.Abstractions.IO.User;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.Interfaces.DapperRepository
{
    public interface IUserDapperRepository : IBaseDapperRepository<UserEntity>
    {
        Task<IEnumerable<UserEntity>> GetListAsync(UserFilter userFilter);
    }
}
