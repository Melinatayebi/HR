using HR.ViewModels.Department;

namespace HR.ViewModels.Employee
{
    public class EmpoloyeeViewModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public int DepartmentId { get; set; }   
        public DepartmentViewModel Department { get; set; }
    }
}
