namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class CreateSaleItemRequest
{
    /// <summary>
    /// Gets the sale associated with the sale item.
    /// </summary>
    public Guid SaleId { get; set; }
    
    /// <summary>
    /// Gets and sets the product associated with the sale item.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets and sets the quantity of the product in the sale item.
    /// This must be a positive integer.
    /// </summary>
    public int Quantity { get; set; }
    
}