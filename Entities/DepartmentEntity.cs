
namespace HR.Entities
{
    public class DepartmentEntity : DomainEntity
    {
        public string DepartmentName { get; set; }
        public List<EmployeeEntity> Employees { get; set; }
    }
}
