using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for sale creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    public CreateSaleRequestValidator()
    {
        // Validates that the Sale Number is not empty and has a minimum length of 3 characters
        RuleFor(sale => sale.Number).NotEmpty().WithMessage("Number is required.");
        
        // Validates that the Sale Date is not empty and is greater than or equal to DateTime.UtcNow 
        RuleFor(sale => sale.Date).NotEmpty().GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Date name is required.");
        
        // Validates that the Customer Id is not empty
        RuleFor(sale => sale.CustomerId).NotEmpty().WithMessage("Customer Id is required.");
        
        // Validates that the Total Amount is not empty and is greater than or equal to 0 
        RuleFor(sale => sale.TotalAmount).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Total Amount is required and greater than or equal to 0.");
        
        // Validates that the Branch Id is not empty
        RuleFor(sale => sale.BranchId).NotEmpty().WithMessage("Branch Id is required.");
        
        // Validates that the Status is not empty
        RuleFor(sale => sale.Status).NotEmpty().WithMessage("Status is required.");
    }
}