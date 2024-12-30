namespace Ambev.DeveloperEvaluation.Domain.DiscountRulesStrategies;

public class DiscountBetween10And20Items: IDiscountRuleStrategy
{
    public decimal ApplyDiscount(decimal value)
    {
        return value * 0.2m;
    }
}