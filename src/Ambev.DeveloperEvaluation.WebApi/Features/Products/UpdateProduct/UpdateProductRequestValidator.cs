using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for product creation.
/// </summary>
public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        // Validates that the ExternalId is not empty and has a minimum length of 3 characters
        RuleFor(product => product.ExternalId).NotEmpty().WithMessage("ExternalId is required.");
        
        // Validates that the Name is not empty and has a minimum length of 3 characters
        RuleFor(product => product.Name).NotEmpty().WithMessage("Product name is required.");
        
        // Validates that the Description is not empty
        RuleFor(product => product.Description).NotEmpty().WithMessage("Description is required.");
        
        // Validates that the Price is not empty
        RuleFor(product => product.Price).NotEmpty().WithMessage("Price is required.");

    }
}