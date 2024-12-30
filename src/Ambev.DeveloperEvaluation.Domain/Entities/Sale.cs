using System.ComponentModel.DataAnnotations.Schema;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
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
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Gets the date and time when the sale occurred.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets the customer associated with the sale.
    /// </summary>
    public Customer? Customer { get; set; }

    /// <summary>
    /// Gets the branch where the sale occurred.
    /// </summary>
    public Branch? Branch { get; set; }

    /// <summary>
    /// Gets the collection of items in the sale.
    /// </summary>
    public ICollection<SaleItem> Items { get; set; }

    /// <summary>
    /// Gets a value indicating the status.
    /// </summary>
    public SaleStatus Status { get; set; }

    /// <summary>
    /// Gets the total amount for the sale.
    /// This value is calculated.
    /// </summary>
    [NotMapped]
    public decimal TotalAmount 
    {
        get { return Items.Where(i=> !i.IsCancelled()).Sum(x => x.TotalAmount); }
    }    
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Sale"/> class.
    /// </summary>
    public Sale()
    {
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

    public void SetCustomer(Customer? customer) => Customer = customer ?? throw new ArgumentException("Customer cannot be null");
    
    public void SetBranch(Branch? branch) => Branch = branch ?? throw new ArgumentException("Branch cannot be null");

    public void SetStatus(int? statusValue)
    {
        if (!statusValue.HasValue)
            throw new ArgumentException("Status cannot be null");
            
        Status = (SaleStatus)statusValue;
    }

    public void Update(string number, DateTime date, Customer? customer, Branch? branch)
    {
        this.Number = number;
        this.Date = date;
        SetBranch(branch);
        SetCustomer(customer);
    }

    public void Cancel() => Status = SaleStatus.Cancelled;

    public bool IsCancelled() => Status == SaleStatus.Cancelled;
}