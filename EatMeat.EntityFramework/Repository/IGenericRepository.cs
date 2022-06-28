using Microsoft.EntityFrameworkCore;

namespace EatMeat.EntityFramework.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public DbSet<TEntity> Table { get; set; }

        void Create(TEntity item);
        Task<TEntity> FindByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        List<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}