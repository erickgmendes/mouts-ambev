namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Response model for GetBranch operation
/// </summary>
public class GetProductResult
{
    /// <summary>
    /// Gets the Id of the branch.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets the external identifier associated with the product, used for integrations with external systems.
    /// </summary>
    public string ExternalId { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the name of the product.
    /// This should not be null or empty.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the description of the product.
    /// Provides additional information about the product's features or specifications.
    /// </summary>
    public string Description { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the price of the product.
    /// This value should be a positive decimal representing the product's cost.
    /// </summary>
    public decimal Price { get; private set; }
}