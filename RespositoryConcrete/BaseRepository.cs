using HR.DataBaseContext;
using HR.Entities;
using HR.RepositoryContract;

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HR.RespositoryConcrete
{
    public class BaseRepository<TEntity> : IBaseRepositories<TEntity> where TEntity : DomainEntity, new()
    {
        protected readonly DataBaseDbContext _dbContext;

        public BaseRepository(DataBaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
           _dbContext.Set<TEntity>().Add(entity);
        }

        public void Remove(int id)
        {
            var search = _dbContext.Set<TEntity>().Where(p => p.Id==id);
             _dbContext.Set<TEntity>().RemoveRange(search);
        }
       

    }
}
