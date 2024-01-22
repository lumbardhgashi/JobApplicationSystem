using JobApplicationSystem.Models;
using JobApplicationSystem.Services.Interface;
using JobApplicationSystem.Validator;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    public class EducationHistoryController : Controller
    {
        private readonly IEducationHistoryService _educationHistoryService;
        public EducationHistoryController(IEducationHistoryService educationHistoryService)
        {
            _educationHistoryService = educationHistoryService;
        }

        [HttpGet("GetAllEducationHistory")]
        public List<EducationHistory> GetAllEducationHistory()
        {
            var result = _educationHistoryService.GetAllEducationHistory();
            return result;
        }

        [HttpGet("GetEducationHistoryById/{id}")]
        public EducationHistory GetEducationHistoryById(int id)
        {
            return _educationHistoryService.GetEducationHistoryById(id);
        }

        [HttpPost("CreateEducationHistory")]
        public IActionResult CreateEducationHistory(EducationHistory educationHistory)
        {
            EducationHistoryValidator validator = new EducationHistoryValidator();
            var validationResult = validator.Validate(educationHistory);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdEducationHistory = _educationHistoryService.CreateEducationHistory(educationHistory);
            return Ok(createdEducationHistory);
        }

        [HttpPut("UpdateEducationHistory/{id}")]
        public IActionResult UpdateEducationHistory(int id, EducationHistory educationHistory)
        {
            var validator = new EducationHistoryValidator();
            var validationResult = validator.Validate(educationHistory);

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
                var oldEducationHistory = _educationHistoryService.GetEducationHistoryById(id);
                if (oldEducationHistory == null)
                {
                    return NotFound();
                }
                _educationHistoryService.UpdateEducationHistory(educationHistory);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete("DeleteEducationHistory/{id}")]
        public IActionResult DeleteEducationHistory(int id)
        {
            try
            {
                var deletedEducationHistory = _educationHistoryService.GetEducationHistoryById(id);
                if (deletedEducationHistory == null)
                {
                    return NotFound();
                }
                _educationHistoryService.DeleteEducationHistory(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }
    }
}
