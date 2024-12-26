namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Response model for GetProduct operation
/// </summary>
public class UpdateProductResult
{
    /// <summary>
    /// Gets the unique identifier for the customer.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the external identifier associated with the product, used for integrations with external systems.
    /// </summary>
    public string ExternalId { get; set; } = string.Empty;

    /// <summary>
    /// Gets the name of the product.
    /// This should not be null or empty.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the description of the product.
    /// Provides additional information about the product's features or specifications.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets the price of the product.
    /// This value should be a positive decimal representing the product's cost.
    /// </summary>
    public decimal Price { get; set; }
}