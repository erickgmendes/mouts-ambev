namespace Ambev.DeveloperEvaluation.Application.Sales.DiscountStrategies;

public class DiscountForMoreThan4ItemsStrategy: IDiscountStrategy
{
    public decimal ApplyDiscount(decimal value)
    {
        return value * 0.1m;
    }
}