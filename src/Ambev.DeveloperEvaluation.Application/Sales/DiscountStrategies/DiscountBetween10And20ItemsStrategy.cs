namespace Ambev.DeveloperEvaluation.Application.Sales.DiscountStrategies;

public class DiscountBetween10And20ItemsStrategy: IDiscountStrategy
{
    public decimal ApplyDiscount(decimal value)
    {
        return value * 0.2m;
    }
}