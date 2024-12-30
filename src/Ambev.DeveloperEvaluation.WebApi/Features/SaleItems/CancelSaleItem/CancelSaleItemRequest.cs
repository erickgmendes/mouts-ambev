namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CancelSaleItem;

/// <summary>
/// Represents a request to create a new saleItem in the system.
/// </summary>
public class CancelSaleItemRequest
{
    /// <summary>
    /// Gets the sale associated with the sale item.
    /// </summary>
    public Guid Id { get; set; }
    
}