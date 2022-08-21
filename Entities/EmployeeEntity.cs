using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Entities
{
    public class EmployeeEntity : DomainEntity
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Nationalcode { get; set; }
        public DepartmentEntity Department { get; set; }
    }
}
