namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Profile for mapping between Application and API CreateSale responses
/// </summary>
public class CreateSaleResponse
{
    /// <summary>
    /// Gets the unique identifier for the sale.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets and sets the sale number, which is a unique reference for the sale.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Gets and sets the date and time when the sale occurred.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets and sets the customer associated with the sale.
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Gets and sets the total amount of the sale.
    /// This is the sum of all sale items' prices.
    /// </summary>
    public decimal TotalAmount { get; set; }
    
    /// <summary>
    /// Gets and sets the branch where the sale occurred.
    /// </summary>
    public Guid? BranchId { get; set; }

    /*
    /// <summary>
    /// Gets and sets the collection of items in the sale.
    /// </summary>
    public ICollection<SaleItem> Items { get; set; }
    */

    /// <summary>
    /// Gets and sets a value indicating the status.
    /// </summary>
    public int Status { get; set; }
    
}