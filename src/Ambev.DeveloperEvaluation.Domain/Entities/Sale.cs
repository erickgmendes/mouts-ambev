using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale transaction in the system, including related customer, branch, and sale items.
/// </summary>
public class Sale: BaseEntity
{
    /// <summary>
    /// Gets the sale number, which is a unique reference for the sale.
    /// </summary>
    public string Number { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the date and time when the sale occurred.
    /// </summary>
    public DateTime Date { get; private set; }

    /// <summary>
    /// Gets the customer associated with the sale.
    /// </summary>
    public Customer? Customer { get; private set; }

    /// <summary>
    /// Gets the branch where the sale occurred.
    /// </summary>
    public Branch? Branch { get; private set; }

    /// <summary>
    /// Gets the total amount of the sale.
    /// This is the sum of all sale items' prices.
    /// </summary>
    public decimal TotalAmount { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the sale has been cancelled.
    /// </summary>
    public bool IsCancelled { get; private set; }

    /// <summary>
    /// Gets the collection of items in the sale.
    /// </summary>
    public ICollection<SaleItem> Items { get; private set; }

    /// <summary>
    /// Gets the date and time when the sale record was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time when the sale record was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Sale"/> class.
    /// </summary>
    public Sale()
    {
        CreatedAt = DateTime.UtcNow;
        Items = new List<SaleItem>();
    }

    /// <summary>
    /// Performs validation of the sale entity.
    /// Ensures that the sale has essential properties like Customer, Branch, and Sale Items.
    /// </summary>
    /// <returns>True if the sale is valid, otherwise false.</returns>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Returns a string representation of the sale, including the sale number and total amount.
    /// </summary>
    /// <returns>A string with the sale number and total amount.</returns>
    public override string ToString()
    {
        return $"Sale: {Number}, Total Amount: {TotalAmount:C}, Date: {Date:yyyy-MM-dd}";
    }
}