using FluentValidation;
using JobApplicationSystem.Models;

namespace JobApplicationSystem.Validator
{
    public class EducationHistoryValidator : AbstractValidator<EducationHistory>
    {
        public EducationHistoryValidator()
        {
            //RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.School).NotEmpty().WithMessage("Fill the School Field!");

            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Give a StartDate!");

            RuleFor(x => x.EndDate).NotEmpty().WithMessage("Give a EndDate!");

            RuleFor(x => x.AvgGrade).NotEmpty().WithMessage("Fill the AvgGrade Field!");
            
            RuleFor(x => x.ApplicantId).NotEmpty().WithMessage("Fill the AvgGrade Field!");

        }

    }
}
