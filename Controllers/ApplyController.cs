using JobApplicationSystem.Models;
using JobApplicationSystem.Services.Interface;
using JobApplicationSystem.Validator;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    public class ApplyController : Controller
    {
        private readonly IApplyService _applyService;

        public ApplyController(IApplyService applyService)
        {
            _applyService = applyService;
        }

        [HttpGet("GetAllApplies")]
        public List<Apply> GetAllApplies()
        {
            var result = _applyService.GetAllApplies();
            return result;
        }

        [HttpGet("GetApplyById/{id}")]
        public Apply GetApplyById(int id)
        {
            return _applyService.GetApplyById(id);
        }

        [HttpGet("GetNumberOfAppliesByJobPostId/{id}")]
        public int GetNumberOfAppliesByJobPostId(int id)
        {
            return _applyService.GetNumberOfAppliesByJobPostId(id);
        }

        [HttpPost("CreateApply")]
        public IActionResult CreateApply(Apply apply)
        {
            ApplyValidator validator = new ApplyValidator();
            var validationResult = validator.Validate(apply);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdApply = _applyService.CreateApply(apply);
            return Ok(createdApply);
        }

        [HttpPut("UpdateApply/{id}")]
        public IActionResult UpdateApply(int id, Apply apply)
        {
            var validator = new ApplyValidator();
            var validationResult = validator.Validate(apply);

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
                var oldApply = _applyService.GetApplyById(id);
                if (oldApply == null)
                {
                    return NotFound();
                }
                _applyService.UpdateApply(apply);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete("DeleteApply/{id}")]
        public IActionResult DeleteApply(int id)
        {
            try
            {
                var deletedApply = _applyService.GetApplyById(id);
                if (deletedApply == null)
                {
                    return NotFound();
                }
                _applyService.DeleteApply(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }

    }
}
