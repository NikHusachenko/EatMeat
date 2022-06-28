using EatMeat.Database.Entities;
using EatMeat.Database.Enums;
using EatMeat.Services.MeatServices.Models;

namespace EatMeat.Services.MeatServices
{
    public interface IMeatService
    {
        void Create(CreateViewModel vm);
        void Update(MeatEntity meatEntity);
        Task<bool> Delete(long id);
        Task<MeatEntity> GetByIdAsync(long id);
        Task<List<MeatEntity>> GetAllAsync();
        Task<List<MeatEntity>> GetAllAsyncNotBuyed();
        Task<List<MeatEntity>> GetByType(MeatTypes type);
        Task<List<MeatEntity>> GetByTypeNotBuyed(MeatTypes type);
        Task<List<MeatEntity>> GetBySource(MeatSource source);
        Task<List<MeatEntity>> GetBySourceNotBuyed(MeatSource source);
        Task<bool> Buy(long meatId, long buyerId);
        Task<bool> Cancel(long id);
    }
}