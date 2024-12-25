using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.Common.Validation;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.CreateBranch;

/// <summary>
/// Command for creating a new branch.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a branch, 
/// including branchname, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest"/> to initiate the request 
/// that returns a <see cref="CreateBranchResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateBranchValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateBranchCommand : IRequest<CreateBranchResult>
{
    /// <summary>
    /// Gets or sets the External identifier for the branch.
    /// </summary>
    public string ExternalId { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the branch.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the address of the branch.
    /// </summary>
    public string Address { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the city where the branch is located.
    /// </summary>
    public string City { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the state where the branch is located.
    /// </summary>
    public string State { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the postal code of the branch's address.
    /// </summary>
    public string PostalCode { get; private set; } = string.Empty;

    public ValidationResultDetail Validate()
    {
        var validator = new CreateBranchCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}