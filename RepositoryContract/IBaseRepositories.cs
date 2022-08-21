using HR.ViewModels.Employee;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HR.RepositoryContract
{
    public interface IBaseRepositories<TEntity> where TEntity : class
    {

        void Add(TEntity entity);
        void Remove(int id);
        
    }
}
