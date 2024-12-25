using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a branch of the company, including its address and status.
/// </summary>
public class Branch: BaseEntity
{
    /// <summary>
    /// Gets the external identifier for the branch.
    /// This identifier is used to reference the branch in external systems.
    /// </summary>
    public string ExternalId { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the name of the branch.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the address of the branch.
    /// </summary>
    public string Address { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the city where the branch is located.
    /// </summary>
    public string City { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the state where the branch is located.
    /// </summary>
    public string State { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the postal code of the branch's address.
    /// </summary>
    public string PostalCode { get; private set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="Branch"/> class.
    /// </summary>
    public Branch() { }

    /// <summary>
    /// Performs validation of the branch entity.
    /// Ensures that essential fields like Name, Address, City, and PostalCode are valid.
    /// </summary>
    /// <returns>True if the branch is valid, otherwise false.</returns>
    public ValidationResultDetail Validate()
    {
        var validator = new BranchValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Returns a string representation of the branch, including its name and city.
    /// </summary>
    /// <returns>A string with the branch name and city.</returns>
    public override string ToString()
    {
        return $"{Name}, {City}, {State}";
    }
}