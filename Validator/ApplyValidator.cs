using FluentValidation;
using JobApplicationSystem.Models;

namespace JobApplicationSystem.Validator
{
    public class ApplyValidator: AbstractValidator<Apply>
    {
        public ApplyValidator()
        {
            //RuleFor(a => a.Id).NotEmpty();
            RuleFor(a => a.applicantId).NotEmpty();
            RuleFor(a => a.JobPostId).NotEmpty();
        }
    }
}
