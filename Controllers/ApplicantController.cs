using JobApplicationSystem.Models;
using JobApplicationSystem.Services.Interface;
using JobApplicationSystem.Validator;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    public class ApplicantController : Controller
    {
        private readonly IApplicantService _applicantService;
        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpGet("GetAllApplicants")]
        public List<Applicant> GetAllApplicants()
        {
            var result = _applicantService.GetAllApplicants();
            return result;
        }

        [HttpGet("GetApplicantById/{id}")]
        public Applicant GetApplicantById(int id)
        {
            return _applicantService.GetApplicantById(id);
        }

        [HttpPost("CreateApplicant")]
        public IActionResult CreateApplicant(Applicant applicant)
        {
            ApplicantValidator validator = new ApplicantValidator();
            var validationResult = validator.Validate(applicant);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdApplicant = _applicantService.CreateApplicant(applicant);
            return Ok(createdApplicant);
        }

        [HttpPut("UpdateApplicant/{id}")]
        public IActionResult UpdateApplicant(int id, Applicant applicant)
        {
            var validator = new ApplicantValidator();
            var validationResult = validator.Validate(applicant);

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
                var oldApplicant = _applicantService.GetApplicantById(id);
                if (oldApplicant == null)
                {
                    return NotFound();
                }
                _applicantService.UpdateApplicant(applicant);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete("DeleteApplicant/{id}")]
        public IActionResult DeleteApplicant(int id)
        {
            try
            {
                var deletedApplicant = _applicantService.GetApplicantById(id);
                if (deletedApplicant == null)
                {
                    return NotFound();
                }
                _applicantService.DeleteApplicant(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }

    }
}
