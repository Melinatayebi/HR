using HR.Entities;
using HR.ViewModels.Department;

namespace HR.RepositoryContract
{
    public interface IDepartmentRepository : IBaseRepositories<DepartmentEntity>
    {
        bool IsExist(string departmentName);
        DepartmentEntity? Find(int id);
        IList<DepartmentEntity> GetList();
    }
}
