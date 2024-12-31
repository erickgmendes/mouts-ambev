namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;

/// <summary>
/// Request model for getting a sale by ID
/// </summary>
public class GetSaleItemRequest
{
    /// <summary>
    /// The unique identifier of the saleItem to retrieve
    /// </summary>
    public Guid Id { get; set; }
}