using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class BranchValidator : AbstractValidator<Branch>
{
    public BranchValidator()
    {
        RuleFor(branch => branch.Name)
            .NotEmpty().WithMessage("Branch name is required.");

        RuleFor(branch => branch.Address)
            .NotEmpty().WithMessage("Address is required.");

        RuleFor(branch => branch.City)
            .NotEmpty().WithMessage("City is required.");

        RuleFor(branch => branch.State)
            .NotEmpty().WithMessage("State is required.");

        RuleFor(branch => branch.PostalCode)
            .NotEmpty().WithMessage("Postal code is required.")
            .Matches(@"^\d{5}-\d{3}$").WithMessage("Postal code must be in the format XXXXX-XXX.");
    }
}