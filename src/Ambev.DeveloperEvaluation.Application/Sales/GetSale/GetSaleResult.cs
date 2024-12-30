using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetBranch operation
/// </summary>
public class GetSaleResult
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
    /// Gets and sets the branch where the sale occurred.
    /// </summary>
    public Guid? BranchId { get; set; }

    /// <summary>
    /// Gets and sets a value indicating the status.
    /// </summary>
    public SaleStatus Status { get; set; }

    /// <summary>
    /// Gets the Total Amount.
    /// </summary>
    public decimal TotalAmount { get; set; }
    
    /// <summary>
    /// Gets the Items list.
    /// </summary>
    public ICollection<GetSaleItemResult> Items { get; set; }

    public GetSaleResult()
    {
        Items = new List<GetSaleItemResult>();
    }

    public void AddItem(GetSaleItemResult item)
    {
        Items.Add(item);
    }
}