using JobApplicationSystem.Models;
using JobApplicationSystem.Services.Interface;
using JobApplicationSystem.Validator;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    public class JobPostingController : Controller
    {
        private readonly IJobPostingService _jobPostingService;

        public JobPostingController(IJobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }

        [HttpGet("GetAllJobPosts")]
        public List<JobPosting> GetAllJobPosts()
        {
            var result = _jobPostingService.GetAllJobPosts();
            return result;
        }

        [HttpGet("GetJobPostById/{id}")]
        public JobPosting GetJobPostingById(int id)
        {
            return _jobPostingService.GetJobPostById(id);
        }

        [HttpPost("CreateJobPost")]
        public IActionResult CreateJobPosty(JobPosting jobPost)
        {
            JobPostingValidator validator = new JobPostingValidator();
            var validationResult = validator.Validate(jobPost);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdJobPost = _jobPostingService.CreateJobPost(jobPost);
            return Ok(createdJobPost);
        }

        [HttpPut("UpdateJobPost/{id}")]
        public IActionResult UpdateJobPost(int id, JobPosting jobPost)
        {
            var validator = new JobPostingValidator();
            var validationResult = validator.Validate(jobPost);

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
                var oldJobPost = _jobPostingService.GetJobPostById(id);
                if (oldJobPost == null)
                {
                    return NotFound();
                }
                _jobPostingService.UpdateJobPost(jobPost);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete("DeleteJobPost/{id}")]
        public IActionResult DeleteJobPost(int id)
        {
            try
            {
                var deletedJobPost = _jobPostingService.GetJobPostById(id);
                if (deletedJobPost == null)
                {
                    return NotFound();
                }
                _jobPostingService.DeleteJobPost(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }
    }
}
