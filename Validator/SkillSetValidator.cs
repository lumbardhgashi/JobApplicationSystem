using FluentValidation;
using JobApplicationSystem.Models;

namespace JobApplicationSystem.Validator
{
    public class SkillSetValidator : AbstractValidator<SkillSet>
    {
        public SkillSetValidator()
        {
            //RuleFor(x => x.Id).NotEmpty();

            RuleFor(a => a.ApplicantId).NotEmpty();

            RuleFor(x => x.Skills).NotEmpty().WithMessage("Fill the Skills Field!");
            RuleFor(x => x.Skills).NotEmpty().MinimumLength(2).WithMessage("Sektori should have 2 characters at least!");

            RuleFor(x => x.Pointer).NotEmpty().WithMessage("Fill the Pointer Field!");
        }
    }
}
