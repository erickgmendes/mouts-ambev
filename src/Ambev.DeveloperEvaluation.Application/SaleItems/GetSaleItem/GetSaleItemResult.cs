using System.ComponentModel.DataAnnotations.Schema;
using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;

/// <summary>
/// Response model for GetBranch operation
/// </summary>
public class GetSaleItemResult
{
    /// <summary>
    /// Gets the unique identifier for the branch.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the sale associated with the sale item.
    /// </summary>
    public Guid SaleId { get; set; }
    
    /// <summary>
    /// Gets the product associated with the sale item.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets the quantity of the product in the sale item.
    /// This must be a positive integer.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets a value indicating whether the sale item has been cancelled.
    /// </summary>
    public SaleItemStatus Status { get; set; }

    /// <summary>
    /// Gets the total amount for the sale.
    /// This value is calculated.
    /// </summary>
    [NotMapped]
    public decimal TotalAmount { get; set; }
    
    /// <summary>
    /// Gets and sets the collection of items in the sale.
    /// </summary>
    public ICollection<GetSaleItemResult> Items { get; set; }

    public decimal Discount { get; set; }
}