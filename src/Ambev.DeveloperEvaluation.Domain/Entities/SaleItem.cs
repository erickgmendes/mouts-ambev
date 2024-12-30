using System.ComponentModel.DataAnnotations.Schema;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents an item in a sale, including product details, quantity, pricing, and discounts.
/// </summary>
public class SaleItem: BaseEntity
{
    /// <summary>
    /// Gets the sale associated with the sale item.
    /// </summary>
    public Sale Sale { get; set; }
    
    /// <summary>
    /// Gets the product associated with the sale item.
    /// </summary>
    public Product Product { get; set; }

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
    public decimal TotalAmount 
    {
        get
        {
            if (Product == null)
                return 0;

            return (Quantity * Product.Price); 
        }
    }
    
    /// <summary>
    /// Gets and sets the unit price of the product.
    /// This value should be greater than zero.
    /// </summary>
    public decimal UnitPrice 
    {
        get
        {
            if (Product == null)
                return 0;
            
            return Product.Price;
        }
    }
    
    /// <summary>
    /// Performs validation of the sale item entity.
    /// Ensures that essential fields like Product, Quantity, UnitPrice, and Discount are valid.
    /// </summary>
    /// <returns>True if the sale item is valid, otherwise false.</returns>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleItemValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    public void Update(Sale sale, Product product)
    {
        Sale = sale;
        Product = product;
    }

    public void Cancel()
    {
        Status = SaleItemStatus.Cancelled;
    }
    
    public bool IsCancelled()
    {
        return Status == SaleItemStatus.Cancelled;
    }

}