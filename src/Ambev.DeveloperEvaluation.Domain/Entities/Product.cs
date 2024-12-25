using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a product in the system with details such as name, description, and price.
/// </summary>
public class Product: BaseEntity
{
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

    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class.
    /// </summary>
    public Product() {}

    /// <summary>
    /// Performs validation of the product entity.
    /// Ensures that required fields such as Name and Price are valid.
    /// </summary>
    /// <returns>True if the product is valid, otherwise false.</returns>
    public ValidationResultDetail Validate()
    {
        var validator = new ProductValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Returns a string representation of the product, including the name and price.
    /// </summary>
    /// <returns>A string with the product's name and price.</returns>
    public override string ToString()
    {
        return $"Product: {Name}, Price: {Price:C}";
    }
}