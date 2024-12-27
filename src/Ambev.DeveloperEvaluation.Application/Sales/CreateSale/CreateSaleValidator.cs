using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for sale creation command.
/// </summary>
public class CreateSaleCommandValidator: AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Number: Required
    /// - Date: Required
    /// - CustomerId: Required
    /// - BranchId: Required
    /// - TotalAmount: Required
    /// </remarks>
    public CreateSaleCommandValidator()
    {
        RuleFor(sale => sale.Number).NotEmpty().Length(3, 50);
        RuleFor(sale => sale.Date).NotEmpty();
        RuleFor(sale => sale.CustomerId).NotEmpty();
        RuleFor(sale => sale.BranchId).NotEmpty();
    }
}