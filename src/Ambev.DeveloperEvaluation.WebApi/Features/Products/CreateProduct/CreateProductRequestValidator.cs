using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for product creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
    /// </summary>
    public CreateProductRequestValidator()
    {
        // Validates that the ExternalId is not empty and has a minimum length of 3 characters
        RuleFor(product => product.ExternalId).NotEmpty().WithMessage("ExternalId is required.");
        
        // Validates that the Name is not empty and has a minimum length of 3 characters
        RuleFor(product => product.Name).NotEmpty().WithMessage("Product name is required.");
        
        // Validates that the Address is not empty
        RuleFor(product => product.Document).NotEmpty().WithMessage("Document is required.");
        
        // Validates that the City is not empty
        RuleFor(product => product.Email).SetValidator(new EmailValidator());
        
        // Validates that the State is not empty
        RuleFor(product => product.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
    }
}