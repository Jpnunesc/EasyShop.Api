using Business.Abstractions.Interfaces.EFRepository;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.User;
using Entities.Data;
using Entities.Entities;
using Infra.Storage.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Infra.Storage.Repositories.EF
{
    public class StoreEFRepository : IStoreEFRepository
    {
        private readonly MarketplaceEFContext _context;
        protected readonly DbSet<StoreEntity> DbSet;

        public StoreEFRepository(MarketplaceEFContext context)
        {
            _context = context;
            DbSet = _context.Set<StoreEntity>();

        }
        public IUnitOfWork UnitOfWork => _context;
        public void Dispose() => _context.Dispose();

        public async Task<StoreEntity> SaveAsync(StoreEntity storeEntity)
        {
                await _context.Stores.AddAsync(storeEntity);
                await _context.SaveChangesAsync();
                return storeEntity;
        }

        public async Task<StoreEntity> UpdateAsync(StoreEntity storeEntity)
        {
            _context.Stores.Update(storeEntity);
            await _context.SaveChangesAsync();
            return storeEntity;
        }

        public async Task<StoreEntity> GetByIdAsync(int? idStore)
        {
            return await _context.Stores.Where(x => x.IdStore == idStore).FirstAsync();
        }

        public async Task DeleteAsync(StoreEntity storeEntity)
        {
            await Task.Run(() => _context.Stores.Remove(storeEntity));
        }

        public async Task<(IEnumerable<StoreEntity>, int)> GetListAsync(StoreFilter storeFilter)
        {
            var query = _context.Stores.AsQueryable();

            if (storeFilter.IdStore.HasValue)
            {
                query = query.Where(s => s.IdStore == storeFilter.IdStore.Value);
            }

            if (!string.IsNullOrEmpty(storeFilter.Name))
            {
                query = query.Where(s => s.Name == storeFilter.Name);
            }

            if (!string.IsNullOrEmpty(storeFilter.Cnpj))
            {
                query = query.Where(s => s.Cnpj == storeFilter.Cnpj);
            }

            if (storeFilter.Status.HasValue)
            {
                query = query.Where(s => s.Status == storeFilter.Status.Value);
            }

            if (storeFilter.DateRegister.HasValue)
            {
                query = query.Where(s => s.DateRegister == storeFilter.DateRegister.Value);
            }

            if (storeFilter.PostalCode.HasValue)
            {
                query = query.Where(s => s.PostalCode == storeFilter.PostalCode.Value);
            }

            if (!string.IsNullOrEmpty(storeFilter.Address))
            {
                query = query.Where(s => s.Address == storeFilter.Address);
            }

            if (!string.IsNullOrEmpty(storeFilter.Number))
            {
                query = query.Where(s => s.Number == storeFilter.Number);
            }

            if (!string.IsNullOrEmpty(storeFilter.Complement))
            {
                query = query.Where(s => s.Complement == storeFilter.Complement);
            }

            if (!string.IsNullOrEmpty(storeFilter.City))
            {
                query = query.Where(s => s.City == storeFilter.City);
            }

            if (!string.IsNullOrEmpty(storeFilter.State))
            {
                query = query.Where(s => s.State == storeFilter.State);
            }

            if (storeFilter.PhoneNumber.HasValue)
            {
                query = query.Where(s => s.PhoneNumber == storeFilter.PhoneNumber.Value);
            }

            if (storeFilter.ListIdStore != null && storeFilter.ListIdStore.Any())
            {
                query = query.Where(s => storeFilter.ListIdStore.Contains(s.IdStore));
            }
            //if (!string.IsNullOrEmpty(storeFilter.SortField))
            //{
            //    query = query.OrderBy($"{storeFilter.SortField} {storeFilter.SortOrder ?? "ASC"}");
            //}

            var totalRecords = await query.CountAsync();

            int page = storeFilter.Page ?? 1;
            int pageSize = storeFilter.PageSize ?? 10;
            int offset = (page - 1) * pageSize;

            var storeList = await query.Skip(offset).Take(pageSize).ToListAsync();

            return (storeList, totalRecords);
        }

    }
}
