namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch;

/// <summary>
/// Represents a request to create a new branch in the system.
/// </summary>
public class CreateBranchRequest
{
    /// <summary>
    /// Gets or sets the External identifier for the branch.
    /// </summary>
    public string ExternalId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the branch.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the address of the branch.
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the city where the branch is located.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the state where the branch is located.
    /// </summary>
    public string State { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the postal code of the branch's address.
    /// </summary>
    public string PostalCode { get; set; } = string.Empty;
    
}