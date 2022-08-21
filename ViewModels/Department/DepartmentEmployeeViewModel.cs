using HR.Entities;
using HR.ViewModels.Employee;

namespace HR.ViewModels.Department
{
    public class DepartmentEmployeeViewModel
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public List<EmployeeViewModelWithoutDepartment> Employee { get; set; }
    }
}
