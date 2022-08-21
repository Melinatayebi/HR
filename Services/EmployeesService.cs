using HR.Entities;
using HR.RepositoryContract;
using HR.ViewModels.Department;
using HR.ViewModels.Employee;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HR.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentRepository _departmentRepository;
        public EmployeeService(IEmployeesRepository employeesRepository, IUnitOfWork unitOfWork, IDepartmentRepository departmentRepository)
        {
            _employeesRepository = employeesRepository;
            _unitOfWork = unitOfWork;
            _departmentRepository = departmentRepository;
        }

        public EmployeeResponse Create(CreateEmployeeRequest request)
        {
            var isExist1 = _employeesRepository.IsExist(request.Nationalcode);
            if (isExist1)
                throw new Exception("کد ملی تکراری است");

            var department = _departmentRepository.Find(request.DepartmentId);
            if (department == null)
                throw new Exception("کد دپارتمان معتبر نمی یاشد");

            var entity = new EmployeeEntity
            {
                Fname = request.Fname,
                Lname = request.Lname,
                Nationalcode = request.Nationalcode, 
                Department = department
            };
             _employeesRepository.Add(entity);
            _unitOfWork.Save();
            return new EmployeeResponse { Id = entity.Id };
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          

        public EmployeeResponse Remove(RemoveEmployeeRequest request)
        {
            _employeesRepository.Remove(request.Id);
            _unitOfWork.Save();
            return new EmployeeResponse { Id = request.Id };
        }

         public List<EmpoloyeeViewModel> GetViewModelEmployee(List<EmployeeEntity> entities)
        {
            return entities.Select(x => new EmpoloyeeViewModel
            {
               EmployeeId = x.Id , 
               Name = x.Fname,
               LastName = x.Lname,
               NationalCode = x.Nationalcode,
               DepartmentId = x.Department.Id
            }).ToList();
        }

        public List<EmpoloyeeViewModel> GetList()
        {
            List<EmployeeEntity> employees = (List<EmployeeEntity>)_employeesRepository.GetList();
            return GetViewModelEmployee(employees);
        }

        public List<EmpoloyeeViewModel> GetViewModelEmployeeDepartment (List<EmployeeEntity> emp )
        {
            return emp.Select(employee => new EmpoloyeeViewModel
            {
                EmployeeId = employee.Id,
                Name = employee.Fname,
                LastName = employee.Lname,
                NationalCode = employee.Nationalcode,
                Department = new DepartmentViewModel
                {
                    DepartmentName = employee.Department.DepartmentName,
                    Id = employee.Department.Id
                }

            }).ToList();
        }

        public List<EmpoloyeeViewModel> GetListExtra()
        {
            List<EmployeeEntity> employees = (List<EmployeeEntity>)_employeesRepository.GetList();
            return GetViewModelEmployeeDepartment(employees);
        }


        public EmployeeDepartmentNameViewModel GetViewModelByNationalCode(string nationalCode) 
        {

            var result = _employeesRepository.FindEmployee(nationalCode);

            EmployeeDepartmentNameViewModel emp = new EmployeeDepartmentNameViewModel();
            emp.FirstName = result.Fname;
            emp.LastName = result.Lname;
            emp.Department = new DepartmentViewModel
            {
                Id = result.Department.Id,
                DepartmentName = result.Department.DepartmentName,
            };

            return emp;
        }
       

      
    }


}
