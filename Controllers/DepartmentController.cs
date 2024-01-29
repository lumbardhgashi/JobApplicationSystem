using JobApplicationSystem.Models;
using JobApplicationSystem.Services;
using JobApplicationSystem.Services.Interface;
using JobApplicationSystem.Validator;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("GetAllDepartments")]
        public List<Department>GetAllDepartments()
        {
            var result = _departmentService.GetAllDepartments();
            return result;
        }

        [HttpGet("GetDepartmentById/ {id}")]
        public Department GetDepartmentById(int id)
        {
            return _departmentService.GetDepartmentById(id);
        }

        [HttpGet("GetDepartmentByName/ {name}")]
        public Department GetDepartmentByName(string name)
        {
            return _departmentService.GetDepartmentByName(name);
        }

        [HttpPost("CreateDepartment")]
        public IActionResult CreateDepartment(Department department)
        {
            DepartmentValidator validator = new DepartmentValidator();
            var validationResult = validator.Validate(department);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdDepartment = _departmentService.CreateDepartment(department);
            return Ok(createdDepartment);
        }

        [HttpPut("UpdateDepartment/{id}")]
        public IActionResult UpdateDepartment(int id, Department department)
        {
            var validator = new DepartmentValidator();
            var validationResult = validator.Validate(department);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            try
            {
                var oldDepartment = _departmentService.GetDepartmentById(id);
                if (oldDepartment == null)
                {
                    return NotFound();
                }
                _departmentService.UpdateDepartment(department);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete("DeleteDepartment/{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                var deletedDepartment = _departmentService.GetDepartmentById(id);
                if (deletedDepartment == null)
                {
                    return NotFound();
                }
                _departmentService.DeleteDepartment(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }
    }
}
