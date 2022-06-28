using EatMeat.Database.Entities;
using EatMeat.Database.Enums;
using EatMeat.EntityFramework.Repository;
using EatMeat.Services.MeatServices.Models;
using Microsoft.EntityFrameworkCore;

namespace EatMeat.Services.MeatServices
{
    public class MeatService : IMeatService
    {
        private readonly IGenericRepository<MeatEntity> _genericRepository;

        public MeatService(IGenericRepository<MeatEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<bool> Buy(long meatId, long buyerId)
        {
            MeatEntity meatEntity = await _genericRepository.Table
                .FirstOrDefaultAsync(meat => meat.Id == meatId);

            if(meatEntity == null)
            {
                return false;
            }

            meatEntity.UserFK = buyerId;
            Update(meatEntity);
            return true;
        }

        public async Task<bool> Cancel(long id)
        {
            MeatEntity meatEntity = await _genericRepository.Table
                .FirstOrDefaultAsync(meat => meat.Id == id);

            if(meatEntity == null)
            {
                return false;
            }

            meatEntity.UserFK = null;
            Update(meatEntity);
            return true;
        }

        public void Create(CreateViewModel vm)
        {
            MeatEntity meatEntity = new MeatEntity()
            {
                Created = DateTime.Now,
                Description = vm.Description,
                Name = vm.Name,
                Price = vm.Price,
                Source = (MeatSource)vm.Source,
                Type = (MeatTypes)vm.Type,
                Weight = vm.Weight,
            };

            _genericRepository.Create(meatEntity);
        }

        public async Task<bool> Delete(long id)
        {
            MeatEntity meatEntity = await _genericRepository.Table
                .FirstOrDefaultAsync(meat => meat.Id == id);

            if(meatEntity == null)
            {
                return false;
            }

            /*meatEntity.Deleted = DateTime.Now;
            Update(meatEntity);*/
            _genericRepository.Remove(meatEntity);
            return true;
        }

        public async Task<List<MeatEntity>> GetAllAsync()
        {
            return await _genericRepository.Table.ToListAsync();
        }

        public async Task<List<MeatEntity>> GetAllAsyncNotBuyed()
        {
            return await _genericRepository.Table
                .Where(meat => meat.UserFK == null)
                .ToListAsync();
        }

        public async Task<MeatEntity> GetByIdAsync(long id)
        {
            return await _genericRepository.Table
                .FirstOrDefaultAsync(meat => meat.Id == id);
        }

        public Task<List<MeatEntity>> GetBySource(MeatSource source)
        {
            return _genericRepository.Table
                .Where(meat => meat.Source == source)
                .ToListAsync();
        }

        public Task<List<MeatEntity>> GetBySourceNotBuyed(MeatSource source)
        {
            return _genericRepository.Table
                .Where(meat => meat.Source == source && meat.UserFK == null)
                .ToListAsync();
               
        }

        public async Task<List<MeatEntity>> GetByType(MeatTypes type)
        {
            return await _genericRepository.Table
                .Where(meat => meat.Type == type)
                .ToListAsync();
        }

        public async Task<List<MeatEntity>> GetByTypeNotBuyed(MeatTypes type)
        {
            return await _genericRepository.Table
                .Where(meat => meat.Type == type && meat.UserFK == null)
                .ToListAsync();
        }

        public void Update(MeatEntity meatEntity)
        {
            _genericRepository.Update(meatEntity);
        }
    }
}