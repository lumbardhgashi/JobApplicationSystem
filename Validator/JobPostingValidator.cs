using FluentValidation;
using JobApplicationSystem.Models;

namespace JobApplicationSystem.Validator
{
    public class JobPostingValidator: AbstractValidator<JobPosting>
    {
        public JobPostingValidator()
        {
            RuleFor(jp => jp.HrManagerId).NotEmpty();
            RuleFor(jp => jp.DepartmentId).NotEmpty();
            RuleFor(jp => jp.Tittle).NotEmpty();
            RuleFor(jp => jp.Description).NotEmpty();
            RuleFor(jp => jp.Requriments).NotEmpty();
            
        }
    }
}
