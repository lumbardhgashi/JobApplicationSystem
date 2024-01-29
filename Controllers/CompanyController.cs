using JobApplicationSystem.Models;
using JobApplicationSystem.Services.Interface;
using JobApplicationSystem.Validator;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetAllCompany")]
        public List<Company> GetAllCompany()
        {
            var result = _companyService.GetAllCompany();
            return result;
        }

        [HttpGet("GetCompanyById/{id}")]
        public Company GetCompanyById(int id)
        {
            return _companyService.GetCompanytById(id);
        }

        [HttpGet("GetNumberOfEmployesByCompanyId/{id}")]
        public int GetNumberOfEmployesByCompanyId(int id)
        {
            return _companyService.GetNumberOfEmployesByCompanyId(id);
        }

        [HttpPost("CreateCompany")]
        public IActionResult CreateCompany(Company company)
        {
            CompanyValidator validator = new CompanyValidator();
            var validationResult = validator.Validate(company);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdCompany = _companyService.CreateCompany(company);
            return Ok(createdCompany);
        }

        [HttpPut("UpdateCompany/{id}")]
        public IActionResult UpdateCompany(int id, Company company)
        {
            var validator = new CompanyValidator();
            var validationResult = validator.Validate(company);

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
                var oldCompany = _companyService.GetCompanytById(id);
                if (oldCompany == null)
                {
                    return NotFound();
                }
                _companyService.UpdateCompany(company);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete("DeleteCompany/{id}")]
        public IActionResult DeleteCompany(int id)
        {
            try
            {
                var deletedCompany = _companyService.GetCompanytById(id);
                if (deletedCompany == null)
                {
                    return NotFound();
                }
                _companyService.DeleteCompany(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }
    }
}
