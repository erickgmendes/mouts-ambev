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
        // Validates that the ExternalId is not empty and has a minimum length of 3 characters
        RuleFor(sale => sale.ExternalId).NotEmpty().WithMessage("ExternalId is required.");
        
        // Validates that the Name is not empty and has a minimum length of 3 characters
        RuleFor(sale => sale.Name).NotEmpty().WithMessage("Sale name is required.");
        
        // Validates that the Address is not empty
        RuleFor(sale => sale.Document).NotEmpty().WithMessage("Document is required.");
        
        // Validates that the City is not empty
        RuleFor(sale => sale.Email).SetValidator(new EmailValidator());
        
        // Validates that the State is not empty
        RuleFor(sale => sale.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
    }
}