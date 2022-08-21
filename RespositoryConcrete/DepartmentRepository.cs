using HR.DataBaseContext;
using HR.Entities;
using HR.RepositoryContract;
using Microsoft.EntityFrameworkCore;

namespace HR.RespositoryConcrete
{
    public class DepartmentRepository : BaseRepository<DepartmentEntity> , IDepartmentRepository
    {
       
        public DepartmentRepository(DataBaseDbContext dbContext) : base(dbContext)
        {
        }

        public bool IsExist(string departmentName)
        {
            return _dbContext.Set<DepartmentEntity>().Any(x => x.DepartmentName == departmentName);
        }

        public DepartmentEntity? Find(int id)
        {
            return _dbContext.Set<DepartmentEntity>().FirstOrDefault(x => x.Id== id);
        }

        public IList<DepartmentEntity> GetList()
        {
            return _dbContext.Set<DepartmentEntity>().Include(x => x.Employees).ToList();
        }

    }
}
