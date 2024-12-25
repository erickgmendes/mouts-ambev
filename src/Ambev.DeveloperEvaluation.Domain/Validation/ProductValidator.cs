using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(200).WithMessage("Product name cannot be longer than 200 characters.");

        RuleFor(product => product.Description)
            .NotEmpty().WithMessage("Product description is required.")
            .MaximumLength(500).WithMessage("Product description cannot be longer than 500 characters.");

        RuleFor(product => product.Price)
            .GreaterThan(0).WithMessage("Product price must be a positive value.");

        RuleFor(product => product.ExternalId)
            .NotEmpty().WithMessage("External Id is required.")
            .MaximumLength(50).WithMessage("External Id cannot be longer than 50 characters.");
    }
}