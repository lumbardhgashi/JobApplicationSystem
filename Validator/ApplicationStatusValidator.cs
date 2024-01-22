using FluentValidation;
using JobApplicationSystem.Models;

namespace JobApplicationSystem.Validator
{
    public class ApplicationStatusValidator:AbstractValidator<ApplicationStatus>
    {
        public ApplicationStatusValidator()
        {
            RuleFor(a => a.Status).NotEmpty();
            RuleFor(a => a.ReviewApplicationId).NotEmpty();
            RuleFor(a => a.StatusDescription).NotEmpty();
        }
    }
}
