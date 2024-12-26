namespace Ambev.DeveloperEvaluation.Application.Branches.UpdateBranch;

public class UpdateBranchResponse
{
    /// <summary>
    /// Gets the Id of the branch.
    /// </summary>
    public Guid Id { get; set; }
    
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
}