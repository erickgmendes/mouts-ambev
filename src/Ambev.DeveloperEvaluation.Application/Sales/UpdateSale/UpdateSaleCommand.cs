using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    /// <summary>
    /// Gets the unique identifier for the sale.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the sale number, which is a unique reference for the sale.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Gets the date and time when the sale occurred.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets the customer associated with the sale.
    /// </summary>
    public Guid? CustomerId { get; set; }
    
    /// <summary>
    /// Gets the branch where the sale occurred.
    /// </summary>
    public Guid? BranchId { get; set; }

    public void SetId(Guid id)
    {
        Id = id;
    }
}