using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
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

        RuleFor(item => item.CreatedAt)
            .NotEmpty().WithMessage("Creation date is required.");

        RuleFor(item => item.UpdatedAt)
            .GreaterThan(item => item.CreatedAt).When(item => item.UpdatedAt.HasValue)
            .WithMessage("Update date must be later than the creation date.");
    }
}