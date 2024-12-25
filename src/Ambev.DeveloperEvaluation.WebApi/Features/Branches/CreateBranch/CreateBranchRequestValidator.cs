using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch;

/// <summary>
/// Validator for CreateBranchRequest that defines validation rules for branch creation.
/// </summary>
public class CreateBranchRequestValidator : AbstractValidator<CreateBranchRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateBranchRequestValidator with defined validation rules.
    /// </summary>
    public CreateBranchRequestValidator()
    {
        // Validates that the ExternalId is not empty and has a minimum length of 3 characters
        RuleFor(branch => branch.ExternalId).NotEmpty().WithMessage("ExternalId is required.");
        
        // Validates that the Name is not empty and has a minimum length of 3 characters
        RuleFor(branch => branch.Name).NotEmpty().WithMessage("Branch name is required.");
        
        // Validates that the Address is not empty
        RuleFor(branch => branch.Address).NotEmpty().WithMessage("Address is required.");
        
        // Validates that the City is not empty
        RuleFor(branch => branch.City).NotEmpty().WithMessage("City is required.");
        
        // Validates that the State is not empty
        RuleFor(branch => branch.State).NotEmpty().WithMessage("State is required.");
        
        // Validates that the PostalCode is a valid format (e.g., ZIP code format)
        RuleFor(branch => branch.PostalCode).Matches(@"^\d{5}-\d{3}$").WithMessage("PostalCode must be in the format XXXXX-XXX.");
    }
}