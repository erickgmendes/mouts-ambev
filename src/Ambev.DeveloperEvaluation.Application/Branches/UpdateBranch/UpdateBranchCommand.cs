using Ambev.DeveloperEvaluation.Application.Branches.GetBranch;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.UpdateBranch;

public class UpdateBranchCommand : IRequest<UpdateBranchResult>
{
    /// <summary>
    /// Gets the Id of the branch.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets the external identifier for the branch.
    /// This identifier is used to reference the branch in external systems.
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