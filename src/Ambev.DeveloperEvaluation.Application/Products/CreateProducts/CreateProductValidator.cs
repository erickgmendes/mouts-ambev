using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProducts;

/// <summary>
/// Validator for CreateProductCommand that defines validation rules for product creation command.
/// </summary>
public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - ExternalId: Required, must be between 3 and 50 characters
    /// - Name: Required, must be between 3 and 50 characters
    /// - Document: Required, must be between 3 and 50 characters
    /// - Email: Must be in valid format (using EmailValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// </remarks>
    public CreateProductCommandValidator()
    {
        RuleFor(product => product.ExternalId).NotEmpty().Length(3, 50);
        RuleFor(product => product.Name).NotEmpty().Length(3, 50);
        RuleFor(product => product.Document).NotEmpty().Length(3, 50);
        RuleFor(product => product.Email).SetValidator(new EmailValidator());
        RuleFor(product => product.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
    }
}