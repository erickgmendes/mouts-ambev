using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;

public class UpdateSaleItemCommand : IRequest<UpdateSaleItemResult>
{
    /// <summary>
    /// Gets the Id of the saleItem.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets the sale associated with the sale item.
    /// </summary>
    public int SaleId { get; set; }
    
    /// <summary>
    /// Gets and sets the product associated with the sale item.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets and sets the quantity of the product in the sale item.
    /// This must be a positive integer.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets and sets the unit price of the product.
    /// This value should be greater than zero.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets and sets the discount applied to the product in this sale item.
    /// This value is expressed as a decimal percentage (e.g., 0.1 for 10%).
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets and sets the total amount for the sale item, including the discount.
    /// This value is calculated as (UnitPrice * Quantity) - Discount.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets and sets a value indicating whether the sale item has been cancelled.
    /// </summary>
    public int Status { get; set; }
}