namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// Gets the external identifier associated with the sale, used for integrations with external systems.
    /// </summary>
    public string ExternalId { get; set; } = string.Empty;

    /// <summary>
    /// Gets the full name of the sale.
    /// This should not be null or empty.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the sale's document number (e.g., CPF, CNPJ).
    /// Follows the format required for sale identification.
    /// </summary>
    public string Document { get; set; } = string.Empty;

    /// <summary>
    /// Gets the email address of the sale.
    /// Must be in a valid email format for communication and authentication purposes.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets the sale's phone number.
    /// Must follow the format (XX) XXXXX-XXXX.
    /// </summary>
    public string Phone { get; set; } = string.Empty;
    
}