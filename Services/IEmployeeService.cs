using HR.Entities;
using HR.ViewModels.Employee;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HR.Services
{
    public interface IEmployeeService 
    {
        EmployeeResponse Create(CreateEmployeeRequest request);
        EmployeeResponse Remove(RemoveEmployeeRequest request);
        public List<EmpoloyeeViewModel> GetList();
        public List<EmpoloyeeViewModel> GetListExtra();
        public EmployeeDepartmentNameViewModel GetViewModelByNationalCode(string nationalCode);
    }
}
