using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(item => item.Sale)
            .NotNull().WithMessage("Sale is required.");
        
        RuleFor(item => item.Product)
            .NotNull().WithMessage("Product is required.");

        RuleFor(item => item.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

        RuleFor(item => item.UnitPrice)
            .GreaterThan(0).WithMessage("Unit price must be greater than zero.");

        RuleFor(item => item.Discount)
            .GreaterThanOrEqualTo(0).WithMessage("Discount must be a non-negative value.");

        RuleFor(item => item.TotalAmount)
            .GreaterThanOrEqualTo(0).WithMessage("Total amount must be a non-negative value.");
        
        RuleFor(sale => sale.Status)
            .NotNull().WithMessage("Status is required.");
    }
}