using HR.Entities;
using HR.ViewModels.Employee;

namespace HR.RepositoryContract
{
    public interface IEmployeesRepository : IBaseRepositories<EmployeeEntity>
    {
        bool IsExist(string nationalCode);
         IList<EmployeeEntity> GetList();

        public EmployeeEntity FindEmployee(string nationalCode);


    }
}
