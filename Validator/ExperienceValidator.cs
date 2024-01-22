using FluentValidation;
using JobApplicationSystem.Models;

namespace JobApplicationSystem.Validator
{
    public class ExperienceValidator : AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            //RuleFor(x => x.Id).NotEmpty();

            RuleFor(a => a.ApplicantId).NotEmpty();

            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Fill the StartDate Field!");

            RuleFor(x => x.EndDate).NotEmpty().WithMessage("Fill the EndDate Field!");

            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Fill the CompanyName Field!");
            RuleFor(x => x.CompanyName).NotEmpty().MinimumLength(2).WithMessage("CompanyName should have 2 characters at least!");

        }
    }
}
