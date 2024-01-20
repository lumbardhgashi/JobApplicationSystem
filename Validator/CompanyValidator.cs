using FluentValidation;
using JobApplicationSystem.Models;

namespace JobApplicationSystem.Validator
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            //RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Fill the CompanyName Field!");
            RuleFor(x => x.CompanyName).NotEmpty().MinimumLength(2).WithMessage("CompanyName should have 2 characters at least!");

            RuleFor(x => x.Sektori).NotEmpty().WithMessage("Fill the Sektori Field!");
            RuleFor(x => x.Sektori).NotEmpty().MinimumLength(2).WithMessage("Sektori should have 2 characters at least!");

            RuleFor(x => x.Adresa).NotEmpty().WithMessage("Fill the Adresa Field!");
            RuleFor(x => x.Adresa).EmailAddress();

            RuleFor(x => x.NumriTelefonit).NotEmpty().WithMessage("Fill the NumriTelefonit Field!");

        }
    }
}
