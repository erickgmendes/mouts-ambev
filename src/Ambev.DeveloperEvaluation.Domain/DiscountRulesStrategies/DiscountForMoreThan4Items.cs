namespace Ambev.DeveloperEvaluation.Domain.DiscountRulesStrategies;

public class DiscountForMoreThan4Items: IDiscountRuleStrategy
{
    public decimal ApplyDiscount(decimal value)
    {
        return value * 0.1m;
    }
}