namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleRequest
{
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
    public int? CustomerId { get; set; }

    /// <summary>
    /// Gets the total amount of the sale.
    /// This is the sum of all sale items' prices.
    /// </summary>
    public decimal TotalAmount { get; set; }
    
    /// <summary>
    /// Gets the branch where the sale occurred.
    /// </summary>
    public int? BranchId { get; set; }

    /// <summary>
    /// Gets a value indicating the status.
    /// </summary>
    public int? Status { get; set; }
}