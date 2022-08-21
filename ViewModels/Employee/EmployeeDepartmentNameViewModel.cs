using HR.ViewModels.Department;

namespace HR.ViewModels.Employee
{
    public class EmployeeDepartmentNameViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DepartmentViewModel Department { get; set; }

    }
}
