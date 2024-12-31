using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;

/// <summary>
/// Command for creating a new sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a sale, 
/// including salename, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest"/> to initiate the request 
/// that returns a <see cref="CreateSaleItemResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleItemCommand : IRequest<CreateSaleItemResult>
{
    /// <summary>
    /// Gets and sets the Sale associated with the sale item.
    /// </summary>
    public Guid SaleId { get; set; }
    
    /// <summary>
    /// Gets and sets the product associated with the sale item.
    /// </summary>
    public Guid ProductId { get; set; }

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
    /// Gets and sets a value indicating whether the sale item has been cancelled.
    /// </summary>
    public bool IsCancelled { get; set; }
    
    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleItemCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}