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
    /// Gets the unit price of the product.
    /// This value should be greater than zero.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets the discount applied to the product in this sale item.
    /// This value is expressed as a decimal percentage (e.g., 0.1 for 10%).
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets the total amount for the sale item, including the discount.
    /// This value is calculated as (UnitPrice * Quantity) - Discount.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets a value indicating whether the sale item has been cancelled.
    /// </summary>
    public SaleItemStatus Status { get; set; }

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

    /// <summary>
    /// Returns a string representation of the sale item, including product name, quantity, and total amount.
    /// </summary>
    /// <returns>A string with the product name, quantity, and total amount.</returns>
    public override string ToString()
    {
        return $"{Product?.Name ?? "Unknown Product"} - Quantity: {Quantity}, Total Amount: {TotalAmount:C}";
    }

    public void Update(int quantity, decimal unitPrice, decimal discount, decimal totalAmount, SaleItemStatus status)
    {
        this.Quantity = quantity;
        this.UnitPrice = unitPrice;
        this.Discount = discount;
        this.TotalAmount = totalAmount;
        this.Status = status;
    }
}