namespace Ambev.DeveloperEvaluation.Domain.DiscountRulesStrategies;

public interface IDiscountRuleStrategy
{
    decimal ApplyDiscount(decimal value);
}