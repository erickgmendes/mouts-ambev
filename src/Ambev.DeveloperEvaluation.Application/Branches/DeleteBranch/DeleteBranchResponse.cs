namespace Ambev.DeveloperEvaluation.Application.Branches.DeleteBranch;

/// <summary>
/// Represents the response returned after successfully creating a new branch.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created branch,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class DeleteBranchResponse
{
    /// <summary>
    /// Indicates whether the deletion was successful
    /// </summary>
    public bool Success { get; set; }
}