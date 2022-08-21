
using HR.ViewModels.Department;
using HR.RepositoryContract;
using HR.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using HR.ViewModels.Employee;

namespace HR.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;


        public DepartmentService(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
        }

        public DepartmentResponse Create(CreateDepartmentRequest request)
        {
            var isExist1 = _departmentRepository.IsExist(request.DepartmentType);
            if (isExist1)
                throw new Exception("اسم دپارتمان تکراری است");

            var entity = new DepartmentEntity { DepartmentName = request.DepartmentType };
            _departmentRepository.Add(entity);

            _unitOfWork.Save();

            return new DepartmentResponse { Id = entity.Id };
        }

        public List<DepartmentViewModel> GetViewModelDepartment(List<DepartmentEntity> entities)
        {
           return entities.Select(x => new DepartmentViewModel
            {
                DepartmentName = x.DepartmentName,
                Id = x.Id
            }).ToList();
        }
        public List<DepartmentViewModel> GetList()
        {
            List<DepartmentEntity> departmentList = (List<DepartmentEntity>)_departmentRepository.GetList();
            return GetViewModelDepartment(departmentList);
           
        }


        public List<DepartmentEmployeeViewModel> GetViewModelDepartmentEmployee (List<DepartmentEntity> entities)
        {
            return entities.Select(department => new DepartmentEmployeeViewModel
            {
                DepartmentID = department.Id,
                DepartmentName = department.DepartmentName,
                Employee = department.Employees.ConvertAll(employee => new EmployeeViewModelWithoutDepartment
                {
                    Name = employee.Fname,
                    LastName = employee.Lname,
                    NationalCode = employee.Nationalcode
                })
            }).ToList();

        }
        public List<DepartmentEmployeeViewModel> GetListExtra()
        {
            List<DepartmentEntity> departmentList = (List<DepartmentEntity>)_departmentRepository.GetList();
            return GetViewModelDepartmentEmployee(departmentList);

        }

        public DepartmentResponse Remove(RemoveDepartmentRequest request)
        {
            _departmentRepository.Remove(request.Id);
            _unitOfWork.Save();
            return new DepartmentResponse { Id = request.Id };
        }

       
    }


}
