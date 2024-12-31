using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem;

/// <summary>
/// Command for deleting a sale
/// </summary>
public class DeleteSaleItemCommand : IRequest<DeleteSaleItemResponse>
{
    /// <summary>
    /// The unique identifier of the sale to delete
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteSaleItemCommand
    /// </summary>
    /// <param name="id">The ID of the sale to delete</param>
    public DeleteSaleItemCommand(Guid id)
    {
        Id = id;
    }
}
