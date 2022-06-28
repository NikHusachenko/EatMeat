using Microsoft.EntityFrameworkCore;

namespace EatMeat.EntityFramework.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        DbContext _context;
        public DbSet<TEntity> Table { get; set; }

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            Table = context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await Table.AsNoTracking().ToListAsync();
        }

        public List<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return Table.AsNoTracking().Where(predicate).ToList();
        }
        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public void Create(TEntity item)
        {
            Table.Add(item);
            _context.SaveChanges();
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(TEntity item)
        {
            Table.Remove(item);
            _context.SaveChanges();
        }
    }
}