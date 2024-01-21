using FluentValidation;
using JobApplicationSystem.Models;

namespace JobApplicationSystem.Validator
{
    public class ReviewApplicationValidator:AbstractValidator<ReviewApplication>
    {
        public ReviewApplicationValidator()
        {
            RuleFor(ra => ra.HrManagerId).NotEmpty();
            RuleFor(ra => ra.PointOfReview).NotEmpty();
            RuleFor(ra => ra.ApplyId).NotEmpty();

        }
    }
}
