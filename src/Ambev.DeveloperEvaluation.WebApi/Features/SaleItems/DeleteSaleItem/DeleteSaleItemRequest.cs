namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.DeleteSaleItem;

/// <summary>
/// Request model for deleting a sale
/// </summary>
public class DeleteSaleItemRequest
{
    /// <summary>
    /// The unique identifier of the sale to delete
    /// </summary>
    public Guid Id { get; set; }
}