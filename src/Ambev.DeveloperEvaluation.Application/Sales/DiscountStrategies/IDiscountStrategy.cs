namespace Ambev.DeveloperEvaluation.Application.Sales.DiscountStrategies;

public interface IDiscountStrategy
{
    decimal ApplyDiscount(decimal value);
}