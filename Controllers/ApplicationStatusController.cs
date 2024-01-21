using JobApplicationSystem.Models;
using JobApplicationSystem.Services.Interface;
using JobApplicationSystem.Validator;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    public class ApplicationStatusController : Controller
    {
        private readonly IApplicationStatusService _applicationStatusService;

        public ApplicationStatusController(IApplicationStatusService applicationStatusService)
        {
            _applicationStatusService = applicationStatusService;
        }

        [HttpGet("GetAllApplicationStatus")]
        public List<ApplicationStatus> GetAllApplicationStatus()
        {
            var result = _applicationStatusService.GetAllApplicationStatus();
            return result;
        }

        [HttpGet("GetApplicationStatusById/{id}")]
        public ApplicationStatus GetApplicationStatusById(int id)
        {
            return _applicationStatusService.GetApplicationStatusById(id);
        }

        [HttpPost("CreateApplicationStatus")]
        public IActionResult CreateApplicationStatus(ApplicationStatus applicationStatus)
        {
            ApplicationStatusValidator validator = new ApplicationStatusValidator();
            var validationResult = validator.Validate(applicationStatus);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdApplicationStatus = _applicationStatusService.CreateApplicationStatus(applicationStatus);
            return Ok(CreateApplicationStatus);
        }

        [HttpPut("UpdateApplicationStatus/{id}")]
        public IActionResult UpdateApplicationStatus(int id, ApplicationStatus applicationStatus)
        {
            var validator = new ApplicationStatusValidator();
            var validationResult = validator.Validate(applicationStatus);

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
                var oldApplicationStatus = _applicationStatusService.GetApplicationStatusById(id);
                if (oldApplicationStatus == null)
                {
                    return NotFound();
                }
                _applicationStatusService.UpdateApplicationStatus(applicationStatus);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete("DeleteApplicationStatus/{id}")]
        public IActionResult DeleteApplicationStatus(int id)
        {
            try
            {
                var deletedApplicationStatus = _applicationStatusService.GetApplicationStatusById(id);
                if (deletedApplicationStatus == null)
                {
                    return NotFound();
                }
                _applicationStatusService.DeleteApplicationStatus(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }
    }
}
