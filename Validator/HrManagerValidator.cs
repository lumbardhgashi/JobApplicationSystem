using FluentValidation;
using JobApplicationSystem.Models;

namespace JobApplicationSystem.Validator
{
    public class HrManagerValidator : AbstractValidator<HRManager>
    {
        public HrManagerValidator() 
        {
            //RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Name).NotEmpty().WithMessage("Fill the Name Field!");
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).WithMessage("Name should have 2 characters at least!");

            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Fill the CompanyId Field!");

            RuleFor(x => x.Department).NotEmpty().WithMessage("Fill the Department Field!");
            RuleFor(x => x.Department).NotEmpty().MinimumLength(2).WithMessage("Department should have 2 characters at least!");
        }
    }
}
