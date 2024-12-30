namespace Ambev.DeveloperEvaluation.Domain.DiscountRulesStrategies;

public class NoDiscountRuleStrategy : IDiscountRuleStrategy
{
    public decimal ApplyDiscount(decimal value)
    {
        return 0;
    }
}