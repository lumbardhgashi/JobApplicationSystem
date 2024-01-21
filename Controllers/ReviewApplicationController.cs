using JobApplicationSystem.Models;
using JobApplicationSystem.Services.Interface;
using JobApplicationSystem.Validator;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    public class ReviewApplicationController : Controller
    {
        private readonly IReviewApplicationService _reviewApplicationService;

        public ReviewApplicationController(IReviewApplicationService reviewApplicationService)
        {
            _reviewApplicationService = reviewApplicationService;
        }

        [HttpGet("GetAllReviewApplication")]
        public List<ReviewApplication> GetAllReviewApplication()
        {
            var result = _reviewApplicationService.GetAllReviewAplications();
            return result;
        }

        [HttpGet("GetReviewApplicationById/{id}")]
        public ReviewApplication GetReviewApplicationById(int id)
        {
            return _reviewApplicationService.GetReviewApplicationById(id);
        }

        [HttpPost("CreateReviewApplication")]
        public IActionResult CreateReviewApplication(ReviewApplication reviewApplication)
        {
            ReviewApplicationValidator validator = new ReviewApplicationValidator();
            var validationResult = validator.Validate(reviewApplication);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdReviewApplication = _reviewApplicationService.CreateReviewApplication(reviewApplication);
            return Ok(createdReviewApplication);
        }

        [HttpPut("UpdateReviewApplication/{id}")]
        public IActionResult UpdateReviewApplication(int id, ReviewApplication reviewApplication)
        {
            var validator = new ReviewApplicationValidator();
            var validationResult = validator.Validate(reviewApplication);

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
                var oldReviewApplication = _reviewApplicationService.GetReviewApplicationById(id);
                if (oldReviewApplication == null)
                {
                    return NotFound();
                }
                _reviewApplicationService.UpdateReviewApplication(reviewApplication);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete("DeleteReviewApplication/{id}")]
        public IActionResult DeleteReviewApplication(int id)
        {
            try
            {
                var deletedReviewApplication = _reviewApplicationService.GetReviewApplicationById(id);
                if (deletedReviewApplication == null)
                {
                    return NotFound();
                }
                _reviewApplicationService.DeleteReviewApplication(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }


    }
}
