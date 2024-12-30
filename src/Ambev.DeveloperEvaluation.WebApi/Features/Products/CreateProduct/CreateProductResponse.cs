namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Profile for mapping between Application and API CreateProduct responses
/// </summary>
public class CreateProductResponse
{
    /// <summary>
    /// Gets the unique identifier for the product.
    /// </summary>
    public Guid Id { get; set; }
    
}