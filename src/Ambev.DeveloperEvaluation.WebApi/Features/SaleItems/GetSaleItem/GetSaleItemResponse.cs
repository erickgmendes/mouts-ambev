namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;

public class GetSaleItemResponse
{
    /// <summary>
    /// Gets the unique identifier for the saleItem.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the external identifier associated with the saleItem, used for integrations with external systems.
    /// </summary>
    public string ExternalId { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the full name of the saleItem.
    /// This should not be null or empty.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the saleItem's document number (e.g., CPF, CNPJ).
    /// Follows the format required for saleItem identification.
    /// </summary>
    public string Document { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the email address of the saleItem.
    /// Must be in a valid email format for communication and authentication purposes.
    /// </summary>
    public string Email { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the saleItem's phone number.
    /// Must follow the format (XX) XXXXX-XXXX.
    /// </summary>
    public string Phone { get; private set; } = string.Empty;

}