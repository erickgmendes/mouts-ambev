using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branches.CreateBranch;

/// <summary>
/// Validator for CreateBranchCommand that defines validation rules for branch creation command.
/// </summary>
public class CreateBranchCommandValidator: AbstractValidator<CreateBranchCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateBranchCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - ExternalId: Required, must be between 3 and 50 characters
    /// - Name: Required, must be between 3 and 50 characters
    /// - Address: Required, must be between 3 and 50 characters
    /// - City: Required, must be between 3 and 50 characters
    /// - State: Required, must be between 2 and 50 characters
    /// - PostalCode: Must match brazilian cep format (99999-999)
    /// </remarks>
    public CreateBranchCommandValidator()
    {
        RuleFor(branch => branch. ExternalId).NotEmpty().Length(3, 50);
        RuleFor(branch => branch.Name).NotEmpty().Length(3, 50);
        RuleFor(branch => branch.Address).NotEmpty().Length(3, 50);
        RuleFor(branch => branch.City).NotEmpty().Length(3, 50);
        RuleFor(branch => branch.State).NotEmpty().Length(2, 50);
        RuleFor(branch => branch.PostalCode).Matches(@"^\d{5}-\d{3}$");

    }
}