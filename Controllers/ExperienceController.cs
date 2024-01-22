using JobApplicationSystem.Models;
using JobApplicationSystem.Services.Interface;
using JobApplicationSystem.Validator;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;
        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        [HttpGet("GetAllExperience")]
        public List<Experience> GetAllExperience()
        {
            var result = _experienceService.GetAllExperience();
            return result;
        }

        [HttpGet("GetExperienceById/{id}")]
        public Experience GetExperienceById(int id)
        {
            return _experienceService.GetExperienceById(id);
        }

        [HttpPost("CreateExperience")]
        public IActionResult CreateExperience(Experience experience)
        {
            ExperienceValidator validator = new ExperienceValidator();
            var validationResult = validator.Validate(experience);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdExperience = _experienceService.CreateExperience(experience);
            return Ok(createdExperience);
        }

        [HttpPut("UpdateExperience/{id}")]
        public IActionResult UpdateExperience(int id, Experience experience)
        {
            var validator = new ExperienceValidator();
            var validationResult = validator.Validate(experience);

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
                var oldExperience = _experienceService.GetExperienceById(id);
                if (oldExperience == null)
                {
                    return NotFound();
                }
                _experienceService.UpdateExperience(experience);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete("DeleteExperience/{id}")]
        public IActionResult DeleteExperience(int id)
        {
            try
            {
                var deletedExperience = _experienceService.GetExperienceById(id);
                if (deletedExperience == null)
                {
                    return NotFound();
                }
                _experienceService.DeleteExperience(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }

    }
}

