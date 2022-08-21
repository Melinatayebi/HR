using Microsoft.AspNetCore.Mvc;
using HR.Entities;
using HR.Services;
using HR.ViewModels.Department;

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("Get")]
        public IEnumerable<DepartmentViewModel> Get()
        {
            return _departmentService.GetList();
        }

        [HttpGet("Get Department & Employee")]
        public IEnumerable<DepartmentEmployeeViewModel> GetExtra()
        {
            return _departmentService.GetListExtra();
        }

        [HttpPost("Post")]
        public IActionResult CreateEmployee(CreateDepartmentRequest department)
        {
          
                var response = _departmentService.Create(department);
                return Ok(response);
            
        }

        [HttpDelete("Delete")]
        public IActionResult RemoveEmployee(RemoveDepartmentRequest department)
        {
            try
            {
               var response = _departmentService.Remove(department);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
