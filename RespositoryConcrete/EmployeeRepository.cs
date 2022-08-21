

using HR.DataBaseContext;
using HR.Entities;
using HR.RepositoryContract;
using Microsoft.EntityFrameworkCore;

namespace HR.RespositoryConcrete
{
    public class EmployeeRepository : BaseRepository<EmployeeEntity>, IEmployeesRepository
    {

        public EmployeeRepository(DataBaseDbContext dbContext) : base(dbContext)
        {
        }

        public IList<EmployeeEntity> GetList()
        {
            return _dbContext.Set<EmployeeEntity>().Include(x => x.Department).ToList();
        }

        public bool IsExist(string nationalCode)
        {
            return _dbContext.Set<EmployeeEntity>().Any(x => x.Nationalcode == nationalCode);
        }


        public EmployeeEntity FindEmployee(string nationalCode)
        {
            return _dbContext.Set<EmployeeEntity>().Include(x => x.Department).FirstOrDefault(x => x.Nationalcode == nationalCode);
        }
    }
}
