using HR.Entities;
using HR.ViewModels.Department;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HR.Services
{
    public interface IDepartmentService
    {
        DepartmentResponse Create(CreateDepartmentRequest request);
        DepartmentResponse Remove(RemoveDepartmentRequest request);
        List<DepartmentViewModel> GetList();
        List<DepartmentEmployeeViewModel> GetListExtra();
    }
}
