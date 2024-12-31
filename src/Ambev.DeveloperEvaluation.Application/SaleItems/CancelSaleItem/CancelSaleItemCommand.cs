using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CancelSaleItem;

/// <summary>
/// Command for deleting a sale item
/// </summary>
public class CancelSaleItemCommand : IRequest<CancelSaleItemResult>
{
    /// <summary>
    /// Gets the Id of the saleItem.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Initializes a new instance of CancelSaleItemCommand
    /// </summary>
    /// <param name="id">The ID of the sale item to cancel</param>
    public CancelSaleItemCommand(Guid id)
    {
        Id = id;
    }
}