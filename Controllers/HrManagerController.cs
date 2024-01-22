using JobApplicationSystem.Models;
using JobApplicationSystem.Services.Interface;
using JobApplicationSystem.Validator;
using Microsoft.AspNetCore.Mvc;


namespace JobApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    public class HrManagerController : Controller
    {
        private readonly IHrManagerService _hrManagerService;
        public HrManagerController(IHrManagerService hrManagerService)
        {
            _hrManagerService = hrManagerService;
        }

        [HttpGet("GetAllHrManager")]
        public List<HRManager> GetAllHrManager()
        {
            var result = _hrManagerService.GetAllHrManager();
            return result;
        }

        [HttpGet("GetHrManagerById/{id}")]
        public HRManager GetHrManagerById(int id)
        {
            return _hrManagerService.GetHrManagerById(id);
        }

        [HttpPost("CreateHrManager")]
        public IActionResult CreateHrManager(HRManager hRManager)
        {
            HrManagerValidator validator = new HrManagerValidator();
            var validationResult = validator.Validate(hRManager);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdHrManager = _hrManagerService.CreateHrManager(hRManager);
            return Ok(createdHrManager);
        }

        [HttpPut("UpdateHrManager/{id}")]
        public IActionResult UpdateHrManager(int id, HRManager hRManager)
        {
            var validator = new HrManagerValidator();
            var validationResult = validator.Validate(hRManager);

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
                var oldHrManager = _hrManagerService.GetHrManagerById(id);
                if (oldHrManager == null)
                {
                    return NotFound();
                }
                _hrManagerService.UpdateHrManager(hRManager);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete("DeleteHrManager/{id}")]
        public IActionResult DeleteHrManager(int id)
        {
            try
            {
                var deletedHrManager = _hrManagerService.GetHrManagerById(id);
                if (deletedHrManager == null)
                {
                    return NotFound();
                }
                _hrManagerService.DeleteHrManager(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }
    }
}
