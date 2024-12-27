namespace Ambev.DeveloperEvaluation.Application.Branches.GetBranch;

/// <summary>
/// Response model for GetBranch operation
/// </summary>
public class UpdateBranchResult
{
    /// <summary>
    /// Gets the unique identifier for the branch.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the External identifier for the branch.
    /// </summary>
    public string ExternalId { get; set; } = string.Empty;

    /// <summary>
    /// Gets the name of the branch.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the address of the branch.
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Gets the city where the branch is located.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Gets the state where the branch is located.
    /// </summary>
    public string State { get; set; } = string.Empty;

    /// <summary>
    /// Gets the postal code of the branch's address.
    /// </summary>
    public string PostalCode { get; set; } = string.Empty;
}