using Ambev.DeveloperEvaluation.Domain.Enums;
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
        RuleFor(sale => sale.Number).NotEmpty().WithMessage("Number is required.");
        RuleFor(sale => sale.Date).NotEmpty();
        RuleFor(sale => sale.CustomerId).NotEmpty().WithMessage("Customer Id is required.");
        RuleFor(sale => sale.TotalAmount).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Total Amount is required and greater than or equal to 0.");
        RuleFor(sale => sale.BranchId).NotEmpty().WithMessage("Branch Id is required.");
        RuleFor(sale => sale.Status).NotNull().WithMessage("Status is required.");
    }
}