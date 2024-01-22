using FluentValidation;
using JobApplicationSystem.Models;

namespace JobApplicationSystem.Validator
{
    public class DepartmentValidator: AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            //RuleFor(x =>  x.id).NotEmpty();

            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Fill the CompanyId Field!");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Fill the Name Field!");
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).WithMessage("Name should have 2 characters at least!");

            RuleFor(x => x.NumriPunonjesve).NotEmpty().WithMessage("Fill the NumriPunojesve Field!");

            RuleFor(x => x.DrejtoriDepartamentit).NotEmpty().WithMessage("Fill the DrejtoriDepartmentit Field!");
            RuleFor(x => x.DrejtoriDepartamentit).NotEmpty().MinimumLength(2).WithMessage("DrejtoriDepartamentit should have 2 characters at least!");
        }
    }
}
