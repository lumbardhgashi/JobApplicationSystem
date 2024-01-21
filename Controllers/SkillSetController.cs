using JobApplicationSystem.Models;
using JobApplicationSystem.Services.Interface;
using JobApplicationSystem.Validator;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    public class SkillSetController : Controller
    {
        private readonly ISkillSetService _skillSetServise;
        public SkillSetController(ISkillSetService skillSetService)
        {
            _skillSetServise = skillSetService;
        }

        [HttpGet("GetAllSkillSet")]
        public List<SkillSet> GetAllSkillSet()
        {
            var result = _skillSetServise.GetAllSkillSet();
            return result;
        }

        [HttpGet("GetSkillSetById/{id}")]
        public SkillSet GetSkillSetById(int id)
        {
            return _skillSetServise.GetSkillSetById(id);
        }

        [HttpPost("CreateSkillSet")]
        public IActionResult CreateSkillSet(SkillSet skillSet)
        {
            SkillSetValidator validator = new SkillSetValidator();
            var validationResult = validator.Validate(skillSet);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdSkillSet = _skillSetServise.CreateSkillSet(skillSet);
            return Ok(createdSkillSet);
        }

        [HttpPut("UpdateSkillSet/{id}")]
        public IActionResult UpdateSkillSet(int id, SkillSet skillSet)
        {
            var validator = new SkillSetValidator();
            var validationResult = validator.Validate(skillSet);

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
                var oldSkillSet = _skillSetServise.GetSkillSetById(id);
                if (oldSkillSet == null)
                {
                    return NotFound();
                }
                _skillSetServise.UpdateSkillSet(skillSet);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete("DeleteSkillSet/{id}")]
        public IActionResult DeleteSkillSet(int id)
        {
            try
            {
                var deletedSkillSet = _skillSetServise.GetSkillSetById(id);
                if (deletedSkillSet == null)
                {
                    return NotFound();
                }
                _skillSetServise.DeleteSkillSet(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }
    }
}
